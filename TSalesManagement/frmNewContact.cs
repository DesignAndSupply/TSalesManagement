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
using TSalesManagement.Class;

namespace TSalesManagement
{
    public partial class frmNewContact : Form
    {

        public string _custAccRef { get; set; }


        public frmNewContact(string custAccRef)
        {
            InitializeComponent();
            _custAccRef = custAccRef;

            Customer c = new Customer(_custAccRef);
         


            lblHeader.Text = "New Contact info for: " + c._customerName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO dbo.crm_customer_contacts(cust_acc_ref,contact_name, contact_email, contact_tel, job_title) " +
                              "values (@custAccRef,@contactName,@contactEmail,@contactTel,@jobtitle); ";

            cmd.Parameters.AddWithValue("@custAccRef", _custAccRef);
            cmd.Parameters.AddWithValue("@contactName", txtName.Text);
            cmd.Parameters.AddWithValue("@contactEmail", txtEmailAddress.Text);
            cmd.Parameters.AddWithValue("@contactTel", txtTelephone.Text);
            cmd.Parameters.AddWithValue("@jobtitle", txtJobTitle.Text);


            cmd.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }

        private void frmNewContact_Load(object sender, EventArgs e)
        {
            
        }
    }
}
