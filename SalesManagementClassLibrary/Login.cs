using System;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using TSalesManagement;


namespace SalesManagementClassLibrary
{
    public class Login
    {

        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool adminUser { get; set; }
        public bool teamLeader { get; set; }

        public  Login(string user, string pass)
        {
            this.UserName = user;
            this.PassWord = pass;
        }

        private void ClearText(string user, string pass)
        {
            user = string.Empty;
            pass = string.Empty;
        }


        internal bool IsLoggedIn(string user, string pass)
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
                SqlCommand sqlCmd = new SqlCommand
                {
                    Connection = sqlConn,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "SELECT username, password from dbo.[user] WHERE username = @user and password = @pass"
                };

                sqlCmd.Parameters.AddWithValue("@user", user);
                sqlCmd.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read())
                {
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
