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

namespace TSalesManagement
{
    public partial class frmLinkEstimating : Form
    {

        private string _custName { get; set; }
        private string _custRef { get; set; }

        public frmLinkEstimating(string CustName, string CustAccRef)
        {
            InitializeComponent();
            _custName = CustName;
            _custRef = CustAccRef;
            lblHeader.Text = "Linking estimating data for customer: " + _custName;
        }






        private void frmLinkEstimating_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'order_databaseDataSet.solidworks_quotation_log' table. You can move, or remove it, as needed.
            this.solidworks_quotation_logTableAdapter.Fill(this.order_databaseDataSet.solidworks_quotation_log);

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO dbo.crm_est_link (crm_acc_ref,est_cust_name) VALUES (@custAccRef,@estCustName);";


            cmd.Parameters.AddWithValue("@custAccRef", _custRef);
            cmd.Parameters.AddWithValue("@estCustName", cmbEstCust.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            this.Close();

        }
    }
}
