namespace TSalesManagement
{
    partial class frmLinkEstimating
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.cmbEstCust = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.orderdatabaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.order_databaseDataSet = new TSalesManagement.order_databaseDataSet();
            this.solidworksquotationlogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.solidworks_quotation_logTableAdapter = new TSalesManagement.order_databaseDataSetTableAdapters.solidworks_quotation_logTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.orderdatabaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_databaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solidworksquotationlogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(35, 13);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "label1";
            // 
            // cmbEstCust
            // 
            this.cmbEstCust.DataSource = this.solidworksquotationlogBindingSource;
            this.cmbEstCust.DisplayMember = "customer";
            this.cmbEstCust.FormattingEnabled = true;
            this.cmbEstCust.Location = new System.Drawing.Point(120, 57);
            this.cmbEstCust.Name = "cmbEstCust";
            this.cmbEstCust.Size = new System.Drawing.Size(251, 21);
            this.cmbEstCust.TabIndex = 1;
            this.cmbEstCust.ValueMember = "customer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estimating Data For:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(296, 117);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // orderdatabaseDataSetBindingSource
            // 
            this.orderdatabaseDataSetBindingSource.DataSource = this.order_databaseDataSet;
            this.orderdatabaseDataSetBindingSource.Position = 0;
            // 
            // order_databaseDataSet
            // 
            this.order_databaseDataSet.DataSetName = "order_databaseDataSet";
            this.order_databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // solidworksquotationlogBindingSource
            // 
            this.solidworksquotationlogBindingSource.DataMember = "solidworks_quotation_log";
            this.solidworksquotationlogBindingSource.DataSource = this.orderdatabaseDataSetBindingSource;
            // 
            // solidworks_quotation_logTableAdapter
            // 
            this.solidworks_quotation_logTableAdapter.ClearBeforeFill = true;
            // 
            // frmLinkEstimating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 168);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEstCust);
            this.Controls.Add(this.lblHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLinkEstimating";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Link Estimating Data";
            this.Load += new System.EventHandler(this.frmLinkEstimating_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orderdatabaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_databaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solidworksquotationlogBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ComboBox cmbEstCust;
        private System.Windows.Forms.BindingSource orderdatabaseDataSetBindingSource;
        private order_databaseDataSet order_databaseDataSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.BindingSource solidworksquotationlogBindingSource;
        private order_databaseDataSetTableAdapters.solidworks_quotation_logTableAdapter solidworks_quotation_logTableAdapter;
    }
}