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
