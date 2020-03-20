using System;
using System.Data.SqlClient;
using System.Windows.Forms;
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
            if (string.IsNullOrWhiteSpace(txtForename.Text) || string.IsNullOrWhiteSpace(txtSurname.Text) || string.IsNullOrWhiteSpace(txtEmailAddress.Text) || string.IsNullOrWhiteSpace(txtJobTitle.Text) || string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                MessageBox.Show("All fields are mandatory and must be filled in to continue!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO dbo.crm_customer_contacts(cust_acc_ref,contact_name, contact_email, contact_tel, job_title,forename,surname) " +
                                  "values (@custAccRef,@contactName,@contactEmail,@contactTel,@jobtitle,@forename,@surname); ";

                cmd.Parameters.AddWithValue("@custAccRef", _custAccRef);
                cmd.Parameters.AddWithValue("@contactName", txtName.Text);
                cmd.Parameters.AddWithValue("@contactEmail", txtEmailAddress.Text);
                cmd.Parameters.AddWithValue("@contactTel", txtTelephone.Text);
                cmd.Parameters.AddWithValue("@jobtitle", txtJobTitle.Text);
                cmd.Parameters.AddWithValue("@forename", txtForename.Text);
                cmd.Parameters.AddWithValue("@surname", txtSurname.Text);

                cmd.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
        }

        private void frmNewContact_Load(object sender, EventArgs e)
        {
        }

        private void populateContactName()
        {
            txtName.Text = txtForename.Text + ' ' + txtSurname.Text;
        }

        private void txtForename_TextChanged(object sender, EventArgs e)
        {
            populateContactName();
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            populateContactName();
        }
    }
}