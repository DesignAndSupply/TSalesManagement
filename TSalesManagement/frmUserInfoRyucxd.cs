﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.PowerBI.Api.V1.Models;

namespace TSalesManagement
{
    public partial class frmUserInfoRyucxd : Form
    {


        //this is where the problem is -- needs to have the list filled on selection ... although istg i did this
        //these are all the lists for retaining the selcted rows     -- pink --
        public List<string> selectedCustomer = new List<string>();  //this uses [account ref] to identify which are selected
        public List<int> selectedActivity = new List<int>();  //this uses the [id] column to identify which are selected
        public List<int> selectedPipeline = new List<int>(); //this uses [pipeline id]
        public List<int> selectedTask = new List<int>(); //this uses [id] of the task -- dont think this one needs any other lists because i cant see it being useful :)

        //these are used for adding the selected items to the listbox on the left of the screen
        public List<string> selectedCustomerName = new List<string>();
        public List<string> selectedActivityName = new List<string>(); //just add the customer name to this and build it into the list box after every new entry/removed entry
        public List<string> selectedPipelineName = new List<string>();

        //we need a list thats used on the first run of painting the datagridview
        //this will get the account reference from Task and link it to Customer and then 
        public List<string> blueLink = new List<string>();
        public List<string> redLink = new List<string>();
        //public List<string> bluePipelineLink  = new List<string>();   //i think i can limit to list to one for each colour rather than 4
        //public List<string> redPipelineLink = new List<string>();

        //these are used for highlighting everything that is ALREADY a task -- orange --
        public List<string> alreadyAssignedCustomer = new List<string>(); //likely to use  [Customer Name] from the customer list
        public List<int> alreadyAssignedActivity = new List<int>(); //when going through the tasks (matching up acc ref to acc ref
        public List<int> alreadyAssignedPipeline = new List<int>();//collect the customer name into these two lists


        //these are used for highlighting everything that has been COMPLETE in the last 7 days -- blue --
        public List<string> alreadyCompleteCustomer = new List<string>();
        public List<int> alreadyCompleteActivity = new List<int>(); //same as above
        public List<int> alreadyCompletePipeline = new List<int>();

        //override lists (used to identify which items were blue/red prior to selecting
        public List<int> overrideBlueActivity = new List<int>(); //use the IDs here so we can easily identify which were selected
        public List<int> overrideBluePipeline = new List<int>(); //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        public List<int> overrideRedActivity = new List<int>();
        public List<int> overrideRedPipeline = new List<int>();



        public string comboName { get; set; } //whats currently in the cmbStaff box
        public string sql { get; set; } //sql for the tables (updated in whichTab()
        public string customer { get; set; } //from the searchbar
        public int skipPaintWithList { get; set; } //this is used to bypass the paintwithlist void on tab change (to allow me to select tabs without running TWO paint voids

        public frmUserInfoRyucxd()
        {
            InitializeComponent();
            updateListBox();
            //cmbStaff.Items.Add("ryucxd"); //hello tom, its me, corey but from the past!
            //cmbStaff.Items.Add("Corey Jones"); //you're gonna wanna remove these and add the datasource like you did last time
            //cmbStaff.Items.Add("Tomas Grother");//hope you're having fun in isolation
            //cmbStaff.Items.Add("Nicholas Thomas");//miss u terribly
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
            paintDataGridFirstTime(); //this flips through every single row and does not read the lists, only writes to them

        }

        private void loadData()
        {
            //null the datagridviews (in the case of switching each user) 
            nullDataGrids();
            whichTab(); //get the unique sql string based on which tab is currently active

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
            //if (tabControl1.SelectedIndex != 2)
            addButtons();
            dataGridView1.ClearSelection();
        }

