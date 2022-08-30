﻿using StartUpClass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace TSalesManagement
{
    public partial class frmAmendActivity : Form
    {
        public int _aID { get; set; }
        private string _custAccRef { get; set; }
        public string _sector { get; set; }


        public frmAmendActivity(int aID)
        {
            InitializeComponent();
            _aID = aID;

            fillData();
            populateContacts();

        }

        private void fillData()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * from dbo.crm_activity where id=@id";
            cmd.Parameters.AddWithValue("@id", _aID);

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                _custAccRef = rdr["customer_acc_ref"].ToString();
                cmbRecipient.Text = rdr["recipient"].ToString();
                cmbType.Text = rdr["correspondance_type"].ToString();
                txtDetails.Text = rdr["details_of"].ToString();
                txtReference.Text = rdr["reference"].ToString();
            }

            rdr.Close();

            //snag the sector here 
            string sql = "select COALESCE(sector_name,'') from dbo.view_tsalesmanager_sector where cust_acc_ref = '" + _custAccRef + "'";
            using (SqlCommand cmdSector = new SqlCommand(sql, conn))
            {
                _sector = "";
                _sector = Convert.ToString(cmdSector.ExecuteScalar());

                txtSector.Text = _sector;
            }
            conn.Close();
        }

        private void frmAmendActivity_Load(object sender, EventArgs e)
        {
            //change the text that the button displays based on if its a fave or not
            string sql = "SELECT COALESCE(bookmarked,'') FROM dbo.crm_activity where bookmarked LIKE '%," + Login.globalUserID + ",%' AND id = " + _aID.ToString();
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    string temp = "";
                    temp = Convert.ToString(cmd.ExecuteScalar());
                    if (temp == "")
                        btnBookmarks.Text = "Add To Bookmarks";
                    else
                        btnBookmarks.Text = "Remove From Bookmarks";
                }
                conn.Close();
            }
        }

        private void populateContacts()
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select id, contact_name from dbo.crm_customer_contacts WHERE cust_acc_ref=@custAccRef", conn);
            cmd.Parameters.AddWithValue("@custAccRef", _custAccRef);

            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("contact_name", typeof(string));
            dt.Load(rdr);

            cmbRecipient.ValueMember = "id";
            cmbRecipient.DisplayMember = "contact_name";
            cmbRecipient.DataSource = dt;
            conn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString);
            conn.Open();

            string nameWithCapital = Login.globalUserName;
            nameWithCapital = char.ToUpper(nameWithCapital[0]) + nameWithCapital.Substring(1);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE dbo.crm_activity set customer_acc_ref = @custAccRef, date_modified = @date ,correspondance_type = @type ,details_of = @details ,recipient = @recipient ,reference =@ref where id = @id ";
            cmd.Parameters.AddWithValue("@custAccRef", _custAccRef);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@type", cmbType.Text); //time stamp the users who just added this
            cmd.Parameters.AddWithValue("@details", txtDetails.Text + " || " + nameWithCapital + " - " + DateTime.Now.ToString() + " || ");
            cmd.Parameters.AddWithValue("@ref", txtReference.Text);
            cmd.Parameters.AddWithValue("@recipient", cmbRecipient.SelectedValue);
            cmd.Parameters.AddWithValue("@id", _aID);
            cmd.ExecuteNonQuery();

            //get the sender ID for this task
            string sql = "SELECT COALESCE(sender_id,0) FROM dbo.crm_activity WHERE id = " + _aID;
            int sender_id = 0;
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                sender_id = Convert.ToInt32(command.ExecuteScalar());
            }
            //now get the cc ID (if it exists)
            int cc = 0;
            sql = "SELECT COALESCE(cc,0) FROM dbo.crm_activity WHERE id = " + _aID;
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                cc = Convert.ToInt32(command.ExecuteScalar());
            }

            if (sender_id != 0) //dont do anything fancy here if its == 0, just carry on as normal and maybe log this error somewhere
            {
                //now check if the sender_id is the same as the person logged in
                if (Login.globalUserID == sender_id)
                {
                    //they are the same
                    //check if cc is 0
                    if (cc != 0 && cc != sender_id)
                    {
                        //there is someone in the CC field and its not the same as the sender id
                        //lets fire this bad boy and email the person who is cc'd
                        using (SqlCommand command = new SqlCommand("usp_crm_activity_cc_or_sender_email", conn))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@email_id", SqlDbType.Int).Value = cc;
                            command.Parameters.Add("@activity_id", SqlDbType.Int).Value = _aID;
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        //there is no one in the cc field and its the original sender logged in therefore do nothing and continue as normal
                    }
                }
                else //login is NOT the same as the sender, therefore attach them to the  column or if they exist already then just fire the response
                {
                    if (cc == 0 && sender_id != Login.globalUserID)
                    {
                        //cc is null and the user logged in is (just for extra safety) not equal to  the sender_id
                        //add this new user to the CC field
                        sql = "UPDATE dbo.crm_activity SET cc = " + Login.globalUserID.ToString() + " WHERE id = " + _aID;
                        using (SqlCommand command = new SqlCommand(sql, conn))
                        {
                            command.ExecuteScalar();
                        }
                    }
                    //at this point cc already existed or has now been added so we can fire the email to the original sender

                    using (SqlCommand command = new SqlCommand("usp_crm_activity_cc_or_sender_email", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@email_id", SqlDbType.Int).Value = sender_id;
                        command.Parameters.Add("@activity_id", SqlDbType.Int).Value = _aID;
                        command.ExecuteNonQuery();
                    }
                }
            }
            conn.Close();
            this.Close();
        }

        private void btnPipeline_Click(object sender, EventArgs e)
        {
            frmNewPipeline frmNP = new frmNewPipeline(_custAccRef, _aID);
            frmNP.ShowDialog();
            this.Close();
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            //open form for note entry
            frmActivityNote frm = new frmActivityNote(_aID);
            frm.ShowDialog();
            //refresh the DGV so that it now shows the newst note aswell :}
            fillDGV();
        }

        private void fillDGV() //frefresh starts from here
        {
            //crm_activity_notes
            string sql = "SELECT detail as [Detail],noteBy as [Note By], noteDate as [Note Date] FROM dbo.crm_activity_notes WHERE activityID = " + _aID + " ORDER BY noteID desc";
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            }
            //also do some formatting while we are here :}
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private void frmAmendActivity_Shown(object sender, EventArgs e)
        {
            fillDGV();
        }

        private void btnBookmarks_Click(object sender, EventArgs e)
        {
            //here we need to allocate the logged in USER to bookmarked in crm_activity
            //find out if bookmarked is null first ig
            string sql = "SELECT COALESCE(bookmarked,'') as bookmarked FROM dbo.crm_activity WHERE id = " + _aID.ToString();
            using (SqlConnection conn = new SqlConnection(SqlStatements.ConnectionString))
            {
                conn.Open();
                string nullValue = "0";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    nullValue = Convert.ToString(cmd.ExecuteScalar());

                if (nullValue == "")
                    nullValue = "-1";
                else
                    nullValue = "0";

                sql = "SELECT COALESCE(bookmarked,'') as bookmarked FROM dbo.crm_activity WHERE id = " + _aID.ToString() + " AND bookmarked LIKE '%," + Login.globalUserID.ToString() + ",%'";
                string temp = "";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    temp = Convert.ToString(cmd.ExecuteScalar());
                if (temp == "")
                {
                    //if the user is NOT in the bookmark string then add it 
                    if (nullValue == "-1")
                        sql = "UPDATE dbo.crm_activity SET  bookmarked = '," + Login.globalUserID.ToString() + ",' WHERE id = " + _aID.ToString(); //comma on both side so we can search for that meaning that the instance of something like 
                    else                                                                                                                                                                                                                       // 13,138 - a user with 13 would show for both of them, this way it wont show twice 
                        sql = "UPDATE dbo.crm_activity SET bookmarked = bookmarked + '," + Login.globalUserID.ToString() + ",' WHERE id = " + _aID.ToString();
                }
                else
                {
                    //else remove them 
                    temp = temp.Replace("," + Login.globalUserID + ",", "");
                    sql = "UPDATE dbo.crm_activity SET  bookmarked = '," + temp + ",' WHERE id = " + _aID.ToString();
                }
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                conn.Close();

                if (btnBookmarks.Text == "Remove From Bookmarks")
                    btnBookmarks.Text = "Add To Bookmarks";
                else
                    btnBookmarks.Text = "Remove From Bookmarks";
                //starts here

                //ends here
            }

        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            Rectangle bounds = this.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                bitmap.Save(@"C:\Temp\temp.jpg", ImageFormat.Jpeg);
                printImage();
            }
        }
        private void printImage()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    Image i = Image.FromFile(@"C:\temp\temp.jpg");
                    Point p = new Point(100, 100);
                    args.Graphics.DrawImage(i, args.MarginBounds);
                };

                pd.DefaultPageSettings.Landscape = true;
                Margins margins = new Margins(50, 50, 50, 50);
                pd.DefaultPageSettings.Margins = margins;
                pd.Print();
            }
            catch
            {
            }
        }


        private void btnEmail_Click(object sender, EventArgs e)
        {
            Rectangle bounds = this.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                bitmap.Save(@"C:\Temp\temp.jpg", ImageFormat.Jpeg); //this is same as print button but without the print (^: 

                Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem mailItem = outlookApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                mailItem.Subject = "";
                mailItem.To = "";
                string imageSrc = @"C:\Temp\temp.jpg"; // Change path as needed

                var attachments = mailItem.Attachments;
                var attachment = attachments.Add(imageSrc);
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpeg");
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "myident"); // Image identifier found in the HTML code right after cid. Can be anything.
                mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", true);

                // Set body format to HTML

                mailItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                mailItem.Attachments.Add(imageSrc);
                string msgHTMLBody = "";
                mailItem.HTMLBody = msgHTMLBody;
                mailItem.Display(true);
                //mailItem.Send();
            }
        }
    }
}