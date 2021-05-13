using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using StartUpClass;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TSalesManagement
{
    public partial class frmActivityNote : Form
    {
        public int activityID { get; set; }
        public frmActivityNote(int activiy_id)
        {
            InitializeComponent();
            activityID = activiy_id;
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                conn.Open();
                int sender_id = 0;
                int email_id = 0;
                int validation = 0;
                int same = 0;
                string sql = "SELECT sender_id FROM dbo.crm_activity WHERE id = " + activityID.ToString();
                using (SqlCommand command = new SqlCommand(sql, conn))
                    sender_id = Convert.ToInt32(command.ExecuteScalar());

                //this should be enough to determine if the logged in user is the same as the activity owner
                
               


                    sql = "INSERT INTO dbo.crm_activity_notes (activityID,noteDate,detail,noteByID,noteBy) VALUES(" + activityID.ToString() + ", GETDATE(),'" + txtNote.Text + "'," + Login.globalUserID.ToString() + ",'" + Login.globalFullName.ToString() + "')";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();


                //I think from here we need to check if the person logged in is the inital recievier of the activity > if they are then check if there was a note from someoneelse
                if (sender_id == Login.globalUserID) 
                    same = -1;

                if (same == -1)
                {
                    //we need to find the next user who entered a note and grab their id (if they exist)
                    sql = "SELECT TOP 1 noteByID FROM dbo.crm_activity_notes where activityID = " + activityID.ToString() + " AND noteByID <> " + sender_id + " ORDER BY noteID DESC";
                    using (SqlCommand senderCMD = new SqlCommand(sql, conn))
                    { //usp_crm_activity_notification_email
                        var getdata = senderCMD.ExecuteScalar(); //for checking if it returns anything
                        if (getdata != null)
                        {
                            validation = -1;
                            email_id = Convert.ToInt32(getdata); //we email this user isntead
                            //MessageBox.Show(email_id.ToString());

                            using (SqlCommand command = new SqlCommand("usp_crm_activity_notification_email", conn))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.Add("@activityID", SqlDbType.Int).Value = activityID;
                                command.Parameters.Add("@emailID", SqlDbType.Int).Value = email_id;
                                command.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            validation = 0; //there is no one to email?
                            MessageBox.Show("email no one");
                        }
                    }    
                }
                else
                {
                    //they are not the same so we can email the original user without worrying
                  //  MessageBox.Show(sender_id.ToString());
                    using (SqlCommand command = new SqlCommand("usp_crm_activity_notification_email", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@activityID", SqlDbType.Int).Value = activityID;
                        command.Parameters.Add("@emailID", SqlDbType.Int).Value = sender_id;
                        command.ExecuteNonQuery();
                    }
                }

               
                
                conn.Close();
            }
            this.Close();
        }
    }
}
