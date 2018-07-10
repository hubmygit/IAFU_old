﻿using System;
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


            tsStatusLblUser.Text = "User: " + UserInfo.userDetails.UserName + " - " + UserInfo.userDetails.FullName;
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

        private void findingsAndImprovementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auditor_AuditView frmAuditView = new Auditor_AuditView();
            frmAuditView.Text = "Select Audit";
            frmAuditView.toolStripMessage.Visible = true;
            frmAuditView.chbCompleted.CheckState = CheckState.Unchecked;
            frmAuditView.dgvAuditView.ContextMenuStrip = null;

            frmAuditView.dgvAuditView.CellDoubleClick += new DataGridViewCellEventHandler(frmAuditView.dgvAuditView_CellDoubleClick);

            //message...

            DialogResult dRes = frmAuditView.ShowDialog();

            if (dRes == DialogResult.OK)
            {
                Audit selAudit = frmAuditView.Header_Audit;

                FIShowHeaders frmShowHeaders = new FIShowHeaders(selAudit);
                frmShowHeaders.ShowDialog();
            }
        }

        private void viewFIRevisionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auditor_AuditView frmAuditView = new Auditor_AuditView();
            frmAuditView.Text = "Select Audit";
            frmAuditView.toolStripMessage.Visible = true;
            frmAuditView.chbCompleted.CheckState = CheckState.Unchecked;
            frmAuditView.dgvAuditView.ContextMenuStrip = null;
            frmAuditView.dgvAuditView.CellDoubleClick += new DataGridViewCellEventHandler(frmAuditView.dgvAuditView_CellDoubleClick);

            DialogResult dRes = frmAuditView.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                Audit selAudit = frmAuditView.Header_Audit;
                FIShowHeaders frmShowHeaders_Rev = new FIShowHeaders(selAudit);
                frmShowHeaders_Rev.cmsDetail.Items["MIDetailRevisions"].Visible = true;
                frmShowHeaders_Rev.ShowDialog();
            }
        }

        private void createRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateRole frmNewRole = new CreateRole();
            frmNewRole.ShowDialog();
        }

        private void viewRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewRole frmViewRole = new ViewRole();
            frmViewRole.ShowDialog();
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUser frmCreateUser = new CreateUser();
            frmCreateUser.ShowDialog();
        }

        private void viewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
