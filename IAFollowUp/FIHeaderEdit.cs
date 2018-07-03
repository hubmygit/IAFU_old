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
    public partial class FIHeaderEdit : Form
    {
        public FIHeaderEdit() 
        {
            InitializeComponent();
        }

        public FIHeaderEdit(Audit audit) //Insert 
        {
            InitializeComponent();

            ArrangeAuditFields(audit);

            Init();

            isInsert = true;

            currentAudit = audit;
        }

        public FIHeaderEdit(Audit audit, FIHeader fiHeader) //Update 
        {
            InitializeComponent();

            ArrangeAuditFields(audit);

            Init();

            isInsert = false;

            currentAudit = audit;
        }

        public void Init()
        {
            cbCategory.Items.AddRange(FICategory.GetFICategoryComboboxItemsList(categoriesList).ToArray<ComboboxItem>());
        }

        public bool isInsert = false;
        public bool success = false;
        public List<FICategory> categoriesList = FICategory.GetSqlFICategoriesList();
        public FIHeader newFIHeaderRecord = new FIHeader();

        public Audit currentAudit = new Audit();

        private void ArrangeAuditFields(Audit selectedAudit)
        {
            txtAuditTitle.Text = selectedAudit.Title;
            txtYear.Text = selectedAudit.Year.ToString();
            txtReportDate.Text = selectedAudit.ReportDt.ToString("dd.MM.yyyy");
            txtCompany.Text = selectedAudit.Company.Name;
            txtAuditNumber.Text = selectedAudit.AuditNumber;
            txtAuditor1.Text = selectedAudit.Auditor1.FullName;
            txtAuditor2.Text = selectedAudit.Auditor2.FullName;
            txtSupervisor.Text = selectedAudit.Supervisor.FullName;
            txtAuditType.Text = selectedAudit.AuditType.Name;
            txtIASentNumber.Text = selectedAudit.IASentNumber;

        }

        private bool InsertIntoTable_FIHeader(FIHeader fiHeader) //INSERT [dbo].[FIHeader]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FIHeader] ([AuditId],[Title],[FICategoryId] ,[InsUserId], [InsDt]) VALUES " +
                           "(@AuditId,encryptByPassPhrase(@passPhrase, convert(varchar, @Title)), " +
                           "@FICategoryId, @InsUserId, getDate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@AuditId", fiHeader.AuditId);
                cmd.Parameters.AddWithValue("@Title", fiHeader.Title);
                cmd.Parameters.AddWithValue("@FICategoryId", fiHeader.FICategoryId);
                cmd.Parameters.AddWithValue("@InsUserId", UserInfo.userDetails.Id);

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
            if (txtHeaderTitle.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a Title!");
                return;
            }
            
            if (cbCategory.Text.Trim() == "")
            {
                MessageBox.Show("Please choose a Category!");
                return;
            }

            newFIHeaderRecord = new FIHeader()
            {
                Title = txtHeaderTitle.Text,
                FICategory = InsertNewAudit.getComboboxItem<FICategory>(cbCategory),
                FICategoryId = InsertNewAudit.getComboboxItem<FICategory>(cbCategory).Id, 
                AuditId = currentAudit.Id
            };

            if (isInsert) //insert
            {
                if (InsertIntoTable_FIHeader(newFIHeaderRecord))
                {
                    MessageBox.Show("New F/I Header inserted successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The New F/I Header has not been inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //update
            {
            }


        }
    }
}
