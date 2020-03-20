using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TSalesManagement
{
    public partial class frmPipeLine : Form
    {
        private string toolTipMonth;
        private string toolTipStyle;
        private string toolTipValue;

        public frmPipeLine()
        {
            InitializeComponent();
            cmbFilterStatus.SelectedIndex = 0;
            DrawPipelineChart();
            FillPipeLineDetails();
        }

        private void frmPipeLine_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_sales_program_users' table. You can move, or remove it, as needed.
            this.c_view_sales_program_usersTableAdapter.Fill(this.user_infoDataSet.c_view_sales_program_users);
            // TODO: This line of code loads data into the 'user_infoDataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.user_infoDataSet.user);
            // TODO: This line of code loads data into the 'order_databaseDataSet.SALES_LEDGER' table. You can move, or remove it, as needed.
            this.sALES_LEDGERTableAdapter.Fill(this.order_databaseDataSet.SALES_LEDGER);
            // TODO: This line of code loads data into the 'order_databaseDataSet.sales_pipeline' table. You can move, or remove it, as needed.
            this.sales_pipelineTableAdapter.Fill(this.order_databaseDataSet.sales_pipeline);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            sales_pipelineTableAdapter.Update(order_databaseDataSet);
            MessageBox.Show("Pipeline data has been successfully added. Do you wish to replot the chart?", "Success!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DrawPipelineChart();
            FillPipeLineDetails();
            //}
            //catch
            //{
            //MessageBox.Show("Update of table has failed. If this error persists please contact IT","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
        }

        private void FillPipeLineDetails()
        {
            string salesManName = "";
            string salesManNameCurrentRow = "";
            string salesEstimatedMonth = "";
            string salesEstimatedMonthCurrentRow = "";

            var sb = new StringBuilder();

            SqlConnection sqlCon = new SqlConnection(SqlStatements.ConnectionString);
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.Text;

            if (string.IsNullOrWhiteSpace(toolTipMonth))
            {
                sqlcmd.CommandText = "Select * from c_view_sales_pipeline_text WHERE order_status = 10 order by added_by_id , estimated_order_date";
                sqlcmd.Parameters.AddWithValue("@status", cmbFilterStatus.Text);

                this.txtPipelineData.Text = "Please hover over a bar on the chart to see breakdown information";
            }
            else
            {
                sqlcmd.CommandText = "Select * from c_view_sales_pipeline_text WHERE door_style = @doorStyle AND estimated_order_date = @estDate AND order_status = @status order by added_by_id , estimated_order_date";
                sqlcmd.Parameters.AddWithValue("@status", cmbFilterStatus.Text);
                sqlcmd.Parameters.AddWithValue("@estDate", DateTime.Parse(toolTipMonth));

                //SETS THE DOOR STYLE FILTER
                if (toolTipStyle == "Traditional Pipeline ")
                {
                    sqlcmd.Parameters.AddWithValue("@doorStyle", "Traditional");
                }
                else
                {
                    sqlcmd.Parameters.AddWithValue("@doorStyle", "Slimline");
                }

                ////ADDS THE TEXT

                DataTable DT = new DataTable();
                SqlDataAdapter adapterText = new SqlDataAdapter(sqlcmd);
                adapterText.Fill(DT);

                foreach (DataRow row in DT.Rows)
                {
                    salesManNameCurrentRow = row["added_by_id"].ToString();
                    salesEstimatedMonthCurrentRow = Convert.ToDateTime(row["estimated_order_date"]).Date.ToString("MMMM");
                    if (salesManName != salesManNameCurrentRow)
                    {
                        if (sb.Length >= 11)
                        {
                            sb.Append(@"\line\line");
                        }
                        else
                        {
                            sb.Append(@"{\rtf1\ansi");
                        }

                        salesManName = salesManNameCurrentRow;
                        sb.Append(@"--------------------------------------------------------------------- \line ");
                        sb.Append(@" \b " + salesManName + @" \b0 " + @"\line");

                        if (salesEstimatedMonthCurrentRow != salesEstimatedMonth)
                        {
                            sb.Append(@" \line \ul Estimated Order Date: ");
                            sb.Append(Convert.ToDateTime(row["estimated_order_date"]).Date.ToString("MMMM") + @" \ul0 ");
                            sb.Append(@" \line \b " + row["Customer Name"].ToString() + @" \b0 " + row["order_ref"].ToString() + " £" + row["estimated_order_value"].ToString() + @"  //" + row["description_of_doors_on_order"] + @" \line ");
                        }
                        else
                        {
                            sb.Append(@" \line \b " + row["Customer Name"].ToString() + @" \b0 " + row["order_ref"].ToString() + " £" + row["estimated_order_value"].ToString() + @"  //" + row["description_of_doors_on_order"] + @" \line ");
                        }
                        salesEstimatedMonth = salesEstimatedMonthCurrentRow;
                    }
                    else
                    {
                        if (salesEstimatedMonthCurrentRow != salesEstimatedMonth)
                        {
                            sb.Append(@" \line \ul Estimated Order Date: ");
                            sb.Append(Convert.ToDateTime(row["estimated_order_date"]).Date.ToString("MMMM") + @" \ul0 ");
                            sb.Append(@" \line \b " + row["Customer Name"].ToString() + @" \b0 " + row["order_ref"].ToString() + " £" + row["estimated_order_value"].ToString() + @"  //" + row["description_of_doors_on_order"] + @" \line ");
                        }
                        else
                        {
                            sb.Append(@" \line \b " + row["Customer Name"].ToString() + @" \b0 " + row["order_ref"].ToString() + " £" + row["estimated_order_value"].ToString() + @"  //" + row["description_of_doors_on_order"] + @" \line ");
                        }
                        salesEstimatedMonth = salesEstimatedMonthCurrentRow;
                    }
                }

                sb.Append("}");

                if (sb.Length < 20)
                {
                    this.txtPipelineData.Text = "Please hover over a bar on the chart to see breakdown information";
                }
                else
                {
                    this.txtPipelineData.Rtf = sb.ToString();
                }
            }
        }

        private void DrawPipelineChart()
        {
            //CLEARS ALL EXISTING SERIES
            while (chrtPipeline.Series.Count > 0) { chrtPipeline.Series.RemoveAt(0); }

            //ADDS SALES FIGURE SERIES
            var traditionalSeries = new Series("Traditional Pipeline");
            var slimlineSeries = new Series("Slimline Pipeline");

            SqlConnection SqlCon = new SqlConnection(SqlStatements.ConnectionString);

            SqlCommand getPipeLineData = new SqlCommand();
            getPipeLineData.Connection = SqlCon;
            getPipeLineData.CommandType = CommandType.Text;

            getPipeLineData.CommandText = "Select * from c_view_pipeline_chart  WHERE order_status=@status order by estimated_order_date";
            getPipeLineData.Parameters.AddWithValue("@status", cmbFilterStatus.Text);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(getPipeLineData);
            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                if (row["door_style"].ToString() == "Traditional")
                {
                    traditionalSeries.Points.AddXY(row["estimated_order_date"], row["estimated_order_value"]);
                }
                else
                {
                    slimlineSeries.Points.AddXY(row["estimated_order_date"], row["estimated_order_value"]);
                }
            }

            ///////////////////////

            chrtPipeline.Series.Add(traditionalSeries);
            chrtPipeline.Series["Traditional Pipeline"].ChartType = SeriesChartType.Column;

            chrtPipeline.Series.Add(slimlineSeries);
            chrtPipeline.Series["Slimline Pipeline"].ChartType = SeriesChartType.Column;

            //SETS THE TOOLTIPS
            chrtPipeline.Series["Traditional Pipeline"].ToolTip = "#SERIESNAME ( #VALY{C} ) #VALX ";
            chrtPipeline.Series["Slimline Pipeline"].ToolTip = "#SERIESNAME ( #VALY{C} ) #VALX";

            //sets bar width
            chrtPipeline.Series["Traditional Pipeline"]["PixelPointWidth"] = "60";
            chrtPipeline.Series["Slimline Pipeline"]["PixelPointWidth"] = "60";

            chrtPipeline.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
            chrtPipeline.ChartAreas[0].AxisX.LabelStyle.Format = "MMM yyyy";
            chrtPipeline.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chrtPipeline.ChartAreas["ChartArea1"].AxisY.Interval = 50000;
        }

        private void salespipelineBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.sales_pipelineTableAdapter.FillBy(this.order_databaseDataSet.sales_pipeline);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DrawPipelineChart();
            FillPipeLineDetails();
        }

        //ToolTip tooltip = new ToolTip();
        //Point? clickPosition = null;
        private void chrtPipeline_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            try
            {
                toolTipMonth = e.Text.Substring(e.Text.LastIndexOf(')') + 1); //WORKING
                toolTipStyle = e.Text.Substring(0, e.Text.IndexOf("(")); //WORKING
                toolTipValue = Regex.Match(e.Text, @"\(([^)]*)\)").Groups[1].Value.ToString();
                txtDate.Text = DateTime.Parse(toolTipMonth).ToString("MMMM");
                txtDept.Text = toolTipStyle;
                txtValue.Text = toolTipValue;
            }
            catch
            {
                txtDate.Text = "";
                //txtDept.Text = "Showing All " + cmbFilterStatus.Text;
                txtDept.Text = "";
                txtValue.Text = "";
            }
            FillPipeLineDetails();
        }

        private void chrtPipeline_Click(object sender, EventArgs e)
        {
        }

        private void cviewsalesprogramusersBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }
    }
}