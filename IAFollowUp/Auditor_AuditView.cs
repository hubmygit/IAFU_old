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
    public partial class Auditor_AuditView : Form
    {
        public Auditor_AuditView()
        {
            InitializeComponent();

            //string hex = "2AB26A9EBDBA39AAE9D1A5C1EA8203228CDC7E4DA8C4A1A85DE3ABC1B64DEEAA03BD9566FE4771D1E36BE15CB14027B19F93A49788B734BB89C08DEDC5CC2264";
            //byte[] test = Enumerable.Range(0, hex.Length)
            //         .Where(x => x % 2 == 0)
            //         .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
            //         .ToArray();

            //byte[] data = System.Text.Encoding.ASCII.GetBytes("QWERTY12345!");
            //data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            //String hash = System.Text.Encoding.ASCII.GetString(data);

            auditList = SelectAudit();
        }

        private void Auditor_AuditView_Load(object sender, EventArgs e)
        {
            FillDataGridView(dgvAuditView, auditList);
        }

        public List<Audit> auditList = new List<Audit>();

        public List<Audit> SelectAudit()
        {
            List<Audit> ret = new List<Audit>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Year], [CompanyId], [AuditTypeId], [Title], [ReportDt], " + 
                              "[Auditor1Id], isnull([Auditor2Id], 0) as Auditor2Id, isnull([SupervisorId], 0) as SupervisorId, " +
                              "[IsCompleted], [AuditNumber], [IASentNumber] " + 
                              "FROM [dbo].[Audit] " +
                              "ORDER BY Id "; //ToDo
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Audit()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Year = Convert.ToInt32(reader["Year"].ToString()),
                        CompanyId = Convert.ToInt32(reader["CompanyId"].ToString()),
                        Company = new Companies(Convert.ToInt32(reader["CompanyId"].ToString())),
                        AuditTypeId = Convert.ToInt32(reader["AuditTypeId"].ToString()),
                        AuditType = new AuditTypes(Convert.ToInt32(reader["AuditTypeId"].ToString())),
                        Title = reader["Title"].ToString(),
                        ReportDt = Convert.ToDateTime(reader["ReportDt"].ToString()),
                        Auditor1ID = Convert.ToInt32(reader["Auditor1Id"].ToString()),
                        Auditor1 = new Users(Convert.ToInt32(reader["Auditor1Id"].ToString())),
                        Auditor2ID = Convert.ToInt32(reader["Auditor2Id"].ToString()),
                        Auditor2 = new Users(Convert.ToInt32(reader["Auditor2Id"].ToString())),
                        SupervisorID = Convert.ToInt32(reader["SupervisorId"].ToString()),
                        Supervisor = new Users(Convert.ToInt32(reader["SupervisorId"].ToString())),
                        IsCompleted = Convert.ToBoolean(reader["IsCompleted"].ToString()),
                        AuditNumber = reader["AuditNumber"].ToString(),
                        IASentNumber = reader["IASentNumber"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public void FillDataGridView(DataGridView dgv, List<Audit> AuditList)
        {
            dgv.Rows.Clear();
                        
            foreach (Audit thisRecord in AuditList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Year, dgvColumnHeader = "Year" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Company.Name, dgvColumnHeader = "Company" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AuditType.Name, dgvColumnHeader = "AuditType" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Title, dgvColumnHeader = "Title" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ReportDt.ToString("dd.MM.yyyy"), dgvColumnHeader = "ReportDt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Auditor1.FullName, dgvColumnHeader = "Auditor1" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Auditor2.FullName, dgvColumnHeader = "Auditor2" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Supervisor.FullName, dgvColumnHeader = "Supervisor" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IsCompleted, dgvColumnHeader = "IsCompleted" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AuditNumber, dgvColumnHeader = "AuditNumber" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IASentNumber, dgvColumnHeader = "IASentNumber" });

                string aaaa = thisRecord.Year.ToString() + "." + thisRecord.Company.NameShort + "." + thisRecord.AuditNumber + "." + thisRecord.AuditType.NameShort + "-" + thisRecord.IASentNumber;

                object[] obj = new object[dgv.Columns.Count];
                
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
                }

                dgv.Rows.Add(obj);
            }

            //    dgv.Rows.Add(new object[]
            //    {
            //        thisRecord.Id,
            //        thisRecord.Year,
            //        thisRecord.Company.Name,
            //        thisRecord.AuditType.Name,
            //        thisRecord.Title,
            //        thisRecord.ReportDt.ToString("dd.MM.yyyy"),
            //        thisRecord.Auditor1.UserName,
            //        thisRecord.Auditor2.UserName,
            //        thisRecord.Supervisor.UserName,
            //        thisRecord.IsCompleted,
            //        thisRecord.AuditNumber,
            //        thisRecord.IASentNumber
            //    });

            dgv.ClearSelection();

        }

        
    }

    public class Audit
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int CompanyId { get; set; }
        public Companies Company { get; set; }
        public int AuditTypeId { get; set; }
        public AuditTypes AuditType { get; set; }
        public string Title { get; set; }
        public DateTime ReportDt { get; set; }
        public int Auditor1ID { get; set; }
        public Users Auditor1 { get; set; }
        public int? Auditor2ID { get; set; }
        public Users Auditor2 { get; set; }
        public int? SupervisorID { get; set; }
        public Users Supervisor { get; set; }
        public bool IsCompleted { get; set; }
        public string AuditNumber { get; set; }
        public string IASentNumber { get; set; }
    }

    public class Companies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameShort { get; set; }

        public Companies()
        {
        }
        public Companies(int Id)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NameShort] " +
                              "FROM [dbo].[Companies] " +
                              "WHERE Id = " + Id.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    Name = reader["Name"].ToString();
                    NameShort = reader["NameShort"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public static List<Companies> GetSqlCompaniesList()
        {
            List<Companies> ret = new List<Companies>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NameShort] " +
                              "FROM [dbo].[Companies] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Companies() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString(), NameShort = reader["NameShort"].ToString()});
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


        public static List<ComboboxItem> GetCompaniesComboboxItemsList(List<Companies> Companies)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Companies c in Companies)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.Name });
            }

            return ret;
        }


    }


    public class AuditTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameShort { get; set; }

        public AuditTypes()
        {
        }

        public AuditTypes(int Id)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NameShort] " +
                              "FROM [dbo].[AuditTypes] " +
                              "WHERE Id = " + Id.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    Name = reader["Name"].ToString();
                    NameShort = reader["NameShort"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }
        public static List<AuditTypes> GetSqlAuditTypesList()
        {
            List<AuditTypes> ret = new List<AuditTypes>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NameShort] " +
                              "FROM [dbo].[AuditTypes] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new AuditTypes() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString(), NameShort = reader["NameShort"].ToString() });
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

        public static List<ComboboxItem> GetAuditTypesComboboxItemsList(List<AuditTypes> AuditTypes)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (AuditTypes c in AuditTypes)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.Name });
            }

            return ret;
        }

    }

    public class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public Users()
        {
        }
        public Users(int Id)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], CONVERT(varchar, DECRYPTBYPASSPHRASE( @passPhrase , [FullName])) as FullName " +
                              "FROM [dbo].[Users] " +
                              "WHERE Id = " + Id.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    FullName = reader["FullName"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }
        public static List<Users> GetSqlUsersList()
        {
            List<Users> ret = new List<Users>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], CONVERT(varchar, DECRYPTBYPASSPHRASE( @passPhrase , [FullName])) as FullName " +
                              "FROM [dbo].[Users] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Users() { Id = Convert.ToInt32(reader["Id"].ToString()), FullName = reader["FullName"].ToString()});
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

        public static List<ComboboxItem> GetUsersComboboxItemsList(List<Users> Users)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Users c in Users)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.FullName });
            }

            return ret;
        }
    }

    public class dgvDictionary
    {
        public object dbfield { get; set; }
        public string dgvColumnHeader { get; set; }
    }


}
