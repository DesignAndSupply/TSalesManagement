using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TSalesManagement
{
    public partial class frmUpdateContact : Form
    {
        public int _ID { get; set; }

        public frmUpdateContact(int customerID)
        {
            InitializeComponent();

            //get info based on ID
            _ID = customerID;

            string sql = "SELECT * FROM dbo.crm_customer_contacts WHERE id = " + customerID.ToString();
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtForename.Text = Convert.ToString(reader["forename"]);
                        txtSurname.Text = Convert.ToString(reader["surname"]);
                        txtEmailAddress.Text = Convert.ToString(reader["contact_email"]);
                        txtTelephone.Text = Convert.ToString(reader["contact_tel"]);
                        txtJobTitle.Text = Convert.ToString(reader["job_title"]);
                        txtName.Text = Convert.ToString(reader["contact_name"]);
                    }
                    conn.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE dbo.crm_customer_contacts SET contact_name = '" + txtName.Text + "',contact_email = '" + txtEmailAddress.Text + "',contact_tel = '" + txtTelephone.Text + "',job_title = '" + txtJobTitle.Text + "',forename = '" + txtForename.Text + "'," +
                "surname = '" + txtSurname.Text + "' WHERE id = " + _ID;

            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                this.Close();
            }
        }
    }
}