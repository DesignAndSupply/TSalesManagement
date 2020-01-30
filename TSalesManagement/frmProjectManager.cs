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
    public partial class frmProjectManager : Form
    {
        public frmProjectManager(int ID)
        {
            InitializeComponent();
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_tender_complete.Checked == true)
            {
                if (chk_prelet.Checked == true)
                {
                    if (chk_design.Checked == true)
                    {
                        if (chk_Order.Checked == true)
                        {
                            if (chk_Survey.Checked == true)
                            {
                                if (chk_SOS.Checked == true)
                                {
                                    // do nothing
                                }
                                else
                                    tabControl1.SelectedIndex = 5;
                            }
                            else
                                tabControl1.SelectedIndex = 4;
                        }
                        else
                            tabControl1.SelectedIndex = 3;
                    }
                    else
                        tabControl1.SelectedIndex = 2;
                }
                else
                    tabControl1.SelectedIndex = 1;
            }
            else
                tabControl1.SelectedIndex = 0;
        }
    }
}

