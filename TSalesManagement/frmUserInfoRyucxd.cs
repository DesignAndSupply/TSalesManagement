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
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboName = cmbStaff.Text;
            //null the datagridviews (in the case of switching each user) 
            nullDataGrids();
            //fill the grid   (need to check which tab is selected? might be worth defaulting to tab1 at this stage of code)
            tabControl1.SelectedIndex = 0;
            loadData();
            
        }

        private void loadData()
        {
            //im thinking a different string based on which tab is selected
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
            if (tabControl1.SelectedIndex != 2)
                addButtons();
            paintDataGrid();
        }

        private void whichTab()
        {
            if (tabControl1.SelectedIndex == 0) //customer list
            {
                sql = "SELECT [account ref],[Customer Name],Telephone,[Address_1],address_2,address_3,Address_4,[Account Status],[Customer Type] FROM dbo.c_sales_view_customer_data WHERE [Customer Name] LIKE @custName ORDER BY [Customer Name] DESC";
            }
            else if (tabControl1.SelectedIndex == 1) //user activity
            {
                sql = "SELECT id,[Customer Name],[Activity Date], date_modified as [Last Updated],Type,reference,Details,Contact,[Logged By] FROM dbo.c_sales_view_activity_list WHERE [Logged By] = '" + comboName + "' AND [Customer Name] LIKE @cust ORDER BY  [Activity Date] DESC";
            }
            else if (tabControl1.SelectedIndex == 2) //tasks
            {
                sql = "SELECT [Task ID],[Date Created],dueDate,[Priority],Detail,[Status],SetBy,SetFor,crmActive,crmCustAccRef, CASE WHEN completeDateAddDays is null THEN DATEADD(day,-2,GETDATE()) ELSE completeDateAddDays END as [completeDateAddDays] FROM [ToDo].dbo.c_view_task_list_crm  WHERE SetFor = @sender AND subject LIKE @cust ORDER BY dueDate DESC";

            }
            else //only option left is pipeline
            {
                //also need userID    --    im guessing this is the ID of the person selected so im gonna grab that id here and build it into the string manually
                int userID = 0;
                using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + comboName + "' ", conn))
                    {
                        userID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                sql = "SELECT id as 'Pipeline ID',[Customer Name], door_style as 'Door Style', order_ref as 'Order Reference', estimated_order_date as 'Estimated date of order', added_by_id as 'Added by', date_added as 'Added on', estimated_order_value as 'Estimated Value', order_status as 'Status' FROM c_view_sales_pipeline_text where added_by_id =  " + userID.ToString();
            }
        }

        private void addButtons()
        {
            //adding buttons to one grid will mean i need to count the current columns and place it at the MAX(+1) column to allow for different columns having different numbers
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

    }
}
