using StartUpClass;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TSalesManagement
{
    public partial class frmNewPipeline : Form
    {
        public string _accRef { get; set; }
        public int _activityID { get; set; }

        public frmNewPipeline(string custAccRef, int activityID)
        {
            InitializeComponent();
            _accRef = custAccRef;
            _activityID = activityID;
        }

        private void frmNewPipeline_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDetails.Text) || string.IsNullOrWhiteSpace(txtOrderDate.Text) || string.IsNullOrWhiteSpace(txtOrderRef.Text) || string.IsNullOrWhiteSpace(txtOrderValue.Text) || string.IsNullOrWhiteSpace(cmbDoorStyle.Text) || string.IsNullOrWhiteSpace(cmbStatus.Text) || string.IsNullOrWhiteSpace(cmbOrder.Text))
            {
                MessageBox.Show("All fields are mandatory, please complete the form in order to submit the pipeline data!", "Complete form!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO DBO.sales_pipeline (door_style,customer_acc_ref,order_ref,estimated_order_value, estimated_order_date,added_by_id, date_added,description_of_doors_on_order,order_status,activity_id,likelihood_of_order) " +
                                  " VALUES (@doorStyle,@custAccRef,@orderRef,@estimatedOrderValue,@estimatedOrderDate,@addedBy,@dateAdded,@description,@status,@activityID,@order)";
                cmd.Parameters.AddWithValue("@doorStyle", cmbDoorStyle.Text);
                cmd.Parameters.AddWithValue("@custAccRef", _accRef);
                cmd.Parameters.AddWithValue("@orderRef", txtOrderRef.Text);
                cmd.Parameters.AddWithValue("@estimatedOrderValue", txtOrderValue.Text);
                cmd.Parameters.AddWithValue("@estimatedOrderDate", txtOrderDate.Text);
                cmd.Parameters.AddWithValue("@addedBy", Login.globalUserID);
                cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@description", txtDetails.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@activityID", _activityID);
                cmd.Parameters.AddWithValue("@order", cmbOrder.Text);

                cmd.ExecuteNonQuery();

                conn.Close();
                this.Close();
            }
        }

        private void txtOrderDate_TextChanged(object sender, EventArgs e)
        {
        }
    }
}