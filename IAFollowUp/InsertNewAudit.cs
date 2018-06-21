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
    public partial class InsertNewAudit : Form
    {
        public InsertNewAudit()
        {
            InitializeComponent();

            cbCompanies.Items.AddRange(Companies.GetCompaniesComboboxItemsList(companiesList).ToArray<ComboboxItem>());
            cbAuditTypes.Items.AddRange(AuditTypes.GetAuditTypesComboboxItemsList(auditTypesList).ToArray<ComboboxItem>());
            cbAuditor1.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());
            cbAuditor2.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());
            cbSupervisor.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());
        }

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
