namespace TSalesManagement
{
    partial class frmUserInfoRyucxd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedGroupBox = new System.Windows.Forms.GroupBox();
            this.selectedListBox = new System.Windows.Forms.ListBox();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.cviewsalesprogramusersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet = new TSalesManagement.user_infoDataSet();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnEmail = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboPipeLine = new System.Windows.Forms.ComboBox();
            this.buttonPipeline = new System.Windows.Forms.Button();
            this.lblPipeline = new System.Windows.Forms.Label();
            this.c_view_sales_program_usersTableAdapter = new TSalesManagement.user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter();
            this.ryucxd = new System.Windows.Forms.Button();
            this.selectedGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select User:";
            // 
            // selectedGroupBox
            // 
            this.selectedGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectedGroupBox.Controls.Add(this.selectedListBox);
            this.selectedGroupBox.Location = new System.Drawing.Point(12, 52);
            this.selectedGroupBox.Name = "selectedGroupBox";
            this.selectedGroupBox.Size = new System.Drawing.Size(229, 509);
            this.selectedGroupBox.TabIndex = 4;
            this.selectedGroupBox.TabStop = false;
            this.selectedGroupBox.Text = "Currently selected:";
            // 
            // selectedListBox
            // 
            this.selectedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedListBox.FormattingEnabled = true;
            this.selectedListBox.Location = new System.Drawing.Point(6, 19);
            this.selectedListBox.Name = "selectedListBox";
            this.selectedListBox.Size = new System.Drawing.Size(217, 485);
            this.selectedListBox.TabIndex = 0;
            // 
            // cmbStaff
            // 
            this.cmbStaff.DataSource = this.cviewsalesprogramusersBindingSource;
            this.cmbStaff.DisplayMember = "fullname";
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(12, 25);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(229, 21);
            this.cmbStaff.TabIndex = 3;
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
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.Location = new System.Drawing.Point(249, 25);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(229, 20);
            this.txtCustomerSearch.TabIndex = 20;
            this.txtCustomerSearch.Visible = false;
            this.txtCustomerSearch.TextChanged += new System.EventHandler(this.txtCustomerSearch_TextChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(300, 10);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(122, 13);
            this.lblCustomer.TabIndex = 19;
            this.lblCustomer.Text = "Search Customer Name:";
            this.lblCustomer.Visible = false;
            // 
            // btnEmail
            // 
            this.btnEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmail.Location = new System.Drawing.Point(1036, 25);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(122, 23);
            this.btnEmail.TabIndex = 21;
            this.btnEmail.Text = "Email Selected Items:";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.BtnEmail_Click_1);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(766, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(266, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Blue = Completed within the last 7 working days";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.OrangeRed;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(766, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Red = Currently assigned";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.HotPink;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(766, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Pink = Selected";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(249, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(911, 35);
            this.tabControl1.TabIndex = 27;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(903, 9);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Customer List";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(903, 9);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User Activity";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(903, 9);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "User Tasks";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(903, 9);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Pipeline Data";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(249, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(909, 483);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentDoubleClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_ColumnHeaderMouseClick);
            // 
            // comboPipeLine
            // 
            this.comboPipeLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPipeLine.FormattingEnabled = true;
            this.comboPipeLine.Items.AddRange(new object[] {
            "Pending",
            "Ordered",
            "Lost"});
            this.comboPipeLine.Location = new System.Drawing.Point(547, 38);
            this.comboPipeLine.Name = "comboPipeLine";
            this.comboPipeLine.Size = new System.Drawing.Size(121, 21);
            this.comboPipeLine.TabIndex = 29;
            this.comboPipeLine.Visible = false;
            this.comboPipeLine.SelectedIndexChanged += new System.EventHandler(this.comboPipeLine_SelectedIndexChanged);
            // 
            // buttonPipeline
            // 
            this.buttonPipeline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPipeline.Location = new System.Drawing.Point(674, 38);
            this.buttonPipeline.Name = "buttonPipeline";
            this.buttonPipeline.Size = new System.Drawing.Size(85, 23);
            this.buttonPipeline.TabIndex = 31;
            this.buttonPipeline.Text = "Clear Search";
            this.buttonPipeline.UseVisualStyleBackColor = true;
            this.buttonPipeline.Visible = false;
            this.buttonPipeline.Click += new System.EventHandler(this.buttonPipeline_Click);
            // 
            // lblPipeline
            // 
            this.lblPipeline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPipeline.AutoSize = true;
            this.lblPipeline.Location = new System.Drawing.Point(575, 16);
            this.lblPipeline.Name = "lblPipeline";
            this.lblPipeline.Size = new System.Drawing.Size(69, 13);
            this.lblPipeline.TabIndex = 30;
            this.lblPipeline.Text = "Order Status:";
            this.lblPipeline.Visible = false;
            // 
            // c_view_sales_program_usersTableAdapter
            // 
            this.c_view_sales_program_usersTableAdapter.ClearBeforeFill = true;
            // 
            // ryucxd
            // 
            this.ryucxd.Location = new System.Drawing.Point(484, 3);
            this.ryucxd.Name = "ryucxd";
            this.ryucxd.Size = new System.Drawing.Size(75, 23);
            this.ryucxd.TabIndex = 32;
            this.ryucxd.Text = "ryucxd";
            this.ryucxd.UseVisualStyleBackColor = true;
            this.ryucxd.Visible = false;
            this.ryucxd.Click += new System.EventHandler(this.ryucxd_Click);
            // 
            // frmUserInfoRyucxd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 561);
            this.Controls.Add(this.ryucxd);
            this.Controls.Add(this.comboPipeLine);
            this.Controls.Add(this.buttonPipeline);
            this.Controls.Add(this.lblPipeline);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomerSearch);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectedGroupBox);
            this.Controls.Add(this.cmbStaff);
            this.Name = "frmUserInfoRyucxd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUserInfoRyucxd";
            this.Load += new System.EventHandler(this.FrmUserInfoRyucxd_Load);
            this.selectedGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox selectedGroupBox;
        private System.Windows.Forms.ListBox selectedListBox;
        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboPipeLine;
        private System.Windows.Forms.Button buttonPipeline;
        private System.Windows.Forms.Label lblPipeline;
        private user_infoDataSet user_infoDataSet;
        private System.Windows.Forms.BindingSource cviewsalesprogramusersBindingSource;
        private user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter c_view_sales_program_usersTableAdapter;
        private System.Windows.Forms.Button ryucxd;
    }
}