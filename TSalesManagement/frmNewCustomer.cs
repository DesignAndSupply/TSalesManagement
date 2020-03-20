using System;
using System.Windows.Forms;
using TSalesManagement.Class;

namespace TSalesManagement
{
    public partial class frmNewCustomer : Form
    {
        public frmNewCustomer()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            NewCustomer nc = new NewCustomer(txtAccRef.Text, txtName.Text, txtAdd1.Text, txtAdd2.Text, txtAdd3.Text, txtAdd4.Text, txtAdd5.Text, txtTel1.Text, txtTel2.Text, txtFax.Text);

            if (nc.validateAccRef() == false)
            {
                nc.addCustomer();
                this.Close();
            }
            else
            {
                MessageBox.Show("A customer in the Sales Ledger already uses this account reference. Please choose another to continue.", "Choose a different sales ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}