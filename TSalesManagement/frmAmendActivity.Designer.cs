namespace TSalesManagement
{
    partial class frmAmendActivity
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDetails = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRecipient = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnPipeline = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddNote = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Reference:";
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(10, 121);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(361, 20);
            this.txtReference.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(721, 638);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save Activity";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(10, 169);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(809, 195);
            this.txtDetails.TabIndex = 18;
            this.txtDetails.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Details:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Correspondance With:";
            // 
            // cmbRecipient
            // 
            this.cmbRecipient.FormattingEnabled = true;
            this.cmbRecipient.Location = new System.Drawing.Point(10, 29);
            this.cmbRecipient.Name = "cmbRecipient";
            this.cmbRecipient.Size = new System.Drawing.Size(215, 21);
            this.cmbRecipient.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Correspondance Type:";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Email",
            "Verbal",
            "Meeting",
            "Other"});
            this.cmbType.Location = new System.Drawing.Point(10, 75);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(361, 21);
            this.cmbType.TabIndex = 15;
            // 
            // btnPipeline
            // 
            this.btnPipeline.Location = new System.Drawing.Point(617, 638);
            this.btnPipeline.Name = "btnPipeline";
            this.btnPipeline.Size = new System.Drawing.Size(98, 23);
            this.btnPipeline.TabIndex = 23;
            this.btnPipeline.Text = "Add to Pipline";
            this.btnPipeline.UseVisualStyleBackColor = true;
            this.btnPipeline.Click += new System.EventHandler(this.btnPipeline_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 399);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(809, 233);
            this.dataGridView1.TabIndex = 24;
            // 
            // btnAddNote
            // 
            this.btnAddNote.Location = new System.Drawing.Point(721, 370);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(98, 23);
            this.btnAddNote.TabIndex = 25;
            this.btnAddNote.Text = "Add Note";
            this.btnAddNote.UseVisualStyleBackColor = true;
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            // 
            // frmAmendActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 668);
            this.Controls.Add(this.btnAddNote);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPipeline);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbRecipient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAmendActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Activity";
            this.Load += new System.EventHandler(this.frmAmendActivity_Load);
            this.Shown += new System.EventHandler(this.frmAmendActivity_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox txtDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRecipient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnPipeline;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddNote;
    }
}