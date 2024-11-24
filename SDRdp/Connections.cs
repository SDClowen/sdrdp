using SDRdp.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using SDRdp.Core.Cryptography;
using System.Text.Json;
using System.Text;

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
            foreach (var file in Directory.GetFiles(savedDir))
            {
                var readedJson = Crypto.Decrypt(File.ReadAllText(file), PrivateKey);
                var configuration = JsonSerializer.Deserialize<FreeRdpConfiguration>(readedJson);
                Add(configuration);
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

            foreach (ConnectionItem item in flowLayoutPanel.Controls)
            {
                var frconfiguration = item.Tag as FreeRdpConfiguration;
                if (frconfiguration.Server == freeRdpConfiguration.Server &&
                    frconfiguration.Username == freeRdpConfiguration.Username)
                {
                    item.Tag = freeRdpConfiguration;
                    item.labelName.Text = freeRdpConfiguration.Title;
                    item.Text = title;
                    break;
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

        public void Add(FreeRdpConfiguration config)
        {
            var title = $"{config.Server}@{config.Username}";
            var connectionItem = new ConnectionItem(title, config);
            connectionItem.ConnectSavedEventHandler += ConnectSavedEventHandler;
            connectionItem.RemoveConnectionEventHandler += (sender, e) =>
            {
                if (MessageBox.Show("Are you sure remove the saved connection?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                TryRemove(config);
                flowLayoutPanel.Controls.Remove(connectionItem);
                RemoveConnectionEventHandler?.Invoke(sender, e);
            };

            Configurations.Add(config);
            flowLayoutPanel.Controls.Add(connectionItem);
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
    }
}
