namespace TSalesManagement
{
    partial class frmPipelineLive
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
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(13, 46);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(1153, 598);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(141, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(54, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Update";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Items.AddRange(new object[] {
            "Pending",
            "Ordered",
            "Lost"});
            this.cmbFilterStatus.Location = new System.Drawing.Point(13, 12);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterStatus.TabIndex = 6;
            this.cmbFilterStatus.Text = "Pending";
            // 
            // frmPipelineLive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 656);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbFilterStatus);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "frmPipelineLive";
            this.Text = "Pipeline Live";
            this.Load += new System.EventHandler(this.frmPipelineLive_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
    }
}