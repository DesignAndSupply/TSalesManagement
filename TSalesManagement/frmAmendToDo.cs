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
    public partial class frmAmendToDo : Form
    {

        public int _taskID { get; set; }
        public frmAmendToDo(int tID)
        {
            InitializeComponent();
            _taskID = tID;
            fillData();
            fillGrid();
        }

        private void fillGrid()
        {
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionStringToDo))
            {
                using (SqlCommand cmd = new SqlCommand("Select [Note ID], [Note Date],[Note By],Detail FROM dbo.view_task_notes where [Task ID] = @taskID order by [Note Date] desc", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@taskID", _taskID);

                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();

                }
            }
            //some formatting heree
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void fillData()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionStringToDo);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT taskDetail from dbo.task where id=@id";
            cmd.Parameters.AddWithValue("@id", _taskID);


            SqlDataReader rdr = cmd.ExecuteReader();


            if (rdr.Read())
            {
                txtDetail.Text = rdr["taskDetail"].ToString();



            }

            rdr.Close();
            conn.Close();
        }

        private void FrmAmendToDo_Load(object sender, EventArgs e)
        {

        }
    }
}
