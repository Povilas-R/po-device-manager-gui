using Po.Forms;

namespace DeviceManagerGUI.DeviceConfiguration
{
    partial class ConfigurationForm
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
            this.Grid = new System.Windows.Forms.PropertyGrid();
            this.Button_Configure = new Po.Forms.BetterButton();
            this.Button_Cancel = new Po.Forms.BetterButton();
            this.Button_Factory = new Po.Forms.BetterButton();
            this.TextBox_ID = new Po.Forms.CueTextBox();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.Location = new System.Drawing.Point(12, 12);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(321, 225);
            this.Grid.TabIndex = 42;
            this.Grid.TabStop = false;
            this.Grid.ToolbarVisible = false;
            // 
            // Button_Configure
            // 
            this.Button_Configure.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_Configure.Location = new System.Drawing.Point(177, 243);
            this.Button_Configure.Name = "Button_Configure";
            this.Button_Configure.Size = new System.Drawing.Size(75, 26);
            this.Button_Configure.TabIndex = 43;
            this.Button_Configure.TabStop = false;
            this.Button_Configure.Text = "Configure";
            this.Button_Configure.UseVisualStyleBackColor = true;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(258, 243);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 26);
            this.Button_Cancel.TabIndex = 44;
            this.Button_Cancel.TabStop = false;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Button_Factory
            // 
            this.Button_Factory.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Button_Factory.Enabled = false;
            this.Button_Factory.Location = new System.Drawing.Point(12, 243);
            this.Button_Factory.Name = "Button_Factory";
            this.Button_Factory.Size = new System.Drawing.Size(75, 26);
            this.Button_Factory.TabIndex = 45;
            this.Button_Factory.TabStop = false;
            this.Button_Factory.Text = "Set factory";
            this.Button_Factory.UseVisualStyleBackColor = true;
            // 
            // TextBox_ID
            // 
            this.TextBox_ID.CueText = "Device ID";
            this.TextBox_ID.Location = new System.Drawing.Point(93, 247);
            this.TextBox_ID.Name = "TextBox_ID";
            this.TextBox_ID.OnlyAllowDigits = true;
            this.TextBox_ID.OnlyAllowNumbers = false;
            this.TextBox_ID.ShortcutsEnabled = false;
            this.TextBox_ID.Size = new System.Drawing.Size(75, 20);
            this.TextBox_ID.TabIndex = 46;
            this.TextBox_ID.TextChanged += new System.EventHandler(this.TextBox_ID_TextChanged);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 279);
            this.Controls.Add(this.TextBox_ID);
            this.Controls.Add(this.Button_Factory);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_Configure);
            this.Controls.Add(this.Grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConfigurationForm";
            this.Text = "ConfigurationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid Grid;
        private BetterButton Button_Configure;
        private BetterButton Button_Cancel;
        private BetterButton Button_Factory;
        private CueTextBox TextBox_ID;
    }
}