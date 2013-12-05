namespace YuriyGuts.Midichlorian.VSPackage
{
    partial class OptionPageControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpDeviceSettings = new System.Windows.Forms.GroupBox();
            this.lblMidiTestStatus = new System.Windows.Forms.Label();
            this.chkTestMidiInputDevice = new System.Windows.Forms.CheckBox();
            this.cmbMidiInputDevice = new System.Windows.Forms.ComboBox();
            this.lblMidiInputDevice = new System.Windows.Forms.Label();
            this.grpDeviceSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDeviceSettings
            // 
            this.grpDeviceSettings.Controls.Add(this.lblMidiTestStatus);
            this.grpDeviceSettings.Controls.Add(this.chkTestMidiInputDevice);
            this.grpDeviceSettings.Controls.Add(this.cmbMidiInputDevice);
            this.grpDeviceSettings.Controls.Add(this.lblMidiInputDevice);
            this.grpDeviceSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDeviceSettings.Location = new System.Drawing.Point(0, 0);
            this.grpDeviceSettings.Name = "grpDeviceSettings";
            this.grpDeviceSettings.Padding = new System.Windows.Forms.Padding(5);
            this.grpDeviceSettings.Size = new System.Drawing.Size(504, 85);
            this.grpDeviceSettings.TabIndex = 2;
            this.grpDeviceSettings.TabStop = false;
            this.grpDeviceSettings.Text = " Device Settings";
            // 
            // lblMidiTestStatus
            // 
            this.lblMidiTestStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMidiTestStatus.AutoEllipsis = true;
            this.lblMidiTestStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblMidiTestStatus.Location = new System.Drawing.Point(219, 54);
            this.lblMidiTestStatus.Name = "lblMidiTestStatus";
            this.lblMidiTestStatus.Size = new System.Drawing.Size(277, 15);
            this.lblMidiTestStatus.TabIndex = 3;
            this.lblMidiTestStatus.Text = "Press any MIDI key...";
            this.lblMidiTestStatus.Visible = false;
            // 
            // chkTestMidiInputDevice
            // 
            this.chkTestMidiInputDevice.AutoSize = true;
            this.chkTestMidiInputDevice.Enabled = false;
            this.chkTestMidiInputDevice.Location = new System.Drawing.Point(127, 53);
            this.chkTestMidiInputDevice.Name = "chkTestMidiInputDevice";
            this.chkTestMidiInputDevice.Size = new System.Drawing.Size(86, 19);
            this.chkTestMidiInputDevice.TabIndex = 2;
            this.chkTestMidiInputDevice.Text = "Test Device";
            this.chkTestMidiInputDevice.UseVisualStyleBackColor = true;
            this.chkTestMidiInputDevice.CheckedChanged += new System.EventHandler(this.chkTestMidiInputDevice_CheckedChanged);
            // 
            // cmbMidiInputDevice
            // 
            this.cmbMidiInputDevice.DisplayMember = "Name";
            this.cmbMidiInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMidiInputDevice.FormattingEnabled = true;
            this.cmbMidiInputDevice.Location = new System.Drawing.Point(127, 24);
            this.cmbMidiInputDevice.Name = "cmbMidiInputDevice";
            this.cmbMidiInputDevice.Size = new System.Drawing.Size(246, 23);
            this.cmbMidiInputDevice.TabIndex = 0;
            this.cmbMidiInputDevice.SelectedIndexChanged += new System.EventHandler(this.cmbMidiInputDevice_SelectedIndexChanged);
            // 
            // lblMidiInputDevice
            // 
            this.lblMidiInputDevice.AutoSize = true;
            this.lblMidiInputDevice.Location = new System.Drawing.Point(18, 27);
            this.lblMidiInputDevice.Name = "lblMidiInputDevice";
            this.lblMidiInputDevice.Size = new System.Drawing.Size(103, 15);
            this.lblMidiInputDevice.TabIndex = 1;
            this.lblMidiInputDevice.Text = "MIDI input device:";
            // 
            // OptionPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpDeviceSettings);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "OptionPageControl";
            this.Size = new System.Drawing.Size(504, 233);
            this.grpDeviceSettings.ResumeLayout(false);
            this.grpDeviceSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDeviceSettings;
        private System.Windows.Forms.ComboBox cmbMidiInputDevice;
        private System.Windows.Forms.Label lblMidiInputDevice;
        private System.Windows.Forms.Label lblMidiTestStatus;
        private System.Windows.Forms.CheckBox chkTestMidiInputDevice;

    }
}
