using StartUpClass;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TSalesManagement
{
    public partial class frmEmailUserManagement : Form
    {
        public string cmbName { get; set; }

        public frmEmailUserManagement(string passedCmbName)
        {
            InitializeComponent();
            cmbName = passedCmbName; // this is passed over from the other form, whoever is selected (to view their tasks etc)
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            Login.emailButtonClicked = 1;
            //ok gonna use this space to  get the user ID
            int cmbNameID;
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select id from [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbName.ToString() + "'", conn))
                {
                    conn.Open();
                    cmbNameID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                    Login.selectedUserID = cmbNameID;
                }
            }
            Login.dueDate = dateTimePicker1.Value;
            txtBody.Text = txtBody.Text.Replace("'", "");
            Login.customerText = txtBody.Text;

            //need to move this code because its not longer being used here, will need to be after uploadListToTempTable
            //SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);

            //conn.Open();
            //SqlCommand cmd = new SqlCommand("usp_TSalesManager_Email", conn); // i think i need to move this to the form prior

            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@user_id ", SqlDbType.Int).Value = cmbUser.SelectedValue;
            //cmd.Parameters.Add("@text ", SqlDbType.NVarChar).Value = txtBody.Text;
            //Login.userSelectedForEmail = Convert.ToString(cmbUser.SelectedValue);

            //cmd.ExecuteNonQuery();
            //conn.Close();

            //MessageBox.Show("Email Sent Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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