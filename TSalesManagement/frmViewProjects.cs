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
            string sql = "SELECT [id],[project_title],[customer_acc_ref],[project_manager]," +
                "CASE WHEN[tender_complete] = -1 then 'Complete' WHEN tender_complete = 1 THEN 'Part Complete' else ' ' END as tender_complete," +
                "CASE WHEN[prelet_complete] = -1 then 'Complete' WHEN prelet_complete = 1 THEN 'Part Complete' else ' ' END as prelet_complete," +
                "CASE WHEN[design_complete] = -1 then 'Complete' WHEN design_complete = 1 THEN 'Part Complete' else ' ' END as design_complete," +
                "CASE WHEN[order_complete] = -1 then 'Complete'   WHEN order_complete = 1 THEN 'Part Complete' else ' ' END as order_complete," +
                "CASE WHEN[survey_complete] = -1 then 'Complete' WHEN survey_complete = 1 THEN 'Part Complete' else ' ' END as survey_complete," +
                "CASE WHEN[on_site_complete] = -1 then 'Complete' WHEN on_site_complete = 1 THEN 'Part Complete' else ' ' END as on_site_complete," +
                "CASE WHEN[completion_complete] = -1 then 'Complete' WHEN completion_complete = 1 THEN 'Part Complete' else ' ' END as completeion_complete," +
                "CASE WHEN[invoiced_complete] = -1 then 'Complete' WHEN invoiced_complete = 1 THEN 'Part Complete' else ' ' END as invoice_complete," +
                "CASE WHEN[retention_complete] = -1 then 'Complete' WHEN retention_complete = 1 THEN 'Part Complete' else ' ' END as retention_complete " +
                "FROM [order_database].[dbo].[projects] ORDER BY [id] DESC";
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
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
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].HeaderText = "Customer";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].HeaderText = "Project Manager";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].HeaderText = "Tender";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].HeaderText = "Prelet";
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].HeaderText = "Design";
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].HeaderText = "Order";
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[8].HeaderText = "Survey";
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[9].HeaderText = "On site";
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[10].HeaderText = "Completion";
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[11].HeaderText = "Invoice";
            dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[12].HeaderText = "Retention";
            dataGridView1.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "Complete")
                    dataGridView1.Rows[i].Cells[4].Style.BackColor = Color.LightSeaGreen;
                if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "Complete")
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.LightSeaGreen;
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "Complete")
                    dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.LightSeaGreen;
                if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "Complete")
                    dataGridView1.Rows[i].Cells[7].Style.BackColor = Color.LightSeaGreen;
                if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "Complete")
                    dataGridView1.Rows[i].Cells[8].Style.BackColor = Color.LightSeaGreen;
                if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "Complete")
                    dataGridView1.Rows[i].Cells[9].Style.BackColor = Color.LightSeaGreen;
                if (dataGridView1.Rows[i].Cells[10].Value.ToString() == "Complete")
                    dataGridView1.Rows[i].Cells[10].Style.BackColor = Color.LightSeaGreen;
                if (dataGridView1.Rows[i].Cells[11].Value.ToString() == "Complete")
                    dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.LightSeaGreen;
                if (dataGridView1.Rows[i].Cells[12].Value.ToString() == "Complete")
                    dataGridView1.Rows[i].Cells[12].Style.BackColor = Color.LightSeaGreen;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "Part Complete")
                    dataGridView1.Rows[i].Cells[4].Style.BackColor = Color.Yellow;
                if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "Part Complete")
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.GreenYellow;
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "Part Complete")
                    dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.LightYellow;
                if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "Part Complete")
                    dataGridView1.Rows[i].Cells[7].Style.BackColor = Color.LightGoldenrodYellow;
                if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "Part Complete")
                    dataGridView1.Rows[i].Cells[8].Style.BackColor = Color.YellowGreen;
                if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "Part Complete")
                    dataGridView1.Rows[i].Cells[9].Style.BackColor = Color.Yellow;
                if (dataGridView1.Rows[i].Cells[10].Value.ToString() == "Part Complete")
                    dataGridView1.Rows[i].Cells[10].Style.BackColor = Color.Yellow;
                if (dataGridView1.Rows[i].Cells[11].Value.ToString() == "Part Complete")
                    dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                if (dataGridView1.Rows[i].Cells[12].Value.ToString() == "Part Yellow")
                    dataGridView1.Rows[i].Cells[12].Style.BackColor = Color.Yellow;

            }



            //add some colour


        }
        private void frmViewProjects_Load(object sender, EventArgs e)
        {
            format();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //get the ID of the row selected
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            int ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            string title = row.Cells[1].Value.ToString();
            string customer = row.Cells[2].Value.ToString();
            frmProjectManager PM = new frmProjectManager(ID, title,customer);
            PM.ShowDialog();
            refreshDGV();
            format();
        }

        private void refreshDGV()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            //onload of this form get info from dbo.project
            string sql = "SELECT [id],[project_title],[customer_acc_ref],[project_manager]," +
                "CASE WHEN[tender_complete] = -1 then 'Complete' WHEN tender_complete = 1 THEN 'Part Complete' else ' ' END as tender_complete," +
                "CASE WHEN[prelet_complete] = -1 then 'Complete' WHEN prelet_complete = 1 THEN 'Part Complete' else ' ' END as prelet_complete," +
                "CASE WHEN[design_complete] = -1 then 'Complete' WHEN design_complete = 1 THEN 'Part Complete' else ' ' END as design_complete," +
                "CASE WHEN[order_complete] = -1 then 'Complete'   WHEN order_complete = 1 THEN 'Part Complete' else ' ' END as order_complete," +
                "CASE WHEN[survey_complete] = -1 then 'Complete' WHEN survey_complete = 1 THEN 'Part Complete' else ' ' END as survey_complete," +
                "CASE WHEN[on_site_complete] = -1 then 'Complete' WHEN on_site_complete = 1 THEN 'Part Complete' else ' ' END as on_site_complete," +
                "CASE WHEN[completion_complete] = -1 then 'Complete' WHEN completion_complete = 1 THEN 'Part Complete' else ' ' END as completeion_complete," +
                "CASE WHEN[invoiced_complete] = -1 then 'Complete' WHEN invoiced_complete = 1 THEN 'Part Complete' else ' ' END as invoice_complete," +
                "CASE WHEN[retention_complete] = -1 then 'Complete' WHEN retention_complete = 1 THEN 'Part Complete' else ' ' END as retention_complete " +
                "FROM [order_database].[dbo].[projects] ORDER BY [id] DESC";
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
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
    }
}
