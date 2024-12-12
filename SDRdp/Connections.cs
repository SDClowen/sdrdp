using SDRdp.Core.Configuration;
using SDRdp.Core.Cryptography;
using SDRdp.Core.Security;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SDRdp
{
    public partial class Connections : UserControl
    {
        /// <summary>
        /// The default private key, using for encrypt / descript the configiration files
        /// </summary>
        public string PrivateKey { get; set; } = "123456";

        /// <summary>
        /// The path for saved configirations
        /// </summary>
        private readonly string savedDir = Path.Combine(Environment.CurrentDirectory, "saved");

        /// <summary>
        /// The rdp configirations
        /// </summary>
        public List<FreeRdpConfiguration> Configurations;

        /// <summary>
        /// Call the event handler after connect to rdp server
        /// </summary>
        public event EventHandler ConnectEventHandler;
        public event EventHandler ConnectSavedEventHandler;
        public event EventHandler RemoveConnectionEventHandler;

        private readonly Color[] _gradient = [Color.Gray, Color.Black];
        private readonly Font _font = new("Segoe UI", 32, FontStyle.Regular);
        private readonly StringFormat _format = new() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

        public Connections()
        {
            InitializeComponent();

            Configurations = new();
        }

        public void LoadConnections()
        {
            foreach (var file in Directory.GetFiles(savedDir, "*.json"))
            {
                var readedJson = Crypto.Decrypt(File.ReadAllText(file), PrivateKey);
                var configuration = JsonSerializer.Deserialize<FreeRdpConfiguration>(readedJson);
                Add(configuration);
            }

            string[] dirs = [
                Environment.ExpandEnvironmentVariables("%AppData%\\mRemoteNG\\confCons.xml"), // old version
                Environment.ExpandEnvironmentVariables("%AppData%\\mRemoteNG Connection Manager\\confCons.xml")
            ];

            var xmldir = string.Empty;
            foreach (var dir in dirs)
                if (File.Exists(dir))
                    xmldir = dir;

            if (!string.IsNullOrEmpty(xmldir) && !Settings.Instance.IsNRemoteRDPImported)
            {
                var dialogResult = MessageBox.Show("mRemoteNG detected on this system! Do you wanna import the connections from that?", "", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                    return;

                var doc = XDocument.Load(xmldir);
                var root = doc.Root;
                var crypter = new SDRdp.Core.Security.Factories.CryptoProviderFactoryFromXml(doc.Root).Build();
                var lastContainer = string.Empty;

                var loadedGroups = new Dictionary<string, List<FreeRdpConfiguration>>();
                xmlNodeLoader(root);

                void xmlNodeLoader(XElement node)
                {
                    foreach (var item in node.Descendants("Node"))
                    {
                        var type = item.Attribute("Type").Value;
                        if (type == "Container") // group
                        {
                            var containerName = item.Attribute("Name").Value;
                            if (lastContainer == string.Empty || lastContainer != containerName)
                            {
                                lastContainer = containerName;
                                loadedGroups.TryAdd(containerName, []);

                                //if (item.HasElements)
                                //  xmlNodeLoader(item);
                            }
                        }
                        else if (type == "Connection")
                        {
                            var config = new FreeRdpConfiguration
                            {
                                Group = lastContainer,
                                Title = item.Attribute("Name").Value,
                                Server = item.Attribute("Hostname").Value,
                                Port = Convert.ToInt32(item.Attribute("Port").Value),
                                Domain = item.Attribute("Domain").Value,
                                Username = item.Attribute("Username").Value,
                                Password = crypter.Decrypt(item.Attribute("Password").Value, "mR3m".ConvertToSecureString()),
                            };

                            if(string.IsNullOrWhiteSpace(lastContainer))
                                lastContainer = "General";

                            if (!loadedGroups.TryGetValue(lastContainer, out var list))
                                loadedGroups.TryAdd(lastContainer, [config]);
                            else
                                list.Add(config);
                        }
                    }
                }

                loadedGroups = loadedGroups.Where(p => p.Value.Count != 0).ToDictionary();
                foreach (var localGroup in loadedGroups)
                {
                    Settings.Instance.Groups.Add(localGroup.Key);
                    AddGroup(localGroup.Key);

                    foreach (var item in localGroup.Value)
                        Add(item);
                }

                Settings.Instance.IsNRemoteRDPImported = true;
                Save();
            }
        }

        public void Save()
        {
            if (!Directory.Exists(savedDir))
                Directory.CreateDirectory(savedDir);

            foreach (var freeRdpConfiguration in Configurations)
            {
                var fileName = Path.Combine(savedDir, $"{freeRdpConfiguration.Server.Replace(":", "_")}_{freeRdpConfiguration.Username}.json");

                var serialized = JsonSerializer.Serialize(freeRdpConfiguration);
                File.WriteAllText(fileName, Crypto.Encrypt(serialized, PrivateKey));
            }

            var settingsFile = Path.Combine(Environment.CurrentDirectory, "settings.json");
            File.WriteAllText(settingsFile, JsonSerializer.Serialize(Settings.Instance));
        }

        public void CheckIsSaved(FreeRdpConfiguration freeRdpConfiguration)
        {
            var title = $"{freeRdpConfiguration.Server}@{freeRdpConfiguration.Username}";
            var fileName = Path.Combine(savedDir, $"{freeRdpConfiguration.Server.Replace(":", "_")}_{freeRdpConfiguration.Username}.json");

            var configuration = Configurations.FirstOrDefault(p => p.Server == freeRdpConfiguration.Server && p.Username == freeRdpConfiguration.Username);
            if (configuration == null)
                Add(freeRdpConfiguration);
            else
                configuration = freeRdpConfiguration;

            foreach (Control groupItem in groups.Controls)
            {
                foreach (ConnectionItem item in groupItem.Controls)
                {
                    var frconfiguration = item.Tag as FreeRdpConfiguration;
                    if (frconfiguration.Server == freeRdpConfiguration.Server &&
                        frconfiguration.Username == freeRdpConfiguration.Username)
                    {
                        item.Tag = freeRdpConfiguration;
                        item.RName = freeRdpConfiguration.Title;
                        item.Text = title;

                        fileName = Path.ChangeExtension(fileName, "png");
                        if (File.Exists(fileName))
                            item.BackgroundImg = Bitmap.FromFile(fileName);
                        
                        fileName = Path.ChangeExtension(fileName, "json");

                        break;
                    }
                }
            }


            if (!Directory.Exists(savedDir))
                Directory.CreateDirectory(savedDir);

            var serialized = JsonSerializer.Serialize(freeRdpConfiguration);

            File.WriteAllText(fileName, Crypto.Encrypt(serialized, PrivateKey));
        }

        public bool TryRemove(FreeRdpConfiguration configuration)
        {
            try
            {
                var fileName = Path.Combine(savedDir, $"{configuration.Server.Replace(":", "_")}_{configuration.Username}.json");
                if (File.Exists(fileName))
                    File.Delete(fileName);

                Configurations.Remove(configuration);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddGroup(string group)
        {
            groups.Add<SDUI.Controls.FlowLayoutPanel>(group);
            moveToGroupMenuItem.DropDown.Items.Add(group, null, moveGroup_Click);
        }

        private void moveGroup_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            var contextMenu = menuItem.OwnerItem.Owner as SDUI.Controls.ContextMenuStrip;
            var groupName = menuItem.Text;

            var connectionItem = contextMenu.SourceControl as ConnectionItem;
            if (connectionItem == null)
                return;

            var cfgs = Configurations;
            var freeRdpConfiguration = connectionItem.Tag as FreeRdpConfiguration;
            if (freeRdpConfiguration == null) return;

            if (freeRdpConfiguration.Group == groupName)
                return;

            var group = groups.Controls.OfType<SDUI.Controls.FlowLayoutPanel>().FirstOrDefault(p => p.Text == freeRdpConfiguration.Group);
            freeRdpConfiguration.Group = groupName;
            group.Controls.Remove(connectionItem);

            // moved group
            group = groups.Controls.OfType<SDUI.Controls.FlowLayoutPanel>().FirstOrDefault(p => p.Text == freeRdpConfiguration.Group);
            group.Controls.Add(connectionItem);
        }

        public void Add(FreeRdpConfiguration config)
        {
            var title = $"{config.Server}@{config.Username}";
            var connectionItem = new ConnectionItem(title, config);
            connectionItem.ConnectSavedEventHandler += ConnectSavedEventHandler;
            connectionItem.ContextMenuStrip = contextMenuConnectionItem;
            var group = groups.Controls.OfType<Control>().FirstOrDefault(c => c.Text == connectionItem.Group);

            connectionItem.RemoveConnectionEventHandler += (sender, e) =>
            {
                if (MessageBox.Show("Are you sure remove the saved connection?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                TryRemove(config);

                group?.Controls.Remove(connectionItem);

                RemoveConnectionEventHandler?.Invoke(sender, e);
            };

            Configurations.Add(config);

            if (group == null)
                group = groups.Add<SDUI.Controls.FlowLayoutPanel>(connectionItem.Group);

            group.Controls.Add(connectionItem);
        }

        private void buttonNewConnect_Click(object sender, EventArgs e)
        {
            ConnectEventHandler?.Invoke(this, EventArgs.Empty);
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            try
            {
                var selectFileDialog = new OpenFileDialog();
                selectFileDialog.Title = "Select importing file";
                selectFileDialog.Filter = "SDRDP File | *.sdrdp";

                if (selectFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using var inputDialog = new Ookii.Dialogs.WinForms.InputDialog();
                    inputDialog.WindowTitle = @"Connections Key";
                    inputDialog.MainInstruction = @"Please enter a key for connections";
                    inputDialog.Content = @"This will be used to encrypt the connections contained here for your security.";
                    inputDialog.UsePasswordMasking = true;

                    if (inputDialog.ShowDialog(this) == DialogResult.Cancel ||
                        string.IsNullOrWhiteSpace(inputDialog.Input))
                        return;

                    var lines = File.ReadAllLines(selectFileDialog.FileName);
                    foreach (var line in lines)
                    {
                        var freeRdpConfiguration = JsonSerializer.Deserialize<FreeRdpConfiguration>(Crypto.Decrypt(line, inputDialog.Input));
                        Add(freeRdpConfiguration);
                    }
                }
            }
            catch (JsonException)
            {
                MessageBox.Show("Could not extract configuration files with this password. Maybe the password is wrong?");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                var fileDialog = new SaveFileDialog();
                fileDialog.Title = "Select saving path for exported file";
                fileDialog.Filter = "SDRDP File | *.sdrdp";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    using var inputDialog = new Ookii.Dialogs.WinForms.InputDialog();
                    inputDialog.WindowTitle = @"Connections Key";
                    inputDialog.MainInstruction = @"Please enter a key for connections";
                    inputDialog.Content = @"This will be used to encrypt the connections contained here for your security.";
                    inputDialog.UsePasswordMasking = true;

                    if (inputDialog.ShowDialog(this) == DialogResult.Cancel ||
                        string.IsNullOrWhiteSpace(inputDialog.Input))
                        return;

                    var builder = new StringBuilder();
                    foreach (var freeRdpConfiguration in Configurations)
                    {
                        var encrypted = Crypto.Encrypt(JsonSerializer.Serialize(freeRdpConfiguration), inputDialog.Input);
                        builder.AppendLine(encrypted);
                    }

                    File.WriteAllText(fileDialog.FileName, builder.ToString());
                }
            }
            catch (JsonException)
            {
                MessageBox.Show("Could not extract configuration files with this password. Maybe the password is wrong?");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groups_ClosePageButtonClicked(object deletingTabIndex, EventArgs e)
        {
            var index = Convert.ToInt32(deletingTabIndex);
            var group = groups.Controls[index];
            if (group.Text == "General")
            {
                MessageBox.Show("You cant delete the General group!");
                return;
            }

            if (MessageBox.Show("Are you sure to delete the group?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (group.Controls.Count > 0)
                {
                    var inputDialog = new SDUI.Controls.InputDialog("Select Group", "Select Group", "You have to be select new group for move the connections before deleting....", SDUI.Controls.InputDialog.InputType.Combobox);

                    var currentGroups = Settings.Instance.Groups.Where(p => p != group.Text).Select(p => (object)p).ToArray();
                    if (currentGroups.Length <= 0)
                    {
                        MessageBox.Show("There no have any avaliable group for move current connections! Otherwise you cant remove the group...", "SDRdp");
                        return;
                    }

                    inputDialog.Selector.Items.AddRange(currentGroups);
                    inputDialog.Selector.SelectedIndex = 0;
                    inputDialog.Padding = new(5);
                    if (inputDialog.ShowDialog() == DialogResult.OK)
                    {
                        var selectedGroupName = inputDialog.Selector.SelectedItem.ToString();

                        var selectedGroup = groups.Controls.OfType<SDUI.Controls.FlowLayoutPanel>().FirstOrDefault(p => p.Text == selectedGroupName);
                        selectedGroup.Controls.AddRange(group.Controls.OfType<ConnectionItem>().ToArray());
                        foreach (var frdpConfig in selectedGroup.Controls.OfType<ConnectionItem>().Select(p => p.Tag as FreeRdpConfiguration))
                            frdpConfig.Group = selectedGroupName;

                        group.Controls.Clear();
                    }
                    else
                        return;
                }

                groups.RemoveAt(index);
                Settings.Instance.Groups.RemoveAt(index);
                Save();
            }
        }

        private void groups_NewPageButtonClicked(object sender, EventArgs e)
        {
            using var inputDialog = new Ookii.Dialogs.WinForms.InputDialog();
            inputDialog.WindowTitle = @"Group Name";
            inputDialog.MainInstruction = @"Please enter a group name";
            inputDialog.Content = @"The group will be use for your connections.";

            if (inputDialog.ShowDialog(this) == DialogResult.Cancel ||
                string.IsNullOrWhiteSpace(inputDialog.Input))
                return;

            AddGroup(inputDialog.Input);

            Settings.Instance.Groups.Add(inputDialog.Input);
        }
    }
}
