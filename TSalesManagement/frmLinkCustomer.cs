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
    public partial class frmLinkCustomer : Form
    {
        public static int customerLinked { get; set; }
        public int _taskID { get; set; }
        public frmLinkCustomer(int taskID)
        {
            InitializeComponent();
            refreshCombo();

            _taskID = taskID;

        }


        private void refreshCombo()
        {
            cmbCustomer.Items.Clear();
            string sql = "SELECT [NAME] FROM dbo.view_SALES_LEDGER_AND_PROSPECT";
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                        cmbCustomer.Items.Add(dr["NAME"].ToString());
                    conn.Close();
                }
            }
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            //this needs to update crmAccRef in dbo.task i think :}
            //first we need to get the accRef
            string accRef = "";
            string sql = "SELECT ACCOUNT_REF FROM dbo.view_SALES_LEDGER_AND_PROSPECT WHERE [NAME] = '" + cmbCustomer.Text + "'";
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    accRef = cmd.ExecuteScalar().ToString();
                }

                if (accRef.Length < 1)
                {
                    MessageBox.Show("Please select a customer from the list before proceeding");
                    return;
                }
                sql = "UPDATE [ToDo].dbo.task SET crmCustAccRef = '" + accRef + "' WHERE id = " + _taskID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                customerLinked = -1;
                
                this.Close();
            }
        }

        private void lblNewCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNewCustomer frm = new frmNewCustomer();
            frm.ShowDialog();
            refreshCombo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customerLinked = 0;
            this.Close();
        }

        private void frmLinkCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            customerLinked = 0;
        }
    }
}
