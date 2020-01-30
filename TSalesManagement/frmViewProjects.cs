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
            string sql = "SELECT * FROM dbo.project";
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
        }

        private void frmViewProjects_Load(object sender, EventArgs e)
        {

        }
    }
}
