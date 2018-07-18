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




using System.Windows.Media;
using System.Windows;





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


            lblAccRef.Text = "Account Ref: " + _custAccRef;
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
            fillActivityGrid();
            fillContactsGrid();
            addConversionGauge();

        }

        private void frmCustomerInformation_Load(object sender, EventArgs e)
        {
            addConversionGauge();
        }


        private void addConversionGauge()
        {

            //custom fill
            Visualisations v = new Visualisations(_custAccRef);
            
            solidGauge5.From = 0;
            solidGauge5.To = 100;
            solidGauge5.Value = v.conversionRate;
            solidGauge5.Text = "Quotation Conversion";
            solidGauge5.Base.LabelsVisibility = Visibility.Hidden;
            solidGauge5.Base.GaugeActiveFill = new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop(Colors.Yellow, 0),
                    new GradientStop(Colors.Orange, .5),
                    new GradientStop(Colors.Red, 1)
                }
            };


        }


        private void fillPipelineGrid()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT id as 'Pipeline ID',door_style as 'Door Style', order_ref as 'Order Reference' ,estimated_order_date as 'Estimated date of order' ,added_by_id as 'Added by',date_added as 'Added on' ,estimated_order_value as 'Estimated Value' ,order_status as 'Status' FROM c_view_sales_pipeline_text where customer_acc_ref =@custAccRef order by date_added DESC";

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

        private void fillContactsGrid()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT id,contact_name,contact_email,contact_tel,job_title from dbo.crm_customer_contacts WHERE cust_acc_ref = @custAccRef";

            cmd.Parameters.AddWithValue("@custAccRef", _custAccRef);

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            try
            {
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dgContacts.DataSource = dt;

              
            }
            catch (Exception)
            {

            }

        }

        private void fillActivityGrid()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT ID ,[Activity Date],date_modified as [Last Updated],Type,reference,Details,Contact,[Logged By] from dbo.c_sales_view_activity_list where customer_acc_ref =@accRef order by  [Activity Date] desc";

            cmd.Parameters.AddWithValue("@accRef", _custAccRef);

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            try
            {
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dgvActivity.DataSource = dt;

               
            }
            catch (Exception)
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

        private void lblLinkEst_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLinkEstimating frmLE = new frmLinkEstimating(_custName, _custAccRef);
            frmLE.ShowDialog();
            addConversionGauge();

        }

        private void dgvPipeline_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pID;
            if (dgvPipeline.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvPipeline.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvPipeline.Rows[selectedrowindex];

                pID = Convert.ToInt32(selectedRow.Cells["Pipeline ID"].Value);

                frmAmendPipeline frmAP = new frmAmendPipeline(pID);
                frmAP.ShowDialog();

                fillPipelineGrid();
            }
        }

        private void dgvPipeline_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblActivity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNewActivity frmna = new frmNewActivity(_custAccRef);
            frmna.ShowDialog();
            fillActivityGrid();
        }

        private void lblAddContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmNewContact frmNC = new frmNewContact(_custAccRef);
            frmNC.ShowDialog();
            fillContactsGrid();

        }

        private void dgvActivity_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int aID;


            if (dgvActivity.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvActivity.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvActivity.Rows[selectedrowindex];

                aID = Convert.ToInt32(selectedRow.Cells["id"].Value);

                frmAmendActivity frmAA = new frmAmendActivity(aID);
                frmAA.ShowDialog();

                fillActivityGrid();


            }
        }
    }
}
