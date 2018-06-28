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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();  
        }

        public MainMenu(User LogInUser, Role LogInRole)
        {
            InitializeComponent();

            user = LogInUser;
            role = LogInRole;
            
            UserAuth.ArrangeMenuItems(role, menuStrip);

        }

        public User user = new User();
        public Role role = new Role();
        UserAuthorization UserAuth = new UserAuthorization();

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword frmChangePass = new ChangePassword(user);
            frmChangePass.ShowDialog();

            if (frmChangePass.successfullyChangedPassword == false)
            {
                return;
            }
        }

        private void auditViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auditor_AuditView frmAuditorAuditView = new Auditor_AuditView();
            frmAuditorAuditView.ShowDialog();

        }

        private void insertNewAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertNewAudit frmInsertNewAudit = new InsertNewAudit();
            frmInsertNewAudit.ShowDialog();
        }

        private void viewRevisionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Auditor_AuditView frmAuditorAuditView_Rev = new Auditor_AuditView();

            frmAuditorAuditView_Rev.cmsOnGrid.Items["MIRevisions"].Visible = true;

            frmAuditorAuditView_Rev.ShowDialog();

        }
    }

    public class UserAuthorization
    {

        public void ArrangeMenuItems(Role role, MenuStrip menuStrip)
        {
            if (role.IsAuditor) //Tag: 1
            {
                foreach (ToolStripItem tsi in menuStrip.Items)
                {
                    if (tsi.Tag != null && tsi.Tag.ToString() == "1")
                    {
                        tsi.Visible = true;
                    }

                    //foreach (ToolStripDropDownItem tsdi in ((ToolStripDropDownItem)tsi).DropDownItems)
                    //{
                    //    if(tsdi.Tag.ToString() == "1")
                    //    {
                    //        tsdi.Visible = true;
                    //    }
                    //}
                }             
            }

            if (role.IsAuditee) //Tag: 2
            {
                foreach (ToolStripItem tsi in menuStrip.Items)
                {
                    if (tsi.Tag != null && tsi.Tag.ToString() == "2")
                    {
                        tsi.Visible = true;
                    }
                }
            }

            if (role.IsAdmin) //Tag: 3
            {
                foreach (ToolStripItem tsi in menuStrip.Items)
                {
                    if (tsi.Tag != null && tsi.Tag.ToString() == "3")
                    {
                        tsi.Visible = true;
                    }
                }
            }

        }

    }


}
