using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StartUpClass;

namespace TSalesManagement
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string passWord = txtPassword.Text;

            Login login = new Login("","");

            string user = txtUsername.Text;
            string pass = txtPassword.Text;


            if (login.IsLoggedIn(user, pass))
            {
              
                frmMainMenu form = new frmMainMenu();
                this.Hide();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Log in failed please try again!");
            }


        }
    }
}
