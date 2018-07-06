using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public partial class Attachments : Form
    {
        public Attachments()
        {
            InitializeComponent();
        }

        public Attachments(int givenId, int givenRevNo, AttachmentsTableName attTable)
        {
            InitializeComponent();


            glAttTable = attTable;

            string[] fileNames = { };
            RevNo = givenRevNo;

            if (attTable == AttachmentsTableName.Audit_Attachments)
            {
                AuditId = givenId;
                fileNames = getSavedAttachments(AuditId, RevNo, AttachmentsTableName.Audit_Attachments);
            }
            else if (attTable == AttachmentsTableName.FIDetail_Attachments)
            {
                DetailId = givenId;
                fileNames = getSavedAttachments(DetailId, RevNo, AttachmentsTableName.FIDetail_Attachments);
            }
            

            foreach (string thisFileName in fileNames)
            {
                lvAttachedFiles.Items.Add(new ListViewItem(thisFileName));
            }
            AttCnt = fileNames.Length;
        }


        AttachmentsTableName glAttTable;
        int AuditId;
        int DetailId;
        public int RevNo;

        public int AttCnt;
       
        public bool success= false;

        public string[] getSavedAttachments(int tableId, int revNo, AttachmentsTableName attTable)
        {
            List<string> ret = new List<string>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "";
            if (attTable == AttachmentsTableName.Audit_Attachments)
            {
                SelectSt = "SELECT Name FROM [dbo].[Audit_Attachments] WHERE AuditId = " + tableId.ToString() + " AND RevNo = " + revNo.ToString();
            }
            else if (attTable == AttachmentsTableName.FIDetail_Attachments)
            {
                SelectSt = "SELECT Name FROM [dbo].[FIDetail_Attachments] WHERE FIDetailId = " + tableId.ToString() + " AND RevNo = " + revNo.ToString();
            }

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ret.Add(reader["Name"].ToString().Trim());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret.ToArray();
        }

        void addFilesIntoListView(ListView myListView, string[] fileNames)
        {
            bool exists = false;

            if (fileNames is null)
            {
                MessageBox.Show("File not found. \r\nPlease choose a file stored on your local disk!");
                return;
            }

            foreach (string thisFile in fileNames)
            {
                exists = false;
                System.IO.FileInfo newFile = new System.IO.FileInfo(thisFile);

                foreach (ListViewItem lvi in myListView.Items)
                {
                    if (lvi.SubItems[0].Text.ToUpper() == newFile.Name.ToUpper())
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                {
                    MessageBox.Show("File '" + newFile.Name + "' is already attached");
                    continue;
                }

                ListViewItem lvItem = new ListViewItem(new string[] { newFile.Name, newFile.FullName });
                myListView.Items.Add(lvItem);
            }
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Add Files";
            ofd.Multiselect = true; //array of files
            ofd.ShowDialog();

            //Add Files into listView...
            addFilesIntoListView(lvAttachedFiles, ofd.FileNames);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (lvAttachedFiles.SelectedItems.Count > 0)
            {
                string lvPath = "";

                if (lvAttachedFiles.SelectedItems[0].SubItems.Count == 1) //only filename from database into lv
                //if (CountSampleFiles(extraDataId) > 0) //select 
                {
                    string ext = "";
                    string tempPath = Path.GetTempPath(); //C:\Users\hkylidis\AppData\Local\Temp\
                    string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(lvAttachedFiles.SelectedItems[0].SubItems[0].Text) + "~" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
                    try
                    {
                        if (!Directory.Exists(tempPath))
                        {
                            MessageBox.Show("Error. Please check your privileges on " + tempPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                        return;
                    }

                    SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

                    string SelectSt = "";

                    if (glAttTable == AttachmentsTableName.Audit_Attachments)
                    {
                        SelectSt = "SELECT [FileContents] FROM [dbo].[Audit_Attachments] WHERE AuditId = @AuditId AND RevNo = @RevNo AND Name = @Filename";
                    }
                    else if (glAttTable == AttachmentsTableName.FIDetail_Attachments)
                    {
                        SelectSt = "SELECT [FileContents] FROM [dbo].[FIDetail_Attachments] WHERE FIDetailId = @DetailId AND RevNo = @RevNo AND Name = @Filename";
                    }
                        SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
                    try
                    {
                        sqlConn.Open();

                        if (glAttTable == AttachmentsTableName.Audit_Attachments)
                        {
                            cmd.Parameters.AddWithValue("@AuditId", AuditId);
                        }
                        else if (glAttTable == AttachmentsTableName.FIDetail_Attachments)
                        {
                            cmd.Parameters.AddWithValue("@DetailId", DetailId);
                        }

                        cmd.Parameters.AddWithValue("@RevNo", RevNo);
                        
                        cmd.Parameters.AddWithValue("@Filename", lvAttachedFiles.SelectedItems[0].SubItems[0].Text);

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string fname = lvAttachedFiles.SelectedItems[0].SubItems[0].Text;
                            ext = fname.Substring(fname.LastIndexOf("."));
                            lvPath = tempFile + ext;
                            File.WriteAllBytes(tempFile + ext, (byte[])reader["FileContents"]);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                        return;
                    }
                }
                else //path and filename from local dir into lv
                //insert || update -> update ??? mixed files, check... 
                {
                    lvPath = lvAttachedFiles.SelectedItems[0].SubItems[1].Text;
                }

                System.Diagnostics.Process.Start(lvPath);
            }
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (lvAttachedFiles.SelectedItems.Count > 0)
            {
                lvAttachedFiles.SelectedItems[0].Remove();
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            lvAttachedFiles.Items.Clear();
        }

        //private bool UpdateAttachments_IsCurrent(int auditId, int revNo)
        //{
        //    bool ret = false;

        //    SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
        //    string InsSt = "UPDATE [dbo].[Attachments] SET [IsCurrent] = 0 WHERE AuditId = @id AND RevNo = @RevNo";
        //    try
        //    {
        //        sqlConn.Open();

        //        SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

        //        cmd.Parameters.AddWithValue("@id", auditId);
        //        cmd.Parameters.AddWithValue("@RevNo", revNo);

        //        cmd.CommandType = CommandType.Text;
        //        cmd.ExecuteNonQuery();

        //        ret = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("The following error occurred: " + ex.Message);
        //    }
        //    sqlConn.Close();

        //    return ret;
        //}

        LvFileInfo saveAttachmentLocally(int Id, int RevNo, string Filename, AttachmentsTableName attTable)
        {
            LvFileInfo ret = new LvFileInfo();
            string tempPath = Path.GetTempPath(); //C:\Users\hkylidis\AppData\Local\Temp\
            try
            {
                if (!Directory.Exists(tempPath))
                {
                    MessageBox.Show("Error. Please check your privileges on " + tempPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
                return ret;
            }

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "";

            if (attTable == AttachmentsTableName.Audit_Attachments)
            {
                SelectSt = "SELECT [Name], [FileContents] FROM [dbo].[Audit_Attachments] WHERE AuditId = @Id and RevNo = @RevNo and Name = @Filename ";
            }
            else if (attTable == AttachmentsTableName.FIDetail_Attachments)
            {
                SelectSt = "SELECT [Name], [FileContents] FROM [dbo].[FIDetail_Attachments] WHERE FIDetailId = @Id and RevNo = @RevNo and Name = @Filename ";
            }
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@RevNo", RevNo);
                cmd.Parameters.AddWithValue("@Filename", Filename);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string realFileName = reader["Name"].ToString().Trim();
                    //string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "~" + realFileName);
                    //temp file -> attachment name with temp name and tilda 'tmp123~ΦΕΚ123.pdf'
                    string tempFile = Path.Combine(tempPath, realFileName);
                    try
                    {
                        File.WriteAllBytes(tempFile, (byte[])reader["FileContents"]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occured while saving temporarilly the attached file: '" + realFileName +
                            "'\r\n\r\n\r\nDetails:\r\n" + ex.Message);
                        try
                        {
                            tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "~" + realFileName);
                            File.WriteAllBytes(tempFile, (byte[])reader["FileContents"]);

                            MessageBox.Show("Caution! File will be saved as: " + tempFile);
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show("Caution! File " + realFileName + " will not be saved!\r\n" + ex2.Message);
                        }

                    }

                    ret = new LvFileInfo { FileName = realFileName, FilePath = tempFile };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
                return ret;
            }

            return ret;
        }

        private bool InertIntoTable_AttachedFiles(int Id, int RevNo, string fileName, byte[] fileBytes,AttachmentsTableName attTable) //INSERT [dbo].[Audit_Attachments]
        {
            bool ret = false;

            if (Id > 0 && RevNo > 0 && fileName.Trim().Length > 0)
            {
                SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
                string InsSt = "";
                if (attTable == AttachmentsTableName.Audit_Attachments)
                {
                   InsSt = "INSERT INTO [dbo].[Audit_Attachments] (Name, FileContents, AuditId, RevNo, UsersId, InsDate) VALUES " +
                    "(@Filename, @FileCont, @Id, @RevNo, @UsersId, getdate() ) ";
                }
                else if (attTable==AttachmentsTableName.FIDetail_Attachments)
                {
                    InsSt = "INSERT INTO [dbo].[FIDetail_Attachments] (Name, FileContents, FIDetailId, RevNo, UsersId, InsDate) VALUES " +
                   "(@Filename, @FileCont, @Id, @RevNo, @UsersId, getdate() ) ";
                }
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@RevNo", RevNo);
                    cmd.Parameters.AddWithValue("@UsersId", UserInfo.userDetails.Id);
                    cmd.Parameters.AddWithValue("@Filename", fileName);
                    cmd.Parameters.Add("@FileCont", SqlDbType.VarBinary).Value = fileBytes;
                    cmd.CommandType = CommandType.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ret = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            return ret;
        }

        private bool UpdateAuditOnAttSave(int id, AttachmentsTableName attTable)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "";
            if (attTable == AttachmentsTableName.Audit_Attachments)
            {
                InsSt= "UPDATE [dbo].[Audit] SET [UpdUserID] = @UpdUserID, [UpdDt] = getDate(), [RevNo] = RevNo+1, [UseUpdTrigger] = 1 " +
                "WHERE id=@id";
            }
            else if (attTable ==AttachmentsTableName.FIDetail_Attachments)
            {
                InsSt = "UPDATE [dbo].[FIDetail] SET [UpdUserID] = @UpdUserID, [UpdDt] = getDate(), [RevNo] = RevNo+1, [UseUpdTrigger] = 1 " +
                "WHERE id=@id";
            }
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.Parameters.AddWithValue("@UpdUserID", UserInfo.userDetails.Id);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

            }
            sqlConn.Close();

            return ret;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AttCnt == 0 && lvAttachedFiles.Items.Count == 0)
            {
                Close();
                return;
            }


            int Id= 0;

            if (glAttTable==AttachmentsTableName.Audit_Attachments)
            {
                Id = AuditId;
            }
            else if ( glAttTable ==AttachmentsTableName.FIDetail_Attachments)
            {
                Id = DetailId;
            }
            if (UpdateAuditOnAttSave(Id, glAttTable) == false)
            {
                MessageBox.Show("Error: No files attached!");
                return;
            }

            if (lvAttachedFiles.Items.Count > 0)
            {
                List<ListViewItem> newLvItems = new List<ListViewItem>();

                foreach (ListViewItem lvi in lvAttachedFiles.Items)
                {
                    if (lvi.SubItems.Count == 1) //only filename into lv -> from db
                    {
                        LvFileInfo lvfi = saveAttachmentLocally(Id, RevNo, lvi.SubItems[0].Text,glAttTable);

                        newLvItems.Add(new ListViewItem(new string[] { lvfi.FileName, lvfi.FilePath }));
                    }
                    else //path and filename into lv -> from local dir : ok
                    {
                        newLvItems.Add(lvi);
                    }
                }

                //update old records
                //UpdateAttachments_IsCurrent(Id, RevNo);
                RevNo += 1;
                //insert attachments into db - IsCurrent = 1
                foreach (ListViewItem lvi in newLvItems)
                {
                    byte[] attFileBytes = File.ReadAllBytes(lvi.SubItems[1].Text);

                    if (!InertIntoTable_AttachedFiles(Id, RevNo, lvi.SubItems[0].Text, attFileBytes,glAttTable))
                    {
                        MessageBox.Show("File save failed: " + lvi.SubItems[0].Text);
                    }
                }

            }
            //else
            //{
            //update old records
            //UpdateAttachments_IsCurrent(Id, RevNo);
            //}

            success = true;
           
            AttCnt = lvAttachedFiles.Items.Count;
            if (AttCnt > 0)
            {
                MessageBox.Show("File(s) attached successfully!");
            }

            Close();
        }
    }

    public class LvFileInfo
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
