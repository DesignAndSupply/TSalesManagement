using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TSalesManagement
{
    public partial class frmLinkSector : Form
    {
        public string _custAccRef { get; set; }

        public frmLinkSector(string custAccRef)
        {
            InitializeComponent();
            _custAccRef = custAccRef;
            refreshCombo();
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            if (cmbSector.Text.Length > 0)
            {
                string sql = "SELECT id FROM dbo.tsalesmanager_customer_sector WHERE sector_name = '" + cmbSector.Text + "'";
                int sector_id = 0;
                using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
                {
                    conn.Open();
                    //first up grab the id of the sector
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        sector_id = Convert.ToInt32(cmd.ExecuteScalar());
                    //quickly check if it has had an entry before
                    sql = "SELECT id from dbo.view_tsalesmanager_sector WHERE cust_acc_ref = '" + _custAccRef + "'";
                    int insertOrUpdate = 0;
                    using (SqlCommand cmd3 = new SqlCommand(sql, conn))
                    {
                        var getData = cmd3.ExecuteScalar();
                        if (getData != null)
                        {
                            insertOrUpdate = -1;
                        }
                    }
                    if (insertOrUpdate == -1)
                        sql = "UPDATE dbo.tsalesmanager_sector_to_customer_link SET sector_id = " + sector_id.ToString() + " WHERE cust_acc_ref = '" + _custAccRef + "'";
                    else
                        sql = "INSERT INTO dbo.tsalesmanager_sector_to_customer_link (cust_acc_ref,sector_id) VALUES ('" + _custAccRef + "'," + sector_id.ToString() + " )";
                    using (SqlCommand cmd2 = new SqlCommand(sql, conn))
                    {
                        cmd2.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            this.Close();
        }

        private void lblSector_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddSector frm = new frmAddSector();
            frm.ShowDialog();
            refreshCombo();
        }

        private void refreshCombo()
        {
            cmbSector.Items.Clear();
            string sql = "SELECT sector_name FROM dbo.tsalesmanager_customer_sector";
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                        cmbSector.Items.Add(dr["sector_name"].ToString());
                    conn.Close();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}