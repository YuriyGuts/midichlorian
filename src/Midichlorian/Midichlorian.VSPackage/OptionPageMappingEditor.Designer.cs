namespace YuriyGuts.Midichlorian.VSPackage
{
    partial class OptionPageMappingEditor
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
            this.components = new System.ComponentModel.Container();
            this.btnLearnInputFromMidi = new System.Windows.Forms.Button();
            this.txtInputTrigger = new System.Windows.Forms.TextBox();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.txtActionParams = new System.Windows.Forms.TextBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.btnActionExtendedParams = new System.Windows.Forms.Button();
            this.lblKeys = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnLearnInputFromMidi
            // 
            this.btnLearnInputFromMidi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLearnInputFromMidi.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLearnInputFromMidi.Image = global::YuriyGuts.Midichlorian.VSPackage.Resources.MappingLearn;
            this.btnLearnInputFromMidi.Location = new System.Drawing.Point(132, 0);
            this.btnLearnInputFromMidi.Name = "btnLearnInputFromMidi";
            this.btnLearnInputFromMidi.Size = new System.Drawing.Size(28, 23);
            this.btnLearnInputFromMidi.TabIndex = 0;
            this.btnLearnInputFromMidi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnLearnInputFromMidi, "Learn from MIDI device...");
            this.btnLearnInputFromMidi.UseVisualStyleBackColor = true;
            this.btnLearnInputFromMidi.Click += new System.EventHandler(this.btnLearnInputFromMidi_Click);
            // 
            // txtInputTrigger
            // 
            this.txtInputTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtInputTrigger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInputTrigger.Location = new System.Drawing.Point(39, 0);
            this.txtInputTrigger.Name = "txtInputTrigger";
            this.txtInputTrigger.ReadOnly = true;
            this.txtInputTrigger.Size = new System.Drawing.Size(92, 23);
            this.txtInputTrigger.TabIndex = 1;
            // 
            // cmbAction
            // 
            this.cmbAction.DisplayMember = "Name";
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(216, 0);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(98, 23);
            this.cmbAction.TabIndex = 2;
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbAction_SelectedIndexChanged);
            // 
            // txtActionParams
            // 
            this.txtActionParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActionParams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActionParams.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtActionParams.Location = new System.Drawing.Point(315, 0);
            this.txtActionParams.Name = "txtActionParams";
            this.txtActionParams.Size = new System.Drawing.Size(68, 23);
            this.txtActionParams.TabIndex = 3;
            this.toolTip.SetToolTip(this.txtActionParams, "Action parameters");
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(169, 3);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(45, 15);
            this.lblAction.TabIndex = 4;
            this.lblAction.Text = "Action:";
            // 
            // btnActionExtendedParams
            // 
            this.btnActionExtendedParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActionExtendedParams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActionExtendedParams.Location = new System.Drawing.Point(384, 0);
            this.btnActionExtendedParams.Name = "btnActionExtendedParams";
            this.btnActionExtendedParams.Size = new System.Drawing.Size(28, 23);
            this.btnActionExtendedParams.TabIndex = 5;
            this.btnActionExtendedParams.Text = "...";
            this.toolTip.SetToolTip(this.btnActionExtendedParams, "Show extended editor");
            this.btnActionExtendedParams.UseVisualStyleBackColor = true;
            this.btnActionExtendedParams.Click += new System.EventHandler(this.btnActionExtendedParams_Click);
            // 
            // lblKeys
            // 
            this.lblKeys.AutoSize = true;
            this.lblKeys.Location = new System.Drawing.Point(3, 3);
            this.lblKeys.Name = "lblKeys";
            this.lblKeys.Size = new System.Drawing.Size(34, 15);
            this.lblKeys.TabIndex = 7;
            this.lblKeys.Text = "Keys:";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::YuriyGuts.Midichlorian.VSPackage.Resources.MappingDelete;
            this.btnDelete.Location = new System.Drawing.Point(421, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(28, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnDelete, "Delete mapping");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // OptionPageMappingEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblKeys);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnActionExtendedParams);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.txtActionParams);
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.txtInputTrigger);
            this.Controls.Add(this.btnLearnInputFromMidi);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "OptionPageMappingEditor";
            this.Size = new System.Drawing.Size(450, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLearnInputFromMidi;
        private System.Windows.Forms.TextBox txtInputTrigger;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.TextBox txtActionParams;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Button btnActionExtendedParams;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblKeys;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
