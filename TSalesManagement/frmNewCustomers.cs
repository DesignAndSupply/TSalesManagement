using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TSalesManagement.Class;

namespace TSalesManagement
{
    public partial class frmNewCustomers : Form
    {
        public frmNewCustomers()
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

            SqlCommand cmd = new SqlCommand("usp_new_customer_view", conn);
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

                if (string.IsNullOrWhiteSpace(rowNotes) == false)
                {
                    row.Cells["First Door"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Order Date"].Style.BackColor = Color.LawnGreen;

                    row.Cells["Customer"].Style.BackColor = Color.LawnGreen;
                    row.Cells["AccRef"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Notes"].Style.BackColor = Color.LawnGreen;
                }
                else
                {
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

                    frmNewCustomerNotes frmNRCN = new frmNewCustomerNotes(accRef);
                    frmNRCN.ShowDialog();

                    populateLostCustomers();
                }
            }
        }
    }
}