namespace DSToDo
{
    partial class NewTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTask));
            this.label1 = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.dteDueDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSetForID = new System.Windows.Forms.ComboBox();
            this.viewcurrentuserswithemailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet11 = new DSToDo.user_infoDataSet1();
            this.userBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet1 = new DSToDo.user_infoDataSet();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet = new DSToDo.user_infoDataSet();
            this.btnSave = new System.Windows.Forms.Button();
            this.userTableAdapter = new DSToDo.user_infoDataSetTableAdapters.userTableAdapter();
            this.userinfoDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_current_users_with_emailTableAdapter = new DSToDo.user_infoDataSet1TableAdapters.view_current_users_with_emailTableAdapter();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkLogOnBehalf = new System.Windows.Forms.CheckBox();
            this.lblBehalfOf = new System.Windows.Forms.Label();
            this.cmbLogOnBehalf = new System.Windows.Forms.ComboBox();
            this.viewcurrentuserswithemailBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet2 = new DSToDo.user_infoDataSet2();
            this.view_current_users_with_emailTableAdapter1 = new DSToDo.user_infoDataSet2TableAdapters.view_current_users_with_emailTableAdapter();
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillByToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.chkDueDateRequired = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.viewcurrentuserswithemailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userinfoDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewcurrentuserswithemailBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet2)).BeginInit();
            this.fillByToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task For:";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(12, 114);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(56, 13);
            this.lblDueDate.TabIndex = 1;
            this.lblDueDate.Text = "Due Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Priority:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Task Detail:";
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(15, 223);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(621, 188);
            this.txtDetail.TabIndex = 4;
            // 
            // cmbPriority
            // 
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.cmbPriority.Location = new System.Drawing.Point(85, 138);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(200, 21);
            this.cmbPriority.TabIndex = 5;
            // 
            // dteDueDate
            // 
            this.dteDueDate.Location = new System.Drawing.Point(85, 114);
            this.dteDueDate.Name = "dteDueDate";
            this.dteDueDate.Size = new System.Drawing.Size(200, 20);
            this.dteDueDate.TabIndex = 6;
            // 
            // cmbSetForID
            // 
            this.cmbSetForID.DataSource = this.viewcurrentuserswithemailBindingSource;
            this.cmbSetForID.DisplayMember = "FullName";
            this.cmbSetForID.FormattingEnabled = true;
            this.cmbSetForID.Location = new System.Drawing.Point(85, 9);
            this.cmbSetForID.Name = "cmbSetForID";
            this.cmbSetForID.Size = new System.Drawing.Size(200, 21);
            this.cmbSetForID.TabIndex = 7;
            this.cmbSetForID.ValueMember = "id";
            // 
            // viewcurrentuserswithemailBindingSource
            // 
            this.viewcurrentuserswithemailBindingSource.DataMember = "view_current_users_with_email";
            this.viewcurrentuserswithemailBindingSource.DataSource = this.user_infoDataSet11;
            // 
            // user_infoDataSet11
            // 
            this.user_infoDataSet11.DataSetName = "user_infoDataSet1";
            this.user_infoDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userBindingSource1
            // 
            this.userBindingSource1.DataMember = "user";
            this.userBindingSource1.DataSource = this.user_infoDataSet1;
            // 
            // user_infoDataSet1
            // 
            this.user_infoDataSet1.DataSetName = "user_infoDataSet";
            this.user_infoDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataMember = "user";
            this.userBindingSource.DataSource = this.user_infoDataSet;
            // 
            // user_infoDataSet
            // 
            this.user_infoDataSet.DataSetName = "user_infoDataSet";
            this.user_infoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(561, 417);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // userinfoDataSet1BindingSource
            // 
            this.userinfoDataSet1BindingSource.DataSource = this.user_infoDataSet1;
            this.userinfoDataSet1BindingSource.Position = 0;
            // 
            // view_current_users_with_emailTableAdapter
            // 
            this.view_current_users_with_emailTableAdapter.ClearBeforeFill = true;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(15, 184);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(621, 20);
            this.txtSubject.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Task Subject.";
            // 
            // chkLogOnBehalf
            // 
            this.chkLogOnBehalf.AutoSize = true;
            this.chkLogOnBehalf.Location = new System.Drawing.Point(85, 39);
            this.chkLogOnBehalf.Name = "chkLogOnBehalf";
            this.chkLogOnBehalf.Size = new System.Drawing.Size(97, 17);
            this.chkLogOnBehalf.TabIndex = 11;
            this.chkLogOnBehalf.Text = "Log On Behalf:";
            this.chkLogOnBehalf.UseVisualStyleBackColor = true;
            this.chkLogOnBehalf.CheckedChanged += new System.EventHandler(this.chkLogOnBehalf_CheckedChanged);
            // 
            // lblBehalfOf
            // 
            this.lblBehalfOf.AutoSize = true;
            this.lblBehalfOf.Location = new System.Drawing.Point(12, 62);
            this.lblBehalfOf.Name = "lblBehalfOf";
            this.lblBehalfOf.Size = new System.Drawing.Size(71, 13);
            this.lblBehalfOf.TabIndex = 13;
            this.lblBehalfOf.Text = "On Behalf Of:";
            // 
            // cmbLogOnBehalf
            // 
            this.cmbLogOnBehalf.DataSource = this.viewcurrentuserswithemailBindingSource1;
            this.cmbLogOnBehalf.DisplayMember = "FullName";
            this.cmbLogOnBehalf.FormattingEnabled = true;
            this.cmbLogOnBehalf.Location = new System.Drawing.Point(85, 62);
            this.cmbLogOnBehalf.Name = "cmbLogOnBehalf";
            this.cmbLogOnBehalf.Size = new System.Drawing.Size(200, 21);
            this.cmbLogOnBehalf.TabIndex = 14;
            this.cmbLogOnBehalf.ValueMember = "id";
            this.cmbLogOnBehalf.SelectedIndexChanged += new System.EventHandler(this.cmbLogOnBehalf_SelectedIndexChanged);
            // 
            // viewcurrentuserswithemailBindingSource1
            // 
            this.viewcurrentuserswithemailBindingSource1.DataMember = "view_current_users_with_email";
            this.viewcurrentuserswithemailBindingSource1.DataSource = this.user_infoDataSet2;
            // 
            // user_infoDataSet2
            // 
            this.user_infoDataSet2.DataSetName = "user_infoDataSet2";
            this.user_infoDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // view_current_users_with_emailTableAdapter1
            // 
            this.view_current_users_with_emailTableAdapter1.ClearBeforeFill = true;
            // 
            // fillByToolStrip
            // 
            this.fillByToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillByToolStripButton});
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(658, 25);
            this.fillByToolStrip.TabIndex = 15;
            this.fillByToolStrip.Text = "fillByToolStrip";
            this.fillByToolStrip.Visible = false;
            // 
            // fillByToolStripButton
            // 
            this.fillByToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByToolStripButton.Name = "fillByToolStripButton";
            this.fillByToolStripButton.Size = new System.Drawing.Size(39, 22);
            this.fillByToolStripButton.Text = "FillBy";
            this.fillByToolStripButton.Click += new System.EventHandler(this.fillByToolStripButton_Click_1);
            // 
            // chkDueDateRequired
            // 
            this.chkDueDateRequired.AutoSize = true;
            this.chkDueDateRequired.Location = new System.Drawing.Point(85, 91);
            this.chkDueDateRequired.Name = "chkDueDateRequired";
            this.chkDueDateRequired.Size = new System.Drawing.Size(117, 17);
            this.chkDueDateRequired.TabIndex = 16;
            this.chkDueDateRequired.Text = "Requires Due Date";
            this.chkDueDateRequired.UseVisualStyleBackColor = true;
            this.chkDueDateRequired.CheckedChanged += new System.EventHandler(this.chkDueDateRequired_CheckedChanged);
            // 
            // NewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 448);
            this.Controls.Add(this.chkDueDateRequired);
            this.Controls.Add(this.fillByToolStrip);
            this.Controls.Add(this.cmbLogOnBehalf);
            this.Controls.Add(this.lblBehalfOf);
            this.Controls.Add(this.chkLogOnBehalf);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Task";
            this.Load += new System.EventHandler(this.NewTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewcurrentuserswithemailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userinfoDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewcurrentuserswithemailBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet2)).EndInit();
            this.fillByToolStrip.ResumeLayout(false);
            this.fillByToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.DateTimePicker dteDueDate;
        private System.Windows.Forms.ComboBox cmbSetForID;
        private System.Windows.Forms.Button btnSave;
        private user_infoDataSet user_infoDataSet;
        private System.Windows.Forms.BindingSource userBindingSource;
        private user_infoDataSetTableAdapters.userTableAdapter userTableAdapter;
        private user_infoDataSet user_infoDataSet1;
        private System.Windows.Forms.BindingSource userBindingSource1;
        private System.Windows.Forms.BindingSource userinfoDataSet1BindingSource;
        private user_infoDataSet1 user_infoDataSet11;
        private System.Windows.Forms.BindingSource viewcurrentuserswithemailBindingSource;
        private user_infoDataSet1TableAdapters.view_current_users_with_emailTableAdapter view_current_users_with_emailTableAdapter;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkLogOnBehalf;
        private System.Windows.Forms.Label lblBehalfOf;
        private System.Windows.Forms.ComboBox cmbLogOnBehalf;
        private user_infoDataSet2 user_infoDataSet2;
        private System.Windows.Forms.BindingSource viewcurrentuserswithemailBindingSource1;
        private user_infoDataSet2TableAdapters.view_current_users_with_emailTableAdapter view_current_users_with_emailTableAdapter1;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.ToolStripButton fillByToolStripButton;
        private System.Windows.Forms.CheckBox chkDueDateRequired;
    }
}