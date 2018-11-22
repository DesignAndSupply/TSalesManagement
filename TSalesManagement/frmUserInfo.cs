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
    public partial class frmUserInfo : Form
    {
        public frmUserInfo()
        {
            InitializeComponent();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_sales_program_users' table. You can move, or remove it, as needed.
            this.c_view_sales_program_usersTableAdapter.Fill(this.user_infoDataSet.c_view_sales_program_users);
            //cmbStaff.SelectedIndex = -1;
        }

        private void fillGrid()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            string test;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            StringBuilder sb = new StringBuilder("SELECT id as 'Pipeline ID',[Customer Name], door_style as 'Door Style', order_ref as 'Order Reference', estimated_order_date as 'Estimated date of order', added_by_id as 'Added by', date_added as 'Added on', estimated_order_value as 'Estimated Value', order_status as 'Status' FROM c_view_sales_pipeline_text where added_by_id =@user ");

            //If filter on order status is selected
            if (string.IsNullOrWhiteSpace(cmbSearchStatus.Text))
            {
                
            }
            else
            {
                sb.Append(" AND order_status = @oStatus " );
            }


            //If filter on customer is selected
            if (string.IsNullOrWhiteSpace(txtCustomerSearch.Text))
            {

            }
            else
            {
                sb.Append(" AND [Customer Name] = @cust ");
            }

            test = sb.ToString();
            //MessageBox.Show(test);

            sb.Append(" order by date_added DESC");


            
            //-------------
            cmd.CommandText = sb.ToString();
            cmd.Parameters.AddWithValue("@user", cmbStaff.Text);
            //----------

            //Non mandatory filters

            if (string.IsNullOrWhiteSpace(cmbSearchStatus.Text))
            {
                
            }
            else
            {
                cmd.Parameters.AddWithValue("@oStatus", cmbSearchStatus.Text);
            }
            //If filter on customer is selected
            if (string.IsNullOrWhiteSpace(txtCustomerSearch.Text))
            {

            }
            else
            {
                cmd.Parameters.AddWithValue("@cust", "%" + txtCustomerSearch.Text + "%");
            }


            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            // try
            //{
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgPipeline.DataSource = dt;

            dgPipeline.Columns["Estimated Value"].DefaultCellStyle.Format = "c";
            //}
            //catch (Exception)
            //{

            //}

            paintGrid();
        }


        private void paintGrid()
        {
        

            foreach (DataGridViewRow row in dgPipeline.Rows)
            {


                try
                {
                    if (row.Cells["Status"].Value.ToString() == "Ordered")
                    {
                        row.Cells["Pipeline ID"].Style.BackColor = Color.LawnGreen;
                        row.Cells["Customer Name"].Style.BackColor = Color.LawnGreen;
                        row.Cells["Door Style"].Style.BackColor = Color.LawnGreen;
                        row.Cells["Order Reference"].Style.BackColor = Color.LawnGreen;
                        row.Cells["Estimated date of order"].Style.BackColor = Color.LawnGreen;
                        row.Cells["Added By"].Style.BackColor = Color.LawnGreen;
                        row.Cells["Added on"].Style.BackColor = Color.LawnGreen;
                        row.Cells["Estimated Value"].Style.BackColor = Color.LawnGreen;
                        row.Cells["Status"].Style.BackColor = Color.LawnGreen;
                    }
                    else if (row.Cells["Status"].Value.ToString() == "Lost")
                    {
                        row.Cells["Pipeline ID"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Customer Name"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Door Style"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Order Reference"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Estimated date of order"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Added By"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Added on"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Estimated Value"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Status"].Style.BackColor = Color.PaleVioletRed;


                    }
                }
                catch
                {

                }
                    
                }
               
            
        }

        private void fillActivityGrid()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT id,[Customer Name],[Activity Date], date_modified as [Last Updated],Type,reference,Details,Contact,[Logged By] from dbo.c_sales_view_activity_list where [Logged By] = @sender order by  [Activity Date] desc";

            cmd.Parameters.AddWithValue("@sender", cmbStaff.Text);

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            //try
            // {
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgActivity.DataSource = dt;


            //}
            // catch (Exception)
            //{

            //}

        }





        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid();
            fillActivityGrid();
        }


        private void dgPipeline_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pID;
            if (dgPipeline.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgPipeline.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgPipeline.Rows[selectedrowindex];

                pID = Convert.ToInt32(selectedRow.Cells["Pipeline ID"].Value);

                frmAmendPipeline frmAP = new frmAmendPipeline(pID);
                frmAP.ShowDialog();

                fillGrid();


            }
        }

        private void dgActivity_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int aID;
            

            if (dgActivity.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgActivity.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgActivity.Rows[selectedrowindex];

                aID = Convert.ToInt32(selectedRow.Cells["id"].Value);

                frmAmendActivity frmAA = new frmAmendActivity(aID);
                frmAA.ShowDialog();

                fillActivityGrid();


            }
        }

        private void cmbSearchStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void txtCustomerSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            fillGrid();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            cmbSearchStatus.Text = "";
            fillGrid();
        }
    }
}

