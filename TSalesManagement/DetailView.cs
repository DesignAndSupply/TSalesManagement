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
namespace TSalesManagement
{
    public partial class DetailView : Form
    {

        private DateTime firstDayOfMonth;
        private DateTime lastDayOfMonth;
        public DetailView(DateTime fd, DateTime ld)
        {
            InitializeComponent();
            firstDayOfMonth = fd;
            lastDayOfMonth = ld;

        }




     
        private void DetailView_Load(object sender, EventArgs e)
        {
            FillDetailView();

        }
        void FillDetailView()
        {
            SqlConnection sqlconn = new SqlConnection(SqlStatements.ConnectionString);
            if (sqlconn.State == System.Data.ConnectionState.Closed)
            {
                //lastDayOfMonth = lastDayOfMonth.AddDays(-1);
                sqlconn.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("C_usp_forecast_totals", sqlconn);
                sqlda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.Add("@firstDayOfMonth", SqlDbType.DateTime).Value = firstDayOfMonth;
                sqlda.SelectCommand.Parameters.Add("@lastDayOfMonth", SqlDbType.DateTime).Value = lastDayOfMonth;
                sqlda.SelectCommand.Parameters.Add("@grouped", SqlDbType.SmallInt).Value = 0;
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                sqlconn.Close();
                dgDetail.DataSource = dt;

            }

        }


    }
}
