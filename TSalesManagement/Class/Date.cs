using ConnectionNew;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Slimline_Shopfloor
{
    internal class Functions
    {
        public static List<DateTime> listofweekdays = new List<DateTime>();

        public static List<DateTime> ProcessDate(List<DayOfWeek> daysOfWeek)
        {
            string select_holidays = "Select * from c_view_holiday_check";
            DateTime start_date = DateTime.Today.AddDays(1);
            DataTable dt_holidays = new DataTable();
            SqlConnection connection = ConnectionRyucxd.GetConnection_orderdatabase();
            SqlDataAdapter fill_holidays = new SqlDataAdapter(select_holidays, connection);
            fill_holidays.SelectCommand.Parameters.AddWithValue("@date", DateTime.Today);
            fill_holidays.Fill(dt_holidays);

            for (int i = 0; i < 10;)
            {
                if (start_date.DayOfWeek != DayOfWeek.Saturday && start_date.DayOfWeek != DayOfWeek.Sunday)
                {
                    for (int row = 0; row < dt_holidays.Rows.Count;)
                    {
                        int last_record = dt_holidays.Rows.Count - 1;
                        if (dt_holidays.Rows[row]["DATE"].ToString() != start_date.ToString())
                        {
                            if (row == last_record)
                            {
                                listofweekdays.Add(start_date);
                                i++;
                            }
                            row++;
                        }
                        else
                        {
                            goto bank_holiday;
                        }
                    }
                }

            bank_holiday:;
                start_date = start_date.AddDays(1);
            }
            return listofweekdays;
        }
    }
}