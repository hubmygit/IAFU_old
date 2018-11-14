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
            if (UserAction.IsLegal(Action.Audit_View))
            {
                Auditor_AuditView frmAuditorAuditView = new Auditor_AuditView();
                frmAuditorAuditView.auditList = frmAuditorAuditView.auditList.Where(i => i.IsDeleted == false).ToList();
                frmAuditorAuditView.ShowDialog();
            }
        }

        private void insertNewAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserAction.IsLegal(Action.Audit_Create))
            {
                InsertNewAudit frmInsertNewAudit = new InsertNewAudit();
                frmInsertNewAudit.ShowDialog();
            }
        }

        private void viewRevisionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auditor_AuditView frmAuditorAuditView_Rev = new Auditor_AuditView();

            frmAuditorAuditView_Rev.cmsOnGrid.Items["MIRevisions"].Visible = true;
            frmAuditorAuditView_Rev.dgvAuditView.Columns["IsDeleted"].Visible = true;

            frmAuditorAuditView_Rev.ShowDialog();
        }

        private void findingsAndImprovementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auditor_AuditView frmAuditView = new Auditor_AuditView();
            frmAuditView.Text = "Select Audit";

            frmAuditView.auditList = frmAuditView.auditList.Where(i => i.IsDeleted == false).ToList();

            frmAuditView.toolStripMessage.Visible = true;
            //frmAuditView.chbCompleted.CheckState = CheckState.Unchecked;
            frmAuditView.dgvAuditView.ContextMenuStrip = null;

            frmAuditView.dgvAuditView.CellDoubleClick += new DataGridViewCellEventHandler(frmAuditView.dgvAuditView_CellDoubleClick);

            //message...

            DialogResult dRes = frmAuditView.ShowDialog();

            if (dRes == DialogResult.OK)
            {
                Audit selAudit = frmAuditView.Header_Audit;

                //Audit->Headers->Details
                //if (!UserAction.IsLegal(Action.Header_View, selAudit.Auditor1ID, selAudit.Auditor2ID, selAudit.SupervisorID, ))
                //{
                //    return;
                //}                

                FIShowHeaders frmShowHeaders = new FIShowHeaders(selAudit);

                //frmShowHeaders.AdminAccess = false;

                frmShowHeaders.ShowDialog();
            }
        }

        private void viewFIRevisionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auditor_AuditView frmAuditView = new Auditor_AuditView();
            frmAuditView.Text = "Select Audit";
            frmAuditView.toolStripMessage.Visible = true;
            frmAuditView.dgvAuditView.Columns["IsDeleted"].Visible = true;
            frmAuditView.chbCompleted.CheckState = CheckState.Unchecked;
            frmAuditView.dgvAuditView.ContextMenuStrip = null;
            frmAuditView.dgvAuditView.CellDoubleClick += new DataGridViewCellEventHandler(frmAuditView.dgvAuditView_CellDoubleClick);

            DialogResult dRes = frmAuditView.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                Audit selAudit = frmAuditView.Header_Audit;
                FIShowHeaders frmShowHeaders_Rev = new FIShowHeaders(selAudit);
                frmShowHeaders_Rev.cmsDetail.Items["MIDetailRevisions"].Visible = true;

                frmShowHeaders_Rev.AdminAccess = true;

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
            ViewUser frmViewUser = new ViewUser();
            frmViewUser.ShowDialog();
        }

    }

    public enum Action
    {
        None,
        Audit_Create,        
        Audit_View,
        Audit_Edit,
        Audit_Delete,
        Audit_Attach,
        Audit_Finalize,

        Header_Create,
        Header_View,
        Header_Edit,
        Header_Delete,
        Detail_Create,
        Detail_View,
        Detail_Edit,
        Detail_Delete
    }

    public class UserAction
    {
        public static bool IsLegal(Action action, int? auditor1 = null, int? auditor2 = null, int? supervisor = null, bool? isPublished = null)
        {
            bool ret = false;
            bool showMessage = true;

            switch (action)
            {
                case Action.Audit_Create:
                    {
                        //Any auditor can create audit
                        ret = true;
                        break;
                    }
                case Action.Audit_View:
                    {
                        //Any auditor can view audits
                        ret = true;
                        break;
                    }
                case Action.Audit_Edit:
                    {
                        //Only Auditor1, 2, Supervisor can edit this audit
                        if (UserInfo.userDetails.Id == auditor1 || UserInfo.userDetails.Id == auditor2 || UserInfo.userDetails.Id == supervisor) // || UserInfo.roleDetails.IsAdmin
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }                        
                        break;
                    }
                case Action.Audit_Delete:
                    {
                        //Only Auditor1, 2, Supervisor can delete this audit
                        if (UserInfo.userDetails.Id == auditor1 || UserInfo.userDetails.Id == auditor2 || UserInfo.userDetails.Id == supervisor) // || UserInfo.roleDetails.IsAdmin
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    }
                case Action.Audit_Attach:
                    {
                        //Only Auditor1, 2, Supervisor can attach Audit Report
                        if (UserInfo.userDetails.Id == auditor1 || UserInfo.userDetails.Id == auditor2 || UserInfo.userDetails.Id == supervisor) // || UserInfo.roleDetails.IsAdmin
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                            showMessage = false;
                        }
                        break;
                    }
                case Action.Audit_Finalize:
                    {
                        //Only Auditor1, 2, Supervisor can finalize this audit
                        if (UserInfo.userDetails.Id == auditor1 || UserInfo.userDetails.Id == auditor2 || UserInfo.userDetails.Id == supervisor) // || UserInfo.roleDetails.IsAdmin
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    }

                case Action.Header_Create:
                    {
                        //Only Auditor1, 2, Supervisor can create new header referring to this audit
                        if (UserInfo.userDetails.Id == auditor1 || UserInfo.userDetails.Id == auditor2 || UserInfo.userDetails.Id == supervisor) // || UserInfo.roleDetails.IsAdmin
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    }
                case Action.Header_View:
                    {
                        //Only Auditor1, 2, Supervisor - unpublished && All - published, can view new header referring to this audit
                        if (UserInfo.userDetails.Id == auditor1 || UserInfo.userDetails.Id == auditor2 || UserInfo.userDetails.Id == supervisor || isPublished == true) // || UserInfo.roleDetails.IsAdmin
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    }

                //case Action.Audit_Create:
                //    {
                //        break;
                //    }
                default:
                    {
                        //...
                        ret = false;
                        break;
                    }
            }

            if (ret == false && showMessage == true)
            {
                MessageBox.Show("You are not authorized to perform this action!");
            }

            return ret;
        }
    }

    public static class AppVer
    {

        public static bool IsLatestVersion() //Compare app version with db version (2 digits only)
        {
            bool ret = true;
            string CurrentVersion = getCurrentAppVersion();
            string LatestVersion = getLatestAppVersionFromDB();

            string[] CurVer2Dig = CurrentVersion.Split('.');
            string[] LatVer2Dig = LatestVersion.Split('.');

            //if (CurrentVersion < LatestVersion)
            if ((CurVer2Dig[0] + "." + CurVer2Dig[1]) != (LatVer2Dig[0] + "." + LatVer2Dig[1]))
            {
                ret = false;
                MessageBox.Show("Your application version is older than the current version! \r\nIt is necessary to upgrade to continue.");
            }
            else if (CurrentVersion != LatestVersion)
            {
                MessageBox.Show("Your application version is older than the current version! \r\nPlease upgrade as soon as possible.");
            }

            return ret;
        }

        //public static int getCurrentAppVersion()
        public static string getCurrentAppVersion()
        {
            //this is 'File Version' - for 'Assembly Version' use System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() 
            //int ret = 0;
            //string appVer = Application.ProductVersion.Replace(".", "");
            //bool succeeded = Int32.TryParse(appVer, out ret);

            string ret = Application.ProductVersion;

            return ret;
        }

        //public static int getLatestAppVersionFromDB()
        public static string getLatestAppVersionFromDB()
        {
            //int ret = 0;
            string ret = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT AppVersion FROM [dbo].[AppVersion] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //ret = Convert.ToInt32(reader["Num"].ToString());
                    ret = reader["AppVersion"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
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
