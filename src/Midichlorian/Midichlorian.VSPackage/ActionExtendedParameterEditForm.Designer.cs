namespace YuriyGuts.Midichlorian.VSPackage
{
    partial class ActionExtendedParameterEditForm
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
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.txtExtendedParams = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.lblEscapeWarning = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlButtonSpacer = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMainContent.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.txtExtendedParams);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Padding = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.pnlMainContent.Size = new System.Drawing.Size(438, 103);
            this.pnlMainContent.TabIndex = 0;
            // 
            // txtExtendedParams
            // 
            this.txtExtendedParams.AcceptsReturn = true;
            this.txtExtendedParams.AcceptsTab = true;
            this.txtExtendedParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExtendedParams.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtExtendedParams.Location = new System.Drawing.Point(8, 8);
            this.txtExtendedParams.Multiline = true;
            this.txtExtendedParams.Name = "txtExtendedParams";
            this.txtExtendedParams.Size = new System.Drawing.Size(422, 95);
            this.txtExtendedParams.TabIndex = 0;
            this.txtExtendedParams.TextChanged += new System.EventHandler(this.txtExtendedParams_TextChanged);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.lblEscapeWarning);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Controls.Add(this.pnlButtonSpacer);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 103);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(8);
            this.pnlButtons.Size = new System.Drawing.Size(438, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // lblEscapeWarning
            // 
            this.lblEscapeWarning.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEscapeWarning.ForeColor = System.Drawing.Color.Teal;
            this.lblEscapeWarning.Location = new System.Drawing.Point(8, 7);
            this.lblEscapeWarning.Name = "lblEscapeWarning";
            this.lblEscapeWarning.Size = new System.Drawing.Size(249, 28);
            this.lblEscapeWarning.TabIndex = 3;
            this.lblEscapeWarning.Text = "Note: the text contains some special characters so we\'ll encode it in Base64 for " +
    "you.";
            this.lblEscapeWarning.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(262, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 27);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // pnlButtonSpacer
            // 
            this.pnlButtonSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtonSpacer.Location = new System.Drawing.Point(342, 8);
            this.pnlButtonSpacer.Name = "pnlButtonSpacer";
            this.pnlButtonSpacer.Size = new System.Drawing.Size(8, 27);
            this.pnlButtonSpacer.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(350, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 27);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ActionExtendedParameterEditForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(438, 146);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(450, 130);
            this.Name = "ActionExtendedParameterEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Edit Extended Action Parameters";
            this.pnlMainContent.ResumeLayout(false);
            this.pnlMainContent.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel pnlButtonSpacer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtExtendedParams;
        private System.Windows.Forms.Label lblEscapeWarning;
    }
}