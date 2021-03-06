﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public partial class Auditor_AuditView : Form
    {
        public Auditor_AuditView()
        {
            InitializeComponent();

            //------ testing ------
            //string hex = "2AB26A9EBDBA39AAE9D1A5C1EA8203228CDC7E4DA8C4A1A85DE3ABC1B64DEEAA03BD9566FE4771D1E36BE15CB14027B19F93A49788B734BB89C08DEDC5CC2264";
            //byte[] test = Enumerable.Range(0, hex.Length)
            //         .Where(x => x % 2 == 0)
            //         .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
            //         .ToArray();

            //byte[] data = System.Text.Encoding.ASCII.GetBytes("QWERTY12345!");
            //data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            //String hash = System.Text.Encoding.ASCII.GetString(data);
            //------ testing ------

            auditList = SelectAudit();
        }

        //public int dgvIndex = 0;

        private void Auditor_AuditView_Load(object sender, EventArgs e)
        {
            cbCompanies.Items.Add("All");
            cbCompanies.Items.AddRange(Companies.GetCompaniesComboboxItemsList(companiesList).ToArray<ComboboxItem>());
            cbAuditor1.Items.Add("All");
            cbAuditor1.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());
            
            DateTime dtToday = DateTime.Now.Date;
            dtFrom.Value = new DateTime(dtToday.Year, 1, 1).AddYears(-1);
            
            FillDataGridView(dgvAuditView, filteredLines);
            toolStripCounter.Text = "Records: " + filteredLines.Count.ToString();

        }

        public List<Audit> auditList = new List<Audit>();
        public List<Companies> companiesList = Companies.GetSqlCompaniesList();
        public List<Users> usersList = Users.GetUsersByRole(UserRole.IsAuditor); //Users.GetSqlUsersList();

        public List<Audit> filteredLines = new List<Audit>();

        public Audit Header_Audit = new Audit();

        public void ApplyFilters()
        {
            //List<Audit> filteredLines = new List<Audit>();

            //dtFrom & dtTo
            //filteredLines = filteredLines.Where(i => i.ReportDt >= dtFrom.Value.Date && i.ReportDt < dtTo.Value.Date.AddDays(1)).ToList();
            filteredLines = auditList.Where(i => i.ReportDt >= dtFrom.Value.Date && i.ReportDt < dtTo.Value.Date.AddDays(1)).ToList();

            if (cbCompanies.SelectedIndex > 0)
            {
                filteredLines = filteredLines.Where(i => i.CompanyId == InsertNewAudit.getComboboxItem<Companies>(cbCompanies).Id).ToList();
            }

            if(cbAuditor1.SelectedIndex>0)
            {
                filteredLines = filteredLines.Where(i => i.Auditor1ID == InsertNewAudit.getComboboxItem<Users>(cbAuditor1).Id).ToList();
            }
            filteredLines = filteredLines.Where(i => i.Year == dtpYear.Value.Year).ToList();

            if (chbCompleted.CheckState != CheckState.Indeterminate)
            {
                filteredLines = filteredLines.Where(i => i.IsCompleted == chbCompleted.Checked).ToList();
            }

            filteredLines = filteredLines.Where(i =>
            System.Globalization.CultureInfo.CurrentCulture.CompareInfo.IndexOf(i.Title.ToUpper(), txtTitle.Text.ToUpper(), System.Globalization.CompareOptions.IgnoreNonSpace) >= 0).ToList();

            FillDataGridView(dgvAuditView, filteredLines);


            //List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(filteredLines);
            //GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);

            //RowsForeColorFromVolDiff(dgvReceiptData);
            //dgvReceiptData.ClearSelection();
            toolStripCounter.Text = "Records: " + filteredLines.Count.ToString();

        }

        public List<Audit> SelectAudit()
        {
            List<Audit> ret = new List<Audit>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Year], [CompanyId], [AuditTypeId], " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , [Title])) as Title, " + 
                              "[ReportDt], " +
                              "[Auditor1Id], [Auditor2Id], [SupervisorId], " +
                              "[IsCompleted], [AuditNumber], [IASentNumber], [RevNo], " +
                              "(SELECT count(*) FROM [dbo].[Audit_Attachments] T WHERE a.id = T.AuditID and A.RevNo = T.RevNo) as AttCnt, " + 
                              "[AuditRatingId], isnull([IsDeleted], 'FALSE') as IsDeleted " +
                              "FROM [dbo].[Audit] A " +
                              "ORDER BY Id "; //ToDo
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int? Auditor2_Id, Supervisor_Id;
                    int? AuditRating_Id;

                    AuditRating AuditRating_rating;

                    Users Auditor2_User, Supervisor_User;
                    if (reader["Auditor2Id"] == System.DBNull.Value)
                    {
                        Auditor2_Id = null;
                        Auditor2_User = new Users();
                    }
                    else
                    {
                        Auditor2_Id = Convert.ToInt32(reader["Auditor2Id"].ToString());
                        Auditor2_User = new Users(Convert.ToInt32(reader["Auditor2Id"].ToString()));
                    }
                    if (reader["SupervisorId"] == System.DBNull.Value)
                    {
                        Supervisor_Id = null;
                        Supervisor_User = new Users();
                    }
                    else
                    {
                        Supervisor_Id = Convert.ToInt32(reader["SupervisorId"].ToString());
                        Supervisor_User = new Users(Convert.ToInt32(reader["SupervisorId"].ToString()));
                    }
                    if ( reader["AuditRatingId"] == System.DBNull.Value)
                    {
                        AuditRating_Id = null;
                        AuditRating_rating = new AuditRating();
                    }
                    else
                    {
                        AuditRating_Id = Convert.ToInt32(reader["AuditRatingId"].ToString());
                        AuditRating_rating = new AuditRating(Convert.ToInt32(reader["AuditRatingId"].ToString()));
                    }
                    ret.Add(new Audit()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Year = Convert.ToInt32(reader["Year"].ToString()),
                        CompanyId = Convert.ToInt32(reader["CompanyId"].ToString()),
                        Company = new Companies(Convert.ToInt32(reader["CompanyId"].ToString())),
                        AuditTypeId = Convert.ToInt32(reader["AuditTypeId"].ToString()),
                        AuditType = new AuditTypes(Convert.ToInt32(reader["AuditTypeId"].ToString())),
                        Title = reader["Title"].ToString(),
                        ReportDt = Convert.ToDateTime(reader["ReportDt"].ToString()),
                        Auditor1ID = Convert.ToInt32(reader["Auditor1Id"].ToString()),
                        Auditor1 = new Users(Convert.ToInt32(reader["Auditor1Id"].ToString())),

                        Auditor2ID = Auditor2_Id, //Convert.ToInt32(reader["Auditor2Id"].ToString()),
                        Auditor2 = Auditor2_User, //new Users(Convert.ToInt32(reader["Auditor2Id"].ToString())),

                        SupervisorID = Supervisor_Id, //Convert.ToInt32(reader["SupervisorId"].ToString()),
                        Supervisor = Supervisor_User, //new Users(Convert.ToInt32(reader["SupervisorId"].ToString())),

                        IsCompleted = Convert.ToBoolean(reader["IsCompleted"].ToString()),
                        AuditNumber = reader["AuditNumber"].ToString(),
                        IASentNumber = reader["IASentNumber"].ToString(),
                        RevNo = Convert.ToInt32(reader["RevNo"].ToString()),
                        AttCnt = Convert.ToInt32(reader["AttCnt"].ToString()),

                        AuditRatingId = AuditRating_Id,
                        AuditRating = AuditRating_rating,
                        IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString())
                    });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static void FillDataGridView(DataGridView dgv, List<Audit> AuditList)
        {
            dgv.Rows.Clear();

            foreach (Audit thisRecord in AuditList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Year, dgvColumnHeader = "Year" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Company.Name, dgvColumnHeader = "Company" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AuditType.Name, dgvColumnHeader = "AuditType" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Title, dgvColumnHeader = "Title" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ReportDt.ToString("dd.MM.yyyy"), dgvColumnHeader = "ReportDt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Auditor1.FullName, dgvColumnHeader = "Auditor1" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Auditor2.FullName, dgvColumnHeader = "Auditor2" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Supervisor.FullName, dgvColumnHeader = "Supervisor" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IsCompleted, dgvColumnHeader = "IsCompleted" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AuditNumber, dgvColumnHeader = "AuditNumber" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IASentNumber, dgvColumnHeader = "IASentNumber" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.RevNo, dgvColumnHeader = "RevNo" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AttCnt, dgvColumnHeader = "AttCnt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AuditRating.Name, dgvColumnHeader = "Rating" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IsDeleted, dgvColumnHeader = "IsDeleted" });

                string aaaa = thisRecord.Year.ToString() + "." + thisRecord.Company.NameShort + "." + thisRecord.AuditNumber + "." + thisRecord.AuditType.NameShort + "-" + thisRecord.IASentNumber;

                object[] obj = new object[dgv.Columns.Count];

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
                }

                dgv.Rows.Add(obj);
            }

            dgv.ClearSelection();

        }

        public static void FillDataGridView(DataGridView dgv, Audit givenAudit)
        {
            dgv.Rows.Clear();


            List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.Id, dgvColumnHeader = "Id" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.Year, dgvColumnHeader = "Year" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.Company.Name, dgvColumnHeader = "Company" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.AuditType.Name, dgvColumnHeader = "AuditType" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.Title, dgvColumnHeader = "Title" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.ReportDt.ToString("dd.MM.yyyy"), dgvColumnHeader = "ReportDt" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.Auditor1.FullName, dgvColumnHeader = "Auditor1" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.Auditor2.FullName, dgvColumnHeader = "Auditor2" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.Supervisor.FullName, dgvColumnHeader = "Supervisor" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.IsCompleted, dgvColumnHeader = "IsCompleted" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.AuditNumber, dgvColumnHeader = "AuditNumber" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.IASentNumber, dgvColumnHeader = "IASentNumber" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.RevNo, dgvColumnHeader = "RevNo" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.AttCnt, dgvColumnHeader = "AttCnt" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.AuditRating.Name, dgvColumnHeader = "Rating" });
            dgvDictList.Add(new dgvDictionary() { dbfield = givenAudit.IsDeleted, dgvColumnHeader = "IsDeleted" });

            object[] obj = new object[dgv.Columns.Count];

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
            }

            dgv.Rows.Add(obj);


            dgv.ClearSelection();

        }

        public void FillDataGridView(DataGridView dgv, Audit Audit, int dgvIndex)
        {
            //dgv.Rows.Clear();

            List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Id, dgvColumnHeader = "Id" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Year, dgvColumnHeader = "Year" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Company.Name, dgvColumnHeader = "Company" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.AuditType.Name, dgvColumnHeader = "AuditType" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Title, dgvColumnHeader = "Title" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.ReportDt.ToString("dd.MM.yyyy"), dgvColumnHeader = "ReportDt" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Auditor1.FullName, dgvColumnHeader = "Auditor1" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Auditor2.FullName, dgvColumnHeader = "Auditor2" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Supervisor.FullName, dgvColumnHeader = "Supervisor" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.IsCompleted, dgvColumnHeader = "IsCompleted" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.AuditNumber, dgvColumnHeader = "AuditNumber" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.IASentNumber, dgvColumnHeader = "IASentNumber" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.RevNo, dgvColumnHeader = "RevNo" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.AttCnt, dgvColumnHeader = "AttCnt" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.AuditRating.Name, dgvColumnHeader = "Rating" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.IsDeleted, dgvColumnHeader = "IsDeleted" });

            string aaaa = Audit.Year.ToString() + "." + Audit.Company.NameShort + "." + Audit.AuditNumber + "." + Audit.AuditType.NameShort + "-" + Audit.IASentNumber;

            object[] obj = new object[dgv.Columns.Count];

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;

                dgv.Rows[dgvIndex].Cells[i].Value = obj[i];
            }
            //dgv.Rows.Add(obj);
            //dgv.Rows[dgvIndex]

            //DataGridViewRow dgvr = new DataGridViewRow();
            //dgv.Rows[dgvIndex].SetValues(obj);

            //dgv.Rows.Insert(dgvIndex, )

            //dgv.ClearSelection();
            //set selected again???
            dgv.Rows[dgvIndex].Selected = true;
        }

        private void MIupdate_Click(object sender, EventArgs e)
        {            
            //int Id = Convert.ToInt32(((DataGridView)((ToolStripMenuItem)sender).SourceControl).SelectedRows[0].Cells["Id"].Value.ToString());
            //Audit thisAudit = auditList.Where(i => i.Id == Id).First();

            //int Id = dgvIndex;
            if (dgvAuditView.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvAuditView.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvAuditView.SelectedRows[0].Cells["Id"].Value.ToString());
                Audit thisAudit = auditList.Where(i => i.Id == Id).First();

                if (!UserAction.IsLegal(Action.Audit_Edit, thisAudit.Auditor1ID, thisAudit.Auditor2ID, thisAudit.SupervisorID))
                {
                    return;
                }

                InsertNewAudit frmUpdateAudit = new InsertNewAudit(thisAudit);
                frmUpdateAudit.ShowDialog();

                if (frmUpdateAudit.success)
                {
                    //refresh
                    //auditList = SelectAudit();
                    auditList[auditList.FindIndex(w => w.Id == Id)] = frmUpdateAudit.newAuditRecord;

                    //FillDataGridView(dgvAuditView, auditList);
                    //dgvAuditView.SelectedRows[0].Cells[""]
                    FillDataGridView(dgvAuditView, frmUpdateAudit.newAuditRecord, dgvIndex);
                }


            }
        }

        public int getHeadersCntForThisAudit(int givenAuditId)
        {
            int ret = 0;
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT count(*) AS cnt " +
                              "FROM [dbo].[FiHeader] " +
                              "WHERE AuditId = " + givenAuditId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["cnt"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            return ret;
        }

        private void MIdelete_Click(object sender, EventArgs e)
        {
            if (dgvAuditView.SelectedRows.Count > 0)
            {                
                if (dgvAuditView.SelectedRows[0].Cells["IsDeleted"].Value.ToString() == "True")
                {
                    MessageBox.Show("The audit has already been deleted!");
                    return;
                }

                Audit thisAudit = auditList.Where(i => i.Id == Convert.ToInt32(dgvAuditView.SelectedRows[0].Cells["Id"].Value.ToString())).First();
                if (!UserAction.IsLegal(Action.Audit_Delete, thisAudit.Auditor1ID, thisAudit.Auditor2ID, thisAudit.SupervisorID))
                {
                    return;
                }

                //Is there any FiHeader referring to this Audit
                if (getHeadersCntForThisAudit(thisAudit.Id) > 0)
                {
                    MessageBox.Show("The audit has Findings/Improvements referring to this Audit!");
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to permanently delete this record?", "Audit Deletion", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvAuditView.SelectedRows[0].Cells["Id"].Value.ToString());

                    if (DeleteAudit(id))
                    {
                        //auditList[auditList.FindIndex(w => w.Id == id)].IsDeleted = true;
                        //dgvAuditView["IsCompleted", dgvAuditView.SelectedRows[0].Index].Value = true;

                        int rev = auditList[auditList.FindIndex(w => w.Id == id)].RevNo;

                        if (auditList[auditList.FindIndex(w => w.Id == id)].AttCnt > 0)
                        {
                            if (new InsertNewAudit().InsertIntoTable_Att(id, rev, UserInfo.userDetails.Id) == false)
                            {
                                MessageBox.Show("The Deletion of attachments failed!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("The Deletion was successful!");
                        }

                        //rev += 1;
                        //auditList[auditList.FindIndex(w => w.Id == id)].RevNo = rev;
                        //dgvAuditView["RevNo", dgvAuditView.SelectedRows[0].Index].Value = rev;

                        auditList.RemoveAt(auditList.FindIndex(w => w.Id == id));
                        dgvAuditView.Rows.RemoveAt(dgvAuditView.SelectedRows[0].Index);

                        filteredLines.RemoveAt(filteredLines.FindIndex(w => w.Id == id));
                        toolStripCounter.Text = "Records: " + filteredLines.Count.ToString();
                    }
                    else
                    {
                        MessageBox.Show("The Deletion was not successful!");
                    }
                }
            }
        }

        private void MIshowFindings_Click(object sender, EventArgs e)
        {
            if (dgvAuditView.SelectedRows.Count > 0)
            {
                int thisId = Convert.ToInt32(dgvAuditView.SelectedRows[0].Cells["Id"].Value.ToString());
                Audit thisAudit = auditList.Where(i => i.Id == thisId).First();

                FIShowHeaders frmShowHeaders = new FIShowHeaders(thisAudit);
                if (dgvAuditView.Columns["IsDeleted"].Visible)//admin menu
                {
                    frmShowHeaders.AdminAccess = true;
                }
                
                frmShowHeaders.ShowDialog();
            }
        }

        private void MIattachments_Click(object sender, EventArgs e)
        {
            if (dgvAuditView.SelectedRows.Count > 0)
            {
                int auditId = Convert.ToInt32(dgvAuditView.SelectedRows[0].Cells["Id"].Value.ToString());
                int revNo = Convert.ToInt32(dgvAuditView.SelectedRows[0].Cells["RevNo"].Value.ToString());

                Attachments attachedFiles = new Attachments(auditId, revNo, AttachmentsTableName.Audit_Attachments);

                if (Convert.ToBoolean(dgvAuditView.SelectedRows[0].Cells["IsCompleted"].Value.ToString()) == true || Convert.ToBoolean(dgvAuditView.SelectedRows[0].Cells["IsDeleted"].Value.ToString()) == true)
                {
                    attachedFiles.btnAddFiles.Enabled = false;
                    attachedFiles.btnRemoveAll.Enabled = false;
                    attachedFiles.btnRemoveFile.Enabled = false;
                    attachedFiles.btnSave.Enabled = false;
                }

                Audit thisAudit = auditList.Where(i => i.Id == auditId).First();
                if (!UserAction.IsLegal(Action.Audit_Attach, thisAudit.Auditor1ID, thisAudit.Auditor2ID, thisAudit.SupervisorID))
                {
                    attachedFiles.btnAddFiles.Enabled = false;
                    attachedFiles.btnRemoveAll.Enabled = false;
                    attachedFiles.btnRemoveFile.Enabled = false;
                    attachedFiles.btnSave.Enabled = false;
                }

                attachedFiles.ShowDialog();

                int dgvIndex = dgvAuditView.SelectedRows[0].Index;
                if (attachedFiles.success)
                {
                    auditList[auditList.FindIndex(w => w.Id == auditId)].RevNo = attachedFiles.RevNo;
                    auditList[auditList.FindIndex(w => w.Id == auditId)].AttCnt = attachedFiles.AttCnt;
                    FillDataGridView(dgvAuditView, auditList[auditList.FindIndex(w => w.Id == auditId)], dgvIndex);
                }

            }
        }

        private void MIfinalizeAudit_Click(object sender, EventArgs e)
        {
            if (dgvAuditView.SelectedRows[0].Cells["IsCompleted"].Value.ToString() == "True")
            {
                MessageBox.Show("The audit has already been completed!");
                return;
            }

            if (dgvAuditView.SelectedRows[0].Cells["IsDeleted"].Value.ToString() == "True")
            {
                MessageBox.Show("The audit has been deleted!");
                return;
            }

            int id = Convert.ToInt32(dgvAuditView.SelectedRows[0].Cells["Id"].Value.ToString());

            Audit thisAudit = auditList.Where(i => i.Id == id).First();
            if (!UserAction.IsLegal(Action.Audit_Finalize, thisAudit.Auditor1ID, thisAudit.Auditor2ID, thisAudit.SupervisorID))
            {
                return;
            }

            if (UpdateAuditCompleted(id))
            {
                auditList[auditList.FindIndex(w => w.Id == id)].IsCompleted = true;
                dgvAuditView["IsCompleted", dgvAuditView.SelectedRows[0].Index].Value = true;

                int rev = auditList[auditList.FindIndex(w => w.Id == id)].RevNo;

                if (auditList[auditList.FindIndex(w => w.Id == id)].AttCnt > 0)
                {
                    if (new InsertNewAudit().InsertIntoTable_Att(id, rev, UserInfo.userDetails.Id) == false)
                    {
                        MessageBox.Show("The update of the attachments failed!");
                    }
                }
                else
                {
                    MessageBox.Show("The update was successful");
                }

                rev += 1;
                auditList[auditList.FindIndex(w => w.Id == id)].RevNo = rev;
                dgvAuditView["RevNo", dgvAuditView.SelectedRows[0].Index].Value = rev;
            }
            else
            {
                MessageBox.Show("The update was not successful");
            }
        }

        private void MIRevisions_Click(object sender, EventArgs e)
        {
            AuditRevisions frmRevisions = new AuditRevisions(Convert.ToInt32(dgvAuditView.SelectedRows[0].Cells["Id"].Value.ToString()));
            frmRevisions.ShowDialog();


        }
        private bool UpdateAuditCompleted(int id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[Audit] SET [IsCompleted] = 1, [UpdUserID] = @UpdUserID, [UpdDt] = getDate(), [RevNo] = RevNo+1, [UseUpdTrigger] = 1 " +
                "WHERE id=@id";
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

        private bool DeleteAudit(int id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[Audit] SET [IsDeleted] = 1, " + 
                "[UpdUserID] = @UpdUserID, [UpdDt] = getDate(), [DelUserID] = @UpdUserID, [DelDt] = getDate(), [RevNo] = RevNo+1, [UseUpdTrigger] = 1 " +
                "WHERE id = @id";
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

        private void dgvAuditView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvAuditView.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }
                dgvAuditView.Rows[hti.RowIndex].Selected = true;

                if (Convert.ToBoolean(dgvAuditView.SelectedRows[0].Cells["IsCompleted"].Value) == true || Convert.ToBoolean(dgvAuditView.SelectedRows[0].Cells["IsDeleted"].Value) == true)
                {
                    MIupdate.Enabled = false;
                    MIdelete.Enabled = false;
                    MIfinalizeAudit.Enabled = false;

                    //if (auditList.Exists(i => i.Id == Convert.ToInt32(dgvAuditView.SelectedRows[0].Cells["Id"].Value) && i.HasFindings))
                    //{
                    //    MIshowFindings.Enabled = f
                    //}
                    //else
                    //{

                    //}
                }
                else
                {
                    MIupdate.Enabled = true;
                    MIdelete.Enabled = true;
                    MIfinalizeAudit.Enabled = true;
                }
            }
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();

        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbAuditor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnTitleSearch_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void chbCompleted_CheckStateChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dgvAuditView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "ReportDt")
            {
                e.SortResult = System.String.Compare(Convert.ToDateTime(e.CellValue1.ToString()).ToString("yyyyMMdd HHmmss"),
                                                     Convert.ToDateTime(e.CellValue2.ToString()).ToString("yyyyMMdd HHmmss"));

                e.Handled = true;
            }
        }

        public void dgvAuditView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int AuditId = Convert.ToInt32(dgvAuditView["Id", e.RowIndex].Value);
                Header_Audit = auditList.Where(i => i.Id == AuditId).First();

                DialogResult = DialogResult.OK;

                Close();
            }
        }

        
    }

    public class AuditRating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AuditRating()
        { }

        public static bool isEqual(AuditRating x, AuditRating y)
        {
            if (x.Id == y.Id && x.Name == y.Name)
                return true;
            else
                return false;
        }

        public static List<ComboboxItem> GetAuditRatingComboboxItemsList(List<AuditRating> rating)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (AuditRating c in rating)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.Name });
            }

            return ret;
        }

        public AuditRating(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [id], [Name] " +
                              "FROM [dbo].[AuditRating] " +
                              "WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    Name = reader["Name"].ToString();
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public static List<AuditRating> GetSqlAuditRatingList()
        {
            List<AuditRating> ret = new List<AuditRating>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name] "+
                              "FROM [dbo].[AuditRating] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new AuditRating() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }
    }

    public class Audit
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int CompanyId { get; set; }
        public Companies Company { get; set; }
        public int AuditTypeId { get; set; }
        public AuditTypes AuditType { get; set; }
        public string Title { get; set; }
        public DateTime ReportDt { get; set; }
        public int Auditor1ID { get; set; }
        public Users Auditor1 { get; set; }
        public int? Auditor2ID { get; set; }
        public Users Auditor2 { get; set; }
        public int? SupervisorID { get; set; }
        public Users Supervisor { get; set; }
        public bool IsCompleted { get; set; }
        public string AuditNumber { get; set; }
        public string IASentNumber { get; set; }        
        public int RevNo { get; set; }
        public int AttCnt { get; set; }

        public int? AuditRatingId { get; set; }
        public AuditRating AuditRating { get; set; }

        public bool IsDeleted { get; set; }

        public static bool isEqual(Audit x, Audit y)
        {
            if (x.Id == y.Id && x.Year == y.Year && x.CompanyId == y.CompanyId && Companies.isEqual( x.Company , y.Company) && x.AuditTypeId == y.AuditTypeId && AuditTypes.isEqual( x.AuditType , y.AuditType) &&
                x.Title == y.Title && x.ReportDt == y.ReportDt && x.Auditor1ID == y.Auditor1ID && Users.isEqual( x.Auditor1 , y.Auditor1) && x.Auditor2ID == y.Auditor2ID && Users.isEqual(x.Auditor2, y.Auditor2) &&
                x.SupervisorID == y.SupervisorID && Users.isEqual(x.Supervisor, y.Supervisor) && x.IsCompleted == y.IsCompleted && x.AuditNumber == y.AuditNumber && x.IASentNumber == y.IASentNumber && x.RevNo == y.RevNo &&
                x.AuditRatingId == y.AuditRatingId && AuditRating.isEqual( x.AuditRating, y.AuditRating))
                return true;
            else
                return false;
        }

    }

    public class AuditRev
    {
        public int Id { get; set; }
        public int AuditId { get; set; }
        public int Year { get; set; }
        public int CompanyId { get; set; }
        public Companies Company { get; set; }
        public int AuditTypeId { get; set; }
        public AuditTypes AuditType { get; set; }
        public string Title { get; set; }
        public DateTime ReportDt { get; set; }
        public int Auditor1ID { get; set; }
        public Users Auditor1 { get; set; }
        public int? Auditor2ID { get; set; }
        public Users Auditor2 { get; set; }
        public int? SupervisorID { get; set; }
        public Users Supervisor { get; set; }
        public bool IsCompleted { get; set; }
        public string AuditNumber { get; set; }
        public string IASentNumber { get; set; }
        public int RevNo { get; set; }
        public int InsUserId { get; set; }
        public Users InsUser { get; set; }
        public DateTime InsDt { get; set; }

        public int? UpdUserId { get; set; }
        public Users UpdUser { get; set; }
        public DateTime UpdDt { get; set; }
        public int AttCnt { get; set; }

        public int? AuditRatingId { get; set; }
        public AuditRating AuditRating { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class Companies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameShort { get; set; }

        public Companies()
        {
        }
        public Companies(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NameShort] " +
                              "FROM [dbo].[Companies] " +
                              "WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    Name = reader["Name"].ToString();
                    NameShort = reader["NameShort"].ToString();
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public static  bool isEqual(Companies x, Companies y)
        {
            if (x.Id == y.Id && x.Name == y.Name && x.NameShort == y.NameShort)
                return true;
            else
                return false;
        }

     



        public static List<Companies> GetSqlCompaniesList()
        {
            List<Companies> ret = new List<Companies>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NameShort] " +
                              "FROM [dbo].[Companies] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Companies() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString(), NameShort = reader["NameShort"].ToString()});
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }


        public static List<ComboboxItem> GetCompaniesComboboxItemsList(List<Companies> Companies)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Companies c in Companies)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.Name });
            }

            return ret;
        }


    }

    public class FIHeader
    {
        public int Id { get; set; }
        public int AuditId { get; set; }
        public string Title { get; set; }
        public int FICategoryId { get; set; }
        public FICategory FICategory { get; set; }
        public int InsUserId { get; set; }
        public Users InsUser { get; set; }
        public DateTime InsDt { get; set; }
        public int UpdUserId { get; set; }
        public Users UpdUser { get; set; }
        public DateTime UpdDt { get; set; }
        public bool IsDeleted { get; set; }
        
        public bool IsPublished { get; set; }

        public FIHeader()
        {
        }
        
        public static bool isEqual(FIHeader x, FIHeader y)
        {
            if (x.Id == y.Id && x.AuditId == y.AuditId && x.Title == y.Title && x.FICategoryId == y.FICategoryId && FICategory.isEqual(x.FICategory, y.FICategory))
                return true;
            else
                return false;
        }

    }

    public class FIDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int FIHeaderId { get; set; }
        public DateTime ActionDt { get; set; }
        public string ActionReq { get; set; }
        
        public string ActionCode { get; set; }
        public List<Users> Owners { get; set; }
        public int OwnersCnt { get; set; }

        public int InsUserId { get; set; }
        public Users InsUser { get; set; }
        public DateTime InsDt { get; set; }

        public int UpdUserId { get; set; }
        public Users UpdUser { get; set; }
        public DateTime UpdDt { get; set; }

        public int RevNo { get; set; }

        public int AttCnt { get; set; }

        public bool IsDeleted { get; set; }
        public FIDetail()
        {
            Owners = new List<Users>();
        }

        public FIDetail(FIDetailRev fiDetailRev)
        {
            //Id = fiDetailRev.Id;
            Id = fiDetailRev.FIDetailId;
            
            Description = fiDetailRev.Description;
            FIHeaderId = fiDetailRev.FIHeaderId;
            ActionDt = fiDetailRev.ActionDt;
            ActionReq = fiDetailRev.ActionReq;
            ActionCode = fiDetailRev.ActionCode;
            Owners = fiDetailRev.Owners;
            OwnersCnt = fiDetailRev.OwnersCnt;
            InsUserId = fiDetailRev.InsUserId;
            InsUser = fiDetailRev.InsUser;
            InsDt = fiDetailRev.InsDt;
            UpdUserId = fiDetailRev.UpdUserId;
            UpdUser = fiDetailRev.UpdUser;
            UpdDt = fiDetailRev.UpdDt;
            RevNo = fiDetailRev.RevNo;
            AttCnt = fiDetailRev.AttCnt;
        }

        public static bool isEqual(FIDetail x, FIDetail y)
        {
            if (x.Id == y.Id && x.FIHeaderId == y.FIHeaderId && x.Description == y.Description && x.ActionReq == y.ActionReq && x.ActionDt == y.ActionDt && x.RevNo == y.RevNo && 
                x.ActionCode == y.ActionCode && Users.isListEqual(x.Owners, y.Owners))
                return true;
            else
                return false;
        }

        public List<Users> getOwners(int detail_Id, int detail_RevNo)
        {
            List<Users> ret = new List<Users>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [OwnerId] " +
                              "FROM [dbo].[FIDetail_Owners] " +
                              "WHERE FIDetailId = @detail_Id AND RevNo = @detail_RevNo ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detail_Id", detail_Id);
                cmd.Parameters.AddWithValue("@detail_RevNo", detail_RevNo);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Users(Convert.ToInt32(reader["OwnerId"].ToString())));
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }
    }

    public class FIDetailRev
    {
        public int Id { get; set; }
        public int FIDetailId { get; set; }
        public string Description { get; set; }
        public int FIHeaderId { get; set; }
        public DateTime ActionDt { get; set; }
        public string ActionReq { get; set; }

        public string ActionCode { get; set; }
        public List<Users> Owners { get; set; }
        public int OwnersCnt { get; set; }

        public int InsUserId { get; set; }
        public Users InsUser { get; set; }
        public DateTime InsDt { get; set; }

        public int UpdUserId { get; set; }
        public Users UpdUser { get; set; }
        public DateTime UpdDt { get; set; }

        public int RevNo { get; set; }

        public int AttCnt { get; set; }

        public bool IsDeleted { get; set; }

        public FIDetailRev()
        {
            Owners = new List<Users>();
        }

    }

    public class FICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool NeedsApproval { get; set; }

        public FICategory()
        {

        }

        public FICategory(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NeedsApproval] " +
                              "FROM [dbo].[FICategory] " +
                              "WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    Name = reader["Name"].ToString();
                    NeedsApproval = Convert.ToBoolean(reader["NeedsApproval"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }



        }

        public static List<ComboboxItem> GetFICategoryComboboxItemsList(List<FICategory> FICategories)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (FICategory c in FICategories)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.Name });
            }

            return ret;
        }

        public static List<FICategory> GetSqlFICategoriesList()
        {
            List<FICategory> ret = new List<FICategory>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NeedsApproval] " +
                              "FROM [dbo].[FICategory] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new FICategory() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString(), NeedsApproval = Convert.ToBoolean(reader["NeedsApproval"].ToString()) });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static bool isEqual(FICategory x, FICategory y)
        {
            if (x.Id == y.Id && x.Name == y.Name && x.NeedsApproval == y.NeedsApproval)
                return true;
            else
                return false;
        }
    }

    public class AuditTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameShort { get; set; }

        public AuditTypes()
        {
        }

        public AuditTypes(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NameShort] " +
                              "FROM [dbo].[AuditTypes] " +
                              "WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    Name = reader["Name"].ToString();
                    NameShort = reader["NameShort"].ToString();
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }



        }
        public static bool isEqual(AuditTypes x, AuditTypes y)
        {
            if (x.Id == y.Id && x.Name == y.Name && x.NameShort == y.NameShort)
                return true;
            else
                return false;
        }

        public static List<AuditTypes> GetSqlAuditTypesList()
        {
            List<AuditTypes> ret = new List<AuditTypes>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NameShort] " +
                              "FROM [dbo].[AuditTypes] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new AuditTypes() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString(), NameShort = reader["NameShort"].ToString() });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<ComboboxItem> GetAuditTypesComboboxItemsList(List<AuditTypes> AuditTypes)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (AuditTypes c in AuditTypes)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.Name });
            }

            return ret;
        }

    }

    public enum UserRole
    {
        None,
        IsAuditor,
        IsAuditee
    }

    public enum AttachmentsTableName
    {
        None,
        Audit_Attachments,
        FIDetail_Attachments
    }

    public class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string RoleName { get; set; }

        public Users()
        {
        }
        public Users(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT U.[Id], CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , U.[FullName])) as FullName, R.Name as RoleName " +
                              "FROM [dbo].[Roles] R, [dbo].[Users] U  " +
                              "WHERE R.Id = U.RolesId AND U.Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    FullName = reader["FullName"].ToString();
                    RoleName = reader["RoleName"].ToString();
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public static bool isEqual(Users x, Users y)
        {
            if (x.Id == y.Id && x.FullName == y.FullName)
                return true;
            else
                return false;
        }

        public static bool isListEqual(List<Users> x, List<Users> y)
        {
            if (x.Count == y.Count)// && x.Id == y.Id && x.FullName == y.FullName)
            {
                for(int i = 0; i< x.Count; i++)
                {
                    if (isEqual(x[i], y[i]) == false)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Users> GetSqlUsersList()
        {
            List<Users> ret = new List<Users>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , [FullName])) as FullName " +
                              "FROM [dbo].[Users] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Users() { Id = Convert.ToInt32(reader["Id"].ToString()), FullName = reader["FullName"].ToString()});
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<Users> GetUsersByRole(UserRole role)
        {
            List<Users> ret = new List<Users>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT U.[Id], CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , U.[FullName])) as FullName, R.Name as RoleName " +
                              "FROM [dbo].[Roles] R, [dbo].[Users] U " +
                              "WHERE R.Id = U.RolesId ";

            if (role != UserRole.None)
            {
                SelectSt += " AND R." + role.ToString() + " = 1 ";
            }

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Users()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        FullName = reader["FullName"].ToString(),
                        RoleName = reader["RoleName"].ToString()
                    });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<ComboboxItem> GetUsersComboboxItemsList(List<Users> Users)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Users c in Users)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.FullName });
            }

            return ret;
        }
    }

    public class dgvDictionary
    {
        public object dbfield { get; set; }
        public string dgvColumnHeader { get; set; }
    }


}