        private void whichTab()
        {

            //get the userID
            int userID = 0; //this is only used in pipeline
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
                sql = "SELECT [account ref],[Customer Name],Telephone,[Address_1],address_2,address_3,Address_4,[Account Status],[Customer Type] FROM dbo.c_sales_view_customer_data WHERE [Customer Name] LIKE @custName ORDER BY [Customer Name] ASC";
            }
            else if (tabControl1.SelectedIndex == 1) //user activity
            {
                sql = "SELECT COALESCE(id,0),[Customer Name],[Activity Date], date_modified as [Last Updated],Type,reference,Details,Contact,[Logged By] FROM dbo.c_sales_view_activity_list WHERE [Logged By] = '" + comboName + "' AND [Customer Name] LIKE @custName ORDER BY  [Activity Date] DESC";
            }
            else if (tabControl1.SelectedIndex == 2) //tasks
            {
                sql = "SELECT [Task ID],[Date Created],dueDate,[Priority],[NAME] as 'Customer',Detail,[Status],SetBy,SetFor,crmActive,crmCustAccRef, CASE WHEN completeDateAddDays is null THEN DATEADD(day,-2,GETDATE()) ELSE completeDateAddDays END as [completeDateAddDays] FROM [ToDo].dbo.c_view_task_list_crm  WHERE SetFor = '" + comboName + "' AND subject LIKE @custName ORDER BY dueDate DESC";
            }
            else //only option left is pipeline
            {
                //also need userID    --    im guessing this is the ID of the person selected so im gonna grab that id here and build it into the string manually
                sql = "SELECT id as 'Pipeline ID',[Customer Name], door_style as 'Door Style', order_ref as 'Order Reference', estimated_order_date as 'Estimated date of order', added_by_id as 'Added by', date_added as 'Added on', estimated_order_value as 'Estimated Value', order_status as 'Status' FROM c_view_sales_pipeline_text where added_by_id =  '" + comboName + "' AND order_status LIKE '%" + comboPipeLine.Text + "%'";
            }
        }

        private void addButtons()
        {
            //adding buttons to one grid will mean i need to count the current columns and place it at the MAX column to allow for different columns having different numbers
            //if (tabControl1.SelectedIndex != 2) // removing this because chris wants to be able to select a task 13/07/2020
            //{
            DataGridViewButtonColumn selectButton = new DataGridViewButtonColumn();
            selectButton.Name = "Select";
            selectButton.Text = "Select";
            selectButton.UseColumnTextForButtonValue = true;
            int columnIndex = (dataGridView1.Columns.Count);
            if (dataGridView1.Columns["Select"] == null)
            {
                dataGridView1.Columns.Insert(columnIndex, selectButton);
            }
            if (dataGridView1.Columns.Contains("Select"))
            {
                int index = dataGridView1.Columns["Select"].Index;
                dataGridView1.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //allign the header cell because this is done AFTER format();
            }
            //}
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
                dataGridView1.Columns[4].HeaderText = "Customer";
                dataGridView1.Columns[5].HeaderText = "Detail";
                dataGridView1.Columns[6].HeaderText = "Status";
                dataGridView1.Columns[7].HeaderText = "Set By";
                dataGridView1.Columns[8].HeaderText = "Set For";
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
                dataGridView1.Columns[0].HeaderText = "Pipeline ID";
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

            //center all the columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                //column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void paintDataGridFirstTime() //the first time loops through all the tables to identify what colours go where
        {
            skipPaintWithList = -1;
            //check tasks for anything that is currently assigned and also compelte and nab the customer name while we're at it
            //first we need to read the data from tasks
            tabControl1.SelectedIndex = 2;
            //dont trust the buttons they lie
            int crmIndex = 0, completeDaysIndex = 0, crmActive = 0, statusIndex = 0;
            if (dataGridView1.Columns.Contains("crmCustAccRef"))
                crmIndex = dataGridView1.Columns["crmCustAccRef"].Index;
            if (dataGridView1.Columns.Contains("crmActive"))
                crmActive = dataGridView1.Columns["crmActive"].Index;
            if (dataGridView1.Columns.Contains("completeDateAddDays"))
                completeDaysIndex = dataGridView1.Columns["completeDateAddDays"].Index;
            if (dataGridView1.Columns.Contains("Status"))
                statusIndex = dataGridView1.Columns["Status"].Index;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //while we are skipping through these we need to read for both possible orange data AND blue data
                //red is the first [IF] because blue will overwrite red (blue outranks red)
                if (dataGridView1.Rows[i].Cells[crmActive].Value.ToString() == "-1" && dataGridView1.Rows[i].Cells[statusIndex].Value.ToString() != "Complete") //this is the criteria for red
                {
                    //nab the account reference here       
                    redLink.Add(Convert.ToString(dataGridView1.Rows[i].Cells[crmIndex].Value)); //ready to go

                }
                if (DateTime.Now < Convert.ToDateTime(dataGridView1.Rows[i].Cells[completeDaysIndex].Value)) //this is the criteria for blue
                {
                    blueLink.Add(Convert.ToString(dataGridView1.Rows[i].Cells[crmIndex].Value)); //blue is ready
                }
            }

            //now that we have all of the red/blue customer acc references...
            //time for the absolute wildcard that i have no idea if it will work (plus at this point i havent tested a single thing and its all riding on this)
            tabControl1.SelectedIndex = 0;
            //this should load the code for selecting customer
            //im hoping this will be enough to capture the customer acc refs etc

            //buttons again
            int customerAccRef = 0, customerName = 0;
            if (dataGridView1.Columns.Contains("Account Ref"))
                customerAccRef = dataGridView1.Columns["Account Ref"].Index;
            if (dataGridView1.Columns.Contains("Customer Name"))
                customerName = dataGridView1.Columns["Customer Name"].Index;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //check every instance in here and match all the account references
                //when a account reference matches, remove it from the list and add the customer name
                //this should recycle the list allowing for a max of two lists needed for activity and pipeline
                //also i need to start populating the customer list so i wont need to enter this void again except for a new user
                if (redLink.Contains(Convert.ToString(dataGridView1.Rows[i].Cells[customerAccRef].Value)))
                {
                    //so there is a red
                    alreadyAssignedCustomer.Add(dataGridView1.Rows[i].Cells[customerAccRef].Value.ToString()); //this is for customer
                    redLink.Remove(Convert.ToString(dataGridView1.Rows[i].Cells[customerAccRef].Value)); //remove it from redlink
                    redLink.Add(Convert.ToString(dataGridView1.Rows[i].Cells[customerName].Value));//then add it back but as customer name and not reference
                }
                if (blueLink.Contains(Convert.ToString(dataGridView1.Rows[i].Cells[customerAccRef].Value)))
                {
                    //so there is blue 
                    alreadyCompleteCustomer.Add(Convert.ToString(dataGridView1.Rows[i].Cells[customerAccRef].Value)); //add to customer
                    blueLink.Remove(Convert.ToString(dataGridView1.Rows[i].Cells[customerAccRef].Value));//remove
                    blueLink.Add(Convert.ToString(dataGridView1.Rows[i].Cells[customerName].Value));//add it back as customer name
                }
            }
            //now that customer is handled, swap tabs to activity and pipline and grab the ID's where the customer name matches
            tabControl1.SelectedIndex = 1; //activity
            int idIndex = 0, activityCustomerName = 0;
            string columnName = "ID";
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].HeaderText == columnName)
                {
                    idIndex = i;
                }
            }
            //if (dataGridView1.Columns.Contains("ACTIVITY ID"))
            //  idIndex = dataGridView1.Columns["ACTIVITY ID"].Index;
            if (dataGridView1.Columns.Contains("Customer Name"))
                activityCustomerName = dataGridView1.Columns["Customer Name"].Index;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //loop through each record and match any red/blue
                if (redLink.Contains(Convert.ToString(dataGridView1.Rows[i].Cells[activityCustomerName].Value)))
                {
                    //there is a match
                    alreadyAssignedActivity.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[idIndex].Value));
                }
                if (blueLink.Contains(Convert.ToString(dataGridView1.Rows[i].Cells[activityCustomerName].Value)))
                {
                    //there is a match
                    alreadyCompleteActivity.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[idIndex].Value));
                }
            }

            //now we hit pipline
            tabControl1.SelectedIndex = 3;
            //still dont trust the buttons
            int pipelineIdIndex = 0, pipelineCustomerName = 0;
            if (dataGridView1.Columns.Contains("Pipeline ID"))
                pipelineIdIndex = dataGridView1.Columns["Pipeline ID"].Index;
            if (dataGridView1.Columns.Contains("Customer Name"))
                pipelineCustomerName = dataGridView1.Columns["Customer Name"].Index;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (redLink.Contains(dataGridView1.Rows[i].Cells[pipelineCustomerName].Value.ToString()))
                {
                    //is a match
                    alreadyAssignedPipeline.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[pipelineIdIndex].Value));
                }
                if (blueLink.Contains(dataGridView1.Rows[i].Cells[pipelineCustomerName].Value.ToString()))
                {
                    alreadyCompletePipeline.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[pipelineIdIndex].Value));
                }
            }
            //back to home screen
            skipPaintWithList = 0;
            tabControl1.SelectedIndex = 0;
        }
        private void paintDataGridWithListData() //this iteration of painting only loops through tables to paint and nothing else making it more efficent after the user has been loaded once
        {
            int customerAccRefIndex = 0, ActivityIDIndex = 0, pipelineIDIndex = 0;
            //paint the current tab
            if (tabControl1.SelectedIndex == 0)
            {
                //paint customer
                //dont trust buttons :))))

                if (dataGridView1.Columns.Contains("Account Ref"))
                {
                    customerAccRefIndex = dataGridView1.Columns["Account Ref"].Index;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        //check red

                        try
                        {
                            if (alreadyAssignedCustomer.Contains(Convert.ToString(dataGridView1.Rows[i].Cells[customerAccRefIndex].Value)))
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                            }
                            //check blue
                            if (alreadyCompleteCustomer.Contains(Convert.ToString(dataGridView1.Rows[i].Cells[customerAccRefIndex].Value)))
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;
                            }
                            //check pink (in the case that the user has selected one item and then swapped tabs (or has clicked sort on a column)
                            if (selectedCustomer.Contains(Convert.ToString(dataGridView1.Rows[i].Cells[customerAccRefIndex].Value)))
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                            }
                        }

                        catch
                        {

                        }
                    }
                }
            }
            if (tabControl1.SelectedIndex == 1)
            {
                //this is the section where it does not notice ID --
                string columnName;
                columnName = "ID";
                int passloop = 0;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].HeaderText == columnName)
                    {
                        ActivityIDIndex = i;
                        passloop = 1;
                    }
                }
                // MessageBox.Show(dataGridView1.Columns[i].HeaderText.ToString());
                if (passloop == 1) //old code  if (dataGridView1.Columns.Contains(columnName))
                {
                    //ActivityIDIndex = dataGridView1.Columns[columnName].Index;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //check red
                        //  MessageBox.Show(dataGridView1.Columns[i].HeaderText.ToString());
                        if (alreadyAssignedCustomer.Contains(Convert.ToString(dataGridView1.Rows[i].Cells[ActivityIDIndex].Value)))
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                        }
                        //check blue
                        if (alreadyCompleteCustomer.Contains(Convert.ToString(dataGridView1.Rows[i].Cells[ActivityIDIndex].Value)))
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;
                        }
                        //check pink
                        if (selectedActivity.Contains(Convert.ToInt32(dataGridView1.Rows[i].Cells[ActivityIDIndex].Value)))
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                        }
                    }
                }
            }

            if (tabControl1.SelectedIndex == 2) //TASKS
            {
                int taskColumnIndex = 0;
                //check what tasks are in the list and repaint them to hotpink!
                if (dataGridView1.Columns.Contains("ID"))
                {
                    taskColumnIndex = dataGridView1.Columns["ID"].Index;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (selectedTask.Contains(Convert.ToInt32(dataGridView1.Rows[i].Cells[taskColumnIndex].Value)))
                        {
                            //it is in the list already so here we need to make it pink and move on
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                        }
                    }
                }
            }

            if (tabControl1.SelectedIndex == 3)
            {
                if (dataGridView1.Columns.Contains("Pipeline ID"))
                {
                    pipelineIDIndex = dataGridView1.Columns["Pipeline ID"].Index;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        //check red
                        if (alreadyAssignedCustomer.Contains(Convert.ToString(dataGridView1.Rows[i].Cells[pipelineIDIndex].Value)))
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                        }
                        //check blue
                        if (alreadyCompleteCustomer.Contains(Convert.ToString(dataGridView1.Rows[i].Cells[pipelineIDIndex].Value)))
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;
                        }
                        //check pink
                        if (selectedPipeline.Contains(Convert.ToInt32(dataGridView1.Rows[i].Cells[pipelineIDIndex].Value)))
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                    }
                }
            }
        }

        private void nullDataGrids()  //grid(s) because im planning on having hidden dgvs 
        {
            dataGridView1.DataSource = null; dataGridView1.Rows.Clear(); dataGridView1.Columns.Clear(); //alll on one row looks CLEAN

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
            if (skipPaintWithList == -1)
            {
                //skip the function and only load the data
            }
            else
                paintDataGridWithListData();

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
            paintDataGridWithListData();
        }

        private void comboPipeLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
            paintDataGridWithListData();
        }

        private void buttonPipeline_Click(object sender, EventArgs e)
        {
            comboPipeLine.Text = "";
            loadData();
            paintDataGridWithListData();
        }




        //this one is hard to read, all the logic for making rows pink and overriding red/blue and also returning them to red/blue
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int index = -1;
            if (dataGridView1.Columns.Contains("Select"))
                index = dataGridView1.Columns["Select"].Index;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && index >= 0)
            {
                if (dataGridView1.CurrentRow.DefaultCellStyle.BackColor == Color.HotPink)   //REMOVING SELECTION
                {
                    //dont trust the buttons
                    int clearIndex = 0;

                    //we need to check if this matches any of the override list and if they do we return it back to that colour instead of .empty
                    //different route for each tab

                    //adding tasks in here 
                    if (tabControl1.SelectedIndex == 2)
                    {
                        int taskColumnIndex = 0;
                        if (dataGridView1.Columns.Contains("ID"))
                        {
                            taskColumnIndex = dataGridView1.Columns["ID"].Index;

                            if (selectedTask.Contains(Convert.ToInt32(dataGridView1.CurrentRow.Cells[taskColumnIndex].Value)))
                            {
                                //it is in the list already so here we need to make it empty and move on
                                dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Empty;  //herehere
                            }

                        }
                    }
                    if (tabControl1.SelectedIndex == 1) //activity
                    {
                        string columnName = "ID";
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            if (dataGridView1.Columns[i].HeaderText == columnName)
                            {
                                clearIndex = i;
                            }
                        }
                        //if (dataGridView1.Columns.Contains("ACTIVITY ID"))
                        //    clearIndex = dataGridView1.Columns["ACTIVITY ID"].Index;

                        if (overrideBlueActivity.Contains(Convert.ToInt32(dataGridView1.CurrentRow.Cells[clearIndex].Value)))
                        {
                            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.CornflowerBlue; //this was once a blue row, lets put it back 
                            overrideBlueActivity.Remove(Convert.ToInt32(dataGridView1.CurrentRow.Cells[clearIndex].Value)); //also remove the entry into the override list
                        }
                        else if (overrideRedActivity.Contains(Convert.ToInt32(dataGridView1.CurrentRow.Cells[clearIndex].Value)))
                        {
                            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.OrangeRed; //this was once red so lets put it back
                            overrideRedActivity.Remove(Convert.ToInt32(dataGridView1.CurrentRow.Cells[clearIndex].Value));//also remove the entry into the override list
                        }
                        else
                        {
                            int activityRef = 0;

                            string columnName2 = "ID";
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                if (dataGridView1.Columns[i].HeaderText == columnName)
                                {
                                    activityRef = i;
                                    selectedActivity.Remove(Convert.ToInt32(dataGridView1.CurrentRow.Cells[activityRef].Value));
                                }
                            }


                            //also need to remove this from the list aswell
                            int CustomerName = 0; //use this because i have ZERO trust for the columns and their numbering
                            if (dataGridView1.Columns.Contains("Customer Name"))
                            {
                                CustomerName = dataGridView1.Columns["Customer Name"].Index;
                                selectedActivityName.Remove(Convert.ToString(dataGridView1.CurrentRow.Cells[CustomerName].Value));
                            }
                            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Empty;  //wasnt in either override so make it empty
                            updateListBox();
                        }

                        //if (.Contains(dataGridView1.CurrentRow.Cells)) //find the entry location and look @ the code there 


                    }
                    else if (tabControl1.SelectedIndex == 3) //pipeline
                    {
                        if (dataGridView1.Columns.Contains("Pipeline ID"))
                            clearIndex = dataGridView1.Columns["Pipeline ID"].Index;

                        if (overrideBluePipeline.Contains(Convert.ToInt32(dataGridView1.CurrentRow.Cells[clearIndex].Value)))
                        {
                            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.CornflowerBlue; //this was once a blue row, lets put it back 
                            overrideBluePipeline.Remove(Convert.ToInt32(dataGridView1.CurrentRow.Cells[clearIndex].Value));//also remove the entry into the override list
                        }
                        else if (overrideRedPipeline.Contains(Convert.ToInt32(dataGridView1.CurrentRow.Cells[clearIndex].Value)))
                        {
                            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.OrangeRed; //this was once red so lets put it back
                            overrideRedPipeline.Remove(Convert.ToInt32(dataGridView1.CurrentRow.Cells[clearIndex].Value));//also remove the entry into the override list
                        }
                        else
                        { //also need to remove this entry from the list...
                            int pipelineRef = 0;
                            if (dataGridView1.Columns.Contains("Pipeline ID"))
                            {
                                pipelineRef = dataGridView1.Columns["Pipeline ID"].Index;
                                selectedPipeline.Remove(Convert.ToInt32(dataGridView1.CurrentRow.Cells[pipelineRef].Value));
                            }

                            //also need to remove this from the list aswell
                            int CustomerName = 0; //use this because i have ZERO trust for the columns and their numbering
                            if (dataGridView1.Columns.Contains("Customer Name"))
                            {
                                CustomerName = dataGridView1.Columns["Customer Name"].Index;
                                selectedPipelineName.Remove(Convert.ToString(dataGridView1.CurrentRow.Cells[CustomerName].Value));
                            }

                            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Empty;  //wasnt in either override so make it empty
                            updateListBox();
                        }

                    }
                    else //customer
                    {
                        int accountRefIndex = 0;
                        if (dataGridView1.Columns.Contains("Account Ref"))
                        {
                            accountRefIndex = dataGridView1.Columns["Account Ref"].Index;
                            selectedCustomer.Remove(Convert.ToString(dataGridView1.CurrentRow.Cells[accountRefIndex].Value));
                        }

                        //also need to remove this from the list aswell
                        dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Empty;
                        int CustomerName = 0; //use this because i have ZERO trust for the columns and their numbering
                        if (dataGridView1.Columns.Contains("Customer Name"))
                        {
                            CustomerName = dataGridView1.Columns["Customer Name"].Index;
                            selectedCustomerName.Remove(Convert.ToString(dataGridView1.CurrentRow.Cells[CustomerName].Value));
                        }
                        updateListBox();

                    }
                }
                else if (dataGridView1.CurrentRow.DefaultCellStyle.BackColor == Color.CornflowerBlue)
                {
                    if (tabControl1.SelectedIndex == 0) //if this is customer
                        MessageBox.Show("This customer has already been chased within the last 7 days!");
                    else //its not customer so we can prompt the user if they really want to add this person etc
                    {
                        DialogResult result = MessageBox.Show("This customer has been chased within the last 7 working days, are you sure you want to select them?", "Already Completed!", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink; //overrided
                            //find out which tab this is and add this to the unique [o v e r r i d e ] list (to ensure its not highlighted blue/orange again)
                            int overrideIndex = 0;
                            if (tabControl1.SelectedIndex == 1) //activity
                            {
                                //get the index of activity id (im doing this because i dont trust the buttons and sometimes they like to take index 0 and push everything +1 resulting in errors
                                string columnName = "ID";
                                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                                {
                                    if (dataGridView1.Columns[i].HeaderText == columnName)
                                    {
                                        overrideIndex = i;
                                    }
                                }
                                //if (dataGridView1.Columns.Contains("ACTIVITY ID"))
                                // overrideIndex = dataGridView1.Columns["ACTIVITY ID"].Index;
                                //add it to the list
                                overrideBlueActivity.Add(Convert.ToInt32(dataGridView1.CurrentRow.Cells[overrideIndex].Value)); //need to test that this adds correctly

                            }
                            else if (tabControl1.SelectedIndex == 3) //pipeline
                            {
                                if (dataGridView1.Columns.Contains("Pipeline ID"))
                                    overrideIndex = dataGridView1.Columns["Pipeline ID"].Index;
                                //add it to the list
                                overrideBluePipeline.Add(Convert.ToInt32(dataGridView1.CurrentRow.Cells[overrideIndex].Value)); //need to test that this adds correctly
                            }
                        }
                    }
                } //this includes override for activity and pipeline
                else if (dataGridView1.CurrentRow.DefaultCellStyle.BackColor == Color.OrangeRed)
                {
                    if (tabControl1.SelectedIndex == 0) //if this is customer
                        MessageBox.Show("This customer is already assigned as a task!");
                    else //its not customer so we can prompt the user if they really want to add this person etc
                    {
                        DialogResult result = MessageBox.Show("This customer has been chased within the last 7 working days, are you sure you want to select them?", "Already Completed!", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink; //overrided
                            //find out which tab this is and add this to the unique [o v e r r i d e ] list (to ensure its not highlighted blue/orange again)
                            int overrideIndex = 0;
                            if (tabControl1.SelectedIndex == 1) //activity
                            {
                                //get the index of activity id (im doing this because i dont trust the buttons and sometimes they like to take index 0 and push everything +1 resulting in errors
                                string columnName = "ID";
                                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                                {
                                    if (dataGridView1.Columns[i].HeaderText == columnName)
                                    {
                                        overrideIndex = i;
                                    }
                                }
                                //if (dataGridView1.Columns.Contains("ACTIVITY ID"))
                                //  overrideIndex = dataGridView1.Columns["ACTIVITY ID"].Index;
                                //add it to the list
                                overrideRedActivity.Add(Convert.ToInt32(dataGridView1.CurrentRow.Cells[overrideIndex].Value)); //need to test that this adds correctly
                            }
                            else if (tabControl1.SelectedIndex == 3) //pipeline
                            {
                                if (dataGridView1.Columns.Contains("Pipeline ID"))
                                    overrideIndex = dataGridView1.Columns["Pipeline ID"].Index;
                                //add it to the list
                                overrideRedPipeline.Add(Convert.ToInt32(dataGridView1.CurrentRow.Cells[overrideIndex].Value)); //need to test that this adds correctly
                            }
                        }
                    }
                }
                else
                {
                    //i think this is where the pink list needs to be added...
                    if (tabControl1.SelectedIndex == 0) // customer
                    {
                        int CustomerID = 0; //use this because i have ZERO trust for the columns and their numbering
                        if (dataGridView1.Columns.Contains("Account Ref"))
                            CustomerID = dataGridView1.Columns["Account Ref"].Index;
                        dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink;
                        //add it to the list
                        selectedCustomer.Add(Convert.ToString(dataGridView1.CurrentRow.Cells[CustomerID].Value));
                        //add name for the listbox here
                        int CustomerName = 0; //use this because i have ZERO trust for the columns and their numbering
                        if (dataGridView1.Columns.Contains("Customer Name"))
                        {
                            CustomerName = dataGridView1.Columns["Customer Name"].Index;
                            selectedCustomerName.Add(Convert.ToString(dataGridView1.CurrentRow.Cells[CustomerName].Value));
                        }
                        updateListBox();
                    }
                    else if (tabControl1.SelectedIndex == 1) //activity
                    {
                        int activityID = 0; //use this because i have ZERO trust for the columns and their numbering
                        string columnName = "ID";
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            if (dataGridView1.Columns[i].HeaderText == columnName)
                            {
                                activityID = i;
                            }
                        }

                        //if (dataGridView1.Columns.Contains("ACTIVITY ID"))
                        //    activityID = dataGridView1.Columns["ACTIVITY ID"].Index;

                        dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink;
                        //add it to the list
                        selectedActivity.Add(Convert.ToInt32(dataGridView1.CurrentRow.Cells[activityID].Value)); //ID

                        //list box
                        int CustomerName = 0; //use this because i have ZERO trust for the columns and their numbering
                        if (dataGridView1.Columns.Contains("Customer Name"))
                        {
                            CustomerName = dataGridView1.Columns["Customer Name"].Index;
                            selectedActivityName.Add(Convert.ToString(dataGridView1.CurrentRow.Cells[CustomerName].Value));
                        }
                        updateListBox();
                    }
                    else if (tabControl1.SelectedIndex == 2) //THIS IS TASKS BUT ITS NOT ENABLED RIGHT NOW BUT IT NEEDS TO BE ADDED!
                    {
                        if (tabControl1.SelectedIndex == 2)
                        {
                            int taskColumnIndex = 0;
                            if (dataGridView1.Columns.Contains("ID")) //I AM WORKING HERE!!!!!!" // need to tidy this area up and test it
                            {
                                taskColumnIndex = dataGridView1.Columns["ID"].Index;

                                if (selectedTask.Contains(Convert.ToInt32(dataGridView1.CurrentRow.Cells[taskColumnIndex].Value)))
                                {
                                    //it is in the list already so here we need to make it empty and move on
                                    dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink;  //herehere
                                    //also need to add this to a list aswell --- selectedTask :))))))
                                }

                            }
                        }
                    }

                    else if (tabControl1.SelectedIndex == 3) //pipeline
                    {
                        int pipelineIndex = 0; //use this because i have ZERO trust for the columns and their numbering
                        if (dataGridView1.Columns.Contains("Pipeline ID"))
                            pipelineIndex = dataGridView1.Columns["Pipeline ID"].Index;

                        dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink;
                        selectedPipeline.Add(Convert.ToInt32(dataGridView1.CurrentRow.Cells[pipelineIndex].Value)); //pipline ID
                                                                                                                    //list box
                        int CustomerName = 0; //use this because i have ZERO trust for the columns and their numbering
                        if (dataGridView1.Columns.Contains("Customer Name"))
                        {
                            CustomerName = dataGridView1.Columns["Customer Name"].Index;
                            selectedPipelineName.Add(Convert.ToString(dataGridView1.CurrentRow.Cells[CustomerName].Value));
                        }
                        updateListBox();
                    }
                    dataGridView1.ClearSelection();
                }
            }
            dataGridView1.ClearSelection();
        }

        private void FrmUserInfoRyucxd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_sales_program_users' table. You can move, or remove it, as needed.
            this.c_view_sales_program_usersTableAdapter.Fill(this.user_infoDataSet.c_view_sales_program_users);

        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                string aID;
                string custName;

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    aID = selectedRow.Cells["Account Ref"].Value.ToString();
                    custName = selectedRow.Cells["Customer Name"].Value.ToString();
                    frmCustomerInformation frmAA = new frmCustomerInformation(aID, custName);
                    frmAA.ShowDialog();

                    //fillActivityGrid();
                }


            }

            if (tabControl1.SelectedIndex == 1)
            {
                int aID;


                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    aID = Convert.ToInt32(selectedRow.Cells[0].Value);

                    frmAmendActivity frmAA = new frmAmendActivity(aID);
                    frmAA.ShowDialog();

                    //fillActivityGrid();
                }
            }


            if (tabControl1.SelectedIndex == 2)
            {
                int aID;


                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    aID = Convert.ToInt32(selectedRow.Cells[0].Value);

                    frmAmendToDo frmAA = new frmAmendToDo(aID);
                    frmAA.ShowDialog();

                    //fillActivityGrid();
                }
            }

            if (tabControl1.SelectedIndex == 3)
            {
                int aID;


                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    aID = Convert.ToInt32(selectedRow.Cells[0].Value);

                    frmAmendPipeline frmAA = new frmAmendPipeline(aID);
                    frmAA.ShowDialog();

                    //fillActivityGrid();
                }
            }





        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {

        }

        private void BtnEmail_Click_1(object sender, EventArgs e)
        {
            frmEmailUserManagement frmEUM = new frmEmailUserManagement(cmbStaff.Text);
            frmEUM.ShowDialog();
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //on the column sort reapply the colours as they get lost after sorting
            paintDataGridWithListData();
            dataGridView1.ClearSelection();
        }

        private void updateListBox()
        {
            //here we add the selected items to the list box


            //string.Join(Environment.NewLine, selectedActivity)
            selectedListBox.Items.Clear();
            selectedListBox.Items.Add("-- Customer --");
            for (int i = 0; i < selectedCustomerName.Count; i++)
                selectedListBox.Items.Add(selectedCustomerName[i]);
            //selectedListBox.Items.Add(string.Join(Environment.NewLine, selectedCustomerName));
            selectedListBox.Items.Add(" ");
            selectedListBox.Items.Add("-- Activities --");
            // selectedListBox.Items.Add(string.Join(Environment.NewLine, selectedActivityName));
            for (int i = 0; i < selectedActivityName.Count; i++)
                selectedListBox.Items.Add(selectedActivityName[i]);
            selectedListBox.Items.Add(" ");
            selectedListBox.Items.Add("-- Pipeline --");
            //selectedListBox.Items.Add(string.Join(Environment.NewLine, selectedPipelineName));
            for (int i = 0; i < selectedPipelineName.Count; i++)
                selectedListBox.Items.Add(selectedPipelineName[i]);


        }


        private void ryucxd_Click(object sender, EventArgs e)
        {
            //use this for testing shit

            //int z = 999;
            //for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //{
            //    string test;
            //    test = "ID";

            //    MessageBox.Show(dataGridView1.Columns[i].HeaderText.ToString());
            //    if (dataGridView1.Columns[i].HeaderText.Contains(test))
            //    {
            //        z = dataGridView1.Columns[i].Index;

            //    }
            //    MessageBox.Show(z.ToString());

            //}

            //print the lists

            MessageBox.Show("customerlist = " + string.Join(Environment.NewLine, selectedCustomer));

            MessageBox.Show("activity list = " + string.Join(Environment.NewLine, selectedActivity));

            MessageBox.Show("pipeline list = " + string.Join(Environment.NewLine, selectedPipeline));


        }



    }
}
