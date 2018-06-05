namespace TSalesManagement
{
    partial class form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            this.dgInvoice = new System.Windows.Forms.DataGridView();
            this.grpInvoice = new System.Windows.Forms.GroupBox();
            this.btnViewInvoice = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnForecastDetails = new System.Windows.Forms.Button();
            this.btnExplainForecast = new System.Windows.Forms.Button();
            this.dgForeCast = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chrtSlimline = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnPrintScreen = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTraditionalSales = new System.Windows.Forms.TextBox();
            this.txtDailyTargetHit = new System.Windows.Forms.TextBox();
            this.txtDailyTargetHitFromNow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtWorkingDays = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemainingWorkingDays = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSlimlineSales = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDailyTargetHitSlimline = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDailyTargetHitFromNowSlimline = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPipeLine = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBigGoal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoice)).BeginInit();
            this.grpInvoice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgForeCast)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtSlimline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(12, 53);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(251, 21);
            this.cmbMonth.TabIndex = 0;
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cmbYear.Location = new System.Drawing.Point(269, 53);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(68, 21);
            this.cmbYear.TabIndex = 1;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(343, 53);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dgInvoice
            // 
            this.dgInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoice.Location = new System.Drawing.Point(7, 42);
            this.dgInvoice.Name = "dgInvoice";
            this.dgInvoice.RowHeadersVisible = false;
            this.dgInvoice.Size = new System.Drawing.Size(399, 129);
            this.dgInvoice.TabIndex = 0;
            this.dgInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // grpInvoice
            // 
            this.grpInvoice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.grpInvoice.Controls.Add(this.btnViewInvoice);
            this.grpInvoice.Controls.Add(this.button1);
            this.grpInvoice.Controls.Add(this.dgInvoice);
            this.grpInvoice.Location = new System.Drawing.Point(932, 299);
            this.grpInvoice.Name = "grpInvoice";
            this.grpInvoice.Size = new System.Drawing.Size(412, 185);
            this.grpInvoice.TabIndex = 3;
            this.grpInvoice.TabStop = false;
            this.grpInvoice.Text = "Invoice Totals";
            // 
            // btnViewInvoice
            // 
            this.btnViewInvoice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnViewInvoice.Location = new System.Drawing.Point(252, -23);
            this.btnViewInvoice.Name = "btnViewInvoice";
            this.btnViewInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnViewInvoice.TabIndex = 7;
            this.btnViewInvoice.Text = "Populate";
            this.btnViewInvoice.UseVisualStyleBackColor = true;
            this.btnViewInvoice.Click += new System.EventHandler(this.btnViewInvoice_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Location = new System.Drawing.Point(333, -23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "Explain";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnForecastDetails);
            this.groupBox1.Controls.Add(this.btnExplainForecast);
            this.groupBox1.Controls.Add(this.dgForeCast);
            this.groupBox1.Location = new System.Drawing.Point(356, 531);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 255);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forecast Figures (Doors with completion this month)";
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnForecastDetails
            // 
            this.btnForecastDetails.Location = new System.Drawing.Point(261, 12);
            this.btnForecastDetails.Name = "btnForecastDetails";
            this.btnForecastDetails.Size = new System.Drawing.Size(73, 24);
            this.btnForecastDetails.TabIndex = 6;
            this.btnForecastDetails.Text = "List Doors";
            this.btnForecastDetails.UseVisualStyleBackColor = true;
            this.btnForecastDetails.Click += new System.EventHandler(this.btnForecastDetails_Click);
            // 
            // btnExplainForecast
            // 
            this.btnExplainForecast.Location = new System.Drawing.Point(333, 12);
            this.btnExplainForecast.Name = "btnExplainForecast";
            this.btnExplainForecast.Size = new System.Drawing.Size(73, 24);
            this.btnExplainForecast.TabIndex = 5;
            this.btnExplainForecast.Text = "Explain";
            this.btnExplainForecast.UseVisualStyleBackColor = true;
            this.btnExplainForecast.Click += new System.EventHandler(this.btnExplainForecast_Click);
            // 
            // dgForeCast
            // 
            this.dgForeCast.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgForeCast.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgForeCast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgForeCast.Location = new System.Drawing.Point(7, 42);
            this.dgForeCast.Name = "dgForeCast";
            this.dgForeCast.RowHeadersVisible = false;
            this.dgForeCast.Size = new System.Drawing.Size(399, 202);
            this.dgForeCast.TabIndex = 0;
            this.dgForeCast.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgForeCast_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(932, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 219);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Meeting Notes";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(400, 189);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(-36, 86);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(950, 352);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // chrtSlimline
            // 
            this.chrtSlimline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.chrtSlimline.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chrtSlimline.Legends.Add(legend4);
            this.chrtSlimline.Location = new System.Drawing.Point(-36, 462);
            this.chrtSlimline.Name = "chrtSlimline";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chrtSlimline.Series.Add(series4);
            this.chrtSlimline.Size = new System.Drawing.Size(950, 375);
            this.chrtSlimline.TabIndex = 7;
            this.chrtSlimline.Text = "chart2";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(425, 53);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // btnPrintScreen
            // 
            this.btnPrintScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintScreen.Location = new System.Drawing.Point(1259, 29);
            this.btnPrintScreen.Name = "btnPrintScreen";
            this.btnPrintScreen.Size = new System.Drawing.Size(75, 23);
            this.btnPrintScreen.TabIndex = 9;
            this.btnPrintScreen.Text = "Print Screen";
            this.btnPrintScreen.UseVisualStyleBackColor = true;
            this.btnPrintScreen.Click += new System.EventHandler(this.btnPrintScreen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(12, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // txtTraditionalSales
            // 
            this.txtTraditionalSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTraditionalSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTraditionalSales.Location = new System.Drawing.Point(313, 26);
            this.txtTraditionalSales.Name = "txtTraditionalSales";
            this.txtTraditionalSales.Size = new System.Drawing.Size(93, 20);
            this.txtTraditionalSales.TabIndex = 11;
            // 
            // txtDailyTargetHit
            // 
            this.txtDailyTargetHit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDailyTargetHit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDailyTargetHit.Location = new System.Drawing.Point(313, 52);
            this.txtDailyTargetHit.Name = "txtDailyTargetHit";
            this.txtDailyTargetHit.Size = new System.Drawing.Size(93, 20);
            this.txtDailyTargetHit.TabIndex = 12;
            // 
            // txtDailyTargetHitFromNow
            // 
            this.txtDailyTargetHitFromNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDailyTargetHitFromNow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDailyTargetHitFromNow.Location = new System.Drawing.Point(313, 78);
            this.txtDailyTargetHitFromNow.Name = "txtDailyTargetHitFromNow";
            this.txtDailyTargetHitFromNow.Size = new System.Drawing.Size(93, 20);
            this.txtDailyTargetHitFromNow.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Traditional Sales";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Output if goal line achieved:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Output if goal line achieved from now:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtBigGoal);
            this.groupBox3.Controls.Add(this.txtTraditionalSales);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtDailyTargetHit);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtDailyTargetHitFromNow);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(926, 573);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 146);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Traditional";
            // 
            // txtWorkingDays
            // 
            this.txtWorkingDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkingDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWorkingDays.Location = new System.Drawing.Point(1245, 515);
            this.txtWorkingDays.Name = "txtWorkingDays";
            this.txtWorkingDays.Size = new System.Drawing.Size(93, 20);
            this.txtWorkingDays.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1135, 517);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Total Working Days;";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1075, 546);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Remaining Days to 10 day cutoff:";
            // 
            // txtRemainingWorkingDays
            // 
            this.txtRemainingWorkingDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemainingWorkingDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemainingWorkingDays.Location = new System.Drawing.Point(1245, 544);
            this.txtRemainingWorkingDays.Name = "txtRemainingWorkingDays";
            this.txtRemainingWorkingDays.Size = new System.Drawing.Size(93, 20);
            this.txtRemainingWorkingDays.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtSlimlineSales);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtDailyTargetHitSlimline);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtDailyTargetHitFromNowSlimline);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(926, 725);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(412, 107);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Slimline";
            // 
            // txtSlimlineSales
            // 
            this.txtSlimlineSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSlimlineSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlimlineSales.Location = new System.Drawing.Point(313, 22);
            this.txtSlimlineSales.Name = "txtSlimlineSales";
            this.txtSlimlineSales.Size = new System.Drawing.Size(93, 20);
            this.txtSlimlineSales.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Output if goal line achieved from now:";
            // 
            // txtDailyTargetHitSlimline
            // 
            this.txtDailyTargetHitSlimline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDailyTargetHitSlimline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDailyTargetHitSlimline.Location = new System.Drawing.Point(313, 48);
            this.txtDailyTargetHitSlimline.Name = "txtDailyTargetHitSlimline";
            this.txtDailyTargetHitSlimline.Size = new System.Drawing.Size(93, 20);
            this.txtDailyTargetHitSlimline.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Output if goal line achieved:";
            // 
            // txtDailyTargetHitFromNowSlimline
            // 
            this.txtDailyTargetHitFromNowSlimline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDailyTargetHitFromNowSlimline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDailyTargetHitFromNowSlimline.Location = new System.Drawing.Point(313, 74);
            this.txtDailyTargetHitFromNowSlimline.Name = "txtDailyTargetHitFromNowSlimline";
            this.txtDailyTargetHitFromNowSlimline.Size = new System.Drawing.Size(93, 20);
            this.txtDailyTargetHitFromNowSlimline.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Slimline Sales";
            // 
            // btnPipeLine
            // 
            this.btnPipeLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPipeLine.Location = new System.Drawing.Point(1178, 29);
            this.btnPipeLine.Name = "btnPipeLine";
            this.btnPipeLine.Size = new System.Drawing.Size(75, 23);
            this.btnPipeLine.TabIndex = 20;
            this.btnPipeLine.Text = "Pipeline";
            this.btnPipeLine.UseVisualStyleBackColor = true;
            this.btnPipeLine.Click += new System.EventHandler(this.btnPipeLine_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(277, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Output if daily goal acheived from now until 10 day cut off";
            // 
            // txtBigGoal
            // 
            this.txtBigGoal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBigGoal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBigGoal.Location = new System.Drawing.Point(312, 104);
            this.txtBigGoal.Name = "txtBigGoal";
            this.txtBigGoal.Size = new System.Drawing.Size(93, 20);
            this.txtBigGoal.TabIndex = 17;
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1376, 852);
            this.Controls.Add(this.btnPipeLine);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtRemainingWorkingDays);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWorkingDays);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPrintScreen);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chrtSlimline);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpInvoice);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.cmbMonth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form1";
            this.Text = "Sales Management Console";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoice)).EndInit();
            this.grpInvoice.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgForeCast)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtSlimline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridView dgInvoice;
        private System.Windows.Forms.GroupBox grpInvoice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgForeCast;
        private System.Windows.Forms.Button btnExplainForecast;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnForecastDetails;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtSlimline;
        private System.Windows.Forms.Button btnViewInvoice;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnPrintScreen;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTraditionalSales;
        private System.Windows.Forms.TextBox txtDailyTargetHit;
        private System.Windows.Forms.TextBox txtDailyTargetHitFromNow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtWorkingDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemainingWorkingDays;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSlimlineSales;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDailyTargetHitSlimline;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDailyTargetHitFromNowSlimline;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPipeLine;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBigGoal;
    }
}

