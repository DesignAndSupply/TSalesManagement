using StartUpClass;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TSalesManagement
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
            this.MdiChildActivate += new EventHandler(FrmMainMenu_MdiChildActivate);
            this.tabForms.SelectedIndexChanged += new EventHandler(TabForms_SelectedIndexChanged);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Login.globalUserName + " " + Login.globalAdmin + " " + Login.globalSuperUser);
        }

        private void activityLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivityCentre aC = new ActivityCentre();
            aC.Show();
        }

        private void monthlyChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form1 frm = new form1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pipelineChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPipeLine frmP = new frmPipeLine();
            frmP.MdiParent = this;
            frmP.Show();
        }

        private void FrmMainMenu_MdiChildActivate(object sender,
                                    EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                tabForms.Visible = false;
            // If no any child form, hide tabControl
            else
            {
                this.ActiveMdiChild.WindowState =
                FormWindowState.Maximized;
                // Child form always maximized

                // If child form is new and no has tabPage,
                // create new tabPage
                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child
                    // form caption
                    TabPage tp = new TabPage(this.ActiveMdiChild
                                             .Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabForms;
                    tabForms.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed +=
                        new FormClosedEventHandler(
                                        ActiveMdiChild_FormClosed);
                }

                if (!tabForms.Visible) tabForms.Visible = true;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender,
                                    FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void TabForms_SelectedIndexChanged(object sender,
                                           EventArgs e)
        {
            if ((tabForms.SelectedTab != null) &&
                (tabForms.SelectedTab.Tag != null))
                (tabForms.SelectedTab.Tag as Form).Select();
        }

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerList frmCL = new frmCustomerList();
            frmCL.MdiParent = this;
            frmCL.Show();
        }

        private void pipelineLiveChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPipelineLive frmPL = new frmPipelineLive();
            frmPL.MdiParent = this;
            frmPL.Show();
        }

        private void userActivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            frmUserInfoRyucxd frmUI = new frmUserInfoRyucxd();
            frmUI.MdiParent = this;
            frmUI.Show();
        }

        private void nonReturningCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNonReturningCustomers frmNR = new frmNonReturningCustomers();
            frmNR.MdiParent = this;
            frmNR.Show();
        }

        private void newCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewCustomers frmNC = new frmNewCustomers();
            frmNC.MdiParent = this;
            frmNC.Show();
        }

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewTask nt = new frmNewTask(null, null, null, null, null);
            nt.ShowDialog();
        }

        private void addNewProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddProject frmAP = new frmAddProject();
            frmAP.ShowDialog();

            //refresh other form here??
            int was_it_closed = 0;
            foreach (Form f in this.MdiChildren) //this works 100%
            {
                if (f is frmViewProjects)
                {
                    f.Close();
                    was_it_closed = -1;
                }
            }
            if (was_it_closed == -1)
                viewProjectsToolStripMenuItem.PerformClick();
        }

        private void viewProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewProjects vp = new frmViewProjects();
            vp.MdiParent = this;
            vp.Show();
        }

        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Exit!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    Environment.Exit(1);
                else
                    e.Cancel = true;
            }
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void unfinishedTasksEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to fire the unfinished task email?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionStringToDo))
                using (SqlCommand cmd = new SqlCommand("tsales_unfinished_task_email", conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}