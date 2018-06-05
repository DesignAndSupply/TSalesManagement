namespace TSalesManagement
{
    partial class DetailView
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
            this.dgDetail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDetail
            // 
            this.dgDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetail.Location = new System.Drawing.Point(13, 12);
            this.dgDetail.Name = "dgDetail";
            this.dgDetail.Size = new System.Drawing.Size(1006, 578);
            this.dgDetail.TabIndex = 0;
            // 
            // DetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 602);
            this.Controls.Add(this.dgDetail);
            this.Name = "DetailView";
            this.Text = "DetailView";
            this.Load += new System.EventHandler(this.DetailView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDetail;
    }
}