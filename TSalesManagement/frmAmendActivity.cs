using StartUpClass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TSalesManagement
{
    public partial class frmAmendActivity : Form
    {
        public int _aID { get; set; }
        private string _custAccRef { get; set; }

        public frmAmendActivity(int aID)
        {
            InitializeComponent();
            _aID = aID;

            fillData();
            populateContacts();
           
        }

        private void fillData()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * from dbo.crm_activity where id=@id";
            cmd.Parameters.AddWithValue("@id", _aID);

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                _custAccRef = rdr["customer_acc_ref"].ToString();
                cmbRecipient.Text = rdr["recipient"].ToString();
                cmbType.Text = rdr["correspondance_type"].ToString();
                txtDetails.Text = rdr["details_of"].ToString();
                txtReference.Text = rdr["reference"].ToString();
            }

            rdr.Close();
            conn.Close();
        }

        private void frmAmendActivity_Load(object sender, EventArgs e)
        {
        }

        private void populateContacts()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select id, contact_name from dbo.crm_customer_contacts WHERE cust_acc_ref=@custAccRef", conn);
            cmd.Parameters.AddWithValue("@custAccRef", _custAccRef);

            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("contact_name", typeof(string));
            dt.Load(rdr);

            cmbRecipient.ValueMember = "id";
            cmbRecipient.DisplayMember = "contact_name";
            cmbRecipient.DataSource = dt;
            conn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            string nameWithCapital = Login.globalUserName;
            nameWithCapital = char.ToUpper(nameWithCapital[0]) + nameWithCapital.Substring(1);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE dbo.crm_activity set customer_acc_ref = @custAccRef, date_modified = @date ,correspondance_type = @type ,details_of = @details ,recipient = @recipient ,reference =@ref where id = @id ";
            cmd.Parameters.AddWithValue("@custAccRef", _custAccRef);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@type", cmbType.Text); //time stamp the users who just added this
            cmd.Parameters.AddWithValue("@details", txtDetails.Text + " || " + nameWithCapital + " - " + DateTime.Now.ToString() + " || ");
            cmd.Parameters.AddWithValue("@ref", txtReference.Text);
            cmd.Parameters.AddWithValue("@recipient", cmbRecipient.SelectedValue);
            cmd.Parameters.AddWithValue("@id", _aID);
            cmd.ExecuteNonQuery();

            //get the sender ID for this task
            string sql = "SELECT COALESCE(sender_id,0) FROM dbo.crm_activity WHERE id = " + _aID;
            int sender_id = 0;
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                sender_id = Convert.ToInt32(command.ExecuteScalar());
            }
            //now get the cc ID (if it exists)
            int cc = 0;
            sql = "SELECT COALESCE(cc,0) FROM dbo.crm_activity WHERE id = " + _aID;
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                cc = Convert.ToInt32(command.ExecuteScalar());
            }

            if (sender_id != 0) //dont do anything fancy here if its == 0, just carry on as normal and maybe log this error somewhere
            {
                //now check if the sender_id is the same as the person logged in
                if (Login.globalUserID == sender_id)
                {
                    //they are the same
                    //check if cc is 0
                    if (cc != 0 && cc != sender_id)
                    {
                        //there is someone in the CC field and its not the same as the sender id
                        //lets fire this bad boy and email the person who is cc'd
                        using (SqlCommand command = new SqlCommand("usp_crm_activity_cc_or_sender_email", conn))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@email_id", SqlDbType.Int).Value = cc;
                            command.Parameters.Add("@activity_id", SqlDbType.Int).Value = _aID;
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        //there is no one in the cc field and its the original sender logged in therefore do nothing and continue as normal
                    }
                }
                else //login is NOT the same as the sender, therefore attach them to the  column or if they exist already then just fire the response
                {
                    if (cc == 0 && sender_id != Login.globalUserID)
                    {
                        //cc is null and the user logged in is (just for extra safety) not equal to  the sender_id
                        //add this new user to the CC field
                        sql = "UPDATE dbo.crm_activity SET cc = " + Login.globalUserID.ToString() + " WHERE id = " + _aID;
                        using (SqlCommand command = new SqlCommand(sql, conn))
                        {
                            command.ExecuteScalar();
                        }
                    }
                    //at this point cc already existed or has now been added so we can fire the email to the original sender

                    using (SqlCommand command = new SqlCommand("usp_crm_activity_cc_or_sender_email", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@email_id", SqlDbType.Int).Value = sender_id;
                        command.Parameters.Add("@activity_id", SqlDbType.Int).Value = _aID;
                        command.ExecuteNonQuery();
                    }
                }
            }
            conn.Close();
            this.Close();
        }

        private void btnPipeline_Click(object sender, EventArgs e)
        {
            frmNewPipeline frmNP = new frmNewPipeline(_custAccRef, _aID);
            frmNP.ShowDialog();
            this.Close();
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            //open form for note entry
            frmActivityNote frm = new frmActivityNote(_aID);
            frm.ShowDialog();
            //refresh the DGV so that it now shows the newst note aswell :}
            fillDGV();
        }

        private void fillDGV()
        {
            //crm_activity_notes
            string sql = "SELECT detail as [Detail],noteBy as [Note By], noteDate as [Note Date] FROM dbo.crm_activity_notes WHERE activityID = " + _aID + " ORDER BY noteID desc";
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            }
            //also do some formatting while we are here :}
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private void frmAmendActivity_Shown(object sender, EventArgs e)
        {
            fillDGV();
        }
    }
}