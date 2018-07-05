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
    public partial class InsertNewAudit : Form
    {

        public InsertNewAudit() //insert
        {
            InitializeComponent();
            Init();
            isInsert = true;
        }

        public InsertNewAudit(Audit audit) //update
        {
            InitializeComponent();
            Init();
            isInsert = false;

            oldAuditRecord = audit;
            AuditUpdId = audit.Id;

            txtTitle.Text = audit.Title;
            dtpYear.Value = new DateTime (audit.Year, 1,1);

            cbCompanies.SelectedIndex = cbCompanies.FindStringExact(audit.Company.Name);

            txtAuditNumber.Text = audit.AuditNumber;
            txtIASentNumber.Text = audit.IASentNumber;
            dtpReportDate.Value = audit.ReportDt;

            cbAuditTypes.SelectedIndex = cbAuditTypes.FindStringExact(audit.AuditType.Name);
            cbAuditor1.SelectedIndex = cbAuditor1.FindStringExact(audit.Auditor1.FullName);

            if (audit.Auditor2 != null)
            {
                cbAuditor2.SelectedIndex = cbAuditor2.FindStringExact(audit.Auditor2.FullName);
            }
            if (audit.Supervisor!= null)
            {
                cbSupervisor.SelectedIndex = cbSupervisor.FindStringExact(audit.Supervisor.FullName);
            }
        }


        public void Init()
        {
            cbCompanies.Items.AddRange(Companies.GetCompaniesComboboxItemsList(companiesList).ToArray<ComboboxItem>());
            cbAuditTypes.Items.AddRange(AuditTypes.GetAuditTypesComboboxItemsList(auditTypesList).ToArray<ComboboxItem>());

            //List<Users> auditorsList = usersList;
            //List<Users> auditorsList = new List<Users>();

            cbAuditor1.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());
            cbAuditor2.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());
            cbSupervisor.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());
        }

        //public User user = new User();

        public List<Companies> companiesList = Companies.GetSqlCompaniesList();

        public List<AuditTypes> auditTypesList = AuditTypes.GetSqlAuditTypesList();

        public List<Users> usersList = Users.GetUsersByRole(UserRole.IsAuditor); //Users.GetSqlUsersList();

        public bool isInsert = false;
        public int AuditUpdId = 0;
        public bool success = false;

        public Audit oldAuditRecord = new Audit();
        public Audit newAuditRecord = new Audit();
        private void button1_Click(object sender, EventArgs e)
        {
            cbAuditor2.SelectedIndex = -1;
        }

        private void btnEraseSupervisor_Click(object sender, EventArgs e)
        {
            cbSupervisor.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            if (txtTitle.Text.Trim()=="")
            {
                MessageBox.Show("Please insert a Title!");
                return;
            }
            if (txtAuditNumber.Text.Trim() == "")
            {
                MessageBox.Show("Please insert an Audit Number!");
                return;
            }
            if (txtIASentNumber.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a IA Sent Number!");
                return;
            }
            if (cbCompanies.Text.Trim() == "")
            {
                MessageBox.Show("Please choose a Company!");
                return;
            }

            if (cbAuditTypes.Text.Trim() == "")
            {
                MessageBox.Show("Please choose an Audit Type!");
                return;
            }

            if (cbAuditor1.Text.Trim() == "")
            {
                MessageBox.Show("Please choose an Auditor 1!");
                return;
            }

            newAuditRecord = new Audit()
            {
                AuditNumber = txtAuditNumber.Text, 
                Auditor1 = getComboboxItem<Users>(cbAuditor1),
                Auditor1ID = getComboboxItem<Users>(cbAuditor1).Id,
                Company = getComboboxItem<Companies>(cbCompanies),
                CompanyId = getComboboxItem<Companies>(cbCompanies).Id,
                AuditType = getComboboxItem<AuditTypes>(cbAuditTypes),
                AuditTypeId = getComboboxItem<AuditTypes>(cbAuditTypes).Id,
                IASentNumber = txtIASentNumber.Text,
                Title = txtTitle.Text,
                Year = dtpYear.Value.Year,
                ReportDt = dtpReportDate.Value.Date,
                IsCompleted = false,

                Id = AuditUpdId, //only on update
                RevNo = oldAuditRecord.RevNo,
                AttCnt= oldAuditRecord.AttCnt

            };

            if (cbAuditor2.SelectedIndex > -1)
            {
                newAuditRecord.Auditor2 = getComboboxItem<Users>(cbAuditor2);
                newAuditRecord.Auditor2ID = getComboboxItem<Users>(cbAuditor2).Id;
            }
            else
            {
                newAuditRecord.Auditor2 = new Users();
            }

            if (cbSupervisor.SelectedIndex > -1)
            {
                newAuditRecord.Supervisor = getComboboxItem<Users>(cbSupervisor);
                newAuditRecord.SupervisorID = getComboboxItem<Users>(cbSupervisor).Id;
            }
            else
            {
                newAuditRecord.Supervisor = new Users();
            }

            if (isInsert) //insert
            {
                if (InsertIntoTable_Audit(newAuditRecord))
                {
                    MessageBox.Show("New Audit inserted successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The New Audit has not been inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //update
            {
                if (Audit.isEqual(oldAuditRecord, newAuditRecord) == false)
                {
                    if (UpdateTable_Audit(newAuditRecord))
                    {
                        bool successful = true;
                        newAuditRecord.RevNo = newAuditRecord.RevNo + 1;
                        success = true;
                        
                        if (oldAuditRecord.AttCnt > 0)
                        {
                            if (InsertIntoTable_Att(newAuditRecord.Id, oldAuditRecord.RevNo, UserInfo.userDetails.Id)==false)
                            {
                                successful = false;
                            }
                        }

                        if (successful)
                        {
                            MessageBox.Show("Audit updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Audit updated. Error while inserting attachments.");
                        }
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("The Audit has not been updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Close();
                }
            }

            
            
        }

        public bool InsertIntoTable_Att( int AuditId, int OldRevNo, int UsersID)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Attachments] ([Name], [FileContents], [AuditId], [RevNo], [UsersID], [InsDate]) " +
                           "SELECT [Name], [FileContents], @AuditID, @OldRevNo+1, @UsersID, getDate() " +
                           "FROM [dbo].[Attachments] WHERE AuditID=@AuditID and RevNo= @OldRevNo";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@AuditID", AuditId);
                cmd.Parameters.AddWithValue("@OldRevNo", OldRevNo);
                cmd.Parameters.AddWithValue("@UsersID", UsersID);


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

        private bool InsertIntoTable_Audit (Audit audit) //INSERT [dbo].[Audit]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Audit] ([Year],[CompanyID],[AuditTypeID],[Title],[ReportDt] ," +
                "[Auditor1ID],[Auditor2ID],[SupervisorID],[IsCompleted],[AuditNumber],[IASentNumber],[InsUserID],[InsDt],[UpdUserID],[UpdDt], [RevNo]) VALUES " +
                           "(@Year, @CompanyID, @AuditTypeID, " +
                           "encryptByPassPhrase(@passPhrase, convert(varchar(500), @Title)), " +
                           "@ReportDt, @Auditor1ID, @Auditor2ID, @SupervisorID, @IsCompleted, @AuditNumber, @IASentNumber, @InsUserID, getDate(), @InsUserID, getDate(), 1 ) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@Year", audit.Year);
                cmd.Parameters.AddWithValue("@CompanyID", audit.CompanyId);
                cmd.Parameters.AddWithValue("@AuditTypeID", audit.AuditTypeId);
                cmd.Parameters.AddWithValue("@Title", audit.Title);
                cmd.Parameters.AddWithValue("@ReportDt", audit.ReportDt.Date);
                cmd.Parameters.AddWithValue("@Auditor1ID", audit.Auditor1ID);

                if (audit.Auditor2ID == null)
                {
                    cmd.Parameters.AddWithValue("@Auditor2ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Auditor2ID", audit.Auditor2ID);
                }

                if (audit.SupervisorID == null)
                {
                    cmd.Parameters.AddWithValue("@SupervisorID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SupervisorID", audit.SupervisorID);
                }

                cmd.Parameters.AddWithValue("@IsCompleted",audit.IsCompleted);
                cmd.Parameters.AddWithValue("@AuditNumber", audit.AuditNumber);
                cmd.Parameters.AddWithValue("@IASentNumber", audit.IASentNumber);
                //cmd.Parameters.AddWithValue("@InsUserID", user.Id);
                cmd.Parameters.AddWithValue("@InsUserID", UserInfo.userDetails.Id);

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

        private bool UpdateTable_Audit(Audit audit)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[Audit] SET [Year] = @Year, [CompanyID] = @CompanyID, [AuditTypeID] = @AuditTypeID, " +
                "[Title] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @Title))," + 
                "[ReportDt] = @ReportDt, " +
                "[Auditor1ID] = @Auditor1ID, [Auditor2ID] = @Auditor2ID, [SupervisorID] = @SupervisorID, [IsCompleted] = @IsCompleted, [AuditNumber] = @AuditNumber, " +
                "[IASentNumber] = @IASentNumber, [UpdUserID] = @UpdUserID, [UpdDt] = getDate(), [RevNo] = RevNo+1, [UseUpdTrigger] = 1 " + 
                "WHERE id=@id";
            try
            {
                sqlConn.Open();
                
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@id", audit.Id);
                cmd.Parameters.AddWithValue("@Year", audit.Year);
                cmd.Parameters.AddWithValue("@CompanyID", audit.CompanyId);
                cmd.Parameters.AddWithValue("@AuditTypeID", audit.AuditTypeId);
                cmd.Parameters.AddWithValue("@Title", audit.Title);
                cmd.Parameters.AddWithValue("@ReportDt", audit.ReportDt.Date);
                cmd.Parameters.AddWithValue("@Auditor1ID", audit.Auditor1ID);

                if (audit.Auditor2ID == null)
                {
                    cmd.Parameters.AddWithValue("@Auditor2ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Auditor2ID", audit.Auditor2ID);
                }

                if (audit.SupervisorID == null)
                {
                    cmd.Parameters.AddWithValue("@SupervisorID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SupervisorID", audit.SupervisorID);
                }

                cmd.Parameters.AddWithValue("@IsCompleted", audit.IsCompleted);
                cmd.Parameters.AddWithValue("@AuditNumber", audit.AuditNumber);
                cmd.Parameters.AddWithValue("@IASentNumber", audit.IASentNumber);
                //cmd.Parameters.AddWithValue("@InsUserID", user.Id);
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

        public static T getComboboxItem <T>(ComboBox cb)
        {
            T ret = ((T)((ComboboxItem)cb.SelectedItem).Value);

            return ret;
        }
    }


    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

}
