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
    public partial class FIShowHeaders : Form
    {
        public FIShowHeaders()
        {
            InitializeComponent();

            auditList = SelectAudit();
        }

        public List<Audit> auditList = new List<Audit>();

        public FIShowHeaders(Audit Selected)
        {
            InitializeComponent();
        }
        private void MIeditHeader_Click(object sender, EventArgs e)
        {
            auditList = SelectAudit();
        }

        public List<Audit> SelectAudit()
        {
            List<Audit> ret = new List<Audit>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Year], [CompanyId], [AuditTypeId], " +
                              "CONVERT(varchar, DECRYPTBYPASSPHRASE( @passPhrase , [Title])) as Title, " +
                              "[ReportDt], " +
                              "[Auditor1Id], [Auditor2Id], [SupervisorId], " +
                              "[IsCompleted], [AuditNumber], [IASentNumber], [RevNo], " +
                              "(SELECT count(*) FROM [dbo].[Attachments] T WHERE a.id = T.AuditID and A.RevNo = T.RevNo) as AttCnt " +
                              "FROM [dbo].[Audit] A " +
                              "WHERE isnull([IsCompleted], 0) = 0 " +
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
                        AttCnt = Convert.ToInt32(reader["AttCnt"].ToString())
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
            Auditor_AuditView.FillDataGridView(dgvAudits, auditList);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FIHeaderEdit frmHeaderEdit = new FIHeaderEdit();
            frmHeaderEdit.ShowDialog();

        }
    }
}
