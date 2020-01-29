using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TSalesManagement
{
    class SqlStatements
    {

        public const string ConnectionString = "user id=sa;" +
                               "password=Dodid1;Network Address=192.168.0.150\\sqlexpress;" +
                               "Trusted_Connection=no;" +
                               "database=order_database; " +
                               "connection timeout=30";

        public const string ConnectionStringToDo = "user id=sa;" +
             "password=Dodid1;Network Address=192.168.0.150\\sqlexpress;" +
             "Trusted_Connection=no;" +
             "database=ToDo; " +
             "connection timeout=30";





        public Tuple<Int32,Int32> GetSalesTarget(string monthName, string yearName)
        {

            SqlConnection SqlCon = new SqlConnection(SqlStatements.ConnectionString);

            SqlCommand getSalesTargetSQL = new SqlCommand();
            getSalesTargetSQL.Connection = SqlCon;
            getSalesTargetSQL.CommandType = CommandType.Text;
            getSalesTargetSQL.CommandText = "Select target_value, slimline_target_value FROM dbo.forecast_target where forecast_month = @month and forecast_year = @year";
            getSalesTargetSQL.Parameters.AddWithValue("@month", monthName);
            getSalesTargetSQL.Parameters.AddWithValue("@year", yearName);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(getSalesTargetSQL);
            adapter.Fill(dt);
            

            if (dt != null)
            {

                foreach (DataRow row in dt.Rows)
                {

                    //return Convert.ToInt16(row["target_value"]);
                    return Tuple.Create(Convert.ToInt32(row["target_value"]), Convert.ToInt32(row["slimline_target_value"]));
                }
            }
            else
            {
                return Tuple.Create(Convert.ToInt32(0), Convert.ToInt32(0));
            }


            return Tuple.Create(Convert.ToInt32(0), Convert.ToInt32(0));
        }


        public void UpdateRecord(string meetingNote, DateTime firstDayOfMonth)
        {
            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            //try
            //{

                SqlCommand sqlcmd = new SqlCommand("UPDATE dbo.SALES_meeting_notes SET meetingNotes = @note WHERE meetingMonth = @firstDayOfMonth ", sqlconn);
                sqlcmd.Parameters.AddWithValue("@note", meetingNote);
                sqlcmd.Parameters.AddWithValue("@firstDayOfMonth", firstDayOfMonth);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            //}
            //catch
            //{
            //    SqlCommand sqlcmd = new SqlCommand("INSERT INTO  dbo.SALES_meeting_notes (meetingMonth,meetingNotes) VALUES (@firstDayOfMonth,@note) ", sqlconn);
            //    sqlcmd.Parameters.AddWithValue("@note", meetingNote);
            //    sqlcmd.Parameters.AddWithValue("@firstDayOfMonth", firstDayOfMonth);
            //    sqlcmd.ExecuteNonQuery();
            //    sqlconn.Close();
            //}

        }

    }
}
