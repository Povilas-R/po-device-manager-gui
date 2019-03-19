using Po.Forms;

namespace DeviceManagerGUI
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
				if (_dataCollector != null)
				{
					_dataCollector.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MainMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_ReadFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGrid_Devices = new System.Windows.Forms.DataGridView();
            this.Column_Device = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GridMenu_Watch = new System.Windows.Forms.ToolStripMenuItem();
            this.GridMenu_Live = new System.Windows.Forms.ToolStripMenuItem();
            this.GridMenu_Connection = new System.Windows.Forms.ToolStripMenuItem();
            this.GridMenu_Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.GridMenu_Disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.GridMenu_Configure = new System.Windows.Forms.ToolStripMenuItem();
            this.GridMenu_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBox_AddDevice = new System.Windows.Forms.GroupBox();
            this.ComboBox_Device = new System.Windows.Forms.ComboBox();
            this.TextBox_FileName = new Po.Forms.CueTextBox();
            this.TextBox_Description = new Po.Forms.CueTextBox();
            this.TextBox_Port = new Po.Forms.CueTextBox();
            this.TextBox_DeviceName = new Po.Forms.CueTextBox();
            this.Button_AddDevice = new Po.Forms.BetterButton();
            this.TextBox_Log = new System.Windows.Forms.TextBox();
            this.Label_KaPerNaujus = new System.Windows.Forms.Label();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBar_ToolTip = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_Separator = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_LastUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_VersionSeparator = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_Version = new System.Windows.Forms.ToolStripDropDownButton();
            this.Button_ToggleLog = new Po.Forms.BetterButton();
            this.Button_OpenLaunchDirectory = new Po.Forms.BetterButton();
            this.Button_OpenOutputDirectory = new Po.Forms.BetterButton();
            this.Button_StartCollector = new Po.Forms.BetterButton();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Devices)).BeginInit();
            this.GridMenu.SuspendLayout();
            this.GroupBox_AddDevice.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuItem_File});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1256, 24);
            this.MainMenu.TabIndex = 30;
            // 
            // MainMenuItem_File
            // 
            this.MainMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu_ReadFiles,
            this.MainMenu_Settings,
            this.MainMenu_Exit});
            this.MainMenuItem_File.Name = "MainMenuItem_File";
            this.MainMenuItem_File.Size = new System.Drawing.Size(37, 20);
            this.MainMenuItem_File.Text = "File";
            // 
            // MainMenu_ReadFiles
            // 
            this.MainMenu_ReadFiles.Name = "MainMenu_ReadFiles";
            this.MainMenu_ReadFiles.Size = new System.Drawing.Size(166, 22);
            this.MainMenu_ReadFiles.Text = "Open data viewer";
            this.MainMenu_ReadFiles.Click += new System.EventHandler(this.MenuItem_ReadFiles_Click);
            // 
            // MainMenu_Settings
            // 
            this.MainMenu_Settings.Name = "MainMenu_Settings";
            this.MainMenu_Settings.Size = new System.Drawing.Size(166, 22);
            this.MainMenu_Settings.Text = "Settings";
            this.MainMenu_Settings.Click += new System.EventHandler(this.MainMenu_Settings_Click);
            // 
            // MainMenu_Exit
            // 
            this.MainMenu_Exit.Name = "MainMenu_Exit";
            this.MainMenu_Exit.Size = new System.Drawing.Size(166, 22);
            this.MainMenu_Exit.Text = "Exit";
            this.MainMenu_Exit.Click += new System.EventHandler(this.MenuItem_Exit_Click);
            // 
            // DataGrid_Devices
            // 
            this.DataGrid_Devices.AllowUserToAddRows = false;
            this.DataGrid_Devices.AllowUserToDeleteRows = false;
            this.DataGrid_Devices.AllowUserToResizeColumns = false;
            this.DataGrid_Devices.AllowUserToResizeRows = false;
            this.DataGrid_Devices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_Devices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Device,
            this.Column_DeviceName,
            this.Column_Port,
            this.Column_State,
            this.Column_Description,
            this.Column_FileName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid_Devices.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGrid_Devices.Location = new System.Drawing.Point(12, 27);
            this.DataGrid_Devices.Name = "DataGrid_Devices";
            this.DataGrid_Devices.RowHeadersVisible = false;
            this.DataGrid_Devices.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGrid_Devices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGrid_Devices.Size = new System.Drawing.Size(663, 412);
            this.DataGrid_Devices.TabIndex = 33;
            this.DataGrid_Devices.TabStop = false;
            this.DataGrid_Devices.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGrid_Devices_CellBeginEdit);
            this.DataGrid_Devices.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_Devices_CellValueChanged);
            this.DataGrid_Devices.DoubleClick += new System.EventHandler(this.DataGrid_Devices_DoubleClick);
            this.DataGrid_Devices.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGrid_Devices_MouseClick);
            // 
            // Column_Device
            // 
            this.Column_Device.HeaderText = "Device";
            this.Column_Device.Name = "Column_Device";
            this.Column_Device.ReadOnly = true;
            this.Column_Device.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_DeviceName
            // 
            this.Column_DeviceName.HeaderText = "Name";
            this.Column_DeviceName.Name = "Column_DeviceName";
            this.Column_DeviceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_Port
            // 
            this.Column_Port.HeaderText = "Port";
            this.Column_Port.Name = "Column_Port";
            this.Column_Port.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_Port.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Port.Width = 60;
            // 
            // Column_State
            // 
            this.Column_State.HeaderText = "State";
            this.Column_State.Name = "Column_State";
            this.Column_State.ReadOnly = true;
            this.Column_State.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_State.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_Description
            // 
            this.Column_Description.HeaderText = "Description";
            this.Column_Description.Name = "Column_Description";
            this.Column_Description.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Description.Width = 150;
            // 
            // Column_FileName
            // 
            this.Column_FileName.HeaderText = "File name";
            this.Column_FileName.Name = "Column_FileName";
            this.Column_FileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_FileName.Width = 150;
            // 
            // GridMenu
            // 
            this.GridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GridMenu_Watch,
            this.GridMenu_Live,
            this.GridMenu_Connection,
            this.GridMenu_Configure,
            this.GridMenu_Remove});
            this.GridMenu.Name = "GridMenu";
            this.GridMenu.Size = new System.Drawing.Size(137, 114);
            this.GridMenu.Opening += new System.ComponentModel.CancelEventHandler(this.GridMenu_Opening);
            // 
            // GridMenu_Watch
            // 
            this.GridMenu_Watch.Name = "GridMenu_Watch";
            this.GridMenu_Watch.Size = new System.Drawing.Size(136, 22);
            this.GridMenu_Watch.Text = "Watch";
            this.GridMenu_Watch.Click += new System.EventHandler(this.GridMenu_Watch_Click);
            // 
            // GridMenu_Live
            // 
            this.GridMenu_Live.Name = "GridMenu_Live";
            this.GridMenu_Live.Size = new System.Drawing.Size(136, 22);
            this.GridMenu_Live.Text = "Watch live";
            this.GridMenu_Live.Click += new System.EventHandler(this.GridMenu_Live_Click);
            // 
            // GridMenu_Connection
            // 
            this.GridMenu_Connection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GridMenu_Connect,
            this.GridMenu_Disconnect});
            this.GridMenu_Connection.Name = "GridMenu_Connection";
            this.GridMenu_Connection.Size = new System.Drawing.Size(136, 22);
            this.GridMenu_Connection.Text = "Connection";
            // 
            // GridMenu_Connect
            // 
            this.GridMenu_Connect.Name = "GridMenu_Connect";
            this.GridMenu_Connect.Size = new System.Drawing.Size(133, 22);
            this.GridMenu_Connect.Text = "Connect";
            this.GridMenu_Connect.Click += new System.EventHandler(this.GridMenu_Connect_Click);
            // 
            // GridMenu_Disconnect
            // 
            this.GridMenu_Disconnect.Name = "GridMenu_Disconnect";
            this.GridMenu_Disconnect.Size = new System.Drawing.Size(133, 22);
            this.GridMenu_Disconnect.Text = "Disconnect";
            this.GridMenu_Disconnect.Click += new System.EventHandler(this.GridMenu_Disconnect_Click);
            // 
            // GridMenu_Configure
            // 
            this.GridMenu_Configure.Name = "GridMenu_Configure";
            this.GridMenu_Configure.Size = new System.Drawing.Size(136, 22);
            this.GridMenu_Configure.Text = "Configure";
            this.GridMenu_Configure.Click += new System.EventHandler(this.GridMenu_Configure_Click);
            // 
            // GridMenu_Remove
            // 
            this.GridMenu_Remove.Name = "GridMenu_Remove";
            this.GridMenu_Remove.Size = new System.Drawing.Size(136, 22);
            this.GridMenu_Remove.Text = "Remove";
            this.GridMenu_Remove.Click += new System.EventHandler(this.GridMenu_Remove_Click);
            // 
            // GroupBox_AddDevice
            // 
            this.GroupBox_AddDevice.Controls.Add(this.ComboBox_Device);
            this.GroupBox_AddDevice.Controls.Add(this.TextBox_FileName);
            this.GroupBox_AddDevice.Controls.Add(this.TextBox_Description);
            this.GroupBox_AddDevice.Controls.Add(this.TextBox_Port);
            this.GroupBox_AddDevice.Controls.Add(this.TextBox_DeviceName);
            this.GroupBox_AddDevice.Controls.Add(this.Button_AddDevice);
            this.GroupBox_AddDevice.Location = new System.Drawing.Point(681, 27);
            this.GroupBox_AddDevice.Name = "GroupBox_AddDevice";
            this.GroupBox_AddDevice.Size = new System.Drawing.Size(143, 220);
            this.GroupBox_AddDevice.TabIndex = 43;
            this.GroupBox_AddDevice.TabStop = false;
            this.GroupBox_AddDevice.Text = "New device";
            // 
            // ComboBox_Device
            // 
            this.ComboBox_Device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Device.FormattingEnabled = true;
            this.ComboBox_Device.Location = new System.Drawing.Point(9, 167);
            this.ComboBox_Device.Name = "ComboBox_Device";
            this.ComboBox_Device.Size = new System.Drawing.Size(124, 21);
            this.ComboBox_Device.TabIndex = 9;
            this.ComboBox_Device.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Device_SelectedIndexChanged);
            this.ComboBox_Device.MouseEnter += new System.EventHandler(this.ComboBox_Device_MouseEnter);
            this.ComboBox_Device.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            // 
            // TextBox_FileName
            // 
            this.TextBox_FileName.CueText = "File name";
            this.TextBox_FileName.Location = new System.Drawing.Point(9, 141);
            this.TextBox_FileName.Name = "TextBox_FileName";
            this.TextBox_FileName.OnlyAllowDigits = false;
            this.TextBox_FileName.OnlyAllowNumbers = false;
            this.TextBox_FileName.ReadOnly = true;
            this.TextBox_FileName.ShortcutsEnabled = false;
            this.TextBox_FileName.Size = new System.Drawing.Size(124, 20);
            this.TextBox_FileName.TabIndex = 3;
            this.TextBox_FileName.TextChanged += new System.EventHandler(this.TextBox_AddDevice_TextChanged);
            this.TextBox_FileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_AddDeviceKeyDown);
            // 
            // TextBox_Description
            // 
            this.TextBox_Description.CueText = "Description";
            this.TextBox_Description.Location = new System.Drawing.Point(9, 71);
            this.TextBox_Description.Multiline = true;
            this.TextBox_Description.Name = "TextBox_Description";
            this.TextBox_Description.OnlyAllowDigits = false;
            this.TextBox_Description.OnlyAllowNumbers = false;
            this.TextBox_Description.ShortcutsEnabled = false;
            this.TextBox_Description.Size = new System.Drawing.Size(124, 64);
            this.TextBox_Description.TabIndex = 2;
            this.TextBox_Description.TextChanged += new System.EventHandler(this.TextBox_AddDevice_TextChanged);
            this.TextBox_Description.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_AddDeviceKeyDown);
            this.TextBox_Description.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Description_KeyPress);
            // 
            // TextBox_Port
            // 
            this.TextBox_Port.CueText = "Port";
            this.TextBox_Port.Location = new System.Drawing.Point(9, 45);
            this.TextBox_Port.Name = "TextBox_Port";
            this.TextBox_Port.OnlyAllowDigits = false;
            this.TextBox_Port.OnlyAllowNumbers = false;
            this.TextBox_Port.ReadOnly = true;
            this.TextBox_Port.ShortcutsEnabled = false;
            this.TextBox_Port.Size = new System.Drawing.Size(124, 20);
            this.TextBox_Port.TabIndex = 1;
            this.TextBox_Port.TextChanged += new System.EventHandler(this.TextBox_AddDevice_TextChanged);
            this.TextBox_Port.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_AddDeviceKeyDown);
            this.TextBox_Port.MouseEnter += new System.EventHandler(this.TextBox_Port_MouseEnter);
            this.TextBox_Port.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            // 
            // TextBox_DeviceName
            // 
            this.TextBox_DeviceName.CueText = "Device name";
            this.TextBox_DeviceName.Location = new System.Drawing.Point(9, 19);
            this.TextBox_DeviceName.Name = "TextBox_DeviceName";
            this.TextBox_DeviceName.OnlyAllowDigits = false;
            this.TextBox_DeviceName.OnlyAllowNumbers = false;
            this.TextBox_DeviceName.ShortcutsEnabled = false;
            this.TextBox_DeviceName.Size = new System.Drawing.Size(124, 20);
            this.TextBox_DeviceName.TabIndex = 0;
            this.TextBox_DeviceName.TextChanged += new System.EventHandler(this.TextBox_AddDevice_TextChanged);
            this.TextBox_DeviceName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_AddDeviceKeyDown);
            // 
            // Button_AddDevice
            // 
            this.Button_AddDevice.Enabled = false;
            this.Button_AddDevice.Location = new System.Drawing.Point(9, 190);
            this.Button_AddDevice.Name = "Button_AddDevice";
            this.Button_AddDevice.Size = new System.Drawing.Size(124, 23);
            this.Button_AddDevice.TabIndex = 8;
            this.Button_AddDevice.Text = "Add device";
            this.Button_AddDevice.UseVisualStyleBackColor = true;
            this.Button_AddDevice.Click += new System.EventHandler(this.Button_AddDevice_Click);
            // 
            // TextBox_Log
            // 
            this.TextBox_Log.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_Log.Location = new System.Drawing.Point(830, 27);
            this.TextBox_Log.Multiline = true;
            this.TextBox_Log.Name = "TextBox_Log";
            this.TextBox_Log.ReadOnly = true;
            this.TextBox_Log.Size = new System.Drawing.Size(412, 412);
            this.TextBox_Log.TabIndex = 44;
            this.TextBox_Log.TabStop = false;
            this.TextBox_Log.TextChanged += new System.EventHandler(this.TextBox_Log_TextChanged);
            // 
            // Label_KaPerNaujus
            // 
            this.Label_KaPerNaujus.AutoSize = true;
            this.Label_KaPerNaujus.Location = new System.Drawing.Point(1173, 9);
            this.Label_KaPerNaujus.Name = "Label_KaPerNaujus";
            this.Label_KaPerNaujus.Size = new System.Drawing.Size(71, 13);
            this.Label_KaPerNaujus.TabIndex = 47;
            this.Label_KaPerNaujus.Text = "ka per naujus";
            this.Label_KaPerNaujus.MouseEnter += new System.EventHandler(this.Label_KaPerNaujus_MouseEnter);
            this.Label_KaPerNaujus.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar_ToolTip,
            this.StatusBar_Separator,
            this.StatusBar_LastUpdate,
            this.StatusBar_VersionSeparator,
            this.StatusBar_Version});
            this.StatusBar.Location = new System.Drawing.Point(0, 452);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1256, 22);
            this.StatusBar.SizingGrip = false;
            this.StatusBar.Stretch = false;
            this.StatusBar.TabIndex = 52;
            this.StatusBar.Text = "statusStrip1";
            // 
            // StatusBar_ToolTip
            // 
            this.StatusBar_ToolTip.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBar_ToolTip.Name = "StatusBar_ToolTip";
            this.StatusBar_ToolTip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StatusBar_ToolTip.Size = new System.Drawing.Size(70, 17);
            this.StatusBar_ToolTip.Text = "Tooltip label";
            // 
            // StatusBar_Separator
            // 
            this.StatusBar_Separator.Name = "StatusBar_Separator";
            this.StatusBar_Separator.Size = new System.Drawing.Size(1050, 17);
            this.StatusBar_Separator.Spring = true;
            // 
            // StatusBar_LastUpdate
            // 
            this.StatusBar_LastUpdate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBar_LastUpdate.Name = "StatusBar_LastUpdate";
            this.StatusBar_LastUpdate.Size = new System.Drawing.Size(67, 17);
            this.StatusBar_LastUpdate.Text = "Last update";
            // 
            // StatusBar_VersionSeparator
            // 
            this.StatusBar_VersionSeparator.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBar_VersionSeparator.Name = "StatusBar_VersionSeparator";
            this.StatusBar_VersionSeparator.Size = new System.Drawing.Size(10, 17);
            this.StatusBar_VersionSeparator.Text = "|";
            // 
            // StatusBar_Version
            // 
            this.StatusBar_Version.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StatusBar_Version.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBar_Version.Image = ((System.Drawing.Image)(resources.GetObject("StatusBar_Version.Image")));
            this.StatusBar_Version.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StatusBar_Version.Name = "StatusBar_Version";
            this.StatusBar_Version.ShowDropDownArrow = false;
            this.StatusBar_Version.Size = new System.Drawing.Size(44, 20);
            this.StatusBar_Version.Text = "1.0.0.0";
            this.StatusBar_Version.Click += new System.EventHandler(this.StatusBar_Help_Click);
            // 
            // Button_ToggleLog
            // 
            this.Button_ToggleLog.Location = new System.Drawing.Point(784, 358);
            this.Button_ToggleLog.Name = "Button_ToggleLog";
            this.Button_ToggleLog.Size = new System.Drawing.Size(30, 23);
            this.Button_ToggleLog.TabIndex = 48;
            this.Button_ToggleLog.TabStop = false;
            this.Button_ToggleLog.Text = "<<";
            this.Button_ToggleLog.UseVisualStyleBackColor = true;
            this.Button_ToggleLog.Click += new System.EventHandler(this.Button_ToggleLog_Click);
            this.Button_ToggleLog.MouseEnter += new System.EventHandler(this.Button_ToggleLog_MouseEnter);
            this.Button_ToggleLog.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            // 
            // Button_OpenLaunchDirectory
            // 
            this.Button_OpenLaunchDirectory.Location = new System.Drawing.Point(690, 387);
            this.Button_OpenLaunchDirectory.Name = "Button_OpenLaunchDirectory";
            this.Button_OpenLaunchDirectory.Size = new System.Drawing.Size(124, 23);
            this.Button_OpenLaunchDirectory.TabIndex = 46;
            this.Button_OpenLaunchDirectory.TabStop = false;
            this.Button_OpenLaunchDirectory.Text = "Open launch directory\r\n";
            this.Button_OpenLaunchDirectory.UseVisualStyleBackColor = true;
            this.Button_OpenLaunchDirectory.Click += new System.EventHandler(this.Button_OpenLaunchDirectory_Click);
            this.Button_OpenLaunchDirectory.MouseEnter += new System.EventHandler(this.Button_OpenLaunchDirectory_MouseEnter);
            this.Button_OpenLaunchDirectory.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            // 
            // Button_OpenOutputDirectory
            // 
            this.Button_OpenOutputDirectory.Location = new System.Drawing.Point(690, 416);
            this.Button_OpenOutputDirectory.Name = "Button_OpenOutputDirectory";
            this.Button_OpenOutputDirectory.Size = new System.Drawing.Size(124, 23);
            this.Button_OpenOutputDirectory.TabIndex = 45;
            this.Button_OpenOutputDirectory.TabStop = false;
            this.Button_OpenOutputDirectory.Text = "Open output directory";
            this.Button_OpenOutputDirectory.UseVisualStyleBackColor = true;
            this.Button_OpenOutputDirectory.Click += new System.EventHandler(this.Button_OpenOutputDirectory_Click);
            this.Button_OpenOutputDirectory.MouseEnter += new System.EventHandler(this.Button_OpenOutputDirectory_MouseEnter);
            this.Button_OpenOutputDirectory.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            // 
            // Button_StartCollector
            // 
            this.Button_StartCollector.Enabled = false;
            this.Button_StartCollector.Location = new System.Drawing.Point(690, 253);
            this.Button_StartCollector.Name = "Button_StartCollector";
            this.Button_StartCollector.Size = new System.Drawing.Size(124, 50);
            this.Button_StartCollector.TabIndex = 43;
            this.Button_StartCollector.TabStop = false;
            this.Button_StartCollector.Text = "Start collecting data";
            this.Button_StartCollector.UseVisualStyleBackColor = true;
            this.Button_StartCollector.Click += new System.EventHandler(this.Button_StartCollector_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 474);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.Button_ToggleLog);
            this.Controls.Add(this.Label_KaPerNaujus);
            this.Controls.Add(this.Button_OpenLaunchDirectory);
            this.Controls.Add(this.Button_OpenOutputDirectory);
            this.Controls.Add(this.Button_StartCollector);
            this.Controls.Add(this.TextBox_Log);
            this.Controls.Add(this.GroupBox_AddDevice);
            this.Controls.Add(this.DataGrid_Devices);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Device manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MouseEnter += new System.EventHandler(this.ClearStatusBar);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Devices)).EndInit();
            this.GridMenu.ResumeLayout(false);
            this.GroupBox_AddDevice.ResumeLayout(false);
            this.GroupBox_AddDevice.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem MainMenuItem_File;
		private System.Windows.Forms.ToolStripMenuItem MainMenu_Exit;
		private System.Windows.Forms.DataGridView DataGrid_Devices;
		private System.Windows.Forms.ToolStripMenuItem MainMenu_ReadFiles;
		private BetterButton Button_AddDevice;
		private System.Windows.Forms.ContextMenuStrip GridMenu;
		private System.Windows.Forms.ToolStripMenuItem GridMenu_Remove;
		private System.Windows.Forms.GroupBox GroupBox_AddDevice;
		private System.Windows.Forms.ToolStripMenuItem MainMenu_Settings;
		private System.Windows.Forms.TextBox TextBox_Log;
		private BetterButton Button_StartCollector;
		private BetterButton Button_OpenOutputDirectory;
		private System.Windows.Forms.ToolStripMenuItem GridMenu_Watch;
		private BetterButton Button_OpenLaunchDirectory;
		private System.Windows.Forms.ToolStripMenuItem GridMenu_Connection;
		private System.Windows.Forms.ToolStripMenuItem GridMenu_Connect;
		private System.Windows.Forms.ToolStripMenuItem GridMenu_Disconnect;
		private System.Windows.Forms.Label Label_KaPerNaujus;
		private System.Windows.Forms.ToolStripMenuItem GridMenu_Configure;
		private BetterButton Button_ToggleLog;
		private CueTextBox TextBox_FileName;
		private CueTextBox TextBox_Description;
		private CueTextBox TextBox_Port;
		private CueTextBox TextBox_DeviceName;
		private System.Windows.Forms.ComboBox ComboBox_Device;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Device;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_DeviceName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Port;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_State;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Description;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_FileName;
		private System.Windows.Forms.ToolStripMenuItem GridMenu_Live;
		private System.Windows.Forms.StatusStrip StatusBar;
		private System.Windows.Forms.ToolStripStatusLabel StatusBar_ToolTip;
		private System.Windows.Forms.ToolStripStatusLabel StatusBar_Separator;
		private System.Windows.Forms.ToolStripStatusLabel StatusBar_LastUpdate;
		private System.Windows.Forms.ToolStripDropDownButton StatusBar_Version;
		private System.Windows.Forms.ToolStripStatusLabel StatusBar_VersionSeparator;
	}
}

