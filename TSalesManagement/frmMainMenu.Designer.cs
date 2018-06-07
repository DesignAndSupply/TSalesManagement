namespace TSalesManagement
{
    partial class frmMainMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activityLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pipelineChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabForms = new System.Windows.Forms.TabControl();
            this.pipelineLiveChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customersToolStripMenuItem,
            this.salesDataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(989, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activityLogToolStripMenuItem,
            this.customerListToolStripMenuItem});
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.customersToolStripMenuItem.Text = "Customers";
            // 
            // activityLogToolStripMenuItem
            // 
            this.activityLogToolStripMenuItem.Name = "activityLogToolStripMenuItem";
            this.activityLogToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.activityLogToolStripMenuItem.Text = "Activity Log";
            this.activityLogToolStripMenuItem.Click += new System.EventHandler(this.activityLogToolStripMenuItem_Click);
            // 
            // customerListToolStripMenuItem
            // 
            this.customerListToolStripMenuItem.Name = "customerListToolStripMenuItem";
            this.customerListToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.customerListToolStripMenuItem.Text = "Customer List";
            this.customerListToolStripMenuItem.Click += new System.EventHandler(this.customerListToolStripMenuItem_Click);
            // 
            // salesDataToolStripMenuItem
            // 
            this.salesDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monthlyChartToolStripMenuItem,
            this.pipelineChartToolStripMenuItem,
            this.pipelineLiveChartToolStripMenuItem});
            this.salesDataToolStripMenuItem.Name = "salesDataToolStripMenuItem";
            this.salesDataToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.salesDataToolStripMenuItem.Text = "Sales Data";
            // 
            // monthlyChartToolStripMenuItem
            // 
            this.monthlyChartToolStripMenuItem.Name = "monthlyChartToolStripMenuItem";
            this.monthlyChartToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.monthlyChartToolStripMenuItem.Text = "Monthly Chart";
            this.monthlyChartToolStripMenuItem.Click += new System.EventHandler(this.monthlyChartToolStripMenuItem_Click);
            // 
            // pipelineChartToolStripMenuItem
            // 
            this.pipelineChartToolStripMenuItem.Name = "pipelineChartToolStripMenuItem";
            this.pipelineChartToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pipelineChartToolStripMenuItem.Text = "Pipeline Chart";
            this.pipelineChartToolStripMenuItem.Click += new System.EventHandler(this.pipelineChartToolStripMenuItem_Click);
            // 
            // tabForms
            // 
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabForms.Location = new System.Drawing.Point(0, 24);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.Size = new System.Drawing.Size(989, 28);
            this.tabForms.TabIndex = 4;
            this.tabForms.Visible = false;
            // 
            // pipelineLiveChartToolStripMenuItem
            // 
            this.pipelineLiveChartToolStripMenuItem.Name = "pipelineLiveChartToolStripMenuItem";
            this.pipelineLiveChartToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pipelineLiveChartToolStripMenuItem.Text = "Pipeline Live Chart";
            this.pipelineLiveChartToolStripMenuItem.Click += new System.EventHandler(this.pipelineLiveChartToolStripMenuItem_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 564);
            this.Controls.Add(this.tabForms);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainMenu";
            this.Text = "InSight CRM";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activityLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pipelineChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerListToolStripMenuItem;
        private System.Windows.Forms.TabControl tabForms;
        private System.Windows.Forms.ToolStripMenuItem pipelineLiveChartToolStripMenuItem;
    }
}