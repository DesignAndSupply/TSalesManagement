using StartUpClass;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TSalesManagement
{
    public partial class frmNewTask : Form
    {
        public double? _activityID { get; set; }

        public frmNewTask(double? activityID, string contact, string reference, string details, string customer)
        {
            InitializeComponent();
            _activityID = activityID;
            cmbSetForID.SelectedValue = Login.globalUserID;
            dueDateVisibility();
            if (activityID is null)
            {
            }
            else
            {
                populateFromActivity(contact, reference, details, customer);
            }
        }

        private void populateFromActivity(string contact, string reference, string details, string customer)
        {
            cmbPriority.Text = "High";
            txtSubject.Text = Regex.Replace(customer, "  ", "") + '-' + contact + '-' + reference;
            txtDetail.Text = details;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int logOnBehalfOf = Login.globalUserID;

            //NON URGENT TASKS CAN BE ADDED TO THE SYSTEM WITH NO DUE DATE
            Tasks t = new Tasks();
            if (chkDueDateRequired.Checked == true)
            {
                //TODO ALLOW TIME PICKING NOT JUST DATE
                t.createTask(Convert.ToInt32(cmbSetForID.SelectedValue), Convert.ToDateTime(dteDueDate.Text), cmbPriority.Text, txtDetail.Text, txtSubject.Text, false, logOnBehalfOf, _activityID);
            }
            else
            {
                t.createTask(Convert.ToInt32(cmbSetForID.SelectedValue), null, cmbPriority.Text, txtDetail.Text, txtSubject.Text, false, logOnBehalfOf, _activityID);
            }

            this.Close();
        }

        private void frmNewTask_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'user_infoDataSet1.view_current_users_with_email' table. You can move, or remove it, as needed.
            this.view_current_users_with_emailTableAdapter.Fill(this.user_infoDataSet1.view_current_users_with_email);
            cmbSetForID.SelectedValue = Login.globalUserID;
        }

        private void chkDueDateRequired_CheckedChanged(object sender, EventArgs e)
        {
            dueDateVisibility();
        }

        private void dueDateVisibility()
        {
            if (chkDueDateRequired.Checked == true)
            {
                dteDueDate.Visible = true;
                lblDueDate.Visible = true;
            }
            else
            {
                dteDueDate.Visible = false;
                lblDueDate.Visible = false;
            }
        }
    }
}