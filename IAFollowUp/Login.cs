﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.DirectoryServices.AccountManagement;

namespace IAFollowUp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();


            txtUserName.Text = UserInfo.WindowsUser;
            lblFullName.Text = UserInfo.userDetails.FullName;

            LoggedIn = false;
        }

        public bool LoggedIn;
        public User user = new User();
        public Role role = new Role();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            RunOn_TxtUserName_Leave();

            if (UserInfo.checkPassword(txtUserName.Text, txtPassword.Text))
            {
                UserInfo.roleDetails = UserInfo.get_roleDetails(UserInfo.userDetails.RolesId);

                toolStripMess.Text = "";

                //check expiration date
                if (UserInfo.IsPasswordExpired())
                {
                    MessageBox.Show("Your Password has expired! Please change it.");
                    ChangePassword frmChangePass = new ChangePassword(UserInfo.userDetails);
                    frmChangePass.ShowDialog();

                    if (frmChangePass.successfullyChangedPassword == false)
                    {
                        return;
                    }

                }

                LoggedIn = true;
                user = UserInfo.userDetails;
                role = UserInfo.roleDetails;

                Close();

            }
            else
            {
                toolStripMess.ForeColor = Color.Red;
                toolStripMess.Text = "Not authorized user!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        private void txtUserName_Leave(object sender, EventArgs e)
        {
            //UserInfo.userDetails = UserInfo.get_userDetails(txtUserName.Text);

            //if (UserInfo.userDetails.FullName == "")
            //{
            //    lblFullName.Text = "";
            //    toolStripMess.ForeColor = Color.Red;
            //    toolStripMess.Text = "Not authorized user!";

            //    UserInfo.IsAuthorized = false;
            //}
            //else
            //{
            //    lblFullName.Text = UserInfo.userDetails.FullName;
            //    toolStripMess.Text = "";

            //    UserInfo.IsAuthorized = true;
            //}
            RunOn_TxtUserName_Leave();
        }

        private void RunOn_TxtUserName_Leave()
        {
           UserInfo.userDetails = UserInfo.get_userDetails(txtUserName.Text);

            if (UserInfo.userDetails.FullName is null || UserInfo.userDetails.FullName == "")
            {
                lblFullName.Text = "";
                toolStripMess.ForeColor = Color.Red;
                toolStripMess.Text = "Not authorized user!";

                UserInfo.IsAuthorized = false;
            }
            else
            {
                lblFullName.Text = UserInfo.userDetails.FullName;
                toolStripMess.Text = "";

                UserInfo.IsAuthorized = true;
            }
        }
    }

    public static class UserInfo
    {
        static UserInfo()
        {
            userDetails = new User();
            roleDetails = new Role();

            WindowsUser = "unknown";
            EmailAddress = "";
            userDetails.FullName = "";
            IsAuthorized = false;

            LastThreePasswords = new List<PasswordHistory>();

            //DB_AppUser_Id = 0;


            try
            {
                WindowsUser = Environment.UserName;

                //EmailAddress = UserPrincipal.Current.EmailAddress;
                if (EmailAddress == null) //if domain infos not found
                {
                    EmailAddress = "";
                }

                //userDetails.FullName = UserPrincipal.Current.DisplayName;
                if (userDetails.FullName == null) //if domain infos not found
                {
                    userDetails.FullName = "";
                }

                //DB_AppUser_Id = Get_DB_AppUser_Id(Environment.UserName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }
        //public static string FullName { get; set; }
        public static string EmailAddress { get; set; } //only for init
        public static string WindowsUser { get; set; } //only for init
        public static bool IsAuthorized { get; set; }
        public static User userDetails { get; set; }
        public static Role roleDetails { get; set; }

        public static List<PasswordHistory> LastThreePasswords { get; set; }

        public static DateTime passUpdDate { get; set; }

        public static User get_userDetails(string GivenUserName)
        {
            User ret = new User();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            //string SelectSt = "SELECT [Id], [UserName], [RolesId], [FullName], [Email] FROM [dbo].[Users] WHERE UserName = '" + GivenUserName + "'";
            
            string SelectSt = "SELECT [Id], " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , [UserName])) as UserName, " + 
                              "[RolesId], " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase ,  [FullName])) as FullName, " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase ,  [Email])) as Email " + 
                              "FROM [dbo].[Users] WHERE " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase ,  [UserName])) = '" + GivenUserName + "'";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Id = Convert.ToInt32(reader["Id"].ToString());
                    ret.UserName = reader["UserName"].ToString();
                    ret.RolesId = Convert.ToInt32(reader["RolesId"].ToString());
                    ret.FullName = reader["FullName"].ToString();
                    ret.Email = reader["Email"].ToString();
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static Role get_roleDetails(int RolesId)
        {
            Role ret = new Role();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [IsAuditor], [IsAuditee], [IsAdmin], [PasswordPeriod] FROM [dbo].[Roles] WHERE Id = " + RolesId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Id = Convert.ToInt32(reader["Id"].ToString());
                    ret.Name = reader["Name"].ToString();
                    ret.IsAuditor = Convert.ToBoolean(reader["IsAuditor"].ToString());
                    ret.IsAuditee = Convert.ToBoolean(reader["IsAuditee"].ToString());
                    ret.IsAdmin = Convert.ToBoolean(reader["IsAdmin"].ToString());
                    ret.PasswordPeriod = Convert.ToInt32(reader["PasswordPeriod"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static bool checkPassword(string GivenUserName, string GivenPassword)
        {
            bool ret = false;

            //bool found = false;
            //string pass = "";

            bool Equals = false;

            //string hashGivenPass = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT P.PassUpdDate, " +
                              //P.Password, P.PassUpdDate, " +
                              //"HASHBYTES('SHA2_512', @GivenPassword + @passPhrase) as HashGivenPass, " +
                              "case when HASHBYTES('SHA2_512',  @GivenPassword + @passPhrase) = P.Password then 'True' else 'False' end as Equality " +
                              "FROM [dbo].[PasswordHistory] P left outer join " + 
                              "[dbo].[Users] U on P.UsersId = U.Id " + 
                              "WHERE P.IsCurrent = 'true' and " +
                              //"U.UserName = '" + GivenUserName + "'";
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE(@passPhrase,  U.UserName)) = '" + GivenUserName + "'";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.Add("@GivenPassword", SqlDbType.VarChar);
                cmd.Parameters["@GivenPassword"].Value = GivenPassword;

                cmd.Parameters.Add("@passPhrase", SqlDbType.VarChar);
                cmd.Parameters["@passPhrase"].Value = SqlDBInfo.passPhrase;


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //pass = reader["Password"].ToString();
                    passUpdDate = Convert.ToDateTime(reader["PassUpdDate"].ToString());
                    //hashGivenPass = reader["HashGivenPass"].ToString();
                    //found = true;

                    Equals = Convert.ToBoolean(reader["Equality"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            //if (pass.Trim() != "" && pass == hashGivenPass)
            if(Equals)
            {
                ret = true;
            }

            //if (pass.Trim() != "")
            //{
            //}
            //if (found == false)
            //{
            //    //UPDATE [dbo].[PasswordHistory] SET IsCurrent = 'true' WHERE  usersId = 3
            //    //SELECT top (1) Id, Password, PassUpdDate FROM [dbo].[PasswordHistory] where usersId = 3 order by passupddate desc
            //}

            //if (pass == GivenPassword)
            //{
            //    ret = true;
            //}

            return ret;
        }



        public static bool IsPasswordExpired() //(DateTime PassUpdDate, int PasswordPeriod)
        {
            bool ret = false;

            DateTime expirationDate = passUpdDate.AddDays(roleDetails.PasswordPeriod);

            if (expirationDate < DateTime.Now)
            {
                ret = true;
            }

            return ret;
        }        

        public static List<PasswordHistory> get_passwordHistoryLastThreeDetails(int userId)
        {
            List<PasswordHistory> ret = new List<PasswordHistory>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT TOP (3) [Id], [UsersId], [Password], [PassUpdDate], [IsCurrent] FROM [dbo].[PasswordHistory] WHERE UsersId = " + userId.ToString() + " ORDER BY PassUpdDate DESC";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new PasswordHistory()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        UsersId = Convert.ToInt32(reader["UsersId"].ToString()),
                        //Password = reader["Password"].ToString(),
                        Pass = (byte[])reader["Password"],
                        PassUpdDate = Convert.ToDateTime(reader["PassUpdDate"].ToString()),
                        IsCurrent = Convert.ToBoolean(reader["IsCurrent"].ToString())
                    });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

    }
    

    public static class SqlDBInfo
    {
        static SqlDBInfo()
        {
            //default values
            string server = "DELIGEEL\\SQLEXPRESS";
            string database = "IAFU";
            string username = "sa";
            string password = "motoroil";
            connectionString = "Persist Security Info=False; User ID=" + username + "; Password=" + password + "; Initial Catalog=" + database + "; Server=" + server;
        }

        public static string connectionString { get; set; }
        public static string passPhrase = "Use this passPhrase to decrypt!";
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAuditor { get; set; }
        public bool IsAuditee { get; set; }
        public bool IsAdmin { get; set; }
        public int PasswordPeriod { get; set; }
        public DateTime InsDt { get; set; }

        public Role ()
        { }

        public Role(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [IsAuditor], [IsAuditee], [IsAdmin], [PasswordPeriod], [InsDt] " +
                              "FROM [dbo].[Roles] " +
                              "WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Name = reader["Name"].ToString();
                    IsAuditor = Convert.ToBoolean(reader["IsAuditor"].ToString());
                    IsAuditee = Convert.ToBoolean(reader["IsAuditee"].ToString());
                    IsAdmin = Convert.ToBoolean(reader["IsAdmin"].ToString());
                    PasswordPeriod = Convert.ToInt32(reader["PasswordPeriod"].ToString());
                    InsDt = Convert.ToDateTime(reader["InsDt"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

        }

        public static bool isEqual(Role x, Role y)
        {
            if (x.Id == y.Id && x.Name == y.Name && x.IsAuditor == y.IsAuditor && x.IsAuditee == y.IsAuditee && x.IsAdmin == y.IsAdmin && x.PasswordPeriod == y.PasswordPeriod)
                return true;
            else
                return false;
        }

        public static List<ComboboxItem> GetRolesComboboxItemsList(List<Role> Roles)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Role c in Roles)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.Name });
            }

            return ret;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
        public int RolesId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime InsDt { get; set; }
    }

    public class PasswordHistory
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        //public string Password { get; set; }
        public byte[] Pass { get; set; }
        public DateTime PassUpdDate { get; set; }
        public bool IsCurrent { get; set; }
    }

}
