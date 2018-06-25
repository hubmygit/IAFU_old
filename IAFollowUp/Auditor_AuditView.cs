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

        //public int dgvIndex = 0;

        private void Auditor_AuditView_Load(object sender, EventArgs e)
        {
            FillDataGridView(dgvAuditView, auditList);


            Companies com1 = new Companies() { Id = 1, Name = "100", NameShort = "1" };
            Companies com2 = new Companies() { Id = 1, Name = "100", NameShort = "1" };
            Companies com3 = new Companies() { Id = 2, Name = "200", NameShort = "2" };

            bool test1 = com1.Equals(com2); //true

            bool test2 = com1.Equals(com3); //false

        }

        public List<Audit> auditList = new List<Audit>();

        public List<Audit> SelectAudit()
        {
            List<Audit> ret = new List<Audit>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Year], [CompanyId], [AuditTypeId], [Title], [ReportDt], " +
                              "[Auditor1Id], [Auditor2Id], [SupervisorId], " +
                              "[IsCompleted], [AuditNumber], [IASentNumber], [RevNo] " +
                              "FROM [dbo].[Audit] " +
                              "ORDER BY Id "; //ToDo
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int? Auditor2_Id, Supervisor_Id;
                    Users Auditor2_User, Supervisor_User;
                    if (reader["Auditor2Id"] == System.DBNull.Value)
                    {
                        Auditor2_Id = null;
                        Auditor2_User = new Users();
                    }
                    else
                    {
                        Auditor2_Id = Convert.ToInt32(reader["Auditor2Id"].ToString());
                        Auditor2_User = new Users(Convert.ToInt32(reader["Auditor2Id"].ToString()));
                    }
                    if (reader["SupervisorId"] == System.DBNull.Value)
                    {
                        Supervisor_Id = null;
                        Supervisor_User = new Users();
                    }
                    else
                    {
                        Supervisor_Id = Convert.ToInt32(reader["SupervisorId"].ToString());
                        Supervisor_User = new Users(Convert.ToInt32(reader["SupervisorId"].ToString()));
                    }

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

                        Auditor2ID = Auditor2_Id, //Convert.ToInt32(reader["Auditor2Id"].ToString()),
                        Auditor2 = Auditor2_User, //new Users(Convert.ToInt32(reader["Auditor2Id"].ToString())),

                        SupervisorID = Supervisor_Id, //Convert.ToInt32(reader["SupervisorId"].ToString()),
                        Supervisor = Supervisor_User, //new Users(Convert.ToInt32(reader["SupervisorId"].ToString())),

                        IsCompleted = Convert.ToBoolean(reader["IsCompleted"].ToString()),
                        AuditNumber = reader["AuditNumber"].ToString(),
                        IASentNumber = reader["IASentNumber"].ToString(),
                        RevNo = Convert.ToInt32(reader["RevNo"].ToString())
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

        public void FillDataGridView(DataGridView dgv, Audit Audit, int dgvIndex)
        {
            //dgv.Rows.Clear();

            List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Id, dgvColumnHeader = "Id" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Year, dgvColumnHeader = "Year" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Company.Name, dgvColumnHeader = "Company" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.AuditType.Name, dgvColumnHeader = "AuditType" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Title, dgvColumnHeader = "Title" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.ReportDt.ToString("dd.MM.yyyy"), dgvColumnHeader = "ReportDt" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Auditor1.FullName, dgvColumnHeader = "Auditor1" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Auditor2.FullName, dgvColumnHeader = "Auditor2" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.Supervisor.FullName, dgvColumnHeader = "Supervisor" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.IsCompleted, dgvColumnHeader = "IsCompleted" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.AuditNumber, dgvColumnHeader = "AuditNumber" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Audit.IASentNumber, dgvColumnHeader = "IASentNumber" });

            string aaaa = Audit.Year.ToString() + "." + Audit.Company.NameShort + "." + Audit.AuditNumber + "." + Audit.AuditType.NameShort + "-" + Audit.IASentNumber;

            object[] obj = new object[dgv.Columns.Count];

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;

                dgv.Rows[dgvIndex].Cells[i].Value = obj[i];
            }
            //dgv.Rows.Add(obj);
            //dgv.Rows[dgvIndex]

            //DataGridViewRow dgvr = new DataGridViewRow();
            //dgv.Rows[dgvIndex].SetValues(obj);

            //dgv.Rows.Insert(dgvIndex, )

            //dgv.ClearSelection();
            //set selected again???
            dgv.Rows[dgvIndex].Selected = true;
        }

        private void MIupdate_Click(object sender, EventArgs e)
        {
            //int Id = Convert.ToInt32(((DataGridView)((ToolStripMenuItem)sender).SourceControl).SelectedRows[0].Cells["Id"].Value.ToString());
            //Audit thisAudit = auditList.Where(i => i.Id == Id).First();

            //int Id = dgvIndex;
            if (dgvAuditView.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvAuditView.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvAuditView.SelectedRows[0].Cells["Id"].Value.ToString());
                Audit thisAudit = auditList.Where(i => i.Id == Id).First();

                InsertNewAudit frmUpdateAudit = new InsertNewAudit(thisAudit);
                frmUpdateAudit.ShowDialog();

                if (frmUpdateAudit.success)
                {
                    //refresh
                    //auditList = SelectAudit();
                    auditList[auditList.FindIndex(w => w.Id == Id)] = frmUpdateAudit.newAuditRecord;

                    //FillDataGridView(dgvAuditView, auditList);
                    //dgvAuditView.SelectedRows[0].Cells[""]
                    FillDataGridView(dgvAuditView, frmUpdateAudit.newAuditRecord, dgvIndex);
                }


            }
        }
        private void MIshowFindings_Click(object sender, EventArgs e)
        {

        }

        private void MIattachments_Click(object sender, EventArgs e)
        {

        }
                
        private void dgvAuditView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvAuditView.HitTest(e.X, e.Y);
                dgvAuditView.Rows[hti.RowIndex].Selected = true;

                if (Convert.ToBoolean(dgvAuditView.SelectedRows[0].Cells["IsCompleted"].Value) == true)
                {
                    MIupdate.Enabled = false;
                }
                else
                {
                    MIupdate.Enabled = true;
                }
            }
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
        public int RevNo { get; set; }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || GetType() != obj.GetType())
        //        return false;

        //    return base.Equals(obj);
        //}

        //public override int GetHashCode()
        //{
        //    return this.GetHashCode();
        //}
    }

    public class Companies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameShort { get; set; }

        public Companies()
        {
        }
        public Companies(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NameShort] " +
                              "FROM [dbo].[Companies] " +
                              "WHERE Id = " + givenId.ToString();
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

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || GetType() != obj.GetType())
        //        return false;

        //    return base.Equals(obj as Companies);
        //}

        //public override int GetHashCode()
        //{
        //    return this.GetHashCode();
        //}

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

        public AuditTypes(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NameShort] " +
                              "FROM [dbo].[AuditTypes] " +
                              "WHERE Id = " + givenId.ToString();
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
        public Users(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], CONVERT(varchar, DECRYPTBYPASSPHRASE( @passPhrase , [FullName])) as FullName " +
                              "FROM [dbo].[Users] " +
                              "WHERE Id = " + givenId.ToString();
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
