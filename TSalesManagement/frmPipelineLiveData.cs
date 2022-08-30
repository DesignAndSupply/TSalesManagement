using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TSalesManagement
{
    public partial class frmPipelineLiveData : Form
    {
        public frmPipelineLiveData(DateTime tempDate, string selectedUser, string status, string area, string tempClass)
        {
            InitializeComponent();
            string sql = "";
            int staffID = 0;
            string _class = "";
            if (tempClass == "All")
                _class = "";
            else
                _class = tempClass;
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                conn.Open();
                sql = "SELECT id FROM [user_info].dbo.[user] where forename + ' ' + surname = '" + selectedUser + "'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    staffID = Convert.ToInt32(cmd.ExecuteScalar());
                DateTime tempDateEnd = tempDate;
                tempDateEnd = tempDateEnd.AddMonths(1);
                sql = "SELECT b.forename + ' ' + b.surname as [Added By],a.door_style as [Door Style],c.[NAME] as [Customer],a.order_ref as [Order reference],'£' + CAST(estimated_order_value as nvarchar(max)) as [Estimated Order Value],estimated_order_date as [Estimated Order Date]," +
                    "description_of_doors_on_order as [Description],order_status as [Order Status],likelihood_of_order as [Likelihood of Order] " +
                    "FROM dbo.sales_pipeline a LEFT JOIN[user_info].dbo.[user] b on a.added_by_id = b.id LEFT JOIN view_SALES_LEDGER_AND_PROSPECT c on c.ACCOUNT_REF = a.customer_acc_ref " +
                    "where estimated_order_date >= '" + tempDate.ToString("yyyy-MM-dd") + "'  AND estimated_order_date <= DATEADD(day,-1,'" + tempDateEnd.ToString("yyyy-MM-dd") + "') " +
                   "AND door_style = '" + area + "' AND likelihood_of_order LIKE '%" + _class + "%' AND order_status = '" + status + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                conn.Close();
            }

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            int index = dataGridView1.Columns["Estimated Order Value"].Index;
            dataGridView1.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            index = dataGridView1.Columns["Likelihood of Order"].Index;
            dataGridView1.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            index = dataGridView1.Columns["Description"].Index;
            dataGridView1.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}