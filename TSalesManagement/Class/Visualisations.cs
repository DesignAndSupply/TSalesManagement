using System;
using System.Data.SqlClient;

namespace TSalesManagement.Class
{
    internal class Visualisations
    {
        public string _custAccRef { get; set; }

        public double conversionRate
        {
            get
            {
                SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
                conn.Open();
                double convRate;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM c_view_customer_conversion_rate where crm_acc_ref = @accRef";
                cmd.Parameters.AddWithValue("@accRef", _custAccRef);

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    try
                    {
                        convRate = Convert.ToDouble(rdr["ConversionRate"] ?? 0);
                    }
                    catch
                    {
                        convRate = 0;
                    }
                }
                else
                {
                    convRate = 0;
                }
                conn.Close();
                return convRate;
            }
        }

        public Visualisations(string custAccRef)
        {
            _custAccRef = custAccRef;
        }
    }
}