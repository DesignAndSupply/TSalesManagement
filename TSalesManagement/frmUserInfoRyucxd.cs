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
    public partial class frmUserInfoRyucxd : Form
    {


        public string comboName { get; set; }
        public string sql { get; set; }
        public string customer { get; set; } //from the searchbar

        public frmUserInfoRyucxd()
        {
            InitializeComponent();
            cmbStaff.Items.Add("ryucxd");
            cmbStaff.Items.Add("Corey Jones");
            cmbStaff.Items.Add("Tomas Grother");
            cmbStaff.Items.Add("Nicholas Thomas");
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCustomerSearch.Visible = true;
            lblCustomer.Visible = true;
            txtCustomerSearch.Focus();
            comboName = cmbStaff.Text;
            //also at some point we will need to wipe the lists etc (whatever method I end up using for 

            //fill the grid   (need to check which tab is selected? might be worth defaulting to tab1 at this stage of code)
            tabControl1.SelectedIndex = 0;
            loadData();

        }

        private void loadData()
        {
            //im thinking a different string based on which tab is selected

            //null the datagridviews (in the case of switching each user) 
            nullDataGrids();
            whichTab();

            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (tabControl1.SelectedIndex != 3)
                        cmd.Parameters.AddWithValue("@custName", "%" + customer + "%");  //this will only execute on every tab except pipeline
                    conn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    conn.Close();
                    dataGridView1.DataSource = dt;
                }
            }
            //now that the data is loaded, its probably a good idea to add buttons and paint the DGV here
            formatDataGrid();
            if (tabControl1.SelectedIndex != 2)
                addButtons();

            paintDataGrid();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void whichTab()
        {

            //get the userID
            int userID = 0;
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + comboName + "' ", conn))
                {
                    conn.Open();
                    userID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }


            if (tabControl1.SelectedIndex == 0) //customer list
            {
                sql = "SELECT [account ref],[Customer Name],Telephone,[Address_1],address_2,address_3,Address_4,[Account Status],[Customer Type] FROM dbo.c_sales_view_customer_data WHERE [Customer Name] LIKE @custName ORDER BY [Customer Name] DESC";
            }
            else if (tabControl1.SelectedIndex == 1) //user activity
            {
                sql = "SELECT id,[Customer Name],[Activity Date], date_modified as [Last Updated],Type,reference,Details,Contact,[Logged By] FROM dbo.c_sales_view_activity_list WHERE [Logged By] = '" + comboName + "' AND [Customer Name] LIKE @custName ORDER BY  [Activity Date] DESC";
            }
            else if (tabControl1.SelectedIndex == 2) //tasks
            {
                sql = "SELECT [Task ID],[Date Created],dueDate,[Priority],Detail,[Status],SetBy,SetFor,crmActive,crmCustAccRef, CASE WHEN completeDateAddDays is null THEN DATEADD(day,-2,GETDATE()) ELSE completeDateAddDays END as [completeDateAddDays] FROM [ToDo].dbo.c_view_task_list_crm  WHERE SetFor = '" + comboName + "' AND subject LIKE @custName ORDER BY dueDate DESC";

            }
            else //only option left is pipeline
            {
                //also need userID    --    im guessing this is the ID of the person selected so im gonna grab that id here and build it into the string manually

                sql = "SELECT id as 'Pipeline ID',[Customer Name], door_style as 'Door Style', order_ref as 'Order Reference', estimated_order_date as 'Estimated date of order', added_by_id as 'Added by', date_added as 'Added on', estimated_order_value as 'Estimated Value', order_status as 'Status' FROM c_view_sales_pipeline_text where added_by_id =  '" + comboName + "' AND order_status LIKE '%" + comboPipeLine.Text + "%'";
            }
        }

        private void addButtons()
        {
            //adding buttons to one grid will mean i need to count the current columns and place it at the MAX(+1) column to allow for different columns having different numbers
        }

        private void formatDataGrid()
        {
            if (tabControl1.SelectedIndex == 0) //customer list
            {
                dataGridView1.Columns[0].HeaderText = "Account Ref";
                dataGridView1.Columns[1].HeaderText = "Customer Name";
                dataGridView1.Columns[2].HeaderText = "Telephone";
                dataGridView1.Columns[3].HeaderText = "Address 1";
                dataGridView1.Columns[4].HeaderText = "Address 2";
                dataGridView1.Columns[5].HeaderText = "Address 3";
                dataGridView1.Columns[6].HeaderText = "Address 4";
                dataGridView1.Columns[7].HeaderText = "Account Status";
                dataGridView1.Columns[8].HeaderText = "Customer Type";
                //column size stuff
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (tabControl1.SelectedIndex == 1) //user activity
            {
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Customer Name";
                dataGridView1.Columns[2].HeaderText = "Activity Date";
                dataGridView1.Columns[3].HeaderText = "Last Updated";
                dataGridView1.Columns[4].HeaderText = "Type";
                dataGridView1.Columns[5].HeaderText = "Reference";
                dataGridView1.Columns[6].HeaderText = "Details";
                dataGridView1.Columns[7].HeaderText = "Contact";
                dataGridView1.Columns[8].HeaderText = "Logged By";
                //column size stuff
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (tabControl1.SelectedIndex == 2) //tasks
            {
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Date Created";
                dataGridView1.Columns[2].HeaderText = "Due Date";
                dataGridView1.Columns[3].HeaderText = "Priority";
                dataGridView1.Columns[4].HeaderText = "Detail";
                dataGridView1.Columns[5].HeaderText = "Status";
                dataGridView1.Columns[6].HeaderText = "Set By";
                dataGridView1.Columns[7].HeaderText = "Set For";
                dataGridView1.Columns[8].HeaderText = "Customer Type";
                //column size stuff
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //these will be hidden at some point
                dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else //only option left is pipeline
            {
                dataGridView1.Columns[0].HeaderText = "PipeLine ID";
                dataGridView1.Columns[1].HeaderText = "Customer Name";
                dataGridView1.Columns[2].HeaderText = "Door Style";
                dataGridView1.Columns[3].HeaderText = "Order Reference";
                dataGridView1.Columns[4].HeaderText = "Estimated Date of Order";
                dataGridView1.Columns[5].HeaderText = "Added By";
                dataGridView1.Columns[6].HeaderText = "Added On";
                dataGridView1.Columns[7].HeaderText = "Estimated Value";
                dataGridView1.Columns[8].HeaderText = "Status";
                //column size stuff
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void paintDataGrid()
        {
            //this needs some thinking 
            //regardless I'm going to need to read from the task database for the selected user
        }

        private void nullDataGrids()  //grid(s) because im planning on having hidden dgvs 
        {
            dataGridView1.DataSource = null; dataGridView1.Rows.Clear(); dataGridView1.Columns.Clear(); //alll on one row looks CLEAN
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();

            //if its pipeline then show those three controls else hide them
            if (tabControl1.SelectedIndex != 3)
            {
                comboPipeLine.Text = "";
                lblPipeline.Visible = false; buttonPipeline.Visible = false; comboPipeLine.Visible = false;
            }
            else
            {
                lblPipeline.Visible = true; buttonPipeline.Visible = true; comboPipeLine.Visible = true;
            }
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            customer = txtCustomerSearch.Text;
            loadData();
        }

        private void comboPipeLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void buttonPipeline_Click(object sender, EventArgs e)
        {
            comboPipeLine.Text = "";
            loadData();
        }
    }
}
