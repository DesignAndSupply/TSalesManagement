using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using TSalesManagement;

namespace SalesManagementClassLibrary
{
    public  class Login
    {

        public  string UserName { get; set; }
        public  string PassWord { get; set; }
        private  bool aUser;
        private  bool tLeader;

        public  bool adminUser
        {
            get
                {
                return aUser;
                }
             set
                {
                aUser = value;
                }
        }

        public  bool teamLeader
        {
            get
            {
                return tLeader;
            }
            set
            {
                tLeader = value;
            }
        }

        public Login(string user, string pass)
        {

            this.UserName = user;
            this.PassWord = pass;
        }

        private void ClearText(string user, string pass)
        {
            user = string.Empty;
            pass = string.Empty;
        }

        public bool IsLoggedIn(string user, string pass)
        {
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Enter the user name!");
                return false;
            }
            else
            {
                ConnectionStrings connstring = new ConnectionStrings();
                SqlConnection sqlConn = new SqlConnection(connstring.connNameUser);
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlConn;
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.CommandText = "SELECT username, password, door_order_admin, super_user from dbo.[user] WHERE username = @user and password = @pass";

                sqlCmd.Parameters.AddWithValue("@user", user);
                sqlCmd.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read())
                {
                    if (Convert.ToInt16(reader["door_order_admin"]) == 1)
                    {
                        aUser = true;
                      
                    }
                    else
                    {
                        aUser = false;
                    }

                    if (Convert.ToInt16(reader["super_user"]) == 1)
                    {
                        tLeader = true;
                    }
                    else
                    {
                        tLeader = false;
                    }


                    return true;
                }
                else
                {
                    ClearText(user, pass);
                    return false;
                }
 

            }
        }

    }
}
