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
using StartUpClass;

namespace TSalesManagement
{
    public partial class frmAmendActivity : Form
    {


        public int _aID { get; set; }
        private string _custAccRef { get; set; }

        public frmAmendActivity(int aID)
        {
            InitializeComponent();
            _aID = aID;
            
            fillData();
            populateContacts();
          
        }



        private void fillData()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * from dbo.crm_activity where id=@id";
            cmd.Parameters.AddWithValue("@id", _aID);


            SqlDataReader rdr = cmd.ExecuteReader();


            if (rdr.Read())
            {
                _custAccRef = rdr["customer_acc_ref"].ToString();
                cmbRecipient.Text = rdr["recipient"].ToString() ;
                cmbType.Text = rdr["correspondance_type"].ToString();
                txtDetails.Text = rdr["details_of"].ToString();
                txtReference.Text = rdr["reference"].ToString();


            }

            rdr.Close();
            conn.Close();

        }



        private void frmAmendActivity_Load(object sender, EventArgs e)
        {

        }

        private void populateContacts()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select id, contact_name from dbo.crm_customer_contacts WHERE cust_acc_ref=@custAccRef", conn);
            cmd.Parameters.AddWithValue("@custAccRef", _custAccRef);

            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("contact_name", typeof(string));
            dt.Load(rdr);

            cmbRecipient.ValueMember = "id";
            cmbRecipient.DisplayMember = "contact_name";
            cmbRecipient.DataSource = dt;
            conn.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "UPDATE dbo.crm_activity set customer_acc_ref = @custAccRef, date_modified = @date ,correspondance_type = @type ,details_of = @details ,recipient = @recipient ,reference =@ref where id = @id ";
                             

            cmd.Parameters.AddWithValue("@custAccRef", _custAccRef);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@type", cmbType.Text);
            cmd.Parameters.AddWithValue("@details", txtDetails.Text);
            cmd.Parameters.AddWithValue("@ref", txtReference.Text);
            cmd.Parameters.AddWithValue("@recipient", cmbRecipient.SelectedValue);
            cmd.Parameters.AddWithValue("@id", _aID);
      

            cmd.ExecuteNonQuery();

            conn.Close();
            this.Close();
        }
    }
}
