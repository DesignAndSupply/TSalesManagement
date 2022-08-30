using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSalesManagement
{
    public partial class frmPrintDatePicker : Form
    {
        public frmPrintDatePicker()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            temp._dateStart = dteStart.Value;
            temp._dateEnd = dteEnd.Value;
            this.Close();
        }
    }
}
