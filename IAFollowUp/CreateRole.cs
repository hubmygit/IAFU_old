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
    public partial class CreateRole : Form
    {
        public CreateRole()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a Name!");
                return;
            }
            if (chbIsAuditor.Checked || chbIsAuditee.Checked || chbIsAdmin.Checked)
            {
                MessageBox.Show("Please check at least one Role!");
                return;
            }

            Role newRole = new Role();
            newRole.Name = txtName.Text;
            newRole.IsAdmin = chbIsAdmin.Checked;
           
            newRole.IsAuditee = chbIsAuditee.Checked;
            newRole.IsAuditor = chbIsAuditor.Checked;

            if (chbIsAuditee.Checked || chbIsAuditor.Checked)
            {
                newRole.PasswordPeriod = 90;
            }
            
            if(chbIsAdmin.Checked)
            {
                newRole.PasswordPeriod = 30;
            }


            //InsertRole
        }

        private bool InsertRole(Role newRole)
        {
            return true;
            //
        }
    }
}
