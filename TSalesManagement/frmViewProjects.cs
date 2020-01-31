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
            string sql = "SELECT * FROM dbo.projects";
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
            dataGridView1.Columns[3].HeaderText = "Customer";
            dataGridView1.Columns[4].HeaderText = "Commercial Contact Name";
            dataGridView1.Columns[5].HeaderText = "Commercial Phone Number";
            dataGridView1.Columns[6].HeaderText = "Commercial Email";
            dataGridView1.Columns[7].HeaderText = "Commercial Position";
            dataGridView1.Columns[8].HeaderText = "OnSite Contact Name";
            dataGridView1.Columns[9].HeaderText = "OnSite Phone Number";
            dataGridView1.Columns[10].HeaderText = "OnSite Email";
            dataGridView1.Columns[11].HeaderText = "Onsite Position";
            dataGridView1.Columns[12].HeaderText = "Accounts Contact Name";
            dataGridView1.Columns[13].HeaderText = "Accounts Phone Number";
            dataGridView1.Columns[14].HeaderText = "Accounts Email";
            dataGridView1.Columns[15].HeaderText = "Accounts Position";
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
