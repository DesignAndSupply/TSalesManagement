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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doorstyleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.customeraccrefDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sALESLEDGERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.order_databaseDataSet = new TSalesManagement.order_databaseDataSet();
            this.orderrefDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estimatedordervalueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estimatedorderdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedbyidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cviewsalesprogramusersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet = new TSalesManagement.user_infoDataSet();
            this.dateaddedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description_of_doors_on_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.salespipelineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userTableAdapter = new TSalesManagement.user_infoDataSetTableAdapters.userTableAdapter();
            this.btnSave = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALESLEDGERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_databaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salespipelineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPipeline)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.doorstyleDataGridViewTextBoxColumn,
            this.customeraccrefDataGridViewTextBoxColumn,
            this.orderrefDataGridViewTextBoxColumn,
            this.estimatedordervalueDataGridViewTextBoxColumn,
            this.estimatedorderdateDataGridViewTextBoxColumn,
            this.addedbyidDataGridViewTextBoxColumn,
            this.dateaddedDataGridViewTextBoxColumn,
            this.description_of_doors_on_order,
            this.order_status});
            this.dataGridView1.DataSource = this.salespipelineBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 481);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1327, 228);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 24;
            // 
            // doorstyleDataGridViewTextBoxColumn
            // 
            this.doorstyleDataGridViewTextBoxColumn.DataPropertyName = "door_style";
            this.doorstyleDataGridViewTextBoxColumn.HeaderText = "Door Style:";
            this.doorstyleDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "Traditional",
            "Slimline"});
            this.doorstyleDataGridViewTextBoxColumn.Name = "doorstyleDataGridViewTextBoxColumn";
            this.doorstyleDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.doorstyleDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.doorstyleDataGridViewTextBoxColumn.Width = 78;
            // 
            // customeraccrefDataGridViewTextBoxColumn
            // 
            this.customeraccrefDataGridViewTextBoxColumn.DataPropertyName = "customer_acc_ref";
            this.customeraccrefDataGridViewTextBoxColumn.DataSource = this.sALESLEDGERBindingSource;
            this.customeraccrefDataGridViewTextBoxColumn.DisplayMember = "NAME";
            this.customeraccrefDataGridViewTextBoxColumn.HeaderText = "Customer:";
            this.customeraccrefDataGridViewTextBoxColumn.Name = "customeraccrefDataGridViewTextBoxColumn";
            this.customeraccrefDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.customeraccrefDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.customeraccrefDataGridViewTextBoxColumn.ValueMember = "ACCOUNT_REF";
            this.customeraccrefDataGridViewTextBoxColumn.Width = 79;
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
            // orderrefDataGridViewTextBoxColumn
            // 
            this.orderrefDataGridViewTextBoxColumn.DataPropertyName = "order_ref";
            this.orderrefDataGridViewTextBoxColumn.HeaderText = "Order Ref:";
            this.orderrefDataGridViewTextBoxColumn.Name = "orderrefDataGridViewTextBoxColumn";
            this.orderrefDataGridViewTextBoxColumn.Width = 75;
            // 
            // estimatedordervalueDataGridViewTextBoxColumn
            // 
            this.estimatedordervalueDataGridViewTextBoxColumn.DataPropertyName = "estimated_order_value";
            this.estimatedordervalueDataGridViewTextBoxColumn.HeaderText = "Estimated Order Value:";
            this.estimatedordervalueDataGridViewTextBoxColumn.Name = "estimatedordervalueDataGridViewTextBoxColumn";
            this.estimatedordervalueDataGridViewTextBoxColumn.Width = 101;
            // 
            // estimatedorderdateDataGridViewTextBoxColumn
            // 
            this.estimatedorderdateDataGridViewTextBoxColumn.DataPropertyName = "estimated_order_date";
            this.estimatedorderdateDataGridViewTextBoxColumn.HeaderText = "Estimated Order Date:";
            this.estimatedorderdateDataGridViewTextBoxColumn.Name = "estimatedorderdateDataGridViewTextBoxColumn";
            this.estimatedorderdateDataGridViewTextBoxColumn.Width = 101;
            // 
            // addedbyidDataGridViewTextBoxColumn
            // 
            this.addedbyidDataGridViewTextBoxColumn.DataPropertyName = "added_by_id";
            this.addedbyidDataGridViewTextBoxColumn.DataSource = this.cviewsalesprogramusersBindingSource;
            this.addedbyidDataGridViewTextBoxColumn.DisplayMember = "fullname";
            this.addedbyidDataGridViewTextBoxColumn.HeaderText = "Added By:";
            this.addedbyidDataGridViewTextBoxColumn.Name = "addedbyidDataGridViewTextBoxColumn";
            this.addedbyidDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.addedbyidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.addedbyidDataGridViewTextBoxColumn.ValueMember = "id";
            this.addedbyidDataGridViewTextBoxColumn.Width = 75;
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
            // dateaddedDataGridViewTextBoxColumn
            // 
            this.dateaddedDataGridViewTextBoxColumn.DataPropertyName = "date_added";
            this.dateaddedDataGridViewTextBoxColumn.HeaderText = "Date Added:";
            this.dateaddedDataGridViewTextBoxColumn.Name = "dateaddedDataGridViewTextBoxColumn";
            this.dateaddedDataGridViewTextBoxColumn.Width = 85;
            // 
            // description_of_doors_on_order
            // 
            this.description_of_doors_on_order.DataPropertyName = "description_of_doors_on_order";
            this.description_of_doors_on_order.HeaderText = "Description of doors on the order";
            this.description_of_doors_on_order.Name = "description_of_doors_on_order";
            this.description_of_doors_on_order.Width = 118;
            // 
            // order_status
            // 
            this.order_status.DataPropertyName = "order_status";
            this.order_status.HeaderText = "Order Status";
            this.order_status.Items.AddRange(new object[] {
            "Pending",
            "Ordered",
            "Lost"});
            this.order_status.Name = "order_status";
            this.order_status.Width = 65;
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
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(1224, 715);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save and Update";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.chrtPipeline.Size = new System.Drawing.Size(708, 420);
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
            this.txtPipelineData.Size = new System.Drawing.Size(613, 420);
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
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPipeLine";
            this.Text = "Pipeline Figures";
            this.Load += new System.EventHandler(this.frmPipeLine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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

        private System.Windows.Forms.DataGridView dataGridView1;
        private order_databaseDataSet order_databaseDataSet;
        private System.Windows.Forms.BindingSource salespipelineBindingSource;
        private order_databaseDataSetTableAdapters.sales_pipelineTableAdapter sales_pipelineTableAdapter;
        private System.Windows.Forms.BindingSource sALESLEDGERBindingSource;
        private order_databaseDataSetTableAdapters.SALES_LEDGERTableAdapter sALES_LEDGERTableAdapter;
        private user_infoDataSet user_infoDataSet;
        private System.Windows.Forms.BindingSource userBindingSource;
        private user_infoDataSetTableAdapters.userTableAdapter userTableAdapter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtPipeline;
        private System.Windows.Forms.BindingSource cviewsalesprogramusersBindingSource;
        private user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter c_view_sales_program_usersTableAdapter;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RichTextBox txtPipelineData;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn doorstyleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn customeraccrefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderrefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estimatedordervalueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estimatedorderdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn addedbyidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateaddedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn description_of_doors_on_order;
        private System.Windows.Forms.DataGridViewComboBoxColumn order_status;
    }
}