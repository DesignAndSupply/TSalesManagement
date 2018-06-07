namespace TSalesManagement
{
    partial class frmPipeLine
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPipeLine));
            this.sALESLEDGERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.order_databaseDataSet = new TSalesManagement.order_databaseDataSet();
            this.cviewsalesprogramusersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet = new TSalesManagement.user_infoDataSet();
            this.salespipelineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userTableAdapter = new TSalesManagement.user_infoDataSetTableAdapters.userTableAdapter();
            this.chrtPipeline = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.c_view_sales_program_usersTableAdapter = new TSalesManagement.user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter();
            this.sales_pipelineTableAdapter = new TSalesManagement.order_databaseDataSetTableAdapters.sales_pipelineTableAdapter();
            this.sALES_LEDGERTableAdapter = new TSalesManagement.order_databaseDataSetTableAdapters.SALES_LEDGERTableAdapter();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtPipelineData = new System.Windows.Forms.RichTextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sALESLEDGERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_databaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salespipelineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPipeline)).BeginInit();
            this.SuspendLayout();
            // 
            // sALESLEDGERBindingSource
            // 
            this.sALESLEDGERBindingSource.DataMember = "SALES_LEDGER";
            this.sALESLEDGERBindingSource.DataSource = this.order_databaseDataSet;
            // 
            // order_databaseDataSet
            // 
            this.order_databaseDataSet.DataSetName = "order_databaseDataSet";
            this.order_databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cviewsalesprogramusersBindingSource
            // 
            this.cviewsalesprogramusersBindingSource.DataMember = "c_view_sales_program_users";
            this.cviewsalesprogramusersBindingSource.DataSource = this.user_infoDataSet;
            this.cviewsalesprogramusersBindingSource.CurrentChanged += new System.EventHandler(this.cviewsalesprogramusersBindingSource_CurrentChanged);
            // 
            // user_infoDataSet
            // 
            this.user_infoDataSet.DataSetName = "user_infoDataSet";
            this.user_infoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // salespipelineBindingSource
            // 
            this.salespipelineBindingSource.DataMember = "sales_pipeline";
            this.salespipelineBindingSource.DataSource = this.order_databaseDataSet;
            this.salespipelineBindingSource.CurrentChanged += new System.EventHandler(this.salespipelineBindingSource_CurrentChanged);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataMember = "user";
            this.userBindingSource.DataSource = this.user_infoDataSet;
            // 
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // chrtPipeline
            // 
            this.chrtPipeline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chrtPipeline.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtPipeline.Legends.Add(legend1);
            this.chrtPipeline.Location = new System.Drawing.Point(12, 55);
            this.chrtPipeline.Name = "chrtPipeline";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrtPipeline.Series.Add(series1);
            this.chrtPipeline.Size = new System.Drawing.Size(755, 606);
            this.chrtPipeline.TabIndex = 2;
            this.chrtPipeline.Text = "chart1";
            this.chrtPipeline.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chrtPipeline_GetToolTipText);
            this.chrtPipeline.Click += new System.EventHandler(this.chrtPipeline_Click);
            // 
            // c_view_sales_program_usersTableAdapter
            // 
            this.c_view_sales_program_usersTableAdapter.ClearBeforeFill = true;
            // 
            // sales_pipelineTableAdapter
            // 
            this.sales_pipelineTableAdapter.ClearBeforeFill = true;
            // 
            // sALES_LEDGERTableAdapter
            // 
            this.sALES_LEDGERTableAdapter.ClearBeforeFill = true;
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Items.AddRange(new object[] {
            "Pending",
            "Ordered",
            "Lost"});
            this.cmbFilterStatus.Location = new System.Drawing.Point(12, 28);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterStatus.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(140, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(54, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Update";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtPipelineData
            // 
            this.txtPipelineData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPipelineData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPipelineData.Location = new System.Drawing.Point(726, 55);
            this.txtPipelineData.Name = "txtPipelineData";
            this.txtPipelineData.Size = new System.Drawing.Size(613, 606);
            this.txtPipelineData.TabIndex = 6;
            this.txtPipelineData.Text = "";
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(930, 30);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(116, 22);
            this.txtDate.TabIndex = 22;
            // 
            // txtDept
            // 
            this.txtDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDept.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDept.Location = new System.Drawing.Point(726, 30);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(198, 22);
            this.txtDept.TabIndex = 23;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(1052, 30);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(129, 22);
            this.txtValue.TabIndex = 24;
            // 
            // frmPipeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1351, 749);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtPipelineData);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbFilterStatus);
            this.Controls.Add(this.chrtPipeline);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPipeLine";
            this.Text = "Pipeline Figures";
            this.Load += new System.EventHandler(this.frmPipeLine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sALESLEDGERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_databaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salespipelineBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPipeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private order_databaseDataSet order_databaseDataSet;
        private System.Windows.Forms.BindingSource salespipelineBindingSource;
        private order_databaseDataSetTableAdapters.sales_pipelineTableAdapter sales_pipelineTableAdapter;
        private System.Windows.Forms.BindingSource sALESLEDGERBindingSource;
        private order_databaseDataSetTableAdapters.SALES_LEDGERTableAdapter sALES_LEDGERTableAdapter;
        private user_infoDataSet user_infoDataSet;
        private System.Windows.Forms.BindingSource userBindingSource;
        private user_infoDataSetTableAdapters.userTableAdapter userTableAdapter;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtPipeline;
        private System.Windows.Forms.BindingSource cviewsalesprogramusersBindingSource;
        private user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter c_view_sales_program_usersTableAdapter;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RichTextBox txtPipelineData;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.TextBox txtValue;
    }
}