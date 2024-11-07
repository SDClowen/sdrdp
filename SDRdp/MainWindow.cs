using Microsoft.Win32;
using Ookii.Dialogs.WinForms;
using SDRdp.Core;
using SDRdp.Core.Configuration;
using SDUI;
using SDUI.Controls;
using SDUI.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Windows.Forms;

namespace SDRdp;

public partial class MainWindow : UIWindow
{
    public static readonly Color LightThemeColor = Color.FromArgb(255, 255, 255);
    public static readonly Color DarkThemeColor = Color.FromArgb(16, 16, 16);

    private FreeRdpControl _freeRdpControl => pageController.SelectedIndex < 0 ? null :
            pageController.Controls[pageController.SelectedIndex] as FreeRdpControl;

    private readonly UIWindow _form;
    private readonly PropertyGrid _propertyGrid;
    public MainWindow()
    {
        InitializeComponent();
        SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
        ExtendBox = true;

        _form = new()
        {
            Size = new(640, 640),
            Text = @"Settings",
            FormBorderStyle = FormBorderStyle.SizableToolWindow,
            StartPosition = FormStartPosition.CenterParent
        };

        _form.Closing += (_, args) =>
        {
            _form.Hide();
            args.Cancel = true;
        };

        _propertyGrid = new PropertyGrid
        {
            Dock = DockStyle.Fill
        };
    }

    private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        if (BackColor.IsDark() == WindowsHelper.IsDark())
            return;

        if (WindowsHelper.IsDark())
        {
            ColorScheme.BackColor = DarkThemeColor;
            BackColor = DarkThemeColor;
        }
        else
        {
            ColorScheme.BackColor = LightThemeColor;
            BackColor = LightThemeColor;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        SystemEvents_UserPreferenceChanged(null, new(UserPreferenceCategory.Color));
        _propertyGrid.Parent = _form;
    }

    private void ExitMenuItem_Click(object sender, EventArgs e)
    {
        if (ConfirmUserBeforeClosing())
            Environment.Exit(0);
    }

