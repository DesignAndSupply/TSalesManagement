using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSalesManagement.Class;
using System.Data.SqlClient;

namespace TSalesManagement
{
    public partial class frmCustomerInformation : Form
    {

        private string _custAccRef { get; set; }
        private string _custName { get; set; }


        public frmCustomerInformation(string custAccRef, string custName)
        {
            InitializeComponent();
            _custAccRef = custAccRef;
            _custName = custName;


           
            lblCName.Text = _custName;

            Customer c = new Customer(_custAccRef);
            lblCAdd1.Text = c._add1;
            lblCAdd2.Text = c._add2;
            lblCAdd3.Text = c._add3;
            lblCAdd4.Text = c._add4;
            lblCAdd5.Text = c._add5;

            lblCTel1.Text = c._tel1;
            lblCTel2.Text = c._tel2;

            lblCFax.Text = c._fax;
            fillPipelineGrid();

        }

        private void frmCustomerInformation_Load(object sender, EventArgs e)
        {

        }



        private void fillPipelineGrid()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT door_style as 'Door Style', order_ref as 'Order Reference' ,estimated_order_date as 'Estimated date of order' ,added_by_id as 'Added by',date_added as 'Added on' ,estimated_order_value as 'Estimated Value' ,order_status as 'Status' FROM c_view_sales_pipeline_text where customer_acc_ref =@custAccRef order by date_added DESC";

            cmd.Parameters.AddWithValue("@custAccRef", _custAccRef);

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            try
            {
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dgvPipeline.DataSource = dt;

                dgvPipeline.Columns["Estimated Value"].DefaultCellStyle.Format = "c";
            }
            catch(Exception)
            {

            }

        }

        private void fillActiviyGrid()
        {

        }




        private void lblPipeline_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNewPipeline frmNP = new frmNewPipeline(_custAccRef);
            frmNP.ShowDialog();
            fillPipelineGrid();
        }
    }
}
