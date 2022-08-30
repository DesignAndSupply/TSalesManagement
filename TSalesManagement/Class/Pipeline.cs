using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TSalesManagement.Class
{
    internal class Pipeline
    {
        public string _status { get; set; }

        //////////////////////////////////////////////////
        //variables for filtering the report here~
        public string _area { get; set; }

        public DateTime _dateStart { get; set; }
        public DateTime _dateEnd { get; set; }
        public string _class { get; set; }
        public List<int> _staff { get; set; }

        //////////////////////////////////////////////////

        public double _janSales { get; set; }
        public double _febSales { get; set; }
        public double _marchSales { get; set; }
        public double _aprilSales { get; set; }
        public double _maySales { get; set; }
        public double _juneSales { get; set; }
        public double _julySales { get; set; }
        public double _augustSales { get; set; }
        public double _septemberSales { get; set; }
        public double _octoberSales { get; set; }
        public double _novemberSales { get; set; }
        public double _decemberSales { get; set; }

        public double _SjanSales { get; set; }
        public double _SfebSales { get; set; }
        public double _SmarchSales { get; set; }
        public double _SaprilSales { get; set; }
        public double _SmaySales { get; set; }
        public double _SjuneSales { get; set; }
        public double _SjulySales { get; set; }
        public double _SaugustSales { get; set; }
        public double _SseptemberSales { get; set; }
        public double _SoctoberSales { get; set; }
        public double _SnovemberSales { get; set; }
        public double _SdecemberSales { get; set; }

        public Pipeline()
        {
        }

        public void addPipelineData()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            string loopMonth;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string sql = "SELECT * FROM c_view_pipeline_chart where " +
                " estimated_order_date >= '" + _dateStart.ToString("yyyy-MM-dd") + "' AND estimated_order_date <= '" + _dateEnd.ToString("yyyy-MM-dd") + "' "; //date

            if (_area != "Both")
                sql = sql + " AND door_style = '" + _area + "' "; //area, if its both then we dont need to add a where here

            if (_class != "All") //same again, if its all then we dont need to add anything to the where
                sql = sql + " AND likelihood_of_order = '" + _class + "' ";

            //if (_staff.Count > 0)
            //{
            //    sql = sql + " AND (";
            //    foreach (var item in _staff)
            //    {
            //        sql = sql + " added_by_id = " + item.ToString() + "  OR ";
            //    }
            //    //sql = sql.Substring(sql.Length - 3);
            //    sql = sql.Substring(0, sql.Length - 3);

            //    sql = sql + ")";
            //}

            //"  and order_status = '" + _status.ToString() + "'";

            //cmd.Parameters.AddWithValue("@now", DateTime.Now.AddMonths(-2));
            //cmd.Parameters.AddWithValue("@status", _status);
            cmd.CommandText = sql;
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                loopMonth = Convert.ToDateTime(rdr["estimated_order_date"]).ToString("MMMM");

                if (rdr["door_style"].ToString() == "Traditional")
                {
                    switch (loopMonth)
                    {
                        case "January":
                            _janSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "February":
                            _febSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "March":
                            _marchSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "April":
                            _aprilSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "May":
                            _maySales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "June":
                            _juneSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "July":
                            _julySales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "August":
                            _augustSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "September":
                            _septemberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "October":
                            _octoberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "November":
                            _novemberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "December":
                            _decemberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    switch (loopMonth)
                    {
                        case "January":
                            _SjanSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "February":
                            _SfebSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "March":
                            _SmarchSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "April":
                            _SaprilSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "May":
                            _SmaySales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "June":
                            _SjuneSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "July":
                            _SjulySales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "August":
                            _SaugustSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "September":
                            _SseptemberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "October":
                            _SoctoberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "November":
                            _SnovemberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "December":
                            _SdecemberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        //replicate this for user#
        public void addPipelineUser(int staff)
        {
            //quickly wipe all the variables
            _SjanSales = 0;
            _SfebSales = 0;
            _SmarchSales = 0;
            _SaprilSales = 0;
            _SmaySales = 0;
            _SjuneSales = 0;
            _SjulySales = 0;
            _SaugustSales = 0;
            _SseptemberSales = 0;
            _SoctoberSales = 0;
            _SnovemberSales = 0;
            _SdecemberSales = 0;

            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            string loopMonth;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string sql = "SELECT * FROM c_view_pipeline_chart where " +
                " estimated_order_date >= '" + _dateStart.ToString("yyyy-MM-dd") + "' AND estimated_order_date <= '" + _dateEnd.ToString("yyyy-MM-dd") + "' "; //date

            if (_area != "Both")
                sql = sql + " AND door_style = '" + _area + "' "; //area, if its both then we dont need to add a where here

            if (_class != "All") //same again, if its all then we dont need to add anything to the where
                sql = sql + " AND likelihood_of_order = '" + _class + "' ";

            sql = sql + " AND added_by_id = " + staff.ToString();
            //if (_staff.Count > 0)
            //{
            //    sql = sql + " AND (";
            //    foreach (var item in _staff)
            //    {
            //        sql = sql + " added_by_id = " + item.ToString() + "  OR ";
            //    }
            //    //sql = sql.Substring(sql.Length - 3);
            //    sql = sql.Substring(0, sql.Length - 3);

            //    sql = sql + ")";
            //}

            //"  and order_status = '" + _status.ToString() + "'";

            //cmd.Parameters.AddWithValue("@now", DateTime.Now.AddMonths(-2));
            //cmd.Parameters.AddWithValue("@status", _status);
            cmd.CommandText = sql;
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                loopMonth = Convert.ToDateTime(rdr["estimated_order_date"]).ToString("MMMM");

                if (rdr["door_style"].ToString() == "Traditional")
                {
                    switch (loopMonth)
                    {
                        case "January":
                            _SjanSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "February":
                            _SfebSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "March":
                            _SmarchSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "April":
                            _SaprilSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "May":
                            _SmaySales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "June":
                            _SjuneSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "July":
                            _SjulySales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "August":
                            _SaugustSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "September":
                            _SseptemberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "October":
                            _SoctoberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "November":
                            _SnovemberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "December":
                            _SdecemberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    switch (loopMonth)
                    {
                        case "January":
                            _SjanSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "February":
                            _SfebSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "March":
                            _SmarchSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "April":
                            _SaprilSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "May":
                            _SmaySales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "June":
                            _SjuneSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "July":
                            _SjulySales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "August":
                            _SaugustSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "September":
                            _SseptemberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "October":
                            _SoctoberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "November":
                            _SnovemberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        case "December":
                            _SdecemberSales = Convert.ToDouble(rdr["estimated_order_value"]);
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}