using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        public FIHeaderEdit(Audit audit, FIHeader fiHeader) //Update 
        {
            InitializeComponent();

            ArrangeAuditFields(audit);

            Init();
        }

        public void Init()
        {
            cbCategory.Items.AddRange(FICategory.GetFICategoryComboboxItemsList(categoriesList).ToArray<ComboboxItem>());
        }

        public List<FICategory> categoriesList = FICategory.GetSqlFICategoriesList();

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
        }
    }
}
