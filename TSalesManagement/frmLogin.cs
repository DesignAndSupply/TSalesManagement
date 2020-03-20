using StartUpClass;
using System;
using System.Windows.Forms;

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

            Login login = new Login("", "");

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

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.ActiveControl = txtPassword;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }
    }
}