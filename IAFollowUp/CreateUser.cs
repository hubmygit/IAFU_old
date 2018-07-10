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
    public partial class CreateUser : Form
    {
        public CreateUser() //insert
        {
            InitializeComponent();

            Init();

            isInsert = true;
        }

        public CreateUser(User user) //update
        {
            InitializeComponent();

            oldUserRecord = user;

            isInsert = false;

            //txtName.Text = role.Name;
            //chbIsAuditor.Checked = role.IsAuditor;
            //chbIsAuditee.Checked = role.IsAuditee;
            //chbIsAdmin.Checked = role.IsAdmin;
        }
        public void Init()
        {
            cbRoles.Items.AddRange(Role.GetRolesComboboxItemsList(rolesList).ToArray<ComboboxItem>());
        }

        public List<Role> rolesList = ViewRole.SelectRole();

        public bool isInsert = false;
        public bool success = false;
        public User oldUserRecord = new User();
        public User newUserRecord = new User();

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

    }
}
