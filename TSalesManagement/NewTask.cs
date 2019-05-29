using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSToDo
{
    public partial class NewTask : Form
    {
        public NewTask()
        {
            InitializeComponent();

            behalfOfVisibility();
            dueDateVisibility();
        }

        private void NewTask_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'user_infoDataSet2.view_current_users_with_email' table. You can move, or remove it, as needed.
            this.view_current_users_with_emailTableAdapter1.Fill(this.user_infoDataSet2.view_current_users_with_email);
            // TODO: This line of code loads data into the 'user_infoDataSet11.view_current_users_with_email' table. You can move, or remove it, as needed.
            this.view_current_users_with_emailTableAdapter.Fill(this.user_infoDataSet11.view_current_users_with_email);
            // TODO: This line of code loads data into the 'user_infoDataSet1.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.user_infoDataSet1.user);
            // TODO: This line of code loads data into the 'user_infoDataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.user_infoDataSet.user);

        }
    
        private void btnSave_Click(object sender, EventArgs e)
        {

            
            int logOnBehalfOf;
            bool logOnBehalf = false;
            

            if (chkLogOnBehalf.Checked == true)
            {
                logOnBehalf = true;
                logOnBehalfOf = Convert.ToInt32(cmbLogOnBehalf.SelectedValue);
            }
            else
            {
                logOnBehalfOf = Session.userID;
            }

            //NON URGENT TASKS CAN BE ADDED TO THE SYSTEM WITH NO DUE DATE
            Task t = new Task();
            if (chkDueDateRequired.Checked == true)
            {
                //TODO ALLOW TIME PICKING NOT JUST DATE
                t.createTask(Convert.ToInt32(cmbSetForID.SelectedValue), Convert.ToDateTime(dteDueDate.Text), cmbPriority.Text, txtDetail.Text, txtSubject.Text, logOnBehalf, logOnBehalfOf);

            }
            else
            {
              
                t.createTask(Convert.ToInt32(cmbSetForID.SelectedValue), null, cmbPriority.Text, txtDetail.Text, txtSubject.Text, logOnBehalf, logOnBehalfOf);
            }

            this.Close();



        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.userTableAdapter.FillBy(this.user_infoDataSet.user);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

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


        private void behalfOfVisibility()
        {
            if (chkLogOnBehalf.Checked == true)
            {
                cmbLogOnBehalf.Visible = true;
                lblBehalfOf.Visible = true;
            }
            else
            {
                cmbLogOnBehalf.Visible = false;
                lblBehalfOf.Visible = false;
            }
        }

        private void cmbLogOnBehalf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkLogOnBehalf_CheckedChanged(object sender, EventArgs e)
        {
            behalfOfVisibility();
        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.view_current_users_with_emailTableAdapter.FillBy(this.user_infoDataSet11.view_current_users_with_email);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void chkDueDateRequired_CheckedChanged(object sender, EventArgs e)
        {
            dueDateVisibility();
        }
    }
}