    private bool ConfirmUserBeforeClosing()
    {
        if (pageController.Count == 0)
            return true;

        if (MessageBox.Show("You have some active connections! Are you sure close SDRdp?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            foreach (FreeRdpControl item in pageController.Controls)
                item.Disconnect();

            return true;
        }

        return false;
    }

    private void CheckIsSaved(FreeRdpControl freeRdpControl)
    {
        var title = $"{freeRdpControl.Configuration.Server}@{freeRdpControl.Configuration.Username}";
        var savedDir = Path.Combine(Environment.CurrentDirectory, "saved");
        var fileName = Path.Combine(savedDir, $"{freeRdpControl.Configuration.Server}_{freeRdpControl.Configuration.Username}.json");

        //if (File.Exists(fileName))
        //return;

        var found = false;
        foreach (ToolStripMenuItem item in savedConnections.DropDownItems)
        {
            var configuration = item.Tag as FreeRdpConfiguration;
            if (configuration.Server == freeRdpControl.Configuration.Server &&
                configuration.Username == freeRdpControl.Configuration.Username)
            {
                found = true;
                break;
            }
        }

        if (!found)
        {
            var menuItem = new ToolStripMenuItem()
            {
                Text = freeRdpControl.Configuration.Title,
                Tag = freeRdpControl.Configuration,
            };

            menuItem.Click += SavedConnections_ConnectMenuItem_Click;

            savedConnections.DropDownItems.Add(menuItem);
        }

        if (!Directory.Exists(savedDir))
            Directory.CreateDirectory(savedDir);

        var serialized = JsonSerializer.Serialize<FreeRdpConfiguration>(freeRdpControl.Configuration);

        File.WriteAllText(fileName, serialized);
    }

    private void SavedConnections_ConnectMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            var menuItem = sender as ToolStripMenuItem;
            if (menuItem == null)
                return;

            var configuration = menuItem.Tag as FreeRdpConfiguration;
            if (configuration == null)
                return;

            configuration.DesktopScaleFactor = DeviceDpi / 96 * 100;
            configuration.DesktopWidth = 0;
            configuration.DesktopHeight = 0;
            configuration.SmartReconnect = false;
            configuration.WindowDrag = true;

            var freeRdpControl = new FreeRdpControl();
            freeRdpControl.Configuration = configuration;
            freeRdpControl.Connected += FreeRdpControl_Connected;
            freeRdpControl.Disconnected += FreeRdpControl_Disconnected;
            freeRdpControl.VerifyCredentials += FreeRdpControl_VerifyCredentials;
            freeRdpControl.CertificateError += FreeRdpControl_CertificateError;


            freeRdpControl.Dock = DockStyle.Fill;

            freeRdpControl.Connect();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void ConnectMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            var freeRdpControl = new FreeRdpControl();
            freeRdpControl.Configuration.AutoScaling = true;
            freeRdpControl.Connected += FreeRdpControl_Connected;
            freeRdpControl.Disconnected += FreeRdpControl_Disconnected;
            freeRdpControl.VerifyCredentials += FreeRdpControl_VerifyCredentials;
            freeRdpControl.CertificateError += FreeRdpControl_CertificateError;

            if (string.IsNullOrWhiteSpace(freeRdpControl.Configuration.Server))
            {
                using var inputDialog = new Ookii.Dialogs.WinForms.InputDialog();
                inputDialog.WindowTitle = @"Server Required";
                inputDialog.MainInstruction = @"Please enter a server name or IP address";
                inputDialog.Content = @"Note: The SDRdp will throw an exception if the Server property is not specified.";
                inputDialog.Input = freeRdpControl.Configuration.Server;

                if (inputDialog.ShowDialog(this) == DialogResult.Cancel ||
                    string.IsNullOrWhiteSpace(inputDialog.Input))
                    return;

                freeRdpControl.Configuration.Server = inputDialog.Input;
            }

            if (string.IsNullOrEmpty(freeRdpControl.Configuration.Username) ||
                string.IsNullOrEmpty(freeRdpControl.Configuration.Password))
            {
                var credentials = GetCredentialFromDialog(freeRdpControl, @"Please enter a username and password");
                freeRdpControl.Configuration.Username = credentials?.UserName;
                freeRdpControl.Configuration.Domain = string.IsNullOrWhiteSpace(credentials?.Domain)
                    ? null
                    : credentials.Domain;
                freeRdpControl.Configuration.Password = credentials?.Password;
            }

            freeRdpControl.Text = $"{freeRdpControl.Configuration.Server}@{freeRdpControl.Configuration.Username}";
            freeRdpControl.Dock = DockStyle.Fill;

            using var inputDialogTitle = new Ookii.Dialogs.WinForms.InputDialog();
            inputDialogTitle.WindowTitle = @"Custom Title";
            inputDialogTitle.MainInstruction = @"Please enter a alias for server";
            inputDialogTitle.Content = @"Note: It is not mandatory to assign any alias. If not assigned, it will be assigned as ip@username.";
            inputDialogTitle.Input = $"{freeRdpControl.Configuration.Server}@{freeRdpControl.Configuration.Username}";

            if (inputDialogTitle.ShowDialog(this) == DialogResult.Cancel ||
                string.IsNullOrWhiteSpace(inputDialogTitle.Input))
                return;

            freeRdpControl.Configuration.Title = inputDialogTitle.Input;

            freeRdpControl.Connect();

            CheckIsSaved(freeRdpControl);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void DisconnectMenuItem_Click(object sender, EventArgs e)
    {
        if (pageController.Controls.Count == 0)
            return;

        _freeRdpControl?.Disconnect();
    }

    private void ZoomInMenuItem_Click(object sender, EventArgs e)
    {
        if (pageController.Controls.Count == 0)
            return;

        _freeRdpControl?.ZoomIn();
        ResetZoomMenuItem.Text = $"&Reset Zoom ({_freeRdpControl.Zoom}%)";
    }

    private void ZoomOutMenuItem_Click(object sender, EventArgs e)
    {
        if (pageController.Controls.Count == 0)
            return;

        _freeRdpControl?.ZoomOut();
        ResetZoomMenuItem.Text = $"&Reset Zoom ({_freeRdpControl.Zoom}%)";
    }

    private void ResetZoomMenuItem_Click(object sender, EventArgs e)
    {
        if (pageController.Controls.Count == 0)
            return;

        _freeRdpControl?.ResetZoom();
        ResetZoomMenuItem.Text = $"&Reset Zoom ({_freeRdpControl.Zoom}%)";
    }

    private void SettingsMenuItem_Click(object sender, EventArgs e)
    {
        if (pageController.Controls.Count == 0)
            return;

        _propertyGrid.SelectedObject = _freeRdpControl?.Configuration;
        
        if(!_form.Visible)
            _form.Show(this);
    }

    private void FreeRdpControl_Connected(object sender, EventArgs e)
    {
        try
        {
            var freeRdpControl = sender as FreeRdpControl;
            freeRdpControl.Text = string.IsNullOrWhiteSpace(freeRdpControl.Configuration.Title) ?
                $"{freeRdpControl.Configuration.Server}@{freeRdpControl.Configuration.Username}" :
                freeRdpControl.Configuration.Title;

            pageController.Controls.Add(freeRdpControl);
            this.Invalidate();

            foreach (ToolStripMenuItem item in savedConnections.DropDownItems)
            {
                var configuration = item.Tag as FreeRdpConfiguration;
                if (configuration.Server == freeRdpControl.Configuration.Server &&
                    configuration.Username == freeRdpControl.Configuration.Username)
                    item.Checked = true;
            }

            labelStarting.Visible = pageController.Controls.Count == 0;

            if (pageController.Count == 1)
                Text = $"{_freeRdpControl.Configuration.Server}@{_freeRdpControl.Configuration.Username}";

            DisconnectMenuItem.Enabled = !labelStarting.Visible;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void FreeRdpControl_Disconnected(object sender, DisconnectEventArgs e)
    {
        try
        {
            var freeRdpControl = sender as FreeRdpControl;
            CheckIsSaved(freeRdpControl);

            pageController.Controls.Remove(freeRdpControl);
            if (pageController.Count == 0)
                Text = "SDRdp - Not Connected";

            foreach (ToolStripMenuItem item in savedConnections.DropDownItems)
            {
                var configuration = item.Tag as FreeRdpConfiguration;
                if (configuration.Server == freeRdpControl.Configuration.Server &&
                    configuration.Username == freeRdpControl.Configuration.Username)
                    item.Checked = false;
            }

            labelStarting.Visible = pageController.Controls.Count == 0;
            DisconnectMenuItem.Enabled = !labelStarting.Visible;

            if (!labelStarting.Visible)
                pageController.SelectedIndex--;

            this.Invalidate();

            if (e.UserInitiated)
                return;

            MessageBox.Show(this, e.ErrorMessage, @"RDP Session Terminated", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void FreeRdpControl_CertificateError(object sender, CertificateErrorEventArgs e)
    {
        if (MessageBox.Show(
                this,
                @"The hostname of the server certificate does not match the provided host name. Do you want to ignore this error and try to connect again?",
                @"FreeRdp TLS handshake Error",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            e.Continue();
    }

    private void FreeRdpControl_VerifyCredentials(object? sender, VerifyCredentialsEventArgs e)
    {
        var freeRdpControl = sender as FreeRdpControl;
        var credentials = GetCredentialFromDialog(freeRdpControl, @"An authentication error occurred. Login failed. Please verify your credentials.");
        if (credentials == null)
            return;

        e.SetCredentials(credentials.UserName, credentials.Domain, credentials.Password);
    }

    private NetworkCredential? GetCredentialFromDialog(FreeRdpControl freeRdpControl, string mainInstruction)
    {
        using var credentialDialog = new CredentialDialog();
        credentialDialog.Target = freeRdpControl.Configuration.Server;
        credentialDialog.WindowTitle = @"Credentials Required";
        credentialDialog.MainInstruction = mainInstruction;
        credentialDialog.Content = @"Note: The FreeRdpControl will throws an exception if no credentials are provided.";
        credentialDialog.ShowSaveCheckBox = false;
        credentialDialog.ShowDialog(this);
        return credentialDialog.Credentials;
    }

    private void windowPageControl1_SelectedIndexChanged(object sender, int e)
    {
        if (_freeRdpControl == null)
            return;

        _propertyGrid.SelectedObject = _freeRdpControl.Configuration;
        Text = $"{_freeRdpControl.Configuration.Server}@{_freeRdpControl.Configuration.Username}";
        ResetZoomMenuItem.Text = $"&Reset Zoom (${_freeRdpControl.Zoom}%)";
    }

    private void FreeRdpForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (ConfirmUserBeforeClosing())
            Environment.Exit(0);
        else
            e.Cancel = true;
    }

    private void buttonFullScreen_Click(object sender, EventArgs e)
    {
        try
        {
            if (_freeRdpControl == null)
                return;

            _freeRdpControl.Configuration.SmartReconnect = true;

            if (ShowTitle)
            {
                ShowTitle = false;
                TopMost = true;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Bounds = Screen.FromControl(this).Bounds;
                panelFullScreen.Visible = true;
            }
            else
            {
                panelFullScreen.Visible = false;
                TopMost = false;
                ShowTitle = true;
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        try
        {
            var savedDir = Path.Combine(Environment.CurrentDirectory, "saved");

            if (!Directory.Exists(savedDir))
                Directory.CreateDirectory(savedDir);

            foreach (var item in Directory.GetFiles(savedDir))
            {
                var json = File.ReadAllText(item);
                var configuration = JsonSerializer.Deserialize<FreeRdpConfiguration>(json);
                var menuItem = new ToolStripMenuItem()
                {
                    Text = string.IsNullOrWhiteSpace(configuration.Title) ?
                    $"{configuration.Server}@{configuration.Username}" :
                    configuration.Title,
                    Tag = configuration,
                };

                menuItem.Click += SavedConnections_ConnectMenuItem_Click;

                savedConnections.DropDownItems.Add(menuItem);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        new AboutForm().ShowDialog(this);
    }
}