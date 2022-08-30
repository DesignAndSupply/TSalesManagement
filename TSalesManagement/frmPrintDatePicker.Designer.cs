namespace TSalesManagement
{
    partial class frmPrintDatePicker
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
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(22, 15);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(148, 20);
            this.dteStart.TabIndex = 0;
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(22, 51);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(148, 20);
            this.dteEnd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "to";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(52, 76);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmPrintDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 112);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Name = "frmPrintDatePicker";
            this.Text = "frmPrintDatePicker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
    }
}