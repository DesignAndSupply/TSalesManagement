using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Windows.Forms.DataVisualization.Charting;
using Nager.Date;
using System.Drawing.Printing;

namespace TSalesManagement
{
    public partial class form1 : Form
    {

        DateTime firstDayOfMonth;
        DateTime lastDayOfMonth;
        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, e.PageBounds);
        }


        public form1()
        {
            InitializeComponent();
            cmbMonth.SelectedItem = DateTime.Now.ToString("MMMM");
            cmbYear.SelectedItem = DateTime.Now.Year.ToString();
            calculateData();

        }



        void calculateData()
        {

            TimeConversion tc = new TimeConversion();
            firstDayOfMonth = tc.GetDate(cmbMonth.SelectedItem.ToString(), cmbYear.SelectedItem.ToString());

            lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(0);

            // lastDayOfMonth = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month,1).AddMonths(5).AddDays(0);

            //FillInvoiceGridView();
            progressBar1.Value = 0;
            progressBar1.Update();

            FillForecastGridView();
            DrawSalesChart();
            SlimlineDrawSalesChart();
            FillMeetingData();
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            calculateData();

        }

        void FillInvoiceGridView()
        {
            SqlConnection sqlconn = new SqlConnection(SqlStatements.ConnectionString);
            if (sqlconn.State == System.Data.ConnectionState.Closed)
            {
                sqlconn.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("C_usp_invoice_totals", sqlconn);
                sqlda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.Add("@firstDayOfMonth", SqlDbType.DateTime).Value = firstDayOfMonth;
                sqlda.SelectCommand.Parameters.Add("@lastDayOfMonth", SqlDbType.DateTime).Value = lastDayOfMonth;
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                sqlconn.Close();
                dgInvoice.DataSource = dt;

            }

        }
        void SlimlineDrawSalesChart()
        {
            //CLEARS ALL EXISTING SERIES
            while (chrtSlimline.Series.Count > 0) { chrtSlimline.Series.RemoveAt(0); }

            Double cumulativeSalesFigure;
            Double cumulativePotential;
            Double currentPotential;

            string dateWeekendCheck;
            DateTime weekendCheck;


            SqlStatements sqlst = new SqlStatements();

            var tuple = sqlst.GetSalesTarget(cmbMonth.Text, cmbYear.Text);

            int monthlyTarget = tuple.Item2;
            double dailyTarget = monthlyTarget / 20;
            string dailyTargetWording = Math.Round((dailyTarget / 1000),2).ToString() + "k";

            //ADDS SALES FIGURE SERIES
            var series = new Series("Slimline Sales");
            var seriesTarget = new Series("Slimline Target");
            var potentialSales = new Series(dailyTargetWording + " Per Day Target Line");
            var currentPotentialSeries = new Series(dailyTargetWording+ " Per Day from today onwards");


            SqlConnection SqlCon = new SqlConnection(SqlStatements.ConnectionString);

            SqlCommand getSalesData = new SqlCommand();
            getSalesData.Connection = SqlCon;
            getSalesData.CommandType = CommandType.Text;
            getSalesData.CommandText = "Select * from c_view_daily_output_slimline where date_completion >= @firstDate and date_completion <= @lastDate order by date_completion";
            getSalesData.Parameters.AddWithValue("@firstDate", firstDayOfMonth);
            getSalesData.Parameters.AddWithValue("@lastDate", lastDayOfMonth);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(getSalesData);
            adapter.Fill(dt);

            cumulativeSalesFigure = 0;
            cumulativePotential = 0;
            currentPotential = 0;


            
            foreach (DataRow row in dt.Rows)
            {

               progressBar1.Value = progressBar1.Value +1;
               progressBar1.Update();

                cumulativeSalesFigure = cumulativeSalesFigure + Convert.ToDouble(row["door_value"].ToString());

                dateWeekendCheck = row["date_completion"].ToString();
                weekendCheck = Convert.ToDateTime(dateWeekendCheck);

                if (Convert.ToDateTime(row["date_completion"]) <= DateTime.Today)
                {
                    currentPotential = currentPotential + Convert.ToDouble(row["door_value"].ToString());
                }

                else
                {
                    if (DateSystem.IsPublicHoliday(weekendCheck, CountryCode.GB) || weekendCheck.DayOfWeek == DayOfWeek.Saturday || weekendCheck.DayOfWeek == DayOfWeek.Sunday)
                    {
                        currentPotential = currentPotential + 0;
                    }
                    else
                    {
                        currentPotential = currentPotential + dailyTarget;
                    }
                }


                //ONLY ADD THE CUMULATIVE POTENTIAL IF WEEKDAY ISNT WEEKEND
                if (DateSystem.IsPublicHoliday(weekendCheck, CountryCode.GB) || weekendCheck.DayOfWeek == DayOfWeek.Saturday || weekendCheck.DayOfWeek == DayOfWeek.Sunday)
                {
                    cumulativePotential = cumulativePotential + 0;
                }
                else
                {
                    cumulativePotential = cumulativePotential + dailyTarget;
                }
                potentialSales.Points.AddXY(row["date_completion"], cumulativePotential);

                series.Points.AddXY(row["date_completion"], cumulativeSalesFigure);
                currentPotentialSeries.Points.AddXY(row["date_completion"], currentPotential);

                //NEED DYNAMIC GOALS
                seriesTarget.Points.AddXY(row["date_completion"], monthlyTarget);
            }



            txtSlimlineSales.Text = "£" + cumulativeSalesFigure.ToString();
            txtDailyTargetHitSlimline.Text = "£" + cumulativePotential.ToString();
            txtDailyTargetHitFromNowSlimline.Text = "£" + currentPotential.ToString();

            chrtSlimline.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;

            chrtSlimline.Series.Add(series);
            chrtSlimline.Series["Slimline Sales"].ChartType = SeriesChartType.Line;

            chrtSlimline.Series.Add(seriesTarget);
            chrtSlimline.Series["Slimline Target"].ChartType = SeriesChartType.Line;

            chrtSlimline.Series.Add(potentialSales);
            chrtSlimline.Series[dailyTargetWording + " Per Day Target Line"].ChartType = SeriesChartType.Line;

            chrtSlimline.Series.Add(currentPotentialSeries);
            chrtSlimline.Series[dailyTargetWording + " Per Day from today onwards"].ChartType = SeriesChartType.Line;



            chrtSlimline.Series["Slimline Target"].BorderWidth = 2;
            chrtSlimline.Series["Slimline Sales"].BorderWidth = 2;
            chrtSlimline.Series[dailyTargetWording +" Per Day from today onwards"].BorderWidth = 2;
            chrtSlimline.Series[dailyTargetWording+ " Per Day Target Line"].BorderWidth = 2;


            chrtSlimline.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chrtSlimline.ChartAreas["ChartArea1"].AxisY.Interval = 50000;
            chrtSlimline.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;

        }
        void DrawSalesChart()
        {
            //CLEARS ALL EXISTING SERIES
            while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }

            Double cumulativeSalesFigure;
            Double cumulativePotential;
            int workingDaysInMonth;
            int workingDaysRemaining;
            int workingDayCounter;
            int daysToTenDayCutOff;
            Double currentPotential;

            SqlStatements sqlst = new SqlStatements();

            var tuple = sqlst.GetSalesTarget(cmbMonth.Text, cmbYear.Text);

            int monthlyTarget = tuple.Item1;
            double dailyTarget = monthlyTarget / 20;
            string dailyTargetWording = Math.Round((dailyTarget / 1000), 2).ToString() + "k";

            int monthlyTargetWithAdditionalDays = monthlyTarget;
            
            string dateWeekendCheck;
            DateTime weekendCheck;

            //ADDS SALES FIGURE SERIES
            var series = new Series("Traditional Sales");
            var seriesTarget = new Series("Traditional Target");
            var potentialSales = new Series(dailyTargetWording + " Per Day Target Line");
            var currentPotentialSeries = new Series(dailyTargetWording + " Per Day from today onwards");
            var tenDayCutOff = new Series("10 Day Cut Off");
            var fifteenDayCutOff = new Series("15 Day Cut Off");

            SqlConnection SqlCon = new SqlConnection(SqlStatements.ConnectionString);

            SqlCommand getSalesData = new SqlCommand();
            getSalesData.Connection = SqlCon;
            getSalesData.CommandType = CommandType.Text;
            getSalesData.CommandText = "Select * from c_view_daily_output where date_completion >= @firstDate and date_completion <= @lastDate order by date_completion";
            getSalesData.Parameters.AddWithValue("@firstDate", firstDayOfMonth);
            getSalesData.Parameters.AddWithValue("@lastDate", lastDayOfMonth);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(getSalesData);
            adapter.Fill(dt);

            cumulativeSalesFigure = 0;
            cumulativePotential = 0;
            currentPotential = 0;
            workingDaysInMonth = 0;
            workingDaysRemaining = 0;

            progressBar1.Maximum = dt.Rows.Count * 2;
            foreach (DataRow row in dt.Rows)
            {
                
                progressBar1.Value = progressBar1.Value + 1;
                progressBar1.Update();
                dateWeekendCheck = row["date_completion"].ToString();
                weekendCheck = Convert.ToDateTime(dateWeekendCheck);

                //Totals up the sales figure
                cumulativeSalesFigure = cumulativeSalesFigure + Convert.ToDouble(row["door_value"].ToString());

                if(Convert.ToDateTime(row["date_completion"])<=DateTime.Today)
                {
                    currentPotential = currentPotential + Convert.ToDouble(row["door_value"].ToString());
                }

                else
                {
                    if (DateSystem.IsPublicHoliday(weekendCheck, CountryCode.GB) || weekendCheck.DayOfWeek == DayOfWeek.Saturday || weekendCheck.DayOfWeek == DayOfWeek.Sunday)
                    {
                        currentPotential = currentPotential + 0;
                    }
                    else
                    {
                        currentPotential = currentPotential + dailyTarget;
                        workingDaysRemaining += 1;

                    }
                }

                //ONLY ADD THE CUMULATIVE POTENTIAL IF WEEKDAY ISNT WEEKEND
                if(DateSystem.IsPublicHoliday(weekendCheck,CountryCode.GB) || weekendCheck.DayOfWeek == DayOfWeek.Saturday || weekendCheck.DayOfWeek == DayOfWeek.Sunday)
                {
                    cumulativePotential = cumulativePotential + 0;
                }
                else
                {
                    cumulativePotential = cumulativePotential + dailyTarget;
                    workingDaysInMonth += 1;

                }


                potentialSales.Points.AddXY(row["date_completion"], cumulativePotential);
                series.Points.AddXY(row["date_completion"], cumulativeSalesFigure);
                currentPotentialSeries.Points.AddXY(row["date_completion"], currentPotential);

                //NEED DYNAMIC GOALS
               
                seriesTarget.Points.AddXY(row["date_completion"], monthlyTarget);
                
            }





            //FILL TRADITIONAL TEXTBOXES

            txtTraditionalSales.Text = "£" + cumulativeSalesFigure.ToString();
            txtDailyTargetHit.Text = "£" + cumulativePotential.ToString();
            txtDailyTargetHitFromNow.Text = "£" + currentPotential.ToString();
            txtWorkingDays.Text = workingDaysInMonth.ToString();
            //txtRemainingWorkingDays.Text = workingDaysRemaining.ToString();

            


            //PLOTS THE 10 AND 15 DAY BOOKING IN CUT OFF POINTS.
            DataTable dt2 = new DataTable();
            SqlDataAdapter adapter2 = new SqlDataAdapter(getSalesData);
            adapter.Fill(dt2);
            workingDayCounter = Convert.ToInt32(txtWorkingDays.Text.ToString());

            //IF THE MONTH BEING VIEWED ISNT THE SAME AS THE CURRENT MONTH THEN TOTAL UP THE AMOUNT OF WORKING DAYS BETWEEN THE CURRENT DATE AND THE START OF THE MONTH BEING VIEWED

            daysToTenDayCutOff = 0;
            for (DateTime date = DateTime.Today; date.Date < firstDayOfMonth.Date; date = date.AddDays(1))
            {
                if (DateSystem.IsPublicHoliday(date, CountryCode.GB) || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {

                }
                else
                {
                    daysToTenDayCutOff += 1;
                }
            }




            foreach (DataRow row in dt2.Rows)
            {
                dateWeekendCheck = row["date_completion"].ToString();
                weekendCheck = Convert.ToDateTime(dateWeekendCheck);
                if (DateSystem.IsPublicHoliday(weekendCheck, CountryCode.GB) || weekendCheck.DayOfWeek == DayOfWeek.Saturday || weekendCheck.DayOfWeek == DayOfWeek.Sunday)
                {
                   
                }
                else
                {



                    if (DateTime.Today <= weekendCheck)
                    {
                        daysToTenDayCutOff += 1;
                    }


                    workingDayCounter = workingDayCounter - 1;
                    switch (workingDayCounter)
                    {
                        case 10:
                            tenDayCutOff.Points.AddXY(row["date_completion"], monthlyTarget);
                            //SETS THE AMOUNT OF DAYS REMAINING UNTIL THE 10 DAY CUT OFF
                            txtRemainingWorkingDays.Text = daysToTenDayCutOff.ToString();
                            break;
                        case 15:
                            fifteenDayCutOff.Points.AddXY(row["date_completion"], monthlyTarget);
                            break;
                    }

                }

               
            }

            //SETS THE BIG GOAL --- EVERYTHING WE CURRENTLY HAVE BOOKED IN + DAILY GOAL * BY THE AMOUNT OF DAYS TO THE TEN DAY CUT OFF
            txtBigGoal.Text = "£" + (cumulativeSalesFigure + (27500 * daysToTenDayCutOff));

            //SETS THE INTERVAL TYPE
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;

            //Adds the series to the chart
            chart1.Series.Add(series);
            chart1.Series["Traditional Sales"].ChartType = SeriesChartType.Line;

            chart1.Series.Add(seriesTarget);
            chart1.Series["Traditional Target"].ChartType = SeriesChartType.Spline;

            chart1.Series.Add(potentialSales);
            chart1.Series[dailyTargetWording + " Per Day Target Line"].ChartType = SeriesChartType.Line;

            chart1.Series.Add(currentPotentialSeries);
            chart1.Series[dailyTargetWording + " Per Day from today onwards"].ChartType = SeriesChartType.Line;

            chart1.Series.Add(tenDayCutOff);
            chart1.Series["10 Day Cut Off"].ChartType = SeriesChartType.Stock;

            chart1.Series.Add(fifteenDayCutOff);
            chart1.Series["15 Day Cut Off"].ChartType = SeriesChartType.Stock;




            //Adds the series thicknesses and the axis intervals
            chart1.Series["Traditional Sales"].BorderWidth = 2;
            chart1.Series["Traditional Target"].BorderWidth = 2;
            chart1.Series[dailyTargetWording + " Per Day Target Line"].BorderWidth = 2;
            chart1.Series[dailyTargetWording + " Per Day from today onwards"].BorderWidth = 2;
            chart1.Series["10 Day Cut Off"].BorderWidth = 2;
            chart1.Series["10 Day Cut Off"].Color = Color.Black;
            chart1.Series["15 Day Cut Off"].BorderWidth = 2;
            chart1.Series["15 Day Cut Off"].Color = Color.Black;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.ChartAreas["ChartArea1"].AxisY.Interval = 50000;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;


        }

        void FillMeetingData()
        {
         
                //GETS DOOR DATA
                //UPDATES OPERATIONS DATAGRID
                SqlConnection con = new SqlConnection(SqlStatements.ConnectionString);
                SqlCommand sqlMeetingData = new SqlCommand();
                sqlMeetingData.Connection = con;
                sqlMeetingData.CommandType = CommandType.Text;
                sqlMeetingData.CommandText = "Select * FROM dbo.SALES_meeting_notes where meetingMonth = @firstDayOfMonth";
                sqlMeetingData.Parameters.AddWithValue("@firstDayOfMonth", firstDayOfMonth);



            SqlDataAdapter sqlDoorDataAdap = new SqlDataAdapter(sqlMeetingData);

                DataTable dtDoorData = new DataTable();
                sqlDoorDataAdap.Fill(dtDoorData);
            try
            {
                richTextBox1.Text = dtDoorData.Rows[0]["meetingNotes"].ToString();


            }
            catch
            {

            }

           
        }


        void FillForecastGridView()
        {
            SqlConnection sqlconn = new SqlConnection(SqlStatements.ConnectionString);
            if (sqlconn.State == System.Data.ConnectionState.Closed)
            {
                lastDayOfMonth = lastDayOfMonth.AddDays(-1);
                sqlconn.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("C_usp_forecast_totals", sqlconn);
                sqlda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.Add("@firstDayOfMonth", SqlDbType.DateTime).Value = firstDayOfMonth;
                sqlda.SelectCommand.Parameters.Add("@lastDayOfMonth", SqlDbType.DateTime).Value = lastDayOfMonth;
                sqlda.SelectCommand.Parameters.Add("@grouped", SqlDbType.SmallInt).Value = -1;
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                sqlconn.Close();
                dgForeCast.DataSource = dt;

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnExplainForecast_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Grid displays all doors with a completion date in this month, that are Active/Query/Complete and either have no invoice or have been invoiced this month. Also factored into the totals are doors complete before the start of the current month but invoiced after the start of the current month. These parameters exclude proformas printed in other months.", "Help",  MessageBoxButtons.OK ,MessageBoxIcon.Question);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This grid shows all invoices created this month, split by nominal code. Proformas are included here.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void dgForeCast_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnForecastDetails_Click(object sender, EventArgs e)
        {
            DetailView dv = new DetailView(firstDayOfMonth,lastDayOfMonth);
            dv.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            SqlStatements sqlst = new SqlStatements();
            sqlst.UpdateRecord(this.richTextBox1.Text, firstDayOfMonth);

        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            FillInvoiceGridView();
        }

        private void btnPrintScreen_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.DefaultPageSettings.Landscape = true;
            
            printDocument1.Print();
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnPipeLine_Click(object sender, EventArgs e)
        {
            frmPipeLine frmPL = new frmPipeLine();
            frmPL.Show();
        }
    }
}
