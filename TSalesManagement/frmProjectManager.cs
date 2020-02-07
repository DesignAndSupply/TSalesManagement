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
        public int _ID { get; set; }
        public string _title { get; set; }
        public string _customer { get; set; }
        public frmProjectManager(int ID, string title, string customer)
        {
            InitializeComponent();
            _ID = ID;
            _title = title;
            label1.Text = title;
            _customer = customer;
            this.Text = customer;
            check_chkbox();
        }

        private void check_chkbox()
        {
            int tender = 0, prelet = 0, design = 0, order = 0, survey = 0, on_site = 0, completion = 0, invoiced = 0, retention = 0;
            string sql = "SELECT tender_complete,prelet_complete,design_complete,order_complete,survey_complete,on_site_complete,completion_complete,invoiced_complete,retention_complete FROM dbo.projects WHERE ID = " + _ID;
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //reader in here 
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        tender = Convert.ToInt32(dr["tender_complete"]);
                        prelet = Convert.ToInt32(dr["prelet_complete"]);
                        design = Convert.ToInt32(dr["design_complete"]);
                        order = Convert.ToInt32(dr["order_complete"]);
                        survey = Convert.ToInt32(dr["survey_complete"]);
                        on_site = Convert.ToInt32(dr["on_site_complete"]);
                        completion = Convert.ToInt32(dr["completion_complete"]);
                        invoiced = Convert.ToInt32(dr["invoiced_complete"]);
                        retention = Convert.ToInt32(dr["retention_complete"]);
                    }
                    conn.Close();
                }
            }
            //now adjust check boxes
            if (tender == -1)
                chk_tender.Checked = true;
            if (prelet == -1)
                chk_prelet.Checked = true;
            if (design == -1)
                chk_design.Checked = true;
            if (order == -1)
                chk_Order.Checked = true;
            if (survey == -1)
                chk_Survey.Checked = true;
            if (on_site == -1)
                chk_onSite.Checked = true;
            if (completion == -1)
                chk_completion.Checked = true;
            if (invoiced == -1)
                chk_invoiced.Checked = true;
            if (retention == -1)
                chk_retention.Checked = true;

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

        private void btn_PDF_Click(object sender, EventArgs e)
        {
            create_folders();
            string folder = @"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_tender";
            frmPDF pdf = new frmPDF(folder);
            pdf.ShowDialog();
        }

        private void create_folders()
        { //this is universal so it will make all folders for each operation
            System.IO.Directory.CreateDirectory(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_tender");
            System.IO.Directory.CreateDirectory(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_prelet");
            System.IO.Directory.CreateDirectory(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_design");
            System.IO.Directory.CreateDirectory(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_order");
            System.IO.Directory.CreateDirectory(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_survey");
            System.IO.Directory.CreateDirectory(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_on_site");
            System.IO.Directory.CreateDirectory(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_completion");
            System.IO.Directory.CreateDirectory(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_invoiced");
            System.IO.Directory.CreateDirectory(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_retention");


        }

        private void button1_Click(object sender, EventArgs e) //tender openfolder
        {
            create_folders();
            System.Diagnostics.Process.Start(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_tender"); //open the root folder for /this/ project @ /current/ stage
        }

        private void txtCommercialName_Leave(object sender, EventArgs e)
        {
        }


        private void btnPreletOF_Click(object sender, EventArgs e)
        {
            create_folders();
            System.Diagnostics.Process.Start(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_prelet"); //open the root folder for /this/ project @ /current/ stage
        }

        private void btnDesignOF_Click(object sender, EventArgs e)
        {
            create_folders();
            System.Diagnostics.Process.Start(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_design"); //open the root folder for /this/ project @ /current/ stage
        }

        private void btnOrderOF_Click(object sender, EventArgs e)
        {
            create_folders();
            System.Diagnostics.Process.Start(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_order"); //open the root folder for /this/ project @ /current/ stage
        }

        private void btnSurveyOF_Click(object sender, EventArgs e)
        {
            create_folders();
            System.Diagnostics.Process.Start(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_survey"); //open the root folder for /this/ project @ /current/ stage
        }

        private void btnOnSiteOF_Click(object sender, EventArgs e)
        {
            create_folders();
            System.Diagnostics.Process.Start(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_on_site"); //open the root folder for /this/ project @ /current/ stage
        }

        private void btnCompOF_Click(object sender, EventArgs e)
        {
            create_folders();
            System.Diagnostics.Process.Start(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_completion"); //open the root folder for /this/ project @ /current/ stage
        }

        private void btnInvoiceOF_Click(object sender, EventArgs e)
        {
            create_folders();
            System.Diagnostics.Process.Start(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_invoiced"); //open the root folder for /this/ project @ /current/ stage
        }

        private void btnRetentionOF_Click(object sender, EventArgs e)
        {
            create_folders();
            System.Diagnostics.Process.Start(@"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_retention"); //open the root folder for /this/ project @ /current/ stage
        }

        private void btnPreletPDF_Click(object sender, EventArgs e)
        {
            create_folders();
            string folder = @"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_prelet"; //open PDF form and pass over the correct folder
            frmPDF pdf = new frmPDF(folder);
            pdf.ShowDialog();
        }

        private void btnDesignPDF_Click(object sender, EventArgs e)
        {
            create_folders();
            string folder = @"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_design";//open PDF form and pass over the correct folder
            frmPDF pdf = new frmPDF(folder);
            pdf.ShowDialog();
        }

        private void btnOrderPDF_Click(object sender, EventArgs e)
        {
            create_folders();
            string folder = @"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_order";//open PDF form and pass over the correct folder
            frmPDF pdf = new frmPDF(folder);
            pdf.ShowDialog();
        }

        private void btnSurveyPDF_Click(object sender, EventArgs e)
        {
            create_folders();
            string folder = @"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_survey";//open PDF form and pass over the correct folder
            frmPDF pdf = new frmPDF(folder);
            pdf.ShowDialog();
        }

        private void btnOnSitePDF_Click(object sender, EventArgs e)
        {
            create_folders();
            string folder = @"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_on_site";//open PDF form and pass over the correct folder
            frmPDF pdf = new frmPDF(folder);
            pdf.ShowDialog();
        }

        private void btnCompPDF_Click(object sender, EventArgs e)
        {
            create_folders();
            string folder = @"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_completion";//open PDF form and pass over the correct folder
            frmPDF pdf = new frmPDF(folder);
            pdf.ShowDialog();
        }

        private void btnInvoicePDF_Click(object sender, EventArgs e)
        {
            create_folders();
            string folder = @"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_invoiced";//open PDF form and pass over the correct folder
            frmPDF pdf = new frmPDF(folder);
            pdf.ShowDialog();
        }

        private void btnRetentionPDF_Click(object sender, EventArgs e)
        {
            create_folders();
            string folder = @"\\designsvr1\dropbox\Projects\" + _title + @"\" + _ID + @"_retention";//open PDF form and pass over the correct folder
            frmPDF pdf = new frmPDF(folder);
            pdf.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmProjectEdit frm = new frmProjectEdit(_ID, _customer, _title);
            frm.ShowDialog();
        }

        private void sqlStatement(string section)
        {
            string sql = "update dbo.projects SET [" + section + "] = -1 WHERE id = " + _ID;
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        private void chk_tender_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_tender_3.Checked == true)
            {
                sqlStatement("tender_complete");
                chk_tender.Enabled = false;
            }
            else
                chk_tender.Checked = false;
        }

        private void chk_tender_1_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("tender_1");
            chk_tender_1.Enabled = false;
        }

        private void chk_tender_2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_tender_1.Checked == true)
            {
                sqlStatement("tender_2");
                chk_tender_2.Enabled = false;
            }
            else
                chk_tender_2.Checked = false;
        }

        private void chk_tender_3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_tender_2.Checked == true)
            {
                sqlStatement("tender_3");
                chk_tender_3.Enabled = false;
            }
            else
                chk_tender_3.Checked = false;
        }

        private void chk_prelet_1_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("prelet_1");
            chk_prelet_1.Enabled = false;
        }

        private void chk_prelet_2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_prelet_1.Checked == true)
            {
                sqlStatement("prelet_2");
                chk_prelet_2.Enabled = false;
            }
            else
                chk_prelet_2.Checked = false;
        }

        private void chk_prelet_3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_prelet_2.Checked == true)
            {
                sqlStatement("prelet_3");
                chk_prelet_3.Enabled = false;
            }
            else
                chk_prelet_3.Checked = false;
        }

        private void chk_prelet_4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_prelet_3.Checked == true)
            {
                sqlStatement("prelet_4");
                chk_prelet_4.Enabled = false;
            }
            else
                chk_prelet_4.Checked = false;
        }

        private void chk_prelet_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_prelet_4.Checked == true)
            {
                sqlStatement("prelet_complete");
                chk_prelet.Enabled = false;
            }
            else
                chk_prelet.Checked = false;
        }

        private void chk_design_1_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("design_1");
            chk_design_1.Enabled = false;
        }

        private void chk_design_2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_design_1.Checked == true)
            {
                sqlStatement("design_2");
                chk_design_2.Enabled = false;
            }
            else
                chk_design_2.Checked = false;
        }

        private void chk_design_3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_design_2.Checked == true)
            {
                sqlStatement("design_3");
                chk_design_3.Enabled = false;
            }
            else
                chk_design_3.Checked = false;
        }

        private void chk_design_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_design_3.Checked == true)
            {
                sqlStatement("design_complete");
                chk_design.Enabled = false;
            }
            else
                chk_design.Checked = false;
        }

        private void chk_order_1_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("order_1");
            chk_order_1.Enabled = false;
        }

        private void chk_order_2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_order_1.Checked == true)
            {
                sqlStatement("order_2");
                chk_order_2.Enabled = false;
            }
            else
                chk_order_2.Checked = false;
        }

        private void chk_order_3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_order_2.Checked == true)
            {
                sqlStatement("order_3");
                chk_order_3.Enabled = false;
            }
            else
                chk_order_3.Checked = false;
        }

        private void chk_Order_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_order_3.Checked == true)
            {
                sqlStatement("order_complete");
                chk_Order.Enabled = false;
            }
            else
                chk_Order.Checked = false;
        }

        private void chk_survey_1_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("survey_1");
            chk_survey_1.Enabled = false;
        }

        private void chk_survey_2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_survey_1.Checked == true)
            {
                sqlStatement("survey_2");
                chk_survey_2.Enabled = false;
            }
            else
                chk_survey_2.Checked = false;
        }

        private void chk_survey_3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_survey_2.Checked == true)
            {
                sqlStatement("survey_3");
                chk_survey_3.Enabled = false;
            }
            else
                chk_survey_3.Checked = false;
        }

        private void chk_survey_4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_survey_3.Checked == true)
            {
                sqlStatement("survey_4");
                chk_survey_4.Enabled = false;
            }
            else
                chk_survey_4.Checked = false;
        }

        private void chk_survey_5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_survey_4.Checked == true)
            {
                sqlStatement("survey_5");
                chk_survey_5.Enabled = false;
            }
            else
                chk_survey_5.Checked = false;
        }

        private void chk_Survey_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_survey_5.Checked == true)
            {
                sqlStatement("survey_complete");
                chk_Survey.Enabled = false;
            }
            else
                chk_Survey.Checked = false;
        }

        private void chk_on_site_1_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("on_site_1");
            chk_on_site_1.Enabled = false;
        }

        private void chk_on_site_2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_on_site_1.Checked == true)
            {
                sqlStatement("on_site_2");
                chk_on_site_2.Enabled = false;
            }
            else
                chk_on_site_2.Checked = false;
        }

        private void chk_on_site_3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_on_site_2.Checked == true)
            {
                sqlStatement("on_site_3");
                chk_on_site_3.Enabled = false;
            }
            else
                chk_on_site_3.Checked = false;
        }

        private void chk_on_site_4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_on_site_3.Checked == true)
            {
                sqlStatement("on_site_4");
                chk_on_site_4.Enabled = false;
            }
            else
                chk_on_site_4.Checked = false;
        }

        private void chk_on_site_5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_on_site_4.Checked == true)
            {
                sqlStatement("on_site_5");
                chk_on_site_5.Enabled = false;
            }
            else
                chk_on_site_5.Checked = false;
        }

        private void chk_on_site_6_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_on_site_5.Checked == true)
            {
                sqlStatement("on_site_6");
                chk_on_site_6.Enabled = false;
            }
            else
                chk_on_site_6.Checked = false;
        }

        private void chk_onSite_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_on_site_6.Checked == true)
            {
                sqlStatement("on_site_complete");
                chk_onSite.Enabled = false;
            }
            else
                chk_onSite.Checked = false;
        }

        private void chk_completion_1_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("complete_1");
            chk_completion_1.Enabled = false;
        }

        private void chk_completion_2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_completion_1.Checked == true)
            {
                sqlStatement("complete_2");
                chk_completion_2.Enabled = false;
            }
            else
                chk_completion_2.Checked = false;
        }

        private void chk_completion_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_completion_2.Checked == true)
            {
                sqlStatement("completion_complete");
                chk_completion.Enabled = false;
            }
            else
                chk_completion.Checked = false;
        }

        private void chk_invoice_1_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("invoice_1");
            chk_invoice_1.Enabled = false;
        }

        private void chk_invoice_2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_invoice_1.Checked == true)
            {
                sqlStatement("invoice_2");
                chk_invoice_2.Enabled = false;
            }
            else
                chk_invoice_2.Checked = false;
        }

        private void chk_invoice_3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_invoice_2.Checked == true)
            {
                sqlStatement("invoice_3");
                chk_invoice_3.Enabled = false;
            }
            else
                chk_invoice_3.Checked = false;
        }

        private void chk_invoice_4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_invoice_3.Checked == true)
            {
                sqlStatement("invoice_4");
                chk_invoice_4.Enabled = false;
            }
            else
                chk_invoice_4.Checked = false;
        }

        private void chk_invoice_5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_invoice_4.Checked == true)
            {
                sqlStatement("invoice_5");
                chk_invoice_5.Enabled = false;
            }
            else
                chk_invoice_5.Checked = false;
        }

        private void chk_invoice_6_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_invoice_5.Checked == true)
            {
                sqlStatement("invoice_6");
                chk_invoice_6.Enabled = false;
            }
            else
                chk_invoice_6.Checked = false;
        }

        private void chk_invoice_7_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_invoice_6.Checked == true)
            {
                sqlStatement("invoice_7");
                chk_invoice_7.Enabled = false;
            }
            else
                chk_invoice_7.Checked = false;
        }

        private void chk_invoice_8_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_invoice_7.Checked == true)
            {
                sqlStatement("invoice_8");
                chk_invoice_8.Enabled = false;
            }
            else
                chk_invoice_8.Checked = false;
        }

        private void chk_invoice_9_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_invoice_8.Checked == true)
            {
                sqlStatement("invoice_9");
                chk_invoice_9.Enabled = false;
            }
            else
                chk_invoice_9.Checked = false;
        }

        private void chk_invoice_10_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_invoice_9.Checked == true)
            {
                sqlStatement("invoice_10");
                chk_invoice_10.Enabled = false;
            }
            else
                chk_invoice_10.Checked = false;
        }

        private void chk_invoiced_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_invoice_10.Checked == true)
            {
                sqlStatement("invoiced_complete");
                chk_invoiced.Enabled = false;
            }
            else
                chk_invoiced.Checked = false;
        }

        private void chk_retention_1_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("retention_1");
            chk_retention_1.Enabled = false;
        }

        private void chk_retention_2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_retention_1.Checked == true)
            {
                sqlStatement("retention_2");
                chk_retention_2.Enabled = false;
            }
            else
                chk_retention_2.Checked = false;
        }

        private void chk_retention_3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_retention_2.Checked == true)
            {
                sqlStatement("retention_3");
                chk_retention_3.Enabled = false;
            }
            else
                chk_retention_3.Checked = false;
        }

        private void chk_retention_4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_retention_3.Checked == true)
            {
                sqlStatement("retention_4");
                chk_retention_4.Enabled = false;
            }
            else
                chk_retention_4.Checked = false;
        }

        private void chk_retention_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_retention_4.Checked == true)
            {
                sqlStatement("retention_complete");
                chk_retention.Enabled = false;
            }
            else
                chk_retention.Checked = false;
        }
    }
}

