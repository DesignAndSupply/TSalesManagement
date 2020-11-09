namespace TSalesManagement
{
    partial class frmLinkSector
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
            this.btnLink = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.lblSector = new System.Windows.Forms.LinkLabel();
            this.cmbSector = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(165, 53);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(75, 23);
            this.btnLink.TabIndex = 21;
            this.btnLink.Text = "Link Sector";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 53);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 23;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblSector
            // 
            this.lblSector.AutoSize = true;
            this.lblSector.LinkColor = System.Drawing.Color.Teal;
            this.lblSector.Location = new System.Drawing.Point(82, 9);
            this.lblSector.Name = "lblSector";
            this.lblSector.Size = new System.Drawing.Size(85, 13);
            this.lblSector.TabIndex = 24;
            this.lblSector.TabStop = true;
            this.lblSector.Text = "Add New Sector";
            this.lblSector.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSector_LinkClicked);
            // 
            // cmbSector
            // 
            this.cmbSector.FormattingEnabled = true;
            this.cmbSector.Location = new System.Drawing.Point(12, 26);
            this.cmbSector.Name = "cmbSector";
            this.cmbSector.Size = new System.Drawing.Size(228, 21);
            this.cmbSector.TabIndex = 19;
            // 
            // frmLinkSector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 91);
            this.Controls.Add(this.lblSector);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.cmbSector);
            this.Name = "frmLinkSector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLinkSector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.LinkLabel lblSector;
        private System.Windows.Forms.ComboBox cmbSector;
    }
}