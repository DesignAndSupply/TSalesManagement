using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DSToDo
{
    class Task
    {
        public double _taskID { get; set; }
        public int setByID  { get; set; }
        public int setForID { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime createdDate { get; set; }
        public int priorityLevel { get; set; }
        public string taskDetail { get; set; }
        public string taskSubject { get; set; }
        public string taskStatus { get; set; }



        public Task()
        {

        }

        public void updateTaskStatus(double taskID, string taskStatus)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnectionString);



            string command = "usp_update_status";

            using (SqlCommand cmd = new SqlCommand(command, conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@taskID", SqlDbType.Int).Value = taskID;
                cmd.Parameters.AddWithValue("@taskStatus", SqlDbType.NVarChar).Value = taskStatus;

                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }


        public void getTask(double taskID)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.task where id = @taskID", conn);

            conn.Open();
            cmd.Parameters.AddWithValue("@taskID", taskID);

            SqlDataReader rdr = cmd.ExecuteReader();


            _taskID = taskID;

            while (rdr.Read())
            {
                taskSubject = rdr["taskSubject"].ToString();
                taskDetail = rdr["taskDetail"].ToString();
                taskStatus = rdr["taskStatus"].ToString();
            }



            conn.Close();


        }

        public void createTask(int setForID, DateTime? dueDate, string priorityLevel,string taskDetail, string taskSubject,bool logOnBehalf, int logOnBehalfOF)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnectionString);

            int currentUserID = Session.userID;


            string command = "usp_add_task";

            using (SqlCommand cmd = new SqlCommand(command,conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@setByID", SqlDbType.Int).Value = logOnBehalfOF;
                cmd.Parameters.AddWithValue("@setForID", SqlDbType.Int).Value = setForID;
                if (dueDate != null)
                {
                    cmd.Parameters.AddWithValue("@dueDate", SqlDbType.DateTime).Value = dueDate;
                }
                cmd.Parameters.AddWithValue("@createdDate",SqlDbType.DateTime).Value = DateTime.Now;
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
