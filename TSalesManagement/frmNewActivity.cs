using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSalesManagement.Class;
using System.Data.SqlClient;
using StartUpClass;

namespace TSalesManagement
{
    public partial class frmNewActivity : Form
    {

        public string _custAccRef { get; set; }

        public frmNewActivity(string custAccRef)
        {
            InitializeComponent();
            _custAccRef = custAccRef;

            Customer c = new Customer(_custAccRef);

            lblCustomer.Text =  c._customerName;
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
                
                frmNewTask nt = new frmNewTask(maxID, cmbRecipient.Text, txtReference.Text,txtDetails.Text, lblCustomer.Text);
                nt.ShowDialog();
            }







            this.Close();



        }
    }
}
