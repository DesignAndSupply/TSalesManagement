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
            fillGrid();
        }

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
    }
}
