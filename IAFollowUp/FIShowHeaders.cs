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
    public partial class FIShowHeaders : Form
    {
        public FIShowHeaders()
        {
            InitializeComponent();
        }

        public FIShowHeaders(Audit selAudit)
        {
            InitializeComponent();

            glAudit = selAudit;
        }

        public Audit glAudit = new Audit();
        public List<FIHeader> Audit_Headers = new List<FIHeader>();
        public List<FIDetail> Header_Details = new List<FIDetail>();

        private void MIeditHeader_Click(object sender, EventArgs e)
        {
            if (dgvHeaders.SelectedRows.Count > 0)
            {
                int HeaderId = Convert.ToInt32(dgvHeaders.SelectedRows[0].Cells["HeaderId"].Value.ToString());
                FIHeader selectedHeader = Audit_Headers.Where(i => i.Id == HeaderId).First();

                //Audit selectedAudit = auditList.Where(i => i.Id == selAuditId).First();

                FIHeaderEdit frmHeaderEdit = new FIHeaderEdit(glAudit, selectedHeader);
                frmHeaderEdit.ShowDialog();

                if (frmHeaderEdit.success)
                {
                    Audit_Headers = SelectHeaders(glAudit.Id);
                    FillHeadersDataGridView(dgvHeaders, Audit_Headers);
                }
            }
        }

        private void MIeditDetail_Click(object sender, EventArgs e)
        {
            if (dgvDetails.SelectedRows.Count > 0)
            {
                int DetailId = Convert.ToInt32(dgvDetails.SelectedRows[0].Cells["DetailId"].Value.ToString());
                FIDetail selectedDetail = Header_Details.Where(i => i.Id == DetailId).First();

                int HeaderId = Convert.ToInt32(dgvHeaders.SelectedRows[0].Cells["HeaderId"].Value.ToString());
                FIHeader selectedHeader = Audit_Headers.Where(i => i.Id == HeaderId).First();

                FIDetailEdit frmDetailEdit = new FIDetailEdit(selectedHeader, selectedDetail);
                frmDetailEdit.ShowDialog();

                if (frmDetailEdit.success)
                {
                    Header_Details = SelectDetails(selectedHeader.Id);
                    FillDetailsDataGridView(dgvDetails, Header_Details);
                }
            }
        }

        public List<FIDetail> SelectDetails(int HeaderId)
        {
            List<FIDetail> ret = new List<FIDetail>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , [Description])) as Description, " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , [ActionReq])) as ActionReq,[ActionDt], " +
                              "[FIHeaderId],[InsUserId],[InsDt], [UpdUserId], [UpdDt] " +
                              "FROM [dbo].[FIDetail] " +
                              "WHERE [FIHeaderId] = @HeaderId " +
                              "ORDER BY [InsDt] ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@HeaderId", HeaderId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ret.Add(new FIDetail()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        FIHeaderId = Convert.ToInt32(reader["FIHeaderId"].ToString()),
                        UpdUserId = Convert.ToInt32(reader["UpdUserId"].ToString()),
                        UpdUser = new Users(Convert.ToInt32(reader["UpdUserId"].ToString())),
                        UpdDt = Convert.ToDateTime(reader["UpdDt"].ToString()),
                        ActionDt = Convert.ToDateTime(reader["ActionDt"].ToString()),
                        Description = reader["Description"].ToString(),
                        ActionReq = reader["ActionReq"].ToString()
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

        public static void FillDetailsDataGridView(DataGridView dgv, List<FIDetail> DetailList)
        {
            dgv.Rows.Clear();

            foreach (FIDetail thisRecord in DetailList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "DetailId" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Description, dgvColumnHeader = "DetailDescription" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ActionReq, dgvColumnHeader = "DetailActionReq" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ActionDt.ToString("dd.MM.yyyy"), dgvColumnHeader = "DetailActionDt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.UpdUser.FullName, dgvColumnHeader = "DetailUpdUser" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.UpdDt.ToString("dd.MM.yyyy HH:mm:ss"), dgvColumnHeader = "DetailUpdDate" });


                object[] obj = new object[dgv.Columns.Count];

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
                }

                dgv.Rows.Add(obj);
            }

            dgv.ClearSelection();
        }


        //public List<Audit> SelectAudit()
        //{
        //    List<Audit> ret = new List<Audit>();

        //    SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
        //    string SelectSt = "SELECT [Id], [Year], [CompanyId], [AuditTypeId], " +
        //                      "CONVERT(varchar, DECRYPTBYPASSPHRASE( @passPhrase , [Title])) as Title, " +
        //                      "[ReportDt], " +
        //                      "[Auditor1Id], [Auditor2Id], [SupervisorId], " +
        //                      "[IsCompleted], [AuditNumber], [IASentNumber], [RevNo], " +
        //                      "(SELECT count(*) FROM [dbo].[Attachments] T WHERE a.id = T.AuditID and A.RevNo = T.RevNo) as AttCnt " +
        //                      "FROM [dbo].[Audit] A " +
        //                      "WHERE isnull([IsCompleted], 0) = 0 " +
        //                      "ORDER BY Id "; //ToDo
        //    SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
        //    try
        //    {
        //        sqlConn.Open();
        //        cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            int? Auditor2_Id, Supervisor_Id;
        //            Users Auditor2_User, Supervisor_User;
        //            if (reader["Auditor2Id"] == System.DBNull.Value)
        //            {
        //                Auditor2_Id = null;
        //                Auditor2_User = new Users();
        //            }
        //            else
        //            {
        //                Auditor2_Id = Convert.ToInt32(reader["Auditor2Id"].ToString());
        //                Auditor2_User = new Users(Convert.ToInt32(reader["Auditor2Id"].ToString()));
        //            }
        //            if (reader["SupervisorId"] == System.DBNull.Value)
        //            {
        //                Supervisor_Id = null;
        //                Supervisor_User = new Users();
        //            }
        //            else
        //            {
        //                Supervisor_Id = Convert.ToInt32(reader["SupervisorId"].ToString());
        //                Supervisor_User = new Users(Convert.ToInt32(reader["SupervisorId"].ToString()));
        //            }

        //            ret.Add(new Audit()
        //            {
        //                Id = Convert.ToInt32(reader["Id"].ToString()),
        //                Year = Convert.ToInt32(reader["Year"].ToString()),
        //                CompanyId = Convert.ToInt32(reader["CompanyId"].ToString()),
        //                Company = new Companies(Convert.ToInt32(reader["CompanyId"].ToString())),
        //                AuditTypeId = Convert.ToInt32(reader["AuditTypeId"].ToString()),
        //                AuditType = new AuditTypes(Convert.ToInt32(reader["AuditTypeId"].ToString())),
        //                Title = reader["Title"].ToString(),
        //                ReportDt = Convert.ToDateTime(reader["ReportDt"].ToString()),
        //                Auditor1ID = Convert.ToInt32(reader["Auditor1Id"].ToString()),
        //                Auditor1 = new Users(Convert.ToInt32(reader["Auditor1Id"].ToString())),

        //                Auditor2ID = Auditor2_Id, //Convert.ToInt32(reader["Auditor2Id"].ToString()),
        //                Auditor2 = Auditor2_User, //new Users(Convert.ToInt32(reader["Auditor2Id"].ToString())),

        //                SupervisorID = Supervisor_Id, //Convert.ToInt32(reader["SupervisorId"].ToString()),
        //                Supervisor = Supervisor_User, //new Users(Convert.ToInt32(reader["SupervisorId"].ToString())),

        //                IsCompleted = Convert.ToBoolean(reader["IsCompleted"].ToString()),
        //                AuditNumber = reader["AuditNumber"].ToString(),
        //                IASentNumber = reader["IASentNumber"].ToString(),
        //                RevNo = Convert.ToInt32(reader["RevNo"].ToString()),
        //                AttCnt = Convert.ToInt32(reader["AttCnt"].ToString())
        //            });
        //        }
        //        reader.Close();
        //        sqlConn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("The following error occurred: " + ex.Message);
        //    }

        //    return ret;
        //}

        public List<FIHeader> SelectHeaders(int AuditId)
        {
            List<FIHeader> ret = new List<FIHeader>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [AuditId], " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , [Title])) as Title, " +
                              "[FICategoryId],[InsUserId],[InsDt], [UpdUserId], [UpdDt] " +
                              "FROM [dbo].[FIHeader] " +
                              "WHERE [AuditId] = @AuditId " +
                              "ORDER BY [InsDt] ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@AuditId", AuditId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ret.Add(new FIHeader()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        AuditId = Convert.ToInt32(reader["AuditId"].ToString()),

                        FICategoryId = Convert.ToInt32(reader["FICategoryId"].ToString()),
                        FICategory = new FICategory(Convert.ToInt32(reader["FICategoryId"].ToString())),

                        UpdUserId = Convert.ToInt32(reader["UpdUserId"].ToString()),
                        UpdUser = new Users(Convert.ToInt32(reader["UpdUserId"].ToString())),
                        UpdDt = Convert.ToDateTime(reader["UpdDt"].ToString()),

                        Title = reader["Title"].ToString()
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

        private void FIShowHeaders_Load(object sender, EventArgs e)
        {
            Auditor_AuditView.FillDataGridView(dgvAudits, glAudit);

            List<FIHeader> Audit_HeadersList = SelectHeaders(glAudit.Id);

            if (glAudit.IsCompleted)
            {
                if (Audit_HeadersList.Count > 0)
                {
                    btnNewHeader.Enabled = false;
                    btnNewDetail.Enabled = false;
                    MIeditHeader.Enabled = false; 
                }
                else
                {
                    MessageBox.Show("The Audit has No Findings/Improvements!");
                    Close();
                }
            }

            FillHeadersDataGridView(dgvHeaders, Audit_HeadersList);

            Audit_Headers = Audit_HeadersList;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
                //int AuditId = Convert.ToInt32(dgvAudits.SelectedRows[0].Cells["Id"].Value.ToString());
                //Audit selectedAudit = auditList.Where(i => i.Id == AuditId).First();

                FIHeaderEdit frmHeaderEdit = new FIHeaderEdit(glAudit);
                frmHeaderEdit.ShowDialog();

                if (frmHeaderEdit.success)
                {
                    Audit_Headers = SelectHeaders(glAudit.Id);
                    FillHeadersDataGridView(dgvHeaders, Audit_Headers);
                }
        }

        public static void FillHeadersDataGridView(DataGridView dgv, List<FIHeader> HeaderList)
        {
            dgv.Rows.Clear();

            foreach (FIHeader thisRecord in HeaderList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "HeaderId" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Title, dgvColumnHeader = "HeaderTitle" });               
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.FICategory.Name, dgvColumnHeader = "HeaderCategory" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.UpdUser.FullName, dgvColumnHeader = "UpdUser" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.UpdDt.ToString("dd.MM.yyyy HH:mm:ss"), dgvColumnHeader = "UpdDt" });


                object[] obj = new object[dgv.Columns.Count];

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
                }

                dgv.Rows.Add(obj);
            }

            dgv.ClearSelection();
        }

        private void dgvAudits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvAudits.SelectedRows.Count > 0)
            //{
            //    int AuditId = Convert.ToInt32(dgvAudits.SelectedRows[0].Cells["Id"].Value);

            //    List<FIHeader> Audit_HeadersList = SelectHeaders(AuditId);
            //    FillHeadersDataGridView(dgvHeaders, Audit_HeadersList);

            //    Audit_Headers = Audit_HeadersList;

            //    selAuditId = AuditId;
            //}
        }

        private void dgvHeaders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHeaders.SelectedRows.Count > 0)
            {
                int HeaderId = Convert.ToInt32(dgvHeaders.SelectedRows[0].Cells["HeaderId"].Value.ToString());

                Header_Details = SelectDetails(HeaderId);
                FillDetailsDataGridView(dgvDetails, Header_Details);
            }
        }

        private void dgvHeaders_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvHeaders.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }
                dgvHeaders.Rows[hti.RowIndex].Selected = true;

                //if (Convert.ToBoolean(dgvAudits.SelectedRows[0].Cells["IsCompleted"].Value) == true)
                if(glAudit.IsCompleted == true)
                {
                    MIeditHeader.Enabled = false;
                }
                else
                {
                    MIeditHeader.Enabled = true;
                }
            }
        }

        private void btnNewDetail_Click(object sender, EventArgs e)
        {
            if (dgvHeaders.SelectedRows.Count > 0)
            {
                int HeaderId = Convert.ToInt32(dgvHeaders.SelectedRows[0].Cells["HeaderId"].Value.ToString());
                FIHeader selectedHeader = Audit_Headers.Where(i => i.Id == HeaderId).First();

                FIDetailEdit frmDetailEdit = new FIDetailEdit(selectedHeader);
                frmDetailEdit.ShowDialog();

                if (frmDetailEdit.success)
                {
                    Header_Details = SelectDetails(selectedHeader.Id);
                    FillDetailsDataGridView(dgvDetails, Header_Details);
                }
            }
        }

        
    }
}
