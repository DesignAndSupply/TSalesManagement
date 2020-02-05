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
    public partial class frmAddProject : Form
    {
        public frmAddProject()
        {
            InitializeComponent();

            //fill the combobox
            string sql = "select [NAME] from dbo.SALES_LEDGER UNION ALL select[NAME] from dbo.SALES_LEDGER_PROSPECT;";
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader DR = cmd.ExecuteReader(); // this needs testing 
                    while (DR.Read())
                    {
                        cmbCustomer.Items.Add(DR[0]);
                    }
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

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            //work out which boxes can be null etc 
            string sql = "INSERT INTO dbo.projects (project_title,site_address,customer_acc_ref," +
                "commercial_contact_name,commercial_phone_number,commercial_email,commercial_position," +
                "onsite_contact_name,onsite_phone_number,onsite_email,onsite_position," +
                "accounts_contact_name,accounts_phone_number,accounts_email,accounts_position" +
                ") VALUES ('" + txtProjectTitle.Text + "','" + txtSiteAddress.Text + "','" + cmbCustomer.SelectedIndex.ToString() + "'," +
                "'" + txtCommercialName.Text + "','" + txtCommercialNumber.Text + "','" + txtCommercialEmail.Text + "','" + txtCommercialPosition.Text + "'," +
                "'" + txtOnSiteName.Text + "','" + txtOnSiteNumber.Text + "','" + txtOnSiteEmail.Text + "','" + txtOnSitePosition.Text + "'," +
                "'" + txtAccountsName.Text + "','" + txtAccountsNumber.Text + "','" + txtAccountsEmail.Text + "','" + txtAccountsEmail.Text + "')"; 
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            MessageBox.Show("Project added!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            //refresh my form

                
        }
    }
}
