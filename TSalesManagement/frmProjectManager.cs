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
            int tender_comp = 0, tender_1 = 0, tender_2 = 0, tender_3 = 0;
            int prelet_comp = 0, prelet_1 = 0, prelet_2 = 0, prelet_3 = 0, prelet_4 = 0, prelet_5 = 0, prelet_6 = 0;
            int design_comp = 0, design_1 = 0, design_2 = 0, design_3 = 0;
            int order_comp = 0, order_1 = 0, order_2 = 0, order_3 = 0;
            int survey_comp = 0, survey_1 = 0, survey_2 = 0, survey_3 = 0, survey_4 = 0, survey_5 = 0;
            int on_site_comp = 0, on_site_1 = 0, on_site_2 = 0, on_site_3 = 0, on_site_4 = 0, on_site_5 = 0, on_site_6 = 0;
            int completion_comp = 0, completion_1 = 0, completion_2 = 0, completion_3 = 0;
            int invoiced_comp = 0, invoiced_1 = 0, invoiced_2 = 0, invoiced_3 = 0, invoiced_4 = 0, invoiced_5 = 0, invoiced_6 = 0, invoiced_7 = 0, invoiced_8 = 0, invoiced_9 = 0, invoiced_10 = 0;
            int retention_comp = 0, retention_1 = 0, retention_2 = 0, retention_3 = 0, retention_4 = 0;
            string tender_note = "", prelet_note = "", design_note = "", order_note = "", survey_note = "", on_site_note = "", invoice_note = "", complete_note = "", retention_note = "";
            string sql = "SELECT COALESCE(tender_1,0) as [tender_1],COALESCE(tender_2,0)as [tender_2],COALESCE(tender_3,0)as [tender_3],COALESCE(tender_complete,0) as [tender_complete]," +
                "COALESCE(prelet_1,0) as [prelet_1],COALESCE(prelet_2,0) as [prelet_2],COALESCE(prelet_3,0) as [prelet_3],COALESCE(prelet_4,0) as [prelet_4],COALESCE(prelet_5,0) as [prelet_5],COALESCE(prelet_6,0) as [prelet_6],COALESCE(prelet_complete,0) as [prelet_complete]," +
                "COALESCE(design_1,0) as [design_1],COALESCE(design_2,0) as [design_2],COALESCE(design_3,0) as [design_3],COALESCE(design_complete,0) as [design_complete]," +
                "COALESCE(order_1,0) as [order_1],COALESCE(order_2,0) as [order_2],COALESCE(order_3,0) as [order_3],COALESCE(order_complete,0) as [order_complete]," +
                "COALESCE(survey_1,0) as [survey_1],COALESCE(survey_2,0) as [survey_2],COALESCE(survey_3,0) as [survey_3],COALESCE(survey_4,0) as [survey_4],COALESCE(survey_5,0) as [survey_5],COALESCE(survey_complete,0) as [survey_complete]," +
                "COALESCE(on_site_1,0) as [on_site_1],COALESCE(on_site_2,0) as [on_site_2],COALESCE(on_site_3,0) as [on_site_3],COALESCE(on_site_4,0) as [on_site_4],COALESCE(on_site_5,0) as [on_site_5],COALESCE(on_site_6,0) as [on_site_6],COALESCE(on_site_complete,0) as [on_site_complete]," +
                "COALESCE(complete_1,0) as [complete_1],COALESCE(complete_2,0) as [complete_2],COALESCE(complete_3,0) as [complete_3],COALESCE(completion_complete,0) as [completion_complete]," +
                "COALESCE(invoice_1,0) as [invoice_1],COALESCE(invoice_2,0) as [invoice_2],COALESCE(invoice_3,0) as [invoice_3],COALESCE(invoice_4,0) as [invoice_4],COALESCE(invoice_5,0) as [invoice_5],COALESCE(invoice_6,0) as [invoice_6],COALESCE(invoice_7,0) as [invoice_7],COALESCE(invoice_8,0) as [invoice_8],COALESCE(invoice_9,0) as [invoice_9],COALESCE(invoice_10,0) as [invoice_10],COALESCE(invoiced_complete,0) as [invoiced_complete]," +
                "COALESCE(retention_1,0) as [retention_1],COALESCE(retention_2,0) as [retention_2],COALESCE(retention_3,0) as [retention_3],COALESCE(retention_4,0) as [retention_4],COALESCE(retention_complete ,0) as [retention_complete] ," +
                "COALESCE(tender_note,'') as [tender_note],COALESCE(prelet_note,'') as [prelet_note],COALESCE(design_note,'') as [design_note],COALESCE(order_note,'') as [order_note],COALESCE(survey_note,'') as [survey_note],COALESCE(on_site_note,'') as [on_site_note],COALESCE(complete_note,'') as [complete_note],COALESCE(invoice_note,'') as [invoice_note],COALESCE(retention_note,'') as [retention_note] FROM dbo.projects WHERE ID = " + _ID;
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //reader in here 
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        //tender
                        tender_1 = Convert.ToInt32(dr["tender_1"]);
                        tender_2 = Convert.ToInt32(dr["tender_2"]);
                        tender_3 = Convert.ToInt32(dr["tender_3"]);
                        tender_comp = Convert.ToInt32(dr["tender_complete"]);
                        tender_note = Convert.ToString(dr["tender_note"]);
                        //prelet
                        prelet_1 = Convert.ToInt32(dr["prelet_1"]);
                        prelet_2 = Convert.ToInt32(dr["prelet_2"]);
                        prelet_3 = Convert.ToInt32(dr["prelet_3"]);
                        prelet_4 = Convert.ToInt32(dr["prelet_4"]);
                        prelet_5 = Convert.ToInt32(dr["prelet_5"]);
                        prelet_6 = Convert.ToInt32(dr["prelet_6"]);
                        prelet_comp = Convert.ToInt32(dr["prelet_complete"]);
                        prelet_note = Convert.ToString(dr["prelet_note"]);
                        //design
                        design_1 = Convert.ToInt32(dr["design_1"]);
                        design_2 = Convert.ToInt32(dr["design_2"]);
                        design_3 = Convert.ToInt32(dr["design_3"]);
                        design_comp = Convert.ToInt32(dr["design_complete"]);
                        design_note = Convert.ToString(dr["design_note"]);
                        //order
                        order_1 = Convert.ToInt32(dr["order_1"]);
                        order_2 = Convert.ToInt32(dr["order_2"]);
                        order_3 = Convert.ToInt32(dr["order_3"]);
                        order_comp = Convert.ToInt32(dr["order_complete"]);
                        order_note = Convert.ToString(dr["order_note"]);
                        //survey
                        survey_1 = Convert.ToInt32(dr["survey_1"]);
                        survey_2 = Convert.ToInt32(dr["survey_2"]);
                        survey_3 = Convert.ToInt32(dr["survey_3"]);
                        survey_4 = Convert.ToInt32(dr["survey_4"]);
                        survey_5 = Convert.ToInt32(dr["survey_5"]);
                        survey_comp = Convert.ToInt32(dr["survey_complete"]);
                        survey_note = Convert.ToString(dr["Survey_note"]);
                        //on_site
                        on_site_1 = Convert.ToInt32(dr["on_site_1"]);
                        on_site_2 = Convert.ToInt32(dr["on_site_2"]);
                        on_site_3 = Convert.ToInt32(dr["on_site_3"]);
                        on_site_4 = Convert.ToInt32(dr["on_site_4"]);
                        on_site_5 = Convert.ToInt32(dr["on_site_5"]);
                        on_site_6 = Convert.ToInt32(dr["on_site_6"]);
                        on_site_comp = Convert.ToInt32(dr["on_site_complete"]);
                        on_site_note = Convert.ToString(dr["on_site_note"]);
                        //comp
                        completion_1 = Convert.ToInt32(dr["complete_1"]);
                        completion_2 = Convert.ToInt32(dr["complete_2"]);
                        completion_3 = Convert.ToInt32(dr["complete_3"]);
                        completion_comp = Convert.ToInt32(dr["completion_complete"]);
                        complete_note = Convert.ToString(dr["complete_note"]);
                        //invoiced
                        invoiced_1 = Convert.ToInt32(dr["invoice_1"]);
                        invoiced_2 = Convert.ToInt32(dr["invoice_2"]);
                        invoiced_3 = Convert.ToInt32(dr["invoice_3"]);
                        invoiced_4 = Convert.ToInt32(dr["invoice_4"]);
                        invoiced_5 = Convert.ToInt32(dr["invoice_5"]);
                        invoiced_6 = Convert.ToInt32(dr["invoice_6"]);
                        invoiced_7 = Convert.ToInt32(dr["invoice_7"]);
                        invoiced_8 = Convert.ToInt32(dr["invoice_8"]);
                        invoiced_9 = Convert.ToInt32(dr["invoice_9"]);
                        invoiced_10 = Convert.ToInt32(dr["invoice_10"]);
                        invoiced_comp = Convert.ToInt32(dr["invoiced_complete"]);
                        invoice_note = Convert.ToString(dr["invoice_note"]);
                        //retention
                        retention_1 = Convert.ToInt32(dr["retention_1"]);
                        retention_2 = Convert.ToInt32(dr["retention_2"]);
                        retention_3 = Convert.ToInt32(dr["retention_3"]);
                        retention_4 = Convert.ToInt32(dr["retention_4"]);
                        retention_comp = Convert.ToInt32(dr["retention_complete"]);
                        retention_note = Convert.ToString(dr["retention_note"]);
                    }
                    conn.Close();
                }
            }
            //now adjust check boxes
            //tender
            if (tender_1 == -1)
                chk_tender_1.Checked = true;
            if (tender_2 == -1)
                chk_tender_2.Checked = true;
            if (tender_3 == -1)
                chk_tender_3.Checked = true;
            if (tender_comp == -1)
                chk_tender.Checked = true;
            //prelet
            if (prelet_1 == -1)
                chk_prelet_1.Checked = true;
            if (prelet_2 == -1)
                chk_prelet_2.Checked = true;
            if (prelet_3 == -1)
                chk_prelet_3.Checked = true;
            if (prelet_4 == -1)
                chk_prelet_5.Checked = true;
            if (prelet_5 == -1)
                chk_prelet_5.Checked = true;
            if (prelet_6 == -1)
                chk_prelet_6.Checked = true;
            if (prelet_comp == -1)
                chk_prelet.Checked = true;
            //design
            if (design_1 == -1)
                chk_design_1.Checked = true;
            if (design_2 == -1)
                chk_design_2.Checked = true;
            if (design_3 == -1)
                chk_design_3.Checked = true;
            if (design_comp == -1)
                chk_design.Checked = true;
            //order
            if (order_1 == -1)
                chk_order_1.Checked = true;
            if (order_2 == -1)
                chk_order_2.Checked = true;
            if (order_3 == -1)
                chk_order_3.Checked = true;
            if (order_comp == -1)
                chk_Order.Checked = true;
            //survey
            if (survey_1 == -1)
                chk_survey_1.Checked = true;
            if (survey_2 == -1)
                chk_survey_2.Checked = true;
            if (survey_3 == -1)
                chk_survey_3.Checked = true;
            if (survey_4 == -1)
                chk_survey_4.Checked = true;
            if (survey_5 == -1)
                chk_survey_5.Checked = true;
            if (survey_comp == -1)
                chk_Survey.Checked = true;
            //on_site
            if (on_site_1 == -1)
                chk_on_site_1.Checked = true;
            if (on_site_2 == -1)
                chk_on_site_2.Checked = true;
            if (on_site_3 == -1)
                chk_on_site_3.Checked = true;
            if (on_site_4 == -1)
                chk_on_site_4.Checked = true;
            if (on_site_6 == -1)
                chk_on_site_6.Checked = true;
            if (on_site_comp == -1)
                chk_onSite.Checked = true;
            //comp
            if (completion_1 == -1)
                chk_completion_1.Checked = true;
            if (completion_2 == -1)
                chk_completion_2.Checked = true;
            if (completion_3 == -1)
                chk_completion_3.Checked = true;
            if (completion_comp == -1)
                chk_completion.Checked = true;
            //invoiced
            if (invoiced_1 == -1)
                chk_invoice_1.Checked = true;
            if (invoiced_2 == -1)
                chk_invoice_2.Checked = true;
            if (invoiced_3 == -1)
                chk_invoice_3.Checked = true;
            if (invoiced_4 == -1)
                chk_invoice_4.Checked = true;
            if (invoiced_5 == -1)
                chk_invoice_5.Checked = true;
            if (invoiced_6 == -1)
                chk_invoice_6.Checked = true;
            if (invoiced_7 == -1)
                chk_invoice_7.Checked = true;
            if (invoiced_8 == -1)
                chk_invoice_8.Checked = true;
            if (invoiced_9 == -1)
                chk_invoice_9.Checked = true;
            if (invoiced_10 == -1)
                chk_invoice_10.Checked = true;
            if (invoiced_comp == -1)
                chk_invoiced.Checked = true;
            //retention
            if (retention_1 == -1)
                chk_retention_1.Checked = true;
            if (retention_2 == -1)
                chk_retention_2.Checked = true;
            if (retention_3 == -1)
                chk_retention_3.Checked = true;
            if (retention_4 == -1)
                chk_retention_4.Checked = true;

            if (retention_comp == -1)
                chk_retention.Checked = true;


            //set the text boxes to the correct variables

            txtTender.Text = tender_note;
            txtPrelet.Text = prelet_note;
            txtDesign.Text = design_note;
            txtSurvey.Text = survey_note;
            txtOnSite.Text = on_site_note;
            txtOrder.Text = order_note;
            txtCompletion.Text = complete_note;
            txtInvoice.Text = invoice_note;
            txtRetention.Text = retention_note;

        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {



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
        {//if string does not include "complete" then set compelte of that section to 1 instead of minus 1
            string sql = "";
            if (section.Contains("complete") == true)
                sql = "update dbo.projects SET [" + section + "] = -1 WHERE id = " + _ID;
            else
            { //format for every single one....
                if (section.Contains("tender") == true)
                    sql = "update dbo.projects SET[" + section + "] = -1, [tender_complete] = 1 WHERE id = " + _ID;
                if (section.Contains("prelet") == true)
                    sql = "update dbo.projects SET[" + section + "] = -1, [prelet_complete] = 1 WHERE id = " + _ID;
                if (section.Contains("design") == true)
                    sql = "update dbo.projects SET[" + section + "] = -1, [design_complete] = 1 WHERE id = " + _ID;
                if (section.Contains("order") == true)
                    sql = "update dbo.projects SET[" + section + "] = -1, [order_complete] = 1 WHERE id = " + _ID;
                if (section.Contains("survey") == true)
                    sql = "update dbo.projects SET[" + section + "] = -1, [survey_complete] = 1 WHERE id = " + _ID;
                if (section.Contains("on_site") == true)
                    sql = "update dbo.projects SET[" + section + "] = -1, [on_site_complete] = 1 WHERE id = " + _ID;
                if (section.Contains("complete") == true)
                    sql = "update dbo.projects SET[" + section + "] = -1, [completion_complete] = 1 WHERE id = " + _ID;
                if (section.Contains("invoice") == true)
                    sql = "update dbo.projects SET[" + section + "] = -1, [invoiced_complete] = 1 WHERE id = " + _ID;
                if (section.Contains("retention") == true)
                    sql = "update dbo.projects SET[" + section + "] = -1, [retention_complete] = 1 WHERE id = " + _ID;

            }

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
            if (chk_tender_1.Checked == true && chk_tender_2.Checked == true && chk_tender_3.Checked == true)  //maybe check to ensure they are all fine etc
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
            sqlStatement("tender_2");
            chk_tender_2.Enabled = false;
        }

        private void chk_tender_3_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("tender_3");
            chk_tender_3.Enabled = false;

        }

        private void chk_prelet_1_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("prelet_1");
            chk_prelet_1.Enabled = false;
        }

        private void chk_prelet_2_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("prelet_2");
            chk_prelet_2.Enabled = false;
        }

        private void chk_prelet_3_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("prelet_3");
            chk_prelet_3.Enabled = false;
        }

        //private void chk_prelet_4_CheckedChanged(object sender, EventArgs e)   //this was a mistake meaning that #4 is free but i dont ever want to move 5+6 again so its staying null forever :)
        //{
        //        sqlStatement("prelet_4");
        //        chk_prelet_4.Enabled = false;
        //}
        private void chk_prelet_5_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("prelet_5");
            chk_prelet_5.Enabled = false;
        }
        private void chk_prelet_6_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("prelet_6");
            chk_prelet_6.Enabled = false;
        }

        private void chk_prelet_CheckedChanged(object sender, EventArgs e) //check /1/2/3/5/6/
        {
            if (chk_prelet_1.Checked == true && chk_prelet_2.Checked == true && chk_prelet_3.Checked == true && chk_prelet_5.Checked == true && chk_prelet_6.Checked == true)
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
            sqlStatement("design_2");
            chk_design_2.Enabled = false;
        }

        private void chk_design_3_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("design_3");
            chk_design_3.Enabled = false;
        }

        private void chk_design_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_design_1.Checked == true && chk_design_2.Checked == true && chk_design_3.Checked == true)
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
            sqlStatement("order_2");
            chk_order_2.Enabled = false;
        }

        private void chk_order_3_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("order_3");
            chk_order_3.Enabled = false;
        }

        private void chk_Order_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_order_1.Checked == true && chk_order_2.Checked == true && chk_order_3.Checked == true)
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
            sqlStatement("survey_2");
            chk_survey_2.Enabled = false;
        }

        private void chk_survey_3_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("survey_3");
            chk_survey_3.Enabled = false;
        }

        private void chk_survey_4_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("survey_4");
            chk_survey_4.Enabled = false;
        }

        private void chk_survey_5_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("survey_5");
            chk_survey_5.Enabled = false;
        }

        private void chk_Survey_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_survey_1.Checked == true && chk_survey_2.Checked == true && chk_survey_3.Checked == true && chk_survey_4.Checked == true && chk_survey_5.Checked == true)
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
            sqlStatement("on_site_2");
            chk_on_site_2.Enabled = false;
        }

        private void chk_on_site_3_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("on_site_3");
            chk_on_site_3.Enabled = false;
        }

        private void chk_on_site_4_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("on_site_4");
            chk_on_site_4.Enabled = false;
        }


        private void chk_on_site_6_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("on_site_6");
            chk_on_site_6.Enabled = false;
        }

        private void chk_onSite_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_on_site_1.Checked == true && chk_on_site_2.Checked == true && chk_on_site_3.Checked == true && chk_on_site_4.Checked == true && chk_on_site_6.Checked == true)
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
            sqlStatement("complete_2");
            chk_completion_2.Enabled = false;
        }
        private void chk_completion_3_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("complete_3");
            chk_completion_3.Enabled = false;

        }

        private void chk_completion_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_completion_1.Checked == true && chk_completion_2.Checked == true && chk_completion_3.Checked == true)
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
            sqlStatement("invoice_2");
            chk_invoice_2.Enabled = false;
        }

        private void chk_invoice_3_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("invoice_3");
            chk_invoice_3.Enabled = false;
        }

        private void chk_invoice_4_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("invoice_4");
            chk_invoice_4.Enabled = false;
        }

        private void chk_invoice_5_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("invoice_5");
            chk_invoice_5.Enabled = false;
        }

        private void chk_invoice_6_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("invoice_6");
            chk_invoice_6.Enabled = false;
        }

        private void chk_invoice_7_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("invoice_7");
            chk_invoice_7.Enabled = false;
        }

        private void chk_invoice_8_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("invoice_8");
            chk_invoice_8.Enabled = false;
        }

        private void chk_invoice_9_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("invoice_9");
            chk_invoice_9.Enabled = false;
        }

        private void chk_invoice_10_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("invoice_10");
            chk_invoice_10.Enabled = false;
        }

        private void chk_invoiced_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_invoice_1.Checked == true && chk_invoice_2.Checked == true && chk_invoice_3.Checked == true && chk_invoice_4.Checked == true && chk_invoice_5.Checked == true && chk_invoice_6.Checked == true && chk_invoice_7.Checked == true && chk_invoice_8.Checked == true && chk_invoice_9.Checked == true && chk_invoice_10.Checked == true)
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
            sqlStatement("retention_2");
            chk_retention_2.Enabled = false;
        }

        private void chk_retention_3_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("retention_3");
            chk_retention_3.Enabled = false;
        }

        private void chk_retention_4_CheckedChanged(object sender, EventArgs e)
        {
            sqlStatement("retention_4");
            chk_retention_4.Enabled = false;
        }

        private void chk_retention_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_retention_1.Checked == true && chk_retention_2.Checked == true && chk_retention_3.Checked == true && chk_retention_4.Checked == true)
            {
                sqlStatement("retention_complete");
                chk_retention.Enabled = false;
            }
            else
                chk_retention.Checked = false;
        }

        //to save writing the same update statement constantly....

        private void noteUpdate(string location,string txt)
        {
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                string sql = "UPDATE dbo.projects SET " + location + "_note = '" + txt + "' WHERE ID = " + _ID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void btnTenderNotes_Click(object sender, EventArgs e)
        {
            noteUpdate("tender", txtTender.Text);
            MessageBox.Show("Tender notes has been updated!");
            //refresh note? or is there no need?
        }

        private void btnPreletNotes_Click(object sender, EventArgs e)
        {
            noteUpdate("prelet", txtPrelet.Text);
            MessageBox.Show("Prelet notes have been updated!");
        }

        private void btnDesignNotes_Click(object sender, EventArgs e)
        {
            noteUpdate("design", txtDesign.Text);
            MessageBox.Show("Design notes have been updated!");
        }

        private void btnOrderNotes_Click(object sender, EventArgs e)
        {
            noteUpdate("order", txtOrder.Text);
            MessageBox.Show("Order notes have been updated");
        }

        private void btnSurveyNotes_Click(object sender, EventArgs e)
        {
            noteUpdate("survey", txtSurvey.Text);
            MessageBox.Show("Survey notes have been updated!");
        }

        private void btnOnSiteNotes_Click(object sender, EventArgs e)
        {
            noteUpdate("on_site", txtOnSite.Text);
            MessageBox.Show("On site notes have been updated!");
        }

        private void btnCompletionNotes_Click(object sender, EventArgs e)
        {
            noteUpdate("complete", txtCompletion.Text);
            MessageBox.Show("Complete notes have been updated!");
        }

        private void btnInvoicedNotes_Click(object sender, EventArgs e)
        {
            noteUpdate("invoice", txtInvoice.Text);
            MessageBox.Show("Invoice Notes have been updated!");
        }

        private void btnRetentionNotes_Click(object sender, EventArgs e)
        {
            noteUpdate("retention", txtRetention.Text);
            MessageBox.Show("Retention notes have been updated!");
        }
    }
}

