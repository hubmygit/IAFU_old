using System;
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
    public partial class AuditRevisions : Form
    {
        public AuditRevisions(int id)
        {
            InitializeComponent();
            auditRevList = SelectAuditRev(id);
        }
        private void AuditRevisions_Load(object sender, EventArgs e)
        {
           
            cbUpdUser.Items.Add("All");
            cbUpdUser.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());

            DateTime dtToday = DateTime.Now.Date;
            dtpUpdDtFrom.Value = new DateTime(dtToday.Year, 1, 1).AddYears(-1);


            FillDataGridViewRev(dgvAuditRevView, auditRevList);
        }

        public List<Users> usersList = Users.GetSqlUsersList();


        public void ApplyFilters()
        {
            List<AuditRev> filteredLines = new List<AuditRev>();

            filteredLines = auditRevList.Where(i => i.UpdDt >= dtpUpdDtFrom.Value.Date && i.UpdDt < dtpUpdDtTo.Value.Date.AddDays(1)).ToList();
            
            if (cbUpdUser.SelectedIndex > 0)
            {
                filteredLines = filteredLines.Where(i => i.UpdUserId == InsertNewAudit.getComboboxItem<Users>(cbUpdUser).Id).ToList();
            }

            FillDataGridViewRev(dgvAuditRevView, filteredLines);

            toolStripCounter.Text = "Records: " + filteredLines.Count.ToString();
        }



        public List<AuditRev> auditRevList = new List<AuditRev>();

        public List<AuditRev> SelectAuditRev(int Id)
        {
            List<AuditRev> ret = new List<AuditRev>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT 0 as [Id], [Id] as [AuditId], [Year], [CompanyId], [AuditTypeId], " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , [Title])) as Title, " +
                              "[ReportDt], " +
                              "[Auditor1Id], [Auditor2Id], [SupervisorId], " +
                              "[IsCompleted], [AuditNumber], [IASentNumber],[InsUserId],[UpdUserId],[InsDt], [UpdDt], [RevNo], " +
                              "(SELECT count(*) FROM [dbo].[Audit_Attachments] T WHERE a.id = T.AuditID and A.RevNo = T.RevNo) as AttCnt, " + 
                              "[AuditRatingId], isnull([IsDeleted], 'FALSE') as IsDeleted " +
                              "FROM [dbo].[Audit] A " +
                              "WHERE Id = " + Id.ToString() + 

                              " UNION ALL " +

                              "SELECT R.[Id], R.[AuditId], R.[Year], R.[CompanyId], R.[AuditTypeId], " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , R.[Title])) as Title, " +
                              "R.[ReportDt], " +
                              "R.[Auditor1Id], R.[Auditor2Id], R.[SupervisorId], " +
                              "R.[IsCompleted], R.[AuditNumber], R.[IASentNumber], R.[InsUserId], R.[UpdUserId], R.[InsDt], R.[UpdDt], R.[RevNo], " +
                              "(SELECT count(*) FROM [dbo].[Audit_Attachments] T WHERE R.AuditId = T.AuditID and R.RevNo = T.RevNo) as AttCnt, " +
                              "R.[AuditRatingId], 'FALSE' as IsDeleted " +
                              "FROM [dbo].[AuditRev] R " +
                              "WHERE R.AuditId = " + Id.ToString() +
                              
                              " ORDER BY RevNo DESC"; 
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
                    if (reader["AuditRatingId"]==System.DBNull.Value)
                    {
                        AuditRating_Id = null;
                        AuditRating_rating = new AuditRating();
                    }
                    else
                    {
                        AuditRating_Id = Convert.ToInt32(reader["AuditRatingId"].ToString());
                        AuditRating_rating = new AuditRating(Convert.ToInt32(reader["AuditRatingId"].ToString()));
                    }
                    //if (reader["UpdUserId"] == System.DBNull.Value)
                    //{
                    //    UpdUser_Id = null;
                    //    UpdUser_User = new Users();
                    //    UpdateDt = null; //new DateTime();
                    //}
                    //else
                    //{
                    //    UpdUser_Id = Convert.ToInt32(reader["UpdUserId"].ToString());
                    //    UpdUser_User = new Users(Convert.ToInt32(reader["UpdUserId"].ToString()));
                    //    UpdateDt = Convert.ToDateTime(reader["UpdDt"].ToString());
                    //}


                    ret.Add(new AuditRev()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        AuditId = Convert.ToInt32(reader["AuditId"].ToString()),
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

                        InsUserId = Convert.ToInt32(reader["InsUserId"].ToString()),
                        InsUser = new Users(Convert.ToInt32(reader["InsUserId"].ToString())),
                        InsDt = Convert.ToDateTime(reader["InsDt"].ToString()),

                        UpdUserId = Convert.ToInt32(reader["UpdUserId"].ToString()),
                        UpdUser = new Users(Convert.ToInt32(reader["UpdUserId"].ToString())),
                        UpdDt = Convert.ToDateTime(reader["UpdDt"].ToString()),

                        //UpdUserId = UpdUser_Id,
                        //UpdUser = UpdUser_User,
                        //UpdDt = UpdateDt,

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

        public void FillDataGridViewRev(DataGridView dgv, List<AuditRev> AuditRevList)
        {
            dgv.Rows.Clear();

            foreach (AuditRev thisRecord in AuditRevList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                //string strUpddt = "";
                //if (thisRecord.UpdDt != null)
                //{
                //    strUpddt = Convert.ToDateTime(thisRecord.UpdDt).ToString("dd.MM.yyyy HH:mm:ss");
                //}
                //string strInsdt = "";
                //if (thisRecord.InsDt != null)
                //{
                //    strInsdt = Convert.ToDateTime(thisRecord.InsDt).ToString("dd.MM.yyyy HH:mm:ss");
                //}

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AuditId, dgvColumnHeader = "AuditID" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Year, dgvColumnHeader = "Year" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Company.Name, dgvColumnHeader = "Company" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AuditType.Name, dgvColumnHeader = "AuditType" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Title, dgvColumnHeader = "Title" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ReportDt.ToString("dd.MM.yyyy"), dgvColumnHeader = "ReportDt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Auditor1.FullName, dgvColumnHeader = "Auditor1" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Auditor2.FullName, dgvColumnHeader = "Auditor2" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Supervisor.FullName, dgvColumnHeader = "Supervisor" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.InsUser.FullName, dgvColumnHeader = "InsUser" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.InsDt.ToString("dd.MM.yyyy HH:mm:ss"), dgvColumnHeader = "InsDt" });
                //dgvDictList.Add(new dgvDictionary() { dbfield = strInsdt, dgvColumnHeader = "InsDt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.UpdUser.FullName, dgvColumnHeader = "UpdUser" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.UpdDt.ToString("dd.MM.yyyy HH:mm:ss"), dgvColumnHeader = "UpdDt" });
                //dgvDictList.Add(new dgvDictionary() { dbfield = strUpddt, dgvColumnHeader = "UpdDt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IsCompleted, dgvColumnHeader = "IsCompleted" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AuditNumber, dgvColumnHeader = "AuditNumber" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IASentNumber, dgvColumnHeader = "IASentNumber" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.RevNo, dgvColumnHeader = "RevNo" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AttCnt, dgvColumnHeader = "AttCnt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AuditRating.Name, dgvColumnHeader = "AuditRating" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IsDeleted, dgvColumnHeader = "IsDeleted" });

                string aaaa = thisRecord.Year.ToString() + "." + thisRecord.Company.NameShort + "." + thisRecord.AuditNumber + "." + thisRecord.AuditType.NameShort + "-" + thisRecord.IASentNumber;

                object[] obj = new object[dgv.Columns.Count];

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
                }

                dgv.Rows.Add(obj);

                if (thisRecord.Id == 0)
                {
                    dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.White;
                }

            }

            //if (AuditRevList.Count > 0)
            //{
            //    dgv.Rows[0].DefaultCellStyle.BackColor = Color.White;
            //}

            dgv.ClearSelection();

        }

        private void cbUpdUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpUpdDtFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtUpdDtTo_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void MIattachments_Click(object sender, EventArgs e)
        {
            if (dgvAuditRevView.SelectedRows.Count > 0)
            {
                if (Convert.ToInt32(dgvAuditRevView.SelectedRows[0].Cells["AttCnt"].Value.ToString()) > 0)
                {
                    int auditId = Convert.ToInt32(dgvAuditRevView.SelectedRows[0].Cells["AuditID"].Value.ToString());
                    int revNo = Convert.ToInt32(dgvAuditRevView.SelectedRows[0].Cells["RevNo"].Value.ToString());

                    Attachments attachedFiles = new Attachments(auditId, revNo, AttachmentsTableName.Audit_Attachments);
                    attachedFiles.btnAddFiles.Enabled = false;
                    attachedFiles.btnRemoveAll.Enabled = false;
                    attachedFiles.btnRemoveFile.Enabled = false;
                    attachedFiles.btnSave.Enabled = false;

                    attachedFiles.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No attached files found!");
                }
            }
        }

        private void dgvAuditRevView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvAuditRevView.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }
                dgvAuditRevView.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void dgvAuditRevView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "UpdDt" || e.Column.Name == "ReportDt")
            {
                e.SortResult = System.String.Compare(Convert.ToDateTime(e.CellValue1.ToString()).ToString("yyyyMMdd HHmmss"),
                                                     Convert.ToDateTime(e.CellValue2.ToString()).ToString("yyyyMMdd HHmmss"));

                e.Handled = true;
            }
        }
    }
}
