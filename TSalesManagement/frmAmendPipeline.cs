using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TSalesManagement
{
    public partial class frmAmendPipeline : Form
    {
        private int _pID { get; set; }
        private string _accRef { get; set; }
        public string _doorStyle { get; set; }
        private string _orderRef { get; set; }
        private double _orderValue { get; set; }
        private DateTime _orderDate { get; set; }
        private string _details { get; set; }
        private string _status { get; set; }

        private string _customerName
        {
            get
            {
                SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT [Customer Name] from dbo.c_sales_view_customer_data where [Account Ref]=@accRef", conn);

                cmd.Parameters.AddWithValue("@accRef", _accRef);
                return cmd.ExecuteScalar().ToString();
            }
        }

        public frmAmendPipeline(int pipeID)
        {
            InitializeComponent();
            _pID = pipeID;
            fillData();
        }

        private void fillData()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * from dbo.sales_pipeline where id=@id";
            cmd.Parameters.AddWithValue("@id", _pID);

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                _doorStyle = rdr["door_style"].ToString();
                _accRef = rdr["customer_acc_ref"].ToString();
                _orderRef = rdr["order_ref"].ToString();
                _orderValue = Convert.ToDouble(rdr["estimated_order_value"]);
                _orderDate = Convert.ToDateTime(rdr["estimated_order_date"]);
                _details = rdr["description_of_doors_on_order"].ToString();
                _status = rdr["order_status"].ToString();
            }

            rdr.Close();
            conn.Close();

            cmbDoorStyle.Text = _doorStyle;
            txtOrderRef.Text = _orderRef;
            txtOrderValue.Text = _orderValue.ToString();
            txtOrderDate.Text = _orderDate.ToString();
            txtDetails.Text = _details;
            cmbStatus.Text = _status;
            txtCustomer.Text = _customerName;
        }

        private void frmAmendPipeline_Load(object sender, EventArgs e)
        {
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDetails.Text) || string.IsNullOrWhiteSpace(txtOrderDate.Text) || string.IsNullOrWhiteSpace(txtOrderRef.Text) || string.IsNullOrWhiteSpace(txtOrderValue.Text) || string.IsNullOrWhiteSpace(cmbDoorStyle.Text) || string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("All fields are mandatory, please complete the form in order to submit the pipeline data!", "Complete form!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO DBO.sales_pipeline (door_style,customer_acc_ref,order_ref,estimated_order_value, estimated_order_date,added_by_id, date_added,description_of_doors_on_order,order_status) " +
                                  " VALUES (@doorStyle,@custAccRef,@orderRef,@estimatedOrderValue,@estimatedOrderDate,@addedBy,@dateAdded,@description,@status)";

                cmd.CommandText = "UPDATE dbo.sales_pipeline SET door_style = @doorStyle, customer_acc_ref = @custAccRef, order_ref = @orderRef, estimated_order_value = @estimatedOrderValue, estimated_order_date = @estimatedOrderDate ," +
                                  "  description_of_doors_on_order =@description, order_status = @status WHERE id=@id";

                cmd.Parameters.AddWithValue("@id", _pID);
                cmd.Parameters.AddWithValue("@doorStyle", cmbDoorStyle.Text);
                cmd.Parameters.AddWithValue("@custAccRef", _accRef);
                cmd.Parameters.AddWithValue("@orderRef", txtOrderRef.Text);
                cmd.Parameters.AddWithValue("@estimatedOrderValue", txtOrderValue.Text);
                cmd.Parameters.AddWithValue("@estimatedOrderDate", txtOrderDate.Text);

                cmd.Parameters.AddWithValue("@description", txtDetails.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                cmd.ExecuteNonQuery();

                conn.Close();
                this.Close();
            }
        }
    }
}