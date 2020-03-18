using StartUpClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TSalesManagement
{
    public partial class frmUserInfo : Form
    {
        public string customer { get; set; }
        public List<int> activityID = new List<int>();
        public List<string> customerAccRef = new List<string>();
        public List<int> piplineID = new List<int>();
        public List<int> taskID = new List<int>();
        public List<string> custAccRefList = new List<string>();
        public List<string> completedWithinWeek = new List<string>();
        public string cmbName { get; set; }

        public frmUserInfo()
        {
            InitializeComponent();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_sales_program_users' table. You can move, or remove it, as needed.
            this.c_view_sales_program_usersTableAdapter.Fill(this.user_infoDataSet.c_view_sales_program_users);
            //cmbStaff.SelectedIndex = -1;
            //cmbStaff.Items.Add("Corey Jones");
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
                sb.Append(" AND order_status = @oStatus ");
            }

            //If filter on customer is selected
            if (string.IsNullOrWhiteSpace(customer))
            {
            }
            else
            {
                sb.Append(" AND [Customer Name] LIKE @cust ");
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
            if (string.IsNullOrWhiteSpace(customer))
            {
            }
            else
            {
                cmd.Parameters.AddWithValue("@cust", "%" + customer + "%");
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

            //paintGrid();

            dgActivity.ClearSelection();
            dgPipeline.ClearSelection();
            dgTask.ClearSelection();
            dgCustomer.ClearSelection();
            fillCustomer();
            colourCustomerWithTaskAssigned();
        }

        private void paintActivityGrid()
        {
            foreach (DataGridViewRow row in dgActivity.Rows)
            {
                try
                {
                    if (Convert.ToInt32(row.Cells["Selected"].Value) == -1)
                    {
                        row.DefaultCellStyle.BackColor = Color.HotPink;
                    }
                }
                catch
                {
                }
            }
        }

        private void paintTaskGrid()
        {
            foreach (DataGridViewRow row in dgTask.Rows)
            {
                try
                {
                    if (Convert.ToInt32(row.Cells["Selected"].Value) == -1)
                    {
                        row.DefaultCellStyle.BackColor = Color.HotPink;
                    }
                }
                catch
                {
                }
            }
        }

        private void paintGrid()
        {
            foreach (DataGridViewRow row in dgPipeline.Rows)
            {
                try
                {
                    if (Convert.ToInt32(row.Cells["Selected"].Value) == -1)
                    {
                        row.DefaultCellStyle.BackColor = Color.HotPink;
                    }

                    if (row.Cells["Status"].Value.ToString() == "Ordered")
                    {
                        row.DefaultCellStyle.BackColor = Color.LawnGreen;
                    }
                    else if (row.Cells["Status"].Value.ToString() == "Lost")
                    {
                        row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
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

            cmd.CommandText = "SELECT id,[Customer Name],[Activity Date], date_modified as [Last Updated],Type,reference,Details,Contact,[Logged By] from dbo.c_sales_view_activity_list where [Logged By] = @sender AND [Customer Name] LIKE @cust order by  [Activity Date] desc";

            cmd.Parameters.AddWithValue("@sender", cmbStaff.Text);
            cmd.Parameters.AddWithValue("@cust", "%" + customer + "%");

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

            //paintActivityGrid();

            dgActivity.ClearSelection();
            dgPipeline.ClearSelection();
            dgTask.ClearSelection();
        }

        private void fillTaskGrid()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionStringToDo);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT [Task ID],[Date Created],dueDate,[Priority],Detail,[Status],SetBy,SetFor,crmActive,crmCustAccRef, CASE WHEN completeDateAddDays is null THEN DATEADD(day,-2,GETDATE()) ELSE completeDateAddDays END as [completeDateAddDays] from c_view_task_list_crm  where SetFor = @sender AND subject LIKE @cust order by dueDate desc";

            cmd.Parameters.AddWithValue("@sender", cmbStaff.Text);
            cmd.Parameters.AddWithValue("@cust", "%" + customer + "%");

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            //try
            // {
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgTask.DataSource = dt;

            //dgTask.Columns["crmActive"].Visible = false;
            //dgTask.Columns["crmCustAccRef"].Visible = false;
            //dgTask.Columns["completeDateAddDays"].Visible = false;

            //}
            // catch (Exception)
            //{
            //}

            //paintTaskGrid();V

            dgActivity.ClearSelection();
            dgPipeline.ClearSelection();
            dgTask.ClearSelection();
            dgCustomer.ClearSelection();
            colourCustomerWithTaskAssigned();
        }

        private void colourCustomerWithTaskAssigned()
        {
            string custAccRef = "";
            int crmActiveIndex = 0, taskStatusIndex = 0, custAccRefIndex = 0;
            if (dgTask.Columns.Contains("crmActive"))
                crmActiveIndex = dgTask.Columns["crmActive"].Index;
            if (dgTask.Columns.Contains("Status"))
                taskStatusIndex = dgTask.Columns["Status"].Index;
            if (dgTask.Columns.Contains("crmCustAccRef"))
                custAccRefIndex = dgTask.Columns["crmCustAccRef"].Index;
            for (int i = 0; i < dgTask.Rows.Count; i++)
            {
              //  MessageBox.Show(dgTask.Rows[i].Cells[taskStatusIndex].Value.ToString());
                //check for tasks already assigned 
                if (Convert.ToString(dgTask.Rows[i].Cells[crmActiveIndex].Value) == " - 1" && Convert.ToString(dgTask.Rows[i].Cells[taskStatusIndex].Value) != "Complete")
                {
                    custAccRef = dgTask.Rows[i].Cells[custAccRefIndex].Value.ToString();
                    for (int z = 0; z < dgCustomer.Rows.Count; z++)
                    {
                        if (dgCustomer.Rows[z].Cells[0].Value.ToString() == custAccRef)
                        {
                            dgCustomer.Rows[z].DefaultCellStyle.BackColor = Color.OrangeRed;
                            //also add this to the list
                            custAccRefList.Add(Convert.ToString(dgTask.Rows[i].Cells[9].Value));
                        }

                    }
                }
//here
            }
        }
        //check for the complete date here
        //if (DateTime.Now < (Convert.ToDateTime(dgTask.Rows[i].Cells[10].Value)))
        //{
        //    custAccRef = dgTask.Rows[i].Cells[9].Value.ToString();
        //    for (int z = 0; z < dgCustomer.Rows.Count; z++)
        //    {
        //        if (dgCustomer.Rows[z].Cells[0].Value.ToString() == custAccRef)
        //        {
        //            //change colour to blue (has been completed within the last 7 days)
        //            dgCustomer.Rows[z].DefaultCellStyle.BackColor = Color.CornflowerBlue;
        //            //also add it to the <within 7 days list>
        //            completedWithinWeek.Add(Convert.ToString(dgTask.Rows[i].Cells[9].Value));
        //        }
        //    }
        //}

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gather the selected person here and store it into a variable so that it can be referenced on the other form
            //wipe lists
            customerAccRef.Clear();
            activityID.Clear();
            taskID.Clear();
            piplineID.Clear();
            completedWithinWeek.Clear();
            custAccRefList.Clear();

            cmbName = cmbStaff.Text;
            fillGrid();
            fillActivityGrid();
            fillTaskGrid();
            fillCustomer();
            addButtons();

            //colour based on if there is a task for that customer
            //if crmActive = -1 then make it red etc

            dgActivity.ClearSelection();
            dgPipeline.ClearSelection();
            dgTask.ClearSelection();
            dgCustomer.ClearSelection();

            colourCustomerWithTaskAssigned();

            //after all this is done show the customer txtbox
            lblCustomer.Visible = true;
            txtCustomerSearch.Visible = true;
            txtCustomerSearch.Text = "";
            // MessageBox.Show(cmbName);
        }

        private void addButtons()
        {
            DataGridViewButtonColumn selectButton = new DataGridViewButtonColumn();
            selectButton.Name = "Select";
            selectButton.Text = "Select";
            selectButton.UseColumnTextForButtonValue = true;
            int columnIndex = 9;
            if (dgActivity.Columns["Select"] == null)
            {
                dgActivity.Columns.Insert(columnIndex, selectButton);
            }

            DataGridViewButtonColumn selectButtonTask = new DataGridViewButtonColumn();
            selectButtonTask.Name = "Select";
            selectButtonTask.Text = "Select";
            selectButtonTask.UseColumnTextForButtonValue = true;
            int columnIndexTask = 11;
            if (dgTask.Columns["Select"] == null)
            {
                dgTask.Columns.Insert(columnIndexTask, selectButtonTask);
            }

            DataGridViewButtonColumn selectButtonPipeline = new DataGridViewButtonColumn();
            selectButtonPipeline.Name = "Select";
            selectButtonPipeline.Text = "Select";
            selectButtonPipeline.UseColumnTextForButtonValue = true;
            int columnIndexPipeline = 9;
            if (dgPipeline.Columns["Select"] == null)
            {
                dgPipeline.Columns.Insert(columnIndexPipeline, selectButtonPipeline);
            }
            DataGridViewButtonColumn selectButtonCustomer = new DataGridViewButtonColumn();
            selectButtonCustomer.Name = "Select";
            selectButtonCustomer.Text = "Select";
            selectButtonCustomer.UseColumnTextForButtonValue = true;
            int columnIndexCustomer = 9;
            if (dgCustomer.Columns["Select"] == null)
            {
                dgCustomer.Columns.Insert(columnIndexCustomer, selectButtonCustomer);
            }
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

                //fillGrid();
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

                //fillActivityGrid();
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

        private void DgActivity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (dgActivity.CurrentRow.DefaultCellStyle.BackColor == Color.HotPink)
                {
                    dgActivity.CurrentRow.DefaultCellStyle.SelectionForeColor = Color.Black;
                    dgActivity.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.White;
                    dgActivity.CurrentRow.DefaultCellStyle.BackColor = Color.Empty;
                    activityID.Remove(Convert.ToInt32(dgActivity.CurrentRow.Cells[0].Value));
                }
                else
                {
                    dgActivity.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.HotPink;
                    dgActivity.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink;
                    activityID.Add(Convert.ToInt32(dgActivity.CurrentRow.Cells[0].Value));
                }
                //int id;
                //int currentSelected = 0;
                //int readerValue = 0;

                //int selectedrowindex = dgActivity.SelectedCells[0].RowIndex;
                //DataGridViewRow selectedRow = dgActivity.Rows[selectedrowindex];
                //id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                //SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
                //conn.Open();

                //SqlCommand cmdRead = new SqlCommand("SELECT currently_selected from dbo.crm_activity where id = @id", conn);

                //cmdRead.Parameters.AddWithValue("@id", id);

                //SqlDataReader rdr = cmdRead.ExecuteReader();

                //while (rdr.Read())
                //{
                //    try
                //    {
                //        readerValue = Convert.ToInt32(rdr["currently_selected"]);
                //    }
                //    catch
                //    {
                //        readerValue = 0;
                //    }

                //    if (readerValue == -1)
                //    {
                //        currentSelected = 0;
                //    }
                //    else
                //    {
                //        currentSelected = -1;
                //    }

                //}

                //conn.Close();
                //conn.Open();

                //SqlCommand cmd = new SqlCommand("UPDATE dbo.crm_activity set currently_selected= @status where id = @id", conn);
                //cmd.Parameters.AddWithValue("@id", id);
                //cmd.Parameters.AddWithValue("@status", currentSelected);
                //cmd.ExecuteNonQuery();
                //conn.Close();

                //fillActivityGrid();
            }
        }

        private void DgTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (dgTask.CurrentRow.DefaultCellStyle.BackColor == Color.HotPink)
                {
                    dgTask.CurrentRow.DefaultCellStyle.SelectionForeColor = Color.Black;
                    dgTask.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.White;
                    dgTask.CurrentRow.DefaultCellStyle.BackColor = Color.Empty;
                    taskID.Remove(Convert.ToInt32(dgTask.CurrentRow.Cells[0].Value));
                }
                else
                {
                    dgTask.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.HotPink;
                    dgTask.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink;
                    taskID.Add(Convert.ToInt32(dgTask.CurrentRow.Cells[0].Value));
                }

                //int id;
                //int currentSelected = 0;
                //int readerValue = 0;

                //int selectedrowindex = dgTask.SelectedCells[0].RowIndex;
                //DataGridViewRow selectedRow = dgTask.Rows[selectedrowindex];
                //id = Convert.ToInt32(selectedRow.Cells["Task ID"].Value);

                //SqlConnection conn = new SqlConnection(SqlStatements.ConnectionStringToDo);
                //conn.Open();

                //SqlCommand cmdRead = new SqlCommand("SELECT currently_selected from dbo.task where id = @id", conn);

                //cmdRead.Parameters.AddWithValue("@id", id);

                //SqlDataReader rdr = cmdRead.ExecuteReader();

                //while (rdr.Read())
                //{
                //    try
                //    {
                //        readerValue = Convert.ToInt32(rdr["currently_selected"]);
                //    }
                //    catch
                //    {
                //        readerValue = 0;
                //    }

                //    if (readerValue == -1)
                //    {
                //        currentSelected = 0;
                //    }
                //    else
                //    {
                //        currentSelected = -1;
                //    }

                //}

                //conn.Close();
                //conn.Open();

                //SqlCommand cmd = new SqlCommand("UPDATE dbo.task set currently_selected= @status where id = @id", conn);
                //cmd.Parameters.AddWithValue("@id", id);
                //cmd.Parameters.AddWithValue("@status", currentSelected);
                //cmd.ExecuteNonQuery();
                //conn.Close();
                //fillTaskGrid();
            }
        }

        private void DgPipeline_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (dgPipeline.CurrentRow.DefaultCellStyle.BackColor == Color.HotPink)
                {
                    dgPipeline.CurrentRow.DefaultCellStyle.SelectionForeColor = Color.Black;
                    dgPipeline.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.White;
                    dgPipeline.CurrentRow.DefaultCellStyle.BackColor = Color.Empty;
                    piplineID.Remove(Convert.ToInt32(dgPipeline.CurrentRow.Cells[0].Value));
                }
                else
                {
                    dgPipeline.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.HotPink;
                    dgPipeline.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink;
                    piplineID.Add(Convert.ToInt32(dgPipeline.CurrentRow.Cells[0].Value));
                }

                //int id;
                //int currentSelected = 0;
                //int readerValue = 0;

                //int selectedrowindex = dgPipeline.SelectedCells[0].RowIndex;
                //DataGridViewRow selectedRow = dgPipeline.Rows[selectedrowindex];
                //id = Convert.ToInt32(selectedRow.Cells["Pipeline ID"].Value);

                //SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
                //conn.Open();

                //SqlCommand cmdRead = new SqlCommand("SELECT currently_selected from dbo.sales_pipeline where id = @id", conn);

                //cmdRead.Parameters.AddWithValue("@id", id);

                //SqlDataReader rdr = cmdRead.ExecuteReader();

                //while (rdr.Read())
                //{
                //    try
                //    {
                //        readerValue = Convert.ToInt32(rdr["currently_selected"]);
                //    }
                //    catch
                //    {
                //        readerValue = 0;
                //    }

                //    if (readerValue == -1)
                //    {
                //        currentSelected = 0;
                //    }
                //    else
                //    {
                //        currentSelected = -1;
                //    }

                //}

                //conn.Close();
                //conn.Open();

                //SqlCommand cmd = new SqlCommand("UPDATE dbo.sales_pipeline set currently_selected= @status where id = @id", conn);
                //cmd.Parameters.AddWithValue("@id", id);
                //cmd.Parameters.AddWithValue("@status", currentSelected);
                //cmd.ExecuteNonQuery();
                //conn.Close();
                //fillGrid();
            }
        }

        private void updateSelected()
        {
            SqlConnection connToDo = new SqlConnection(SqlStatements.ConnectionStringToDo);
            connToDo.Open();

            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();

            double currentID = 0;

            foreach (DataGridViewRow row in dgPipeline.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.HotPink)
                {
                    currentID = Convert.ToDouble(row.Cells[0].Value);
                    cmd.CommandText = "UPDATE dbo.sales_pipeline set currently_selected= -1 where id = @id";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@id", currentID);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }

            foreach (DataGridViewRow row in dgActivity.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.HotPink)
                {
                    currentID = Convert.ToDouble(row.Cells[0].Value);
                    cmd.CommandText = "UPDATE dbo.crm_activity set currently_selected= -1 where id = @id";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@id", currentID);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }

            foreach (DataGridViewRow row in dgTask.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.HotPink)
                {
                    currentID = Convert.ToDouble(row.Cells[0].Value);
                    cmd.CommandText = "UPDATE dbo.task set currently_selected= -1 where id = @id";
                    cmd.Connection = connToDo;
                    cmd.Parameters.AddWithValue("@id", currentID);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }

            //wipe old data
            cmd.CommandText = "DELETE FROM dbo.crm_customer_temp_table";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            //customer
            foreach (DataGridViewRow row in dgCustomer.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.HotPink)
                {
                    string custAcc = Convert.ToString(row.Cells[0].Value);

                    //add new data
                    cmd.CommandText = "INSERT INTO dbo.crm_customer_temp_table (CustACC) VALUES('" + custAcc + "')";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
            connToDo.Close();
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            Login.emailButtonClicked = 0;
            txtCustomerSearch.Text = "";
            updateSelected();
            frmEmailUserManagement frmeum = new frmEmailUserManagement(cmbName);
            frmeum.ShowDialog();

            //check if email button was pressed
            if (Login.emailButtonClicked == 1)
            {
                //this here is the optimal point to fire the email to people
                //fire todo insert email here that doesnt shoot an email
                using (SqlConnection connectionToDo = new SqlConnection(SqlStatements.ConnectionStringToDo))
                {
                    //activity
                    for (int i = 0; i < dgActivity.Rows.Count; i++)
                    {
                        //if colour is HOT PINK
                        if (dgActivity.Rows[i].DefaultCellStyle.BackColor == Color.HotPink)
                        {
                            using (SqlCommand cmdToDo = new SqlCommand("usp_add_task_no_email", connectionToDo))
                            {
                                cmdToDo.CommandType = CommandType.StoredProcedure;
                                cmdToDo.Parameters.Add("@setByID", SqlDbType.Int).Value = Convert.ToInt32(Login.globalUserID);
                                cmdToDo.Parameters.Add("@setForId", SqlDbType.Int).Value = Convert.ToInt32(Login.userSelectedForEmail);
                                cmdToDo.Parameters.Add("@dueDate", SqlDbType.DateTime).Value = Login.dueDate;
                                cmdToDo.Parameters.Add("@taskDetail", SqlDbType.VarChar).Value = Convert.ToString(dgActivity.Rows[i].Cells[6].Value);
                                cmdToDo.Parameters.Add("@taskSubject", SqlDbType.VarChar).Value = Convert.ToString(dgActivity.Rows[i].Cells[1].Value);
                                cmdToDo.Parameters.Add("@custAccRef", SqlDbType.VarChar).Value = "ryucxd";
                                connectionToDo.Open();
                                cmdToDo.ExecuteNonQuery();
                                connectionToDo.Close();
                            }
                        }
                    }
                    //pipeline
                    for (int i = 0; i < dgPipeline.Rows.Count; i++)
                    {
                        //if colour is HOT PINK
                        if (dgPipeline.Rows[i].DefaultCellStyle.BackColor == Color.HotPink)
                        {
                            using (SqlCommand cmdToDo = new SqlCommand("usp_add_task_no_email", connectionToDo))
                            {
                                cmdToDo.CommandType = CommandType.StoredProcedure;
                                cmdToDo.Parameters.Add("@setByID", SqlDbType.Int).Value = Convert.ToInt32(Login.globalUserID);
                                cmdToDo.Parameters.Add("@setForId", SqlDbType.Int).Value = Convert.ToInt32(Login.userSelectedForEmail);
                                cmdToDo.Parameters.Add("@dueDate", SqlDbType.DateTime).Value = Login.dueDate;
                                cmdToDo.Parameters.Add("@taskDetail", SqlDbType.VarChar).Value = "PIPELINE DATA:" + Convert.ToString(dgPipeline.Rows[i].Cells[3].Value); //this feels so odd and is probably gonna get changed
                                cmdToDo.Parameters.Add("@taskSubject", SqlDbType.VarChar).Value = Convert.ToString(dgPipeline.Rows[i].Cells[1].Value);//customer reference again, this matches the other table so its gotta be right! :D
                                cmdToDo.Parameters.Add("@custAccRef", SqlDbType.VarChar).Value = "ryucxd";
                                connectionToDo.Open();
                                cmdToDo.ExecuteNonQuery();
                                connectionToDo.Close();
                            }
                        }
                    }
                    for (int i = 0; i < dgCustomer.Rows.Count; i++)
                    {
                        //if colour is HOT PINK
                        if (dgCustomer.Rows[i].DefaultCellStyle.BackColor == Color.HotPink)
                        {
                            using (SqlCommand cmdToDo = new SqlCommand("usp_add_task_no_email", connectionToDo))
                            {
                                cmdToDo.CommandType = CommandType.StoredProcedure;
                                cmdToDo.Parameters.Add("@setByID", SqlDbType.Int).Value = Convert.ToInt32(Login.globalUserID);
                                cmdToDo.Parameters.Add("@setForId", SqlDbType.Int).Value = Convert.ToInt32(Login.userSelectedForEmail);
                                cmdToDo.Parameters.Add("@dueDate", SqlDbType.DateTime).Value = Login.dueDate;
                                cmdToDo.Parameters.Add("@taskDetail", SqlDbType.VarChar).Value = "Chase Customer: " + Convert.ToString(dgCustomer.Rows[i].Cells[1].Value); //this feels so odd and is probably gonna get changed
                                cmdToDo.Parameters.Add("@taskSubject", SqlDbType.VarChar).Value = Login.customerText;//customer reference again, this matches the other table so its gotta be right! :D
                                cmdToDo.Parameters.Add("@custAccRef", SqlDbType.VarChar).Value = Convert.ToString(dgCustomer.Rows[i].Cells[0].Value);
                                custAccRefList.Add(dgCustomer.Rows[i].Cells[0].Value.ToString());
                                connectionToDo.Open();
                                cmdToDo.ExecuteNonQuery();
                                connectionToDo.Close();
                            }
                        }
                    }
                    //customer
                }

                foreach (DataGridViewRow row in dgPipeline.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
                }

                foreach (DataGridViewRow row in dgActivity.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
                }

                foreach (DataGridViewRow row in dgTask.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
                }

                foreach (DataGridViewRow row in dgCustomer.Rows)
                {
                    if (custAccRefList.Contains(row.Cells[0].Value.ToString()))
                        row.DefaultCellStyle.BackColor = Color.OrangeRed;
                    else if (completedWithinWeek.Contains(row.Cells[0].Value.ToString()))
                        row.DefaultCellStyle.BackColor = Color.CornflowerBlue;
                    else
                        row.DefaultCellStyle.BackColor = Color.Empty;
                }
                dgActivity.ClearSelection();
                dgPipeline.ClearSelection();
                dgTask.ClearSelection();
                dgCustomer.ClearSelection();
                //wipe the lists here
                customerAccRef.Clear();
                activityID.Clear();
                taskID.Clear();
                piplineID.Clear();

                //nulldgvs();
                //fillGrid();
                //refresh all the grids (I had no success with manually doing it so I'm gonna remove the text in the cmbbox and re add it
            }

        }

        private void DgTask_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pID;
            if (dgTask.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgTask.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgTask.Rows[selectedrowindex];

                pID = Convert.ToInt32(selectedRow.Cells["Task ID"].Value);

                frmAmendToDo frmATD = new frmAmendToDo(pID);
                frmATD.ShowDialog();

                //fillGrid();
            }
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCustomerSearch_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //customer = txtCustomerSearch.Text;
            //fillGrid();
            //fillActivityGrid();
            //fillTaskGrid();
            //fillCustomer();
        }

        private void fillCustomer()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select [account ref],[Customer Name],Telephone,[Address_1],address_2,address_3,Address_4,[Account Status],[Customer Type] From dbo.c_sales_view_customer_data where [Customer Name] like @custName order by [Customer Name] ASC";
            cmd.Parameters.AddWithValue("@custName", "%" + customer + "%");
            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            try
            {
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dgCustomer.DataSource = dt;
            }
            catch (Exception)
            {
            }
        }

        private void dgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (dgCustomer.CurrentRow.DefaultCellStyle.BackColor == Color.OrangeRed)
                {
                    MessageBox.Show("This customer is already assigned as a task!"); //ryucxdddd
                }
                else if (dgCustomer.CurrentRow.DefaultCellStyle.BackColor == Color.CornflowerBlue)
                {
                    MessageBox.Show("This customer has already been chased within the last 7 working days!");
                }
                else if (dgCustomer.CurrentRow.DefaultCellStyle.BackColor == Color.HotPink)
                {
                    dgCustomer.CurrentRow.DefaultCellStyle.SelectionForeColor = Color.Black;
                    dgCustomer.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.White;
                    dgCustomer.CurrentRow.DefaultCellStyle.BackColor = Color.Empty;
                    customerAccRef.Remove(dgCustomer.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    dgCustomer.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.HotPink;
                    dgCustomer.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink;
                    //add to the array here
                    customerAccRef.Add(dgCustomer.CurrentRow.Cells[0].Value.ToString());
                }
            }
        }

        private void dgCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgCustomer.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgCustomer.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgCustomer.Rows[selectedrowindex];

                string custAccRef = selectedRow.Cells["Account Ref"].Value.ToString();
                string custName = selectedRow.Cells["Customer Name"].Value.ToString();

                frmCustomerInformation frmCI = new frmCustomerInformation(custAccRef, custName);
                frmCI.ShowDialog();
                //fillGrid();
            }
        }

        private void txtCustomerSearch_TextChanged_1(object sender, EventArgs e)
        {
            customer = txtCustomerSearch.Text;
            //null the dgvs
            nulldgvs();
            fillGrid();
            fillActivityGrid();
            fillTaskGrid();
            fillCustomer();
            addButtons();
            addPink();
        }

        private void addPink()
        {
            //for each DGV, loop through the records and if any match the list for that table make it pink again
            //customer
            for (int i = 0; i < dgCustomer.Rows.Count; i++)
            {
                if (customerAccRef.Contains(dgCustomer.Rows[i].Cells[0].Value.ToString()))
                {
                    dgCustomer.Rows[i].DefaultCellStyle.SelectionBackColor = Color.HotPink; //if its the top row then it sekects it as pink and not the awful blue color
                    dgCustomer.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                }
                else if (custAccRefList.Contains(dgCustomer.Rows[i].Cells[0].Value.ToString()))
                {
                    dgCustomer.Rows[i].DefaultCellStyle.SelectionBackColor = Color.OrangeRed; //if its the top row then it sekects it as pink and not the awful blue color
                    dgCustomer.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                }
                else if (completedWithinWeek.Contains(dgCustomer.Rows[i].Cells[0].Value.ToString()))
                {
                    dgCustomer.Rows[i].DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue; //if its the top row then it sekects it as pink and not the awful blue color
                    dgCustomer.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;
                }
                else
                {
                    dgCustomer.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black; //this stops the awful /blue/ highlight from appearing
                    dgCustomer.Rows[i].DefaultCellStyle.SelectionBackColor = Color.White;
                    dgCustomer.Rows[i].DefaultCellStyle.BackColor = Color.Empty;
                }
            }
            //User Activity
            for (int i = 0; i < dgActivity.Rows.Count; i++)
            {
                if (activityID.Contains(Convert.ToInt32(dgActivity.Rows[i].Cells[0].Value)))
                {
                    dgActivity.Rows[i].DefaultCellStyle.SelectionBackColor = Color.HotPink;
                    dgActivity.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                }
                else
                {
                    dgActivity.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                    dgActivity.Rows[i].DefaultCellStyle.SelectionBackColor = Color.White;
                    dgActivity.Rows[i].DefaultCellStyle.BackColor = Color.Empty;
                }
            }
            //Task to do system
            for (int i = 0; i < dgTask.Rows.Count; i++)
            {
                if (taskID.Contains(Convert.ToInt32(dgTask.Rows[i].Cells[0].Value)))
                {
                    dgTask.Rows[i].DefaultCellStyle.SelectionBackColor = Color.HotPink;
                    dgTask.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                }
                else
                {
                    dgTask.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                    dgTask.Rows[i].DefaultCellStyle.SelectionBackColor = Color.White;
                    dgTask.Rows[i].DefaultCellStyle.BackColor = Color.Empty;
                }
            }
            //last of all the Pipline data
            for (int i = 0; i < dgPipeline.Rows.Count; i++)
            {
                if (piplineID.Contains(Convert.ToInt32(dgPipeline.Rows[i].Cells[0].Value)))
                {
                    dgPipeline.Rows[i].DefaultCellStyle.SelectionBackColor = Color.HotPink;
                    dgPipeline.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                }
                else
                {
                    dgPipeline.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                    dgPipeline.Rows[i].DefaultCellStyle.SelectionBackColor = Color.White;
                    dgPipeline.Rows[i].DefaultCellStyle.BackColor = Color.Empty;
                }
            }
        }

        private void nulldgvs()
        {
            dgActivity.DataSource = null;
            dgActivity.Rows.Clear();
            dgActivity.Columns.Clear();
            dgTask.DataSource = null;
            dgTask.Rows.Clear();
            dgTask.Columns.Clear();
            dgCustomer.DataSource = null;
            dgCustomer.Rows.Clear();
            dgCustomer.Columns.Clear();
            dgPipeline.DataSource = null;
            dgPipeline.Rows.Clear();
            dgPipeline.Columns.Clear();
        }

        private void cviewsalesprogramusersBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }
    }
}