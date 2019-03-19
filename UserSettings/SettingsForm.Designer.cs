using Po.Forms;

namespace DeviceManagerGUI.UserSettings
{
    partial class SettingsForm
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
            this.Button_LoadDefault = new Po.Forms.BetterButton();
            this.Button_OK = new Po.Forms.BetterButton();
            this.Button_Cancel = new Po.Forms.BetterButton();
            this.Button_Reload = new Po.Forms.BetterButton();
            this.Grid = new System.Windows.Forms.PropertyGrid();
            this.Button_Save = new Po.Forms.BetterButton();
            this.SuspendLayout();
            // 
            // Button_LoadDefault
            // 
            this.Button_LoadDefault.Location = new System.Drawing.Point(93, 260);
            this.Button_LoadDefault.Name = "Button_LoadDefault";
            this.Button_LoadDefault.Size = new System.Drawing.Size(75, 26);
            this.Button_LoadDefault.TabIndex = 35;
            this.Button_LoadDefault.TabStop = false;
            this.Button_LoadDefault.Text = "Default";
            this.Button_LoadDefault.UseVisualStyleBackColor = true;
            this.Button_LoadDefault.Click += new System.EventHandler(this.Button_LoadDefault_Click);
            // 
            // Button_OK
            // 
            this.Button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_OK.Location = new System.Drawing.Point(376, 260);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 26);
            this.Button_OK.TabIndex = 36;
            this.Button_OK.TabStop = false;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(457, 260);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 26);
            this.Button_Cancel.TabIndex = 37;
            this.Button_Cancel.TabStop = false;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Button_Reload
            // 
            this.Button_Reload.Location = new System.Drawing.Point(12, 260);
            this.Button_Reload.Name = "Button_Reload";
            this.Button_Reload.Size = new System.Drawing.Size(75, 26);
            this.Button_Reload.TabIndex = 40;
            this.Button_Reload.TabStop = false;
            this.Button_Reload.Text = "Reload";
            this.Button_Reload.UseVisualStyleBackColor = true;
            this.Button_Reload.Click += new System.EventHandler(this.Button_Reload_Click);
            // 
            // Grid
            // 
            this.Grid.Location = new System.Drawing.Point(12, 12);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(520, 242);
            this.Grid.TabIndex = 41;
            this.Grid.TabStop = false;
            this.Grid.ToolbarVisible = false;
            this.Grid.UseCompatibleTextRendering = true;
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(295, 260);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(75, 26);
            this.Button_Save.TabIndex = 42;
            this.Button_Save.TabStop = false;
            this.Button_Save.Text = "Save";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 295);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.Button_Reload);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_LoadDefault);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion
        private BetterButton Button_LoadDefault;
        private BetterButton Button_OK;
        private BetterButton Button_Cancel;
        private BetterButton Button_Reload;
        private System.Windows.Forms.PropertyGrid Grid;
        private BetterButton Button_Save;
    }
}