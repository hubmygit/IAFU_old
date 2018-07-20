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
    public partial class FIDetail_Revisions : Form
    {
        public FIDetail_Revisions()
        {
            InitializeComponent();
        }

        public FIDetail_Revisions(Audit givenAudit, FIHeader givenHeader, int detailId)
        {
            InitializeComponent();

            glAudit = givenAudit;
            glHeader = givenHeader;

            DetailRevList = SelectDetailsRev(detailId);
        }

        public Audit glAudit = new Audit();
        public FIHeader glHeader = new FIHeader();
        public List<FIDetailRev> DetailRevList = new List<FIDetailRev>();

        private void FIDetail_Revisions_Load(object sender, EventArgs e)
        {
            Auditor_AuditView.FillDataGridView(dgvAudits, glAudit);
            FIShowHeaders.FillHeadersDataGridView(dgvHeader, glHeader);

            FillDetailsDataGridViewRev(dgvDetails, DetailRevList);

            toolStripCounter.Text = "Records: " + DetailRevList.Count.ToString();
        }

        private void dgvDetails_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvDetails.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }
                dgvDetails.Rows[hti.RowIndex].Selected = true;

                //if (glAudit.IsCompleted == true)
                //{

                //    MIeditDetail.Enabled = false;
                //}
                //else
                //{
                //    MIeditDetail.Enabled = true;
                //}

            }
        }

        public List<FIDetailRev> SelectDetailsRev(int Id)
        {
            List<FIDetailRev> ret = new List<FIDetailRev>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT 0 as [Id], [Id] as [FIDetailId], " +
                "CONVERT(varchar(500), DECRYPTBYPASSPHRASE(@passPhrase, [Description])) as [Description], " +
                "[FIHeaderId], [InsUserId], [InsDt], [UpdUserId], [UpdDt], [ActionDt], " +
                "CONVERT(varchar(500), DECRYPTBYPASSPHRASE(@passPhrase , [ActionReq])) as [ActionReq], [ActionCode], [RevNo], " +
                "(SELECT count(*) FROM [dbo].[FIDetail_Attachments] T WHERE d.id = T.FIDetailID and d.RevNo = T.RevNo) as AttCnt, " +
                "(SELECT count(*) FROM [dbo].[FIDetail_Owners] T WHERE d.id = T.FIDetailID and d.RevNo = T.RevNo) as OwnersCnt, " +
                "isnull([IsDeleted], 'FALSE') as IsDeleted " + 
                "FROM [dbo].[FIDetail] d WHERE Id = " + Id.ToString() + 

                " UNION ALL " +

                "SELECT [Id], [FIDetailId], " +
                "CONVERT(varchar(500), DECRYPTBYPASSPHRASE(@passPhrase, [Description])) as [Description], " +
                "[FIHeaderId], [InsUserId], [InsDt], [UpdUserId], [UpdDt], [ActionDt], " +
                "CONVERT(varchar(500), DECRYPTBYPASSPHRASE(@passPhrase, [ActionReq])) as [ActionReq], [ActionCode], [RevNo], " +
	            "(SELECT count(*) FROM [dbo].[FIDetail_Attachments] T WHERE r.[FIDetailId] = T.FIDetailID and r.RevNo = T.RevNo) as AttCnt, " +
                "(SELECT count(*) FROM [dbo].[FIDetail_Owners] T WHERE r.[FIDetailId] = T.FIDetailID and r.RevNo = T.RevNo) as OwnersCnt, " +
                "'FALSE' as IsDeleted " + 
                "FROM [dbo].[FIDetailRev] r WHERE [FIDetailId] = " + Id.ToString() +

                "ORDER BY RevNo DESC ";

        SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ret.Add(new FIDetailRev()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        FIDetailId = Convert.ToInt32(reader["FIDetailId"].ToString()),
                        Description = reader["Description"].ToString(),
                        FIHeaderId = Convert.ToInt32(reader["FIHeaderId"].ToString()),

                        InsUserId = Convert.ToInt32(reader["InsUserId"].ToString()),
                        InsUser = new Users(Convert.ToInt32(reader["InsUserId"].ToString())),
                        InsDt = Convert.ToDateTime(reader["InsDt"].ToString()),

                        UpdUserId = Convert.ToInt32(reader["UpdUserId"].ToString()),
                        UpdUser = new Users(Convert.ToInt32(reader["UpdUserId"].ToString())),
                        UpdDt = Convert.ToDateTime(reader["UpdDt"].ToString()),

                        ActionDt = Convert.ToDateTime(reader["ActionDt"].ToString()),
                        ActionReq = reader["ActionReq"].ToString(),

                        ActionCode = reader["ActionCode"].ToString(),
                        OwnersCnt = Convert.ToInt32(reader["OwnersCnt"].ToString()),

                        RevNo = Convert.ToInt32(reader["RevNo"].ToString()),

                        AttCnt = Convert.ToInt32(reader["AttCnt"].ToString()),

                        IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString())
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

        public static void FillDetailsDataGridViewRev(DataGridView dgv, List<FIDetailRev> DetailList)
        {
            dgv.Rows.Clear();

            foreach (FIDetailRev thisRecord in DetailList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "DetailId" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.FIDetailId, dgvColumnHeader = "DetailDetailRevId" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Description, dgvColumnHeader = "DetailDescription" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ActionReq, dgvColumnHeader = "DetailActionReq" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ActionDt.ToString("dd.MM.yyyy"), dgvColumnHeader = "DetailActionDt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.UpdUser.FullName, dgvColumnHeader = "DetailUpdUser" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.UpdDt.ToString("dd.MM.yyyy HH:mm:ss"), dgvColumnHeader = "DetailUpdDate" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.RevNo, dgvColumnHeader = "DetailRevNo" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AttCnt, dgvColumnHeader = "AttCnt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ActionCode, dgvColumnHeader = "DetailActionCode" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.OwnersCnt, dgvColumnHeader = "OwnersCnt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IsDeleted, dgvColumnHeader = "DetailIsDeleted" });

                object[] obj = new object[dgv.Columns.Count];

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
                }

                dgv.Rows.Add(obj);

                if (thisRecord.Id == 0)
                {
                    dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.White;
                }
            }

            dgv.ClearSelection();
        }

        private void MIattachments_Click(object sender, EventArgs e)
        {
            if (dgvDetails.SelectedRows.Count > 0)
            {
                if (Convert.ToInt32(dgvDetails.SelectedRows[0].Cells["AttCnt"].Value.ToString()) > 0)
                {
                    int detailId = Convert.ToInt32(dgvDetails.SelectedRows[0].Cells["DetailDetailRevId"].Value.ToString());
                    int revNo = Convert.ToInt32(dgvDetails.SelectedRows[0].Cells["DetailRevNo"].Value.ToString());

                    Attachments attachedFiles = new Attachments(detailId, revNo, AttachmentsTableName.FIDetail_Attachments);
                    attachedFiles.btnAddFiles.Enabled = false;
                    attachedFiles.btnRemoveAll.Enabled = false;
                    attachedFiles.btnRemoveFile.Enabled = false;
                    attachedFiles.btnSave.Enabled = false;

                    attachedFiles.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No attached files found!");
                }
            }

        }

        private void dgvDetails_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "DetailUpdDate" || e.Column.Name == "DetailActionDt")
            {
                e.SortResult = System.String.Compare(Convert.ToDateTime(e.CellValue1.ToString()).ToString("yyyyMMdd HHmmss"),
                                                     Convert.ToDateTime(e.CellValue2.ToString()).ToString("yyyyMMdd HHmmss"));

                e.Handled = true;
            }
        }

        private void ownersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDetails.SelectedRows.Count > 0)
            {
                if (Convert.ToInt32(dgvDetails.SelectedRows[0].Cells["OwnersCnt"].Value.ToString()) > 0)
                {
                    int detailId = Convert.ToInt32(dgvDetails.SelectedRows[0].Cells["DetailDetailRevId"].Value.ToString());
                    int revNo = Convert.ToInt32(dgvDetails.SelectedRows[0].Cells["DetailRevNo"].Value.ToString());

                    FIDetailRev detRev = DetailRevList.Where(i => i.FIDetailId == detailId && i.RevNo == revNo).First();
                    FIDetail det = new FIDetail(detRev);
                    FIDetailEdit frmShowDetails = new FIDetailEdit(glHeader, det);

                    frmShowDetails.txtDescription.ReadOnly = true;
                    frmShowDetails.txtActionReq.ReadOnly = true;
                    frmShowDetails.txtActionCode.Enabled = false;
                    frmShowDetails.dtpActionDate.Enabled = false;
                    frmShowDetails.dgvOwners.Enabled = false;
                    frmShowDetails.btnSave.Enabled = false;

                    frmShowDetails.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No Owners found!"); //will never be here! 
                }
            }
        }
    }
}
