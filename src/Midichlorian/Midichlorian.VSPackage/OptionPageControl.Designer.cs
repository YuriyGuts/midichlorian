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
            this.grpMappings = new System.Windows.Forms.GroupBox();
            this.pnlMappingList = new System.Windows.Forms.Panel();
            this.pnlMappingListItems = new System.Windows.Forms.Panel();
            this.pnlMappingListSpacer = new System.Windows.Forms.Panel();
            this.tlbMappingListActions = new System.Windows.Forms.ToolStrip();
            this.tbtnAddMapping = new System.Windows.Forms.ToolStripButton();
            this.tlspSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnImportFile = new System.Windows.Forms.ToolStripButton();
            this.tbtnExportFile = new System.Windows.Forms.ToolStripButton();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            this.grpDeviceSettings.SuspendLayout();
            this.grpMappings.SuspendLayout();
            this.pnlMappingList.SuspendLayout();
            this.tlbMappingListActions.SuspendLayout();
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
            this.grpDeviceSettings.Size = new System.Drawing.Size(450, 85);
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
            this.lblMidiTestStatus.Size = new System.Drawing.Size(223, 15);
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
            // grpMappings
            // 
            this.grpMappings.Controls.Add(this.pnlMappingList);
            this.grpMappings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMappings.Enabled = false;
            this.grpMappings.Location = new System.Drawing.Point(0, 95);
            this.grpMappings.Name = "grpMappings";
            this.grpMappings.Padding = new System.Windows.Forms.Padding(10);
            this.grpMappings.Size = new System.Drawing.Size(450, 168);
            this.grpMappings.TabIndex = 3;
            this.grpMappings.TabStop = false;
            this.grpMappings.Text = " Mappings ";
            // 
            // pnlMappingList
            // 
            this.pnlMappingList.Controls.Add(this.pnlMappingListItems);
            this.pnlMappingList.Controls.Add(this.pnlMappingListSpacer);
            this.pnlMappingList.Controls.Add(this.tlbMappingListActions);
            this.pnlMappingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMappingList.Location = new System.Drawing.Point(10, 26);
            this.pnlMappingList.Name = "pnlMappingList";
            this.pnlMappingList.Size = new System.Drawing.Size(430, 132);
            this.pnlMappingList.TabIndex = 0;
            // 
            // pnlMappingListItems
            // 
            this.pnlMappingListItems.AutoScroll = true;
            this.pnlMappingListItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMappingListItems.Location = new System.Drawing.Point(0, 35);
            this.pnlMappingListItems.Name = "pnlMappingListItems";
            this.pnlMappingListItems.Size = new System.Drawing.Size(430, 97);
            this.pnlMappingListItems.TabIndex = 3;
            // 
            // pnlMappingListSpacer
            // 
            this.pnlMappingListSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMappingListSpacer.Location = new System.Drawing.Point(0, 25);
            this.pnlMappingListSpacer.Name = "pnlMappingListSpacer";
            this.pnlMappingListSpacer.Size = new System.Drawing.Size(430, 10);
            this.pnlMappingListSpacer.TabIndex = 2;
            // 
            // tlbMappingListActions
            // 
            this.tlbMappingListActions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlbMappingListActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnAddMapping,
            this.tlspSeparator,
            this.tbtnImportFile,
            this.tbtnExportFile});
            this.tlbMappingListActions.Location = new System.Drawing.Point(0, 0);
            this.tlbMappingListActions.Name = "tlbMappingListActions";
            this.tlbMappingListActions.Size = new System.Drawing.Size(430, 25);
            this.tlbMappingListActions.TabIndex = 0;
            this.tlbMappingListActions.Text = "toolStrip1";
            // 
            // tbtnAddMapping
            // 
            this.tbtnAddMapping.Image = global::YuriyGuts.Midichlorian.VSPackage.Resources.MappingAdd;
            this.tbtnAddMapping.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddMapping.Name = "tbtnAddMapping";
            this.tbtnAddMapping.Size = new System.Drawing.Size(100, 22);
            this.tbtnAddMapping.Text = "Add Mapping";
            this.tbtnAddMapping.Click += new System.EventHandler(this.tbtnAddMapping_Click);
            // 
            // tlspSeparator
            // 
            this.tlspSeparator.Name = "tlspSeparator";
            this.tlspSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnImportFile
            // 
            this.tbtnImportFile.Image = global::YuriyGuts.Midichlorian.VSPackage.Resources.MappingImport;
            this.tbtnImportFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnImportFile.Name = "tbtnImportFile";
            this.tbtnImportFile.Size = new System.Drawing.Size(122, 22);
            this.tbtnImportFile.Text = "Import from File...";
            this.tbtnImportFile.Click += new System.EventHandler(this.tbtnImportFile_Click);
            // 
            // tbtnExportFile
            // 
            this.tbtnExportFile.Image = global::YuriyGuts.Midichlorian.VSPackage.Resources.MappingExport;
            this.tbtnExportFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnExportFile.Name = "tbtnExportFile";
            this.tbtnExportFile.Size = new System.Drawing.Size(104, 22);
            this.tbtnExportFile.Text = "Export to File...";
            this.tbtnExportFile.Click += new System.EventHandler(this.tbtnExportFile_Click);
            // 
            // pnlSpacer
            // 
            this.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpacer.Location = new System.Drawing.Point(0, 85);
            this.pnlSpacer.Name = "pnlSpacer";
            this.pnlSpacer.Size = new System.Drawing.Size(450, 10);
            this.pnlSpacer.TabIndex = 4;
            // 
            // OptionPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMappings);
            this.Controls.Add(this.pnlSpacer);
            this.Controls.Add(this.grpDeviceSettings);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "OptionPageControl";
            this.Size = new System.Drawing.Size(450, 263);
            this.grpDeviceSettings.ResumeLayout(false);
            this.grpDeviceSettings.PerformLayout();
            this.grpMappings.ResumeLayout(false);
            this.pnlMappingList.ResumeLayout(false);
            this.pnlMappingList.PerformLayout();
            this.tlbMappingListActions.ResumeLayout(false);
            this.tlbMappingListActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDeviceSettings;
        private System.Windows.Forms.ComboBox cmbMidiInputDevice;
        private System.Windows.Forms.Label lblMidiInputDevice;
        private System.Windows.Forms.Label lblMidiTestStatus;
        private System.Windows.Forms.CheckBox chkTestMidiInputDevice;
        private System.Windows.Forms.GroupBox grpMappings;
        private System.Windows.Forms.Panel pnlMappingList;
        private System.Windows.Forms.ToolStrip tlbMappingListActions;
        private System.Windows.Forms.Panel pnlSpacer;
        private System.Windows.Forms.ToolStripButton tbtnAddMapping;
        private System.Windows.Forms.ToolStripSeparator tlspSeparator;
        private System.Windows.Forms.ToolStripButton tbtnImportFile;
        private System.Windows.Forms.ToolStripButton tbtnExportFile;
        private System.Windows.Forms.Panel pnlMappingListSpacer;
        private System.Windows.Forms.Panel pnlMappingListItems;

    }
}
