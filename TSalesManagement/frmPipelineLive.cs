using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Forms;
using TSalesManagement.Class;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace TSalesManagement
{
    public partial class frmPipelineLive : Form
    {
        public frmPipelineLive()
        {
            InitializeComponent();
            drawPipelineChart();
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
                    conn.Close();
                }
            }
        }

        public void drawPipelineChart()
        {
            Pipeline p = new Pipeline();
            p._status = cmbFilterStatus.Text;
            p._area = cmbArea.Text;
            p._dateStart = dteStart.Value;
            p._dateEnd = dteEnd.Value;
            p._class = cmbClass.Text;
            List<int> staff = new List<int>();
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                conn.Open();
                foreach (var item in lstStaff.SelectedItems)
                {
                    string sql = "SELECT id FROM [user_info].dbo.[user] where forename + ' ' + surname = '" + item.ToString() + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        staff.Add(Convert.ToInt32(cmd.ExecuteScalar()));
                }
                conn.Close();
            }
            p._staff = staff;

            p.addPipelineData();

            //cartesianChart1.Series.Clear();

            //CLEARS ALL EXISTING SERIES
            while (cartesianChart1.Series.Count > 0) { cartesianChart1.Series.RemoveAt(0); }

            cartesianChart1.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> {p._janSales, p._febSales, p._marchSales, p._aprilSales,p._maySales,p._juneSales,p._julySales,p._augustSales,p._septemberSales,p._octoberSales,p._novemberSales,p._decemberSales},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true,
                    Title = "Traditional"
                },
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> {p._SjanSales, p._SfebSales, p._SmarchSales, p._SaprilSales,p._SmaySales,p._SjuneSales,p._SjulySales,p._SaugustSales,p._SseptemberSales,p._SoctoberSales,p._SnovemberSales,p._SdecemberSales},
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    Title = "Slimline"
                }


            };

            if (lstStaff.Items.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
                {
                    conn.Open();
                    foreach (var item in staff)
                    {
                        p.addPipelineUser(Convert.ToInt32(item));
                        string sql = "SELECT forename + ' ' + surname FROM [user_info].dbo.[user] where id = " + item.ToString() + "";
                        string temp = "";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            temp = (Convert.ToString(cmd.ExecuteScalar()));
                        cartesianChart1.Series.Add(new LineSeries
                        {
                            Values = new ChartValues<double> { p._SjanSales, p._SfebSales, p._SmarchSales, p._SaprilSales, p._SmaySales, p._SjuneSales, p._SjulySales, p._SaugustSales, p._SseptemberSales, p._SoctoberSales, p._SnovemberSales, p._SdecemberSales },
                            DataLabels = true,
                            Title = temp
                        });
                    }
                    conn.Close();
                }
            }


            ////adding values also updates and animates
            cartesianChart1.Series[1].Values.Add(4d);

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November","December" },
                Separator = DefaultAxes.CleanSeparator
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sales Value",
                LabelFormatter = value => value + ""
            });




            //cartesianChart1.DataTooltip = new CustomersTooltip();
        }

        private void frmPipelineLive_Load(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            drawPipelineChart();
        }
    }
}