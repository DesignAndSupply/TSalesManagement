using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using TSalesManagement.Class;

namespace TSalesManagement
{
    public partial class frmNewCustomer : Form
    {
        public frmNewCustomer()
        {
            InitializeComponent();

            //fill the combobox here
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            NewCustomer nc = new NewCustomer(txtAccRef.Text, txtName.Text, txtAdd1.Text, txtAdd2.Text, txtAdd3.Text, txtAdd4.Text, txtAdd5.Text, txtTel1.Text, txtTel2.Text, txtFax.Text);

            if (nc.validateAccRef() == false)
            {
                nc.addCustomer();

                //also add to tsalesmanager_customer_sector
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
                        sql = "INSERT INTO dbo.tsalesmanager_sector_to_customer_link (cust_acc_ref,sector_id) VALUES ('" + txtAccRef.Text + "'," + sector_id.ToString() + " )";
                        using (SqlCommand cmd2 = new SqlCommand(sql, conn))
                        {
                            cmd2.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("A customer in the Sales Ledger already uses this account reference. Please choose another to continue.", "Choose a different sales ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}