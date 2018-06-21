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
        public InsertNewAudit()
        {
            InitializeComponent();
        }
        public InsertNewAudit(User LogInUser)
        {
            InitializeComponent();
            user = LogInUser;
            cbCompanies.Items.AddRange(Companies.GetCompaniesComboboxItemsList(companiesList).ToArray<ComboboxItem>());
            cbAuditTypes.Items.AddRange(AuditTypes.GetAuditTypesComboboxItemsList(auditTypesList).ToArray<ComboboxItem>());
            cbAuditor1.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());
            cbAuditor2.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());
            cbSupervisor.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());

        }
        public User user = new User();

        public List<Companies> companiesList = Companies.GetSqlCompaniesList();

        public List<AuditTypes> auditTypesList = AuditTypes.GetSqlAuditTypesList();

        public List<Users> usersList = Users.GetSqlUsersList();

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

            Audit newAuditRecord = new Audit()
            {
                AuditNumber = txtAuditNumber.Text,
                Auditor1ID = getComboboxItem<Users>(cbAuditor1).Id,
                CompanyId = getComboboxItem<Companies>(cbCompanies).Id,
                AuditTypeId = getComboboxItem<AuditTypes>(cbAuditTypes).Id,
                IASentNumber = txtIASentNumber.Text,
                Title = txtTitle.Text,
                Year = dtpYear.Value.Year,
                ReportDt = dtpReportDate.Value.Date,
                IsCompleted = false,
            };

            if(cbAuditor2.SelectedIndex > -1)
            {
                newAuditRecord.Auditor2ID = getComboboxItem<Users>(cbAuditor2).Id;
            }
            if (cbSupervisor.SelectedIndex > -1)
            {
                newAuditRecord.SupervisorID = getComboboxItem<Users>(cbSupervisor).Id;
            }


            if (InsertIntoTable_Audit(newAuditRecord))
            {
                MessageBox.Show("New Audit inserted successfully!");
                Close();
            }
            else
            {
                MessageBox.Show("The New Audit has not been inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private bool InsertIntoTable_Audit (Audit audit) //INSERT [dbo].[Audit]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Audit] ([Year],[CompanyID],[AuditTypeID],[Title],[ReportDt] ," +
                "[Auditor1ID],[Auditor2ID],[SupervisorID],[IsCompleted],[AuditNumber],[IASentNumber],[InsUserID],[InsDt]) VALUES " +
                           "(@Year, @CompanyID, @AuditTypeID, @Title, @ReportDt, @Auditor1ID, @Auditor2ID, @SupervisorID, @IsCompleted, @AuditNumber, @IASentNumber, @InsUserID, getDate() ) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
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
                cmd.Parameters.AddWithValue("@InsUserID", user.Id);

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
