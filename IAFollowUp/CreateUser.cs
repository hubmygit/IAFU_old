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
            Init();

            oldUserRecord = user;

            isInsert = false;
            txtUserName.Text = user.UserName;
            txtFullName.Text = user.FullName;
            txtEmail.Text = user.Email;
            cbRoles.SelectedIndex = cbRoles.FindStringExact(user.Role.Name);

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
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a User Name!");
                return;
            }
            if (txtFullName.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a Full Name!");
                return;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please insert an Email!");
                return;
            }
            if (cbRoles.Text.Trim() == "")
            {
                MessageBox.Show("Please choose a Role!");
                return;
            }

            newUserRecord = new User();

            newUserRecord.Email = txtEmail.Text;
            newUserRecord.FullName = txtFullName.Text;
            newUserRecord.UserName = txtUserName.Text;
            newUserRecord.Role = InsertNewAudit.getComboboxItem<Role>(cbRoles);
            newUserRecord.RolesId = InsertNewAudit.getComboboxItem<Role>(cbRoles).Id;


            newUserRecord.Id = oldUserRecord.Id; //update only

            if (isInsert) //insert
            {
                if (InsertUser(newUserRecord))
                {
                    MessageBox.Show("New User inserted successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The New User has not been inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //update
            {
                if (UpdateTable_User(newUserRecord))
                {
                    MessageBox.Show("User updated successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The User has not been updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool InsertUser(User user)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Users] ([UserName],[FullName],[Email] ,[RolesId], [InsDt]) VALUES " +
                           "(encryptByPassPhrase(@passPhrase, convert(varchar(500), @UserName)), encryptByPassPhrase(@passPhrase, convert(varchar(500), @FullName))," +
                           " encryptByPassPhrase(@passPhrase, convert(varchar(500), @Email)), @RolesId, getdate() )";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@RolesId", user.RolesId);

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

        private bool UpdateTable_User(User user)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[Users] SET [UserName] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @UserName)), " +
                "[FullName] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @FullName)), [Email] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @Email)) , " +
                "[RolesId] = @RolesId " +
                "WHERE id = @id ";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@RolesId", user.RolesId);


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

    }
}
