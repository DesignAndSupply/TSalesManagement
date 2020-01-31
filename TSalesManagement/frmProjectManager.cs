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
            axAcroPDF1.src = @"\\designsvr1\dropbox\calendar-2020-landscape-2-pages.pdf";
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
            //tender
            if ((chk_tender.Checked == true) && (tabControl1.SelectedTab == tabPage2))
            {
                tabControl1.SelectedTab = tabPage2;
            }
            else if ((chk_tender.Checked == false) && (tabControl1.SelectedTab == tabPage2))
            {
                tabControl1.SelectedTab = tabPage1;
            }
            //prelet
            if ((chk_prelet.Checked == true) && (tabControl1.SelectedTab == tabPage3))
            {
                tabControl1.SelectedTab = tabPage3;
            }
            else if ((chk_prelet.Checked == false) && (tabControl1.SelectedTab == tabPage3))
            {
                tabControl1.SelectedTab = tabPage1;
            }

            //design
            if ((chk_design.Checked == true) && (tabControl1.SelectedTab == tabPage4))
            {
                tabControl1.SelectedTab = tabPage4;
            }
            else if ((chk_design.Checked == false) && (tabControl1.SelectedTab == tabPage4))
            {
                tabControl1.SelectedTab = tabPage1;
            }

            //Order
            if ((chk_Order.Checked == true) && (tabControl1.SelectedTab == tabPage5))
            {
                tabControl1.SelectedTab = tabPage5;
            }
            else if ((chk_Order.Checked == false) && (tabControl1.SelectedTab == tabPage5))
            {
                tabControl1.SelectedTab = tabPage1;
            }

            //Survey
            if ((chk_Survey.Checked == true) && (tabControl1.SelectedTab == tabPage6))
            {
                tabControl1.SelectedTab = tabPage6;
            }
            else if ((chk_Survey.Checked == false) && (tabControl1.SelectedTab == tabPage6))
            {
                tabControl1.SelectedTab = tabPage1;
            }

            //On Site
            if ((chk_onSite.Checked == true) && (tabControl1.SelectedTab == tabPage7))
            {
                tabControl1.SelectedTab = tabPage7;
            }
            else if ((chk_onSite.Checked == false) && (tabControl1.SelectedTab == tabPage7))
            {
                tabControl1.SelectedTab = tabPage1;
            }

            //Completion 
            if ((chk_completion.Checked == true) && (tabControl1.SelectedTab == tabPage8))
            {
                tabControl1.SelectedTab = tabPage8;
            }
            else if ((chk_completion.Checked == false) && (tabControl1.SelectedTab == tabPage8))
            {
                tabControl1.SelectedTab = tabPage1;
            }

            //100% invoice
            if ((chk_invoiced.Checked == true) && (tabControl1.SelectedTab == tabPage9))
            {
                tabControl1.SelectedTab = tabPage9;
            }
            else if ((chk_invoiced.Checked == false) && (tabControl1.SelectedTab == tabPage9))
            {
                tabControl1.SelectedTab = tabPage1;
            }


        }
    }
}

