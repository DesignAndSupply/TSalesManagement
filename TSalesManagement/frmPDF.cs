using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TSalesManagement
{
    public partial class frmPDF : Form
    {
        public string folderPath { get; set; }
        public frmPDF(string folder_location)
        {
            InitializeComponent();
            //fill list box
            GetFilesFromFolder(folder_location);
            folderPath = folder_location;



            //axAcroPDF1.src = @"\\designsvr1\dropbox\";
            axAcroPDF1.setShowToolbar(false); //remove annoying toolbar
        }

        private void GetFilesFromFolder(string file_location)
        {
            DirectoryInfo dinfo = new DirectoryInfo(file_location);
            FileInfo[] Files = dinfo.GetFiles("*.pdf");
            foreach (FileInfo file in Files)
                cmb_folder.Items.Add(file.Name);
        }

        private void cmb_folder_SelectedIndexChanged(object sender, EventArgs e)
        {
            axAcroPDF1.src = folderPath + @"\" + cmb_folder.Text.ToString();
        }
    }
}
