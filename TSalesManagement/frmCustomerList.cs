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
    public partial class frmCustomerList : Form
    {
        public frmCustomerList()
        {
            InitializeComponent();
            //dgvCustomer.CellDoubleClick += dgvCustomer_CellDoubleClick;
            fillGrid();
        }

        private string custAccRef;
        private string custName;

        private void frmCustomerList_Load(object sender, EventArgs e)
        {

        }


        private void fillGrid()
        {
            SqlConnection con = new SqlConnection(SqlStatements.ConnectionString);

 

            //UPDATES THE PAINT TO DOOR DATAGRID
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From dbo.c_sales_view_customer_data where [Customer Name] like @custName";
            cmd.Parameters.AddWithValue("@custName","%" + txtCustName.Text + "%");
            SqlDataAdapter adap = new SqlDataAdapter(cmd);


            try
            {

                DataTable dt = new DataTable();
                adap.Fill(dt);
                dgvCustomer.DataSource = dt;

            }
            catch (Exception)
            {
               
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustName.Text = "";
            fillGrid();
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvCustomer.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvCustomer.Rows[selectedrowindex];

                custAccRef= selectedRow.Cells["Account Ref"].Value.ToString();
                custName = selectedRow.Cells["Customer Name"].Value.ToString();


                frmCustomerInformation frmCI = new frmCustomerInformation(custAccRef, custName);
                frmCI.ShowDialog();
                //fillGrid();


            }



           
                
            





        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            frmNewCustomer frmNC = new frmNewCustomer();
            frmNC.ShowDialog();
            fillGrid();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCustName_TextChanged(object sender, EventArgs e)
        {
            fillGrid();
        }
    }
}
