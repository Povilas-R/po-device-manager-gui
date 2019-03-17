namespace DeviceManagerGUI
{
	partial class LiveWatchForm
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
            this.Label_Info1 = new System.Windows.Forms.Label();
            this.Panel_Info1 = new System.Windows.Forms.Panel();
            this.Panel_Info2 = new System.Windows.Forms.Panel();
            this.Label_Info2 = new System.Windows.Forms.Label();
            this.Panel_Info1.SuspendLayout();
            this.Panel_Info2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label_Info1
            // 
            this.Label_Info1.AutoSize = true;
            this.Label_Info1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Info1.Location = new System.Drawing.Point(5, 4);
            this.Label_Info1.Name = "Label_Info1";
            this.Label_Info1.Size = new System.Drawing.Size(55, 13);
            this.Label_Info1.TabIndex = 51;
            this.Label_Info1.Text = "label1";
            // 
            // Panel_Info1
            // 
            this.Panel_Info1.Controls.Add(this.Label_Info1);
            this.Panel_Info1.Location = new System.Drawing.Point(14, 12);
            this.Panel_Info1.Name = "Panel_Info1";
            this.Panel_Info1.Size = new System.Drawing.Size(275, 479);
            this.Panel_Info1.TabIndex = 52;
            // 
            // Panel_Info2
            // 
            this.Panel_Info2.Controls.Add(this.Label_Info2);
            this.Panel_Info2.Location = new System.Drawing.Point(295, 12);
            this.Panel_Info2.Name = "Panel_Info2";
            this.Panel_Info2.Size = new System.Drawing.Size(275, 479);
            this.Panel_Info2.TabIndex = 53;
            // 
            // Label_Info2
            // 
            this.Label_Info2.AutoSize = true;
            this.Label_Info2.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Info2.Location = new System.Drawing.Point(3, 4);
            this.Label_Info2.Name = "Label_Info2";
            this.Label_Info2.Size = new System.Drawing.Size(55, 13);
            this.Label_Info2.TabIndex = 51;
            this.Label_Info2.Text = "label1";
            // 
            // LiveWatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 503);
            this.Controls.Add(this.Panel_Info2);
            this.Controls.Add(this.Panel_Info1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LiveWatchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Live watch";
            this.TopMost = true;
            this.Panel_Info1.ResumeLayout(false);
            this.Panel_Info1.PerformLayout();
            this.Panel_Info2.ResumeLayout(false);
            this.Panel_Info2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label Label_Info1;
		private System.Windows.Forms.Panel Panel_Info1;
		private System.Windows.Forms.Panel Panel_Info2;
		private System.Windows.Forms.Label Label_Info2;
	}
}