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
using StartUpClass;
using TSalesManagement.Class;

namespace TSalesManagement
{
    public partial class frmNonReturningCustomers : Form
    {
        public frmNonReturningCustomers()
        {
            InitializeComponent();
        }


        private void populateLostCustomers()
        {
            clearGrid();
            DateTime dateString;

            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);

            //dateString = Convert.ToDateTime("23/08/2018");

            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("usp_lost_customer_view", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@start_Date", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = dateString;

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgvCustomer.DataSource = dt;

            //Color the datagrid

            paintGrid();

            //Add button to data grid
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "Button1";
                button.HeaderText = "Update";
                button.Text = "Update";
                button.UseColumnTextForButtonValue = true; //dont forget this line
                if (dgvCustomer.Columns["Update"] == null)
                {
                    this.dgvCustomer.Columns.Add(button);
                }
            }

        }


        private void clearGrid()
        {
            try
            {
                dgvCustomer.Columns.Remove("Button1");

            }
            catch
            {

            }
        }

        private void paintGrid()
        {
            foreach (DataGridViewRow row in dgvCustomer.Rows)
            {

                string rowNotes = row.Cells["Notes"].Value.ToString();

                



                if(string.IsNullOrWhiteSpace(rowNotes) == false)
                {
                    row.Cells["FirstAndLast"].Style.BackColor = Color.LawnGreen;
                    row.Cells["FirstAndLast"].Style.ForeColor = Color.LawnGreen;
                    row.Cells["Last Time Ordered"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Customer"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Trade_Contact"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Telephone"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Telephone_2"].Style.BackColor = Color.LawnGreen;
                    row.Cells["AccRef"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Contact?"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Notes"].Style.BackColor = Color.LawnGreen;
                }
                else
                {
                    if (row.Cells["Contact?"].Value.ToString() == "Do not contact")
                    {
                        row.Cells["FirstAndLast"].Style.BackColor = Color.DarkOrange;
                        row.Cells["FirstAndLast"].Style.ForeColor = Color.DarkOrange;
                        row.Cells["Last Time Ordered"].Style.BackColor = Color.DarkOrange;
                        row.Cells["Customer"].Style.BackColor = Color.DarkOrange;
                        row.Cells["Trade_Contact"].Style.BackColor = Color.DarkOrange;
                        row.Cells["Telephone"].Style.BackColor = Color.DarkOrange;
                        row.Cells["Telephone_2"].Style.BackColor = Color.DarkOrange;
                        row.Cells["AccRef"].Style.BackColor = Color.DarkOrange;
                        row.Cells["Contact?"].Style.BackColor = Color.DarkOrange;
                        row.Cells["Notes"].Style.BackColor = Color.DarkOrange;
                    }
                    else
                    if (Convert.ToInt32(row.Cells["FirstAndLast"].Value) == -1)
                    {

                        row.Cells["FirstAndLast"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["FirstAndLast"].Style.ForeColor = Color.PaleVioletRed;
                        row.Cells["Last Time Ordered"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Customer"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Trade_Contact"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Telephone"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Telephone_2"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["AccRef"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Contact?"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Notes"].Style.BackColor = Color.PaleVioletRed;


                    }
                    else
                    {
                        // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row

                        row.Cells["FirstAndLast"].Style.BackColor = Color.White;
                        row.Cells["FirstAndLast"].Style.ForeColor = Color.White;
                    }
                }

 

            }
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            populateLostCustomers();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                var senderGrid = (DataGridView)sender;
                string accRef;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    int selectedrowindex = dgvCustomer.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dgvCustomer.Rows[selectedrowindex];

                    accRef = Convert.ToString(selectedRow.Cells["AccRef"].Value);

                    frmNonReturningCustomerNotes frmNRCN = new frmNonReturningCustomerNotes(accRef);
                    frmNRCN.ShowDialog();


                    populateLostCustomers();
                }
            }
        }
    }
}
