using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using TSalesManagement.Class;
using Wpf.CartesianChart.CustomTooltipAndLegend;

namespace TSalesManagement
{
    public partial class frmPipelineLive : Form
    {
        public frmPipelineLive()
        {
            InitializeComponent();
            drawPipelineChart();

        }

        public void drawPipelineChart()
        {
            Pipeline p = new Pipeline();
            p._status = cmbFilterStatus.Text;


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



            ////adding values also updates and animates
            cartesianChart1.Series[1].Values.Add(4d);

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" },
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

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            drawPipelineChart();
        }
    }
}
