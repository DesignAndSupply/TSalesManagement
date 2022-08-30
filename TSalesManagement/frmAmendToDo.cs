using StartUpClass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TSalesManagement
{
    public partial class frmAmendToDo : Form
    {
        public int _taskID { get; set; } // i think this i
        public string customerAccRef { get; set; }
        public int validation { get; set; }

        public frmAmendToDo(int tID)
        {
            Login.activityAdded = 0;
            InitializeComponent();
            _taskID = tID;
            fillData();
            fillGrid();

            getCustAccRef();
        }

        private void getCustAccRef()
        {
            //im moving this here from the add activity button to make things cleaner (and also to fire this on formload)

            string sql = "SELECT [NAME] FROM [ToDo].dbo.c_view_task_list_crm WHERE [Task ID] = " + _taskID;
            using (SqlConnection zzz = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmdzz = new SqlCommand(sql, zzz))
                {
                    zzz.Open();
                    var getData = Convert.ToString(cmdzz.ExecuteScalar());
                    if (getData != null && getData != "")
                    {
                        customerAccRef = Convert.ToString(cmdzz.ExecuteScalar());
                    }
                    else
                    {
                        validation = 0;
                        return;
                    }
                    zzz.Close();
                }
            }
            sql = "select ACCOUNT_REF from dbo.view_SALES_LEDGER_AND_PROSPECT WHERE [NAME] = '" + customerAccRef + "'";
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var getData = Convert.ToString(cmd.ExecuteScalar());
                    if (getData != null && getData != "")
                    {
                        customerAccRef = getData;
                        validation = -1;
                    }
                    else
                    {
                        customerAccRef = "ryucxd";
                        validation = 0;
                    }
                    conn.Close();
                }
            }
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
            if (validation == 0)
            {
                MessageBox.Show("This task needs to be linked to a customer before you can create an activity!");
                frmLinkCustomer frm2 = new frmLinkCustomer(_taskID);
                frm2.ShowDialog();
                validation = frmLinkCustomer.customerLinked;
                if (validation == -1)
                {
                    getCustAccRef();
                    frmNewActivity frm = new frmNewActivity(customerAccRef, _taskID, -1);
                    frm.ShowDialog();
                }
            }
            else
            {
                //MessageBox.Show(customerAccRef);
                //this needs to add an activity with a link to the task
                frmNewActivity frm = new frmNewActivity(customerAccRef, _taskID, -1);
                frm.ShowDialog();

                if (Login.activityAdded == -1)
                {
                    //quickly link up the tasks
                    string sql = "SELECT MAX(id) FROM dbo.crm_activity ";
                    int activityID = 0;
                    using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            activityID = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        // link the activity id to the task id
                        sql = "UPDATE [todo].dbo.task SET crm_activity_link = " + activityID + " WHERE id = " + _taskID;
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                //after making the task prompt user for marking this task as complete
            }
        }
    }
}