using StartUpClass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TSalesManagement.Class;


namespace TSalesManagement
{
    public partial class frmNewActivity : Form
    {
        public string _custAccRef { get; set; }
        public int _taskID { get; set; }
        public int _validation { get; set; }
        public frmNewActivity(string custAccRef,int taskID,int validation)
        {
            InitializeComponent();
            _custAccRef = custAccRef;
            _taskID = taskID;
            _validation = validation;
            Customer c = new Customer(_custAccRef);

            lblCustomer.Text = c._customerName;
            populateContacts();
            
        }

        private void frmNewActivity_Load(object sender, EventArgs e)
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
            if (cmbRecipient.SelectedItem == null)
            {
                MessageBox.Show("Please select a Contact before adding the activity!");
                return;
            }
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO dbo.crm_activity (customer_acc_ref, date_created,correspondance_type,details_of,recipient,sender_id,reference) " +
                              "VALUES (@custAccRef,@date,@type,@details,@recipient,@sender,@ref)";

            cmd.Parameters.AddWithValue("@custAccRef", _custAccRef);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@type", cmbType.Text);
            cmd.Parameters.AddWithValue("@details", txtDetails.Text);
            cmd.Parameters.AddWithValue("@ref", txtReference.Text);
            cmd.Parameters.AddWithValue("@recipient", cmbRecipient.SelectedValue);
            cmd.Parameters.AddWithValue("@sender", Login.globalUserID);

            cmd.ExecuteNonQuery();

            conn.Close();
            Login.activityAdded = -1;

            if (_validation == 0)  //if its -1 its adding an activity from a task
            {
                //Prompts user to add task to ToDo  System
                DialogResult dr = MessageBox.Show("Do you want to create a task from this activity?", "Create Task?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    double maxID;
                    SqlConnection connr = new SqlConnection(SqlStatements.ConnectionString);
                    connr.Open();
                    SqlCommand cmdr = new SqlCommand("select max(id) as maxID from dbo.crm_activity", connr);
                    SqlDataReader rdr = cmdr.ExecuteReader();

                    if (rdr.Read())
                    {
                        maxID = Convert.ToDouble(rdr["maxID"]);
                    }
                    else
                    {
                        maxID = 0;
                    }

                    frmNewTask nt = new frmNewTask(maxID, cmbRecipient.Text, txtReference.Text, txtDetails.Text, lblCustomer.Text);
                    nt.ShowDialog();
                }
            }

            this.Close();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            frmNewContact frm = new frmNewContact(_custAccRef);
            frm.ShowDialog();
            populateContacts();
        }
    }
}