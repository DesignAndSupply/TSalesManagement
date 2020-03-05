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

            StringBuilder sb = new StringBuilder("SELECT id as 'Pipeline ID',[Customer Name], door_style as 'Door Style', order_ref as 'Order Reference', estimated_order_date as 'Estimated date of order', added_by_id as 'Added by', date_added as 'Added on', estimated_order_value as 'Estimated Value', order_status as 'Status',currently_selected as 'Selected' FROM c_view_sales_pipeline_text where added_by_id =@user ");

            //If filter on order status is selected
            if (string.IsNullOrWhiteSpace(cmbSearchStatus.Text))
            {

            }
            else
            {
                sb.Append(" AND order_status = @oStatus ");
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

            //paintGrid();

            dgActivity.ClearSelection();
            dgPipeline.ClearSelection();
            dgTask.ClearSelection();
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

            cmd.CommandText = "SELECT id,[Customer Name],[Activity Date], date_modified as [Last Updated],Type,reference,Details,Contact,[Logged By],[Selected] from dbo.c_sales_view_activity_list where [Logged By] = @sender order by  [Activity Date] desc";

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

            cmd.CommandText = "SELECT * from c_view_task_list_crm where SetFor = @sender order by dueDate desc";

            cmd.Parameters.AddWithValue("@sender", cmbStaff.Text);

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            //try
            // {
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgTask.DataSource = dt;


            //}
            // catch (Exception)
            //{

            //}

            //paintTaskGrid();V

            dgActivity.ClearSelection();
            dgPipeline.ClearSelection();
            dgTask.ClearSelection();

        }





        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid();
            fillActivityGrid();
            fillTaskGrid();
            addButtons();

            dgActivity.ClearSelection();
            dgPipeline.ClearSelection();
            dgTask.ClearSelection();


        }


        private void addButtons()
        {
            DataGridViewButtonColumn selectButton = new DataGridViewButtonColumn();
            selectButton.Name = "Select";
            selectButton.Text = "Select";
            selectButton.UseColumnTextForButtonValue = true;
            int columnIndex = 10;
            if (dgActivity.Columns["Select"] == null)
            {
                dgActivity.Columns.Insert(columnIndex, selectButton);
            }

            DataGridViewButtonColumn selectButtonTask = new DataGridViewButtonColumn();
            selectButtonTask.Name = "Select";
            selectButtonTask.Text = "Select";
            selectButtonTask.UseColumnTextForButtonValue = true;
            int columnIndexTask = 10;
            if (dgTask.Columns["Select"] == null)
            {
                dgTask.Columns.Insert(columnIndexTask, selectButtonTask);
            }

            DataGridViewButtonColumn selectButtonPipeline = new DataGridViewButtonColumn();
            selectButtonPipeline.Name = "Select";
            selectButtonPipeline.Text = "Select";
            selectButtonPipeline.UseColumnTextForButtonValue = true;
            int columnIndexPipeline = 10;
            if (dgPipeline.Columns["Select"] == null)
            {
                dgPipeline.Columns.Insert(columnIndexPipeline, selectButtonPipeline);
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
                }
                else
                {

                    dgActivity.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.HotPink;
                    dgActivity.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink;
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
                }
                else
                {
                    dgTask.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.HotPink;
                    dgTask.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink;
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
                }
                else
                {
                    dgPipeline.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.HotPink;
                    dgPipeline.CurrentRow.DefaultCellStyle.BackColor = Color.HotPink;
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



            conn.Close();
            connToDo.Close();





        }


        private void BtnEmail_Click(object sender, EventArgs e)
        {

            updateSelected();
            frmEmailUserManagement frmeum = new frmEmailUserManagement();
            frmeum.ShowDialog();


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
                            cmdToDo.Parameters.Add("@taskSubject", SqlDbType.VarChar).Value = Convert.ToString(dgPipeline.Rows[i].Cells[1].Value);
                            connectionToDo.Open();
                            cmdToDo.ExecuteNonQuery();
                            connectionToDo.Close();
                        }
                    }
                }
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

            dgActivity.ClearSelection();
            dgPipeline.ClearSelection();
            dgTask.ClearSelection();


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
    }
}

