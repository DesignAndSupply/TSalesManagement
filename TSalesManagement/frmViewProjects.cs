using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TSalesManagement
{
    public partial class frmViewProjects : Form
    {
        public frmViewProjects()
        {
            InitializeComponent();
            //onload of this form get info from dbo.project
            string sql = "SELECT [id],[project_title],[site_address]," +
                "CASE WHEN[tender_complete] = -1 then 'Complete' else ' ' END as tender_complete," +
                "CASE WHEN[prelet_complete] = -1 then 'Complete' else ' ' END as prelet_complete," +
                "CASE WHEN[design_complete] = -1 then 'Complete' else ' ' END as design_complete," +
                "CASE WHEN[order_complete] = -1 then 'Complete'  else ' ' END as order_complete," +
                "CASE WHEN[survey_complete] = -1 then 'Complete' else ' ' END as survey_complete," +
                "CASE WHEN[on_site_complete] = -1 then 'Complete' else ' ' END as on_site_complete," +
                "CASE WHEN[completion_complete] = -1 then 'Complete' else ' ' END as completeion_complete," +
                "CASE WHEN[invoiced_complete] = -1 then 'Complete' else ' ' END as invoice_complete," +
                "CASE WHEN[retention_complete] = -1 then 'Complete' else ' ' END as retention_complete " +
                "FROM [order_database].[dbo].[projects]";
            using  (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            format();
        }

        private void format()
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Project Title";
            dataGridView1.Columns[2].HeaderText = "Site Address";
            dataGridView1.Columns[3].HeaderText = "Tender";
            dataGridView1.Columns[4].HeaderText = "Prelet";
            dataGridView1.Columns[5].HeaderText = "Design";
            dataGridView1.Columns[6].HeaderText = "Order";
            dataGridView1.Columns[7].HeaderText = "Survey";
            dataGridView1.Columns[8].HeaderText = "On site";
            dataGridView1.Columns[9].HeaderText = "Completion";
            dataGridView1.Columns[10].HeaderText = "Invoice";
            dataGridView1.Columns[11].HeaderText = "Retention";
        }
        private void frmViewProjects_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //get the ID of the row selected
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            int ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            string title = row.Cells[1].Value.ToString();
            frmProjectManager PM = new frmProjectManager(ID,title);
            PM.ShowDialog();
        }
    }
}
