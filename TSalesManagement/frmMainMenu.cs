using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StartUpClass;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.PowerBI.Api.V2;
using Microsoft.PowerBI.Api.V2.Models;



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
    }
}
