using StartUpClass;
using System;
using System.Data;
using System.Data.SqlClient;

namespace TSalesManagement
{
    internal class Tasks
    {
        public void createTask(int setForID, DateTime? dueDate, string priorityLevel, string taskDetail, string taskSubject, bool logOnBehalf, int logOnBehalfOF, double? activityiD)
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionStringToDo);

            int currentUserID = Login.globalUserID;

            string command = "usp_add_task";

            using (SqlCommand cmd = new SqlCommand(command, conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@setByID", SqlDbType.Int).Value = logOnBehalfOF;
                cmd.Parameters.AddWithValue("@setForID", SqlDbType.Int).Value = setForID;
                if (dueDate != null)
                {
                    cmd.Parameters.AddWithValue("@dueDate", SqlDbType.DateTime).Value = dueDate;
                }

                if (activityiD != null)
                {
                    cmd.Parameters.AddWithValue("@activityID", SqlDbType.Int).Value = activityiD;
                }

                cmd.Parameters.AddWithValue("@createdDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@priorityLevel", SqlDbType.NVarChar).Value = priorityLevel;
                cmd.Parameters.AddWithValue("@taskDetail", SqlDbType.NVarChar).Value = taskDetail;
                cmd.Parameters.AddWithValue("@taskSubject", SqlDbType.NVarChar).Value = taskSubject;
                cmd.Parameters.AddWithValue("@onBehalfOf", SqlDbType.Bit).Value = logOnBehalf;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
    }
}