namespace TSalesManagement
{
    partial class frmUserInfo
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
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.cviewsalesprogramusersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet = new TSalesManagement.user_infoDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstLoginHistory = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.c_view_sales_program_usersTableAdapter = new TSalesManagement.user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter();
            this.dgActivity = new System.Windows.Forms.DataGridView();
            this.dgPipeline = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSearchStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgActivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPipeline)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbStaff
            // 
            this.cmbStaff.DataSource = this.cviewsalesprogramusersBindingSource;
            this.cmbStaff.DisplayMember = "fullname";
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(12, 30);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(229, 21);
            this.cmbStaff.TabIndex = 0;
            this.cmbStaff.ValueMember = "id";
            this.cmbStaff.SelectedIndexChanged += new System.EventHandler(this.cmbStaff_SelectedIndexChanged);
            // 
            // cviewsalesprogramusersBindingSource
            // 
            this.cviewsalesprogramusersBindingSource.DataMember = "c_view_sales_program_users";
            this.cviewsalesprogramusersBindingSource.DataSource = this.user_infoDataSet;
            // 
            // user_infoDataSet
            // 
            this.user_infoDataSet.DataSetName = "user_infoDataSet";
            this.user_infoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lstLoginHistory);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 563);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Information:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Login History";
            // 
            // lstLoginHistory
            // 
            this.lstLoginHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstLoginHistory.FormattingEnabled = true;
            this.lstLoginHistory.Location = new System.Drawing.Point(4, 345);
            this.lstLoginHistory.Name = "lstLoginHistory";
            this.lstLoginHistory.Size = new System.Drawing.Size(219, 212);
            this.lstLoginHistory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select User:";
            // 
            // c_view_sales_program_usersTableAdapter
            // 
            this.c_view_sales_program_usersTableAdapter.ClearBeforeFill = true;
            // 
            // dgActivity
            // 
            this.dgActivity.AllowUserToAddRows = false;
            this.dgActivity.AllowUserToDeleteRows = false;
            this.dgActivity.AllowUserToOrderColumns = true;
            this.dgActivity.AllowUserToResizeColumns = false;
            this.dgActivity.AllowUserToResizeRows = false;
            this.dgActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgActivity.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActivity.Location = new System.Drawing.Point(248, 30);
            this.dgActivity.MultiSelect = false;
            this.dgActivity.Name = "dgActivity";
            this.dgActivity.RowHeadersVisible = false;
            this.dgActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgActivity.Size = new System.Drawing.Size(968, 322);
            this.dgActivity.TabIndex = 3;
            this.dgActivity.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActivity_CellDoubleClick);
            // 
            // dgPipeline
            // 
            this.dgPipeline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPipeline.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPipeline.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgPipeline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPipeline.Location = new System.Drawing.Point(248, 393);
            this.dgPipeline.Name = "dgPipeline";
            this.dgPipeline.RowHeadersVisible = false;
            this.dgPipeline.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPipeline.Size = new System.Drawing.Size(968, 221);
            this.dgPipeline.TabIndex = 4;
            this.dgPipeline.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPipeline_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pipeline Data:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "User Activity";
            // 
            // cmbSearchStatus
            // 
            this.cmbSearchStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSearchStatus.FormattingEnabled = true;
            this.cmbSearchStatus.Items.AddRange(new object[] {
            "Pending",
            "Ordered",
            "Lost"});
            this.cmbSearchStatus.Location = new System.Drawing.Point(1009, 366);
            this.cmbSearchStatus.Name = "cmbSearchStatus";
            this.cmbSearchStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbSearchStatus.TabIndex = 7;
            this.cmbSearchStatus.SelectedIndexChanged += new System.EventHandler(this.cmbSearchStatus_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(934, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Order Status:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(621, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Customer:";
            this.label6.Visible = false;
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerSearch.Location = new System.Drawing.Point(681, 366);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(205, 20);
            this.txtCustomerSearch.TabIndex = 11;
            this.txtCustomerSearch.Visible = false;
            this.txtCustomerSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerSearch_KeyPress);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSearch.Location = new System.Drawing.Point(1131, 365);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(85, 23);
            this.btnClearSearch.TabIndex = 12;
            this.btnClearSearch.Text = "Clear Search";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // frmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 632);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.txtCustomerSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSearchStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgPipeline);
            this.Controls.Add(this.dgActivity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbStaff);
            this.Name = "frmUserInfo";
            this.Text = "User Information";
            this.Load += new System.EventHandler(this.frmUserInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgActivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPipeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private user_infoDataSet user_infoDataSet;
        private System.Windows.Forms.BindingSource cviewsalesprogramusersBindingSource;
        private user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter c_view_sales_program_usersTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstLoginHistory;
        private System.Windows.Forms.DataGridView dgActivity;
        private System.Windows.Forms.DataGridView dgPipeline;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSearchStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.Button btnClearSearch;
    }
}