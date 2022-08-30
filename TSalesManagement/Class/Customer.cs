using System.Data.SqlClient;

namespace TSalesManagement.Class
{
    internal class Customer
    {
        public string _custAccRef { get; set; }
        public string _add1 { get; set; }
        public string _add2 { get; set; }
        public string _add3 { get; set; }
        public string _add4 { get; set; }
        public string _add5 { get; set; }
        public string _tel1 { get; set; }
        public string _tel2 { get; set; }
        public string _fax { get; set; }

        public string _customerName
        {
            get
            {
                SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT [Name] from dbo.view_SALES_LEDGER_AND_PROSPECT where [Account_Ref]=@accRef", conn);
                //c_sales_view_customer_data  -- swapped the left view out for the sales ledger one, seems archived accoutns returned null and broke the code
                cmd.Parameters.AddWithValue("@accRef", _custAccRef);
                return cmd.ExecuteScalar().ToString();
            }
        }

        public Customer(string accRef)
        {
            _custAccRef = accRef;
            getCustomerInfo();
        }

        private void getCustomerInfo()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select Address_1,Address_2,Address_3,Address_4,Address_5, telephone, [telephone 2] , fax from c_sales_view_customer_data where [Account Ref] = @accRef;";
            cmd.Parameters.AddWithValue("@accRef", _custAccRef);

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                _add1 = rdr["Address_1"].ToString() ?? "";
                _add2 = rdr["Address_2"].ToString() ?? "";
                _add3 = rdr["Address_3"].ToString() ?? "";
                _add4 = rdr["Address_4"].ToString() ?? "";
                _add5 = rdr["Address_5"].ToString() ?? "";
                _tel1 = rdr["telephone"].ToString() ?? "";
                _tel2 = rdr["telephone 2"].ToString() ?? "";
                _fax = rdr["fax"].ToString() ?? "";
            }
            else
            {
            }

            conn.Close();
        }
    }
}