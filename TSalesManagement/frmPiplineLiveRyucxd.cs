using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace TSalesManagement
{
    public partial class frmPiplineLiveRyucxd : Form
    {
        public DateTime _dateStart { get; set; }
        public DateTime _dateEnd { get; set; }
        public string _area { get; set; }
        public string _class { get; set; }
        public string _filter { get; set; }
        public int months { get; set; }

        public frmPiplineLiveRyucxd()
        {
            InitializeComponent();
            //drawPipelineChart();
            dteStart.Value = dteStart.Value.AddMonths(-2);
            dteEnd.Value = dteEnd.Value.AddMonths(12);

            //add estimators to the list box

            string sql = "select forename + ' ' + surname FROM [user_info].dbo.[user] WHERE isEstimator = -1 AND [current] = 1 order by forename + ' ' + surname ";
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        lstStaff.Items.Add(row[0].ToString());
                    }
                    lstStaff.Refresh();
                    conn.Close();
                }
            }
        }

        private void getData()
        {
            //fire the procedure and populate lists
            List<double> data = new List<double>();
            List<string> monthList = new List<string>();

            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                conn.Open();
                int validation = 0;
                foreach (var item in lstStaff.SelectedItems)
                {
                    validation = -1;
                    int userID = 0;
                    DateTime tempStart = new DateTime(dteStart.Value.Year, dteStart.Value.Month, 1);
                    DateTime tempEnd = new DateTime(dteEnd.Value.Year, dteEnd.Value.Month, 1);
                    months = Convert.ToInt32(tempStart.Month - tempEnd.Month) + 12 * (tempStart.Year - tempEnd.Year);
                    if (months < 0)
                        months = months * -1;
                    string sql = "SELECT id FROM [user_info].dbo.[user] where forename + ' ' + surname = '" + item.ToString() + "'";
                    using (SqlCommand cmdUser = new SqlCommand(sql, conn))
                        userID = Convert.ToInt32(cmdUser.ExecuteScalar());
                    sql = "";
                    using (SqlCommand cmd = new SqlCommand("usp_kpi_pipeline_live", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@dateStart", SqlDbType.DateTime).Value = Convert.ToDateTime(tempStart.ToString("yyyy-MM-dd"));
                        cmd.Parameters.Add("@dateEnd", SqlDbType.DateTime).Value = Convert.ToDateTime(tempEnd.ToString("yyyy-MM-dd"));
                        cmd.Parameters.Add("@area", SqlDbType.NVarChar).Value = _area;
                        cmd.Parameters.Add("@class", SqlDbType.NVarChar).Value = _class;
                        cmd.Parameters.Add("@orderStatus", SqlDbType.NVarChar).Value = _filter;
                        cmd.Parameters.Add("@staff", SqlDbType.Int).Value = userID;
                        cmd.Parameters.Add("@monthDiff", SqlDbType.Int).Value = months;

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        foreach (DataRow row in dt.Rows)
                        {
                            data.Add(Convert.ToDouble(row[0]));
                        }
                    }
                }
                if (validation == 0) //lazy but if the foreach doesnt proc then this hits instead
                {
                    validation = -1;
                    int userID = 0;
                    DateTime tempStart = new DateTime(dteStart.Value.Year, dteStart.Value.Month, 1);
                    DateTime tempEnd = new DateTime(dteEnd.Value.Year, dteEnd.Value.Month, 1);
                    months = Convert.ToInt32(tempStart.Month - tempEnd.Month) + 12 * (tempStart.Year - tempEnd.Year);
                    if (months < 0)
                        months = months * -1;
                    string sql = "";
                    userID = 0;
                    using (SqlCommand cmd = new SqlCommand("usp_kpi_pipeline_live", conn))  //procedure should always return a value, even if its null!!!
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@dateStart", SqlDbType.DateTime).Value = Convert.ToDateTime(tempStart.ToString("yyyy-MM-dd"));
                        cmd.Parameters.Add("@dateEnd", SqlDbType.DateTime).Value = Convert.ToDateTime(tempEnd.ToString("yyyy-MM-dd"));
                        cmd.Parameters.Add("@area", SqlDbType.NVarChar).Value = _area;
                        cmd.Parameters.Add("@class", SqlDbType.NVarChar).Value = _class;
                        cmd.Parameters.Add("@orderStatus", SqlDbType.NVarChar).Value = _filter;
                        cmd.Parameters.Add("@staff", SqlDbType.Int).Value = userID;
                        cmd.Parameters.Add("@monthDiff", SqlDbType.Int).Value = months;

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        foreach (DataRow row in dt.Rows)
                        {
                            data.Add(Convert.ToDouble(row[0]));
                        }
                    }

                    //DataTable dt = new DataTable();
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //da.Fill(dt);
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    data.Add(Convert.ToDouble(row[0]));
                    //}

                    //dataGridView1.DataSource = dt;
                }
                conn.Close();
            }

            //quickly grab the month list
            for (int i = 0; i < months; i++)
            {
                DateTime tempMonth = new DateTime(dteStart.Value.Year, dteStart.Value.Month, 1);
                tempMonth = tempMonth.AddMonths(i);
                monthList.Add(tempMonth.ToString("MMMM"));
            }

            while (cartesianChart1.Series.Count > 0) { cartesianChart1.Series.RemoveAt(0); }
            int value = 0;
            //cartesianChart1.Series = new SeriesCollection
            //{
            //    new StackedColumnSeries
            //    {
            //        Values = new ChartValues<double> {},
            //        StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
            //        DataLabels = true,
            //        Title = ""
            //}};

            foreach (var item in lstStaff.SelectedItems)
            {
                var tempData = new ChartValues<double>();
                for (int i = 0; i < months; i++)
                {
                    //MessageBox.Show(data[value].ToString());
                    tempData.Add(data[value]);
                    //  MessageBox.Show(data[value].ToString()) ;
                    value++;
                }
                // value = value - 1;

                cartesianChart1.Series.Add(new StackedColumnSeries
                {
                    Values = tempData,
                    DataLabels = true,
                    Title = item.ToString()
                });
            }
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Months",
                FontSize = 10,
                Labels = monthList,
                Separator = new Separator { Step = 1 }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Estimated Order Value",
                FontSize = 10,
            });
            cartesianChart1.LegendLocation = LegendLocation.Bottom;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _area = cmbArea.Text;
            _class = cmbClass.Text;
            _filter = cmbFilterStatus.Text;
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Clear();
            getData();
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstStaff.Items.Clear();
            string sql = "";
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                if (cmbArea.Text == "Traditional")
                {
                    sql = "select forename + ' ' + surname FROM [user_info].dbo.[user] WHERE isEstimator = -1 AND [current] = 1 order by forename + ' ' + surname ";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            lstStaff.Items.Add(row[0].ToString());
                        }
                        lstStaff.Refresh();
                    }
                }
                else
                {
                    sql = "select forename + ' ' + surname FROM [user_info].dbo.[user] WHERE [current] <> 0 AND current_department_id = 'SL Estimating' OR current_department_id = 'SL Drawing' and id <> 82 order by forename + ' ' + surname ";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            lstStaff.Items.Add(row[0].ToString());
                        }
                        lstStaff.Refresh();
                    }
                }
                conn.Close();
            }
        }

        private void cartesianChart1_DataClick(object sender, ChartPoint p)
        {
            var asPixels = cartesianChart1.Base.ConvertToPixels(p.AsPoint());
            //MessageBox.Show("[EVENT] You clicked (" + p.X + ", " + p.Y + ") in pixels (" +
            //asPixels.X + ", " + asPixels.Y + ")");

            //can use p.x to count across how many months we are at and from there populate a datagridview to see what is there
            DateTime tempStart = new DateTime(dteStart.Value.Year, dteStart.Value.Month, 1);
            double months = 0;
            months = p.X;
            tempStart = tempStart.AddMonths(Convert.ToInt32(months));
            //string user = "Nicholas Thomas";
            ////find the users here
            //if (lstStaff.SelectedItems.Count == 1)
            //    user = lstStaff.SelectedItems[0].ToString();
            frmPipelineLiveData frm = new frmPipelineLiveData(tempStart, "", _filter, _area, _class);
            frm.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                bit.Save(@"C:\temp\temp.jpg");

                printImage();
            }
            catch
            {
            }
        }

        private void printImage()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    System.Drawing.Image i = System.Drawing.Image.FromFile(@"C:\temp\temp.jpg");
                    Point p = new Point(100, 100);
                    args.Graphics.DrawImage(i, args.MarginBounds);
                };

                pd.DefaultPageSettings.Landscape = true;
                Margins margins = new Margins(50, 50, 50, 50);
                pd.DefaultPageSettings.Margins = margins;
                pd.Print();
            }
            catch
            {
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                bit.Save(@"C:\temp\temp.jpg");
            }
            catch
            {
            }

            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "";
            mailItem.To = "";
            string imageSrc = @"C:\Temp\temp.jpg"; // Change path as needed

            var attachments = mailItem.Attachments;
            var attachment = attachments.Add(imageSrc);
            attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpeg");
            attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "myident"); // Image identifier found in the HTML code right after cid. Can be anything.
            mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", true);

            // Set body format to HTML
            try
            {
                mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                mailItem.Attachments.Add(imageSrc);
                string msgHTMLBody = "";
                mailItem.HTMLBody = msgHTMLBody;
                mailItem.Display(true);
                //mailItem.Send();
            }
            catch
            {
            }
        }
    }
}