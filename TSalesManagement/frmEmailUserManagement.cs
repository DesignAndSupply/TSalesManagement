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
using StartUpClass;

namespace TSalesManagement
{
    public partial class frmEmailUserManagement : Form
    {
        public string cmbName { get; set; }

        public frmEmailUserManagement(string passedCmbName)
        {
            InitializeComponent();
            cmbName = passedCmbName;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_TSalesManager_Email", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@user_id ", SqlDbType.Int).Value = cmbUser.SelectedValue;
            cmd.Parameters.Add("@text ", SqlDbType.NVarChar).Value = txtBody.Text;
            Login.userSelectedForEmail = Convert.ToString(cmbUser.SelectedValue);
            Login.dueDate = dateTimePicker1.Value;
            Login.customerText = txtBody.Text;
            
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Email Sent Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void FrmEmailUserManagement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'user_infoDataSet1.view_current_users_with_email' table. You can move, or remove it, as needed.
            this.view_current_users_with_emailTableAdapter.Fill(this.user_infoDataSet1.view_current_users_with_email);

            //here we set the current cmbbox to what was passed over c:
            int index = cmbUser.FindString(cmbName);
            cmbUser.SelectedIndex = index;
        }
    }
}
