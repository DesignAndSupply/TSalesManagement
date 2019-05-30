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
using TSalesManagement.Class;
using StartUpClass;

namespace TSalesManagement
{
    public partial class frmNewCustomerNotes : Form
    {
        public frmNewCustomerNotes(string accRef)
        {
            InitializeComponent();
            _accRef = accRef;
            populateNotes();
        }


        public string _accRef { get; set; }


        private void frmNonReturningCustomerNotes_Load(object sender, EventArgs e)
        {

        }

        private void populateNotes()
        {
            if (checkRecordExists() == true)
            {
                SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("select notes_of_conversation from dbo.crm_new_customer_data where customer_acc_ref = @accRef", conn);
                cmd.Parameters.AddWithValue("@accRef", _accRef);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    txtNotes.Text = rdr["notes_of_conversation"].ToString();
                }

                conn.Close();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            if (checkRecordExists() == true)
            {
                SqlCommand cmd = new SqlCommand("update dbo.crm_new_customer_data set notes_of_conversation = @notes, contacted_date =@date, contacted_by = @contactBy where customer_acc_ref = @accRef", conn);

                cmd.Parameters.AddWithValue("@accRef", _accRef);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@contactBy", Login.globalFullName);
                cmd.Parameters.AddWithValue("@notes", txtNotes.Text);
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.crm_new_customer_data (notes_of_conversation,contacted_by, contacted_date,customer_acc_ref) VALUES(@notes,@contactBy,@date,@accRef);", conn);

                cmd.Parameters.AddWithValue("@accRef", _accRef);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@contactBy", Login.globalFullName);
                cmd.Parameters.AddWithValue("@notes", txtNotes.Text);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
            this.Close();

            DialogResult dr = MessageBox.Show("Would you like to add this to your activity list also?", "Add activity", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                updateActivity();
                MessageBox.Show("Activity added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void updateActivity()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Insert INTO dbo.crm_activity (customer_acc_ref,date_created,correspondance_type,details_of,sender_id,date_modified) " +
                "VALUES (@custAccRef,@dateCreated,@cType,@detailsOf,@senderID,@dateModified)", conn);

            cmd.Parameters.AddWithValue("@custAccRef", _accRef);
            cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now);
            cmd.Parameters.AddWithValue("@cType", "New Customers Update");
            cmd.Parameters.AddWithValue("@detailsOf", txtNotes.Text);
            cmd.Parameters.AddWithValue("@senderID", Login.globalUserID);
            cmd.Parameters.AddWithValue("@dateModified", DateTime.Now);

            cmd.ExecuteNonQuery();

            conn.Close();




        }
        private bool checkRecordExists()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.crm_new_customer_data where customer_acc_ref = @accRef", conn);

            cmd.Parameters.AddWithValue("@accRef", _accRef);

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
