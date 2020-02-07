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
    public partial class frmProjectEdit : Form
    {
        public int _ID { get; set; }
        public frmProjectEdit(int ID, string customer,string title)
        {
            InitializeComponent();
            _ID = ID;
            this.Text = customer;
            label1.Text = title;
            //get information
            string sql = "SELECT * from dbo.projects WHERE ID = " + ID;
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        txtCommercialName.Text = sdr["commercial_contact_name"].ToString();
                        txtCommercialNumber.Text = sdr["commercial_phone_number"].ToString();
                        txtCommercialEmail.Text = sdr["commercial_email"].ToString();
                        txtCommercialPosition.Text = sdr["commercial_position"].ToString();

                        txtOnSiteName.Text = sdr["onsite_contact_name"].ToString();
                        txtOnSiteNumber.Text = sdr["onsite_phone_number"].ToString();
                        txtOnSiteEmail.Text = sdr["onsite_email"].ToString();
                        txtOnSitePosition.Text = sdr["onsite_position"].ToString();

                        txtAccountsName.Text = sdr["accounts_contact_name"].ToString();
                        txtAccountsNumber.Text = sdr["accounts_phone_number"].ToString();
                        txtAccountsEmail.Text = sdr["accounts_email"].ToString();
                        txtAccountsPosition.Text = sdr["accounts_position"].ToString();
                    }
                    conn.Close();
                }
            }
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            //update all the information in one place
            //(commercial_contact_name,commercial_phone_number,commercial_email,commercial_position,onsite_contact_name,
            //onsite_phone_number,onsite_email,onsite_position,accounts_contact_name,accounts_phone_number,accounts_email,accounts_position)
            //make the sql string
            string sql = "UPDATE dbo.projects" +
                " SET  commercial_contact_name = '" + txtCommercialName.Text.ToString() + "',commercial_phone_number = '" + txtCommercialNumber.Text.ToString() + "',commercial_email = '" + txtCommercialEmail.Text.ToString() + "',commercial_position = '" + txtCommercialPosition.Text.ToString() + "'," +
                "onsite_contact_name = '" + txtOnSiteName.Text.ToString() + "',onsite_phone_number = '" + txtOnSiteNumber.Text.ToString() + "',onsite_email = '" + txtOnSiteEmail.Text.ToString() + "',onsite_position = '" + txtOnSitePosition.Text.ToString() + "'," +
                "accounts_contact_name = '" + txtAccountsName.Text.ToString() + "',accounts_phone_number = '" + txtAccountsNumber.Text.ToString() + "',accounts_email = '" + txtAccountsEmail.Text.ToString() + "',accounts_position = '" + txtAccountsPosition.Text.ToString() + "' " +
                " WHERE id = " + _ID;
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Contact Information updated!");
                    this.Close();
                }
            }
        }

        private void txtCommercialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtOnSiteNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAccountsNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
