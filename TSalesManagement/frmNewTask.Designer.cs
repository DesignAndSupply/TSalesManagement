namespace TSalesManagement
{
    partial class frmNewTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewTask));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chkDueDateRequired = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbSetForID = new System.Windows.Forms.ComboBox();
            this.dteDueDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.user_infoDataSet1 = new TSalesManagement.user_infoDataSet1();
            this.viewcurrentuserswithemailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_current_users_with_emailTableAdapter = new TSalesManagement.user_infoDataSet1TableAdapters.view_current_users_with_emailTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewcurrentuserswithemailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // chkDueDateRequired
            // 
            this.chkDueDateRequired.AutoSize = true;
            this.chkDueDateRequired.Location = new System.Drawing.Point(88, 106);
            this.chkDueDateRequired.Name = "chkDueDateRequired";
            this.chkDueDateRequired.Size = new System.Drawing.Size(117, 17);
            this.chkDueDateRequired.TabIndex = 31;
            this.chkDueDateRequired.Text = "Requires Due Date";
            this.chkDueDateRequired.UseVisualStyleBackColor = true;
            this.chkDueDateRequired.CheckedChanged += new System.EventHandler(this.chkDueDateRequired_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Task Subject.";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(18, 199);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(621, 20);
            this.txtSubject.TabIndex = 26;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(567, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbSetForID
            // 
            this.cmbSetForID.DataSource = this.viewcurrentuserswithemailBindingSource;
            this.cmbSetForID.DisplayMember = "FullName";
            this.cmbSetForID.FormattingEnabled = true;
            this.cmbSetForID.Location = new System.Drawing.Point(88, 79);
            this.cmbSetForID.Name = "cmbSetForID";
            this.cmbSetForID.Size = new System.Drawing.Size(200, 21);
            this.cmbSetForID.TabIndex = 24;
            this.cmbSetForID.ValueMember = "id";
            // 
            // dteDueDate
            // 
            this.dteDueDate.Location = new System.Drawing.Point(88, 129);
            this.dteDueDate.Name = "dteDueDate";
            this.dteDueDate.Size = new System.Drawing.Size(200, 20);
            this.dteDueDate.TabIndex = 23;
            // 
            // cmbPriority
            // 
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.cmbPriority.Location = new System.Drawing.Point(88, 153);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(200, 21);
            this.cmbPriority.TabIndex = 22;
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(21, 246);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(621, 188);
            this.txtDetail.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Task Detail:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Priority:";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(15, 129);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(56, 13);
            this.lblDueDate.TabIndex = 18;
            this.lblDueDate.Text = "Due Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Task For:";
            // 
            // user_infoDataSet1
            // 
            this.user_infoDataSet1.DataSetName = "user_infoDataSet1";
            this.user_infoDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewcurrentuserswithemailBindingSource
            // 
            this.viewcurrentuserswithemailBindingSource.DataMember = "view_current_users_with_email";
            this.viewcurrentuserswithemailBindingSource.DataSource = this.user_infoDataSet1;
            // 
            // view_current_users_with_emailTableAdapter
            // 
            this.view_current_users_with_emailTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 26);
            this.label2.TabIndex = 33;
            this.label2.Text = "Adding Note to DS ToDo Application";
            // 
            // frmNewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 513);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkDueDateRequired);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbSetForID);
            this.Controls.Add(this.dteDueDate);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewTask";
            this.Text = "New Task";
            this.Load += new System.EventHandler(this.frmNewTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewcurrentuserswithemailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox chkDueDateRequired;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbSetForID;
        private System.Windows.Forms.DateTimePicker dteDueDate;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label label1;
        private user_infoDataSet1 user_infoDataSet1;
        private System.Windows.Forms.BindingSource viewcurrentuserswithemailBindingSource;
        private user_infoDataSet1TableAdapters.view_current_users_with_emailTableAdapter view_current_users_with_emailTableAdapter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}