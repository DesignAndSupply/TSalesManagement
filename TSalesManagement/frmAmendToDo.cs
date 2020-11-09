using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StartUpClass;

namespace TSalesManagement
{
    public partial class frmAmendToDo : Form
    {
        public int _taskID { get; set; } // i think this i

        public frmAmendToDo(int tID)
        {
            Login.activityAdded = 0;
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

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            string customerAccRef = "";
            string sql = "SELECT [NAME] FROM [ToDo].dbo.c_view_task_list_crm WHERE [Task ID] = " + _taskID;
            using (SqlConnection zzz = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmdzz = new SqlCommand(sql,zzz))
                {
                    zzz.Open();
                    customerAccRef = Convert.ToString(cmdzz.ExecuteScalar());
                    zzz.Close();
                }
            }

                //first step we need to go and grab customer details (acc ref) 
            //    string customerAccRef = txtDetail.Text;
            //customerAccRef = customerAccRef.Substring(customerAccRef.IndexOf(":") + 2);
            //customerAccRef =  customerAccRef.Trim();
            //MessageBox.Show(customerAccRef);

            sql = "select ACCOUNT_REF from dbo.view_SALES_LEDGER_AND_PROSPECT WHERE [NAME] = '" + customerAccRef + "'";
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var getData = Convert.ToString(cmd.ExecuteScalar());
                    if (getData != null)
                        customerAccRef = getData;
                    else
                        customerAccRef = "ryucxd";
                    conn.Close();
                }
            }
            //MessageBox.Show(customerAccRef);
            //this needs to add an activity with a link to the task
            frmNewActivity frm = new frmNewActivity(customerAccRef,_taskID,-1);
            frm.ShowDialog();
            //after making the task prompt user for marking this task as complete

        }
    }
}