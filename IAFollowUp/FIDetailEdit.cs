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
    public partial class FIDetailEdit : Form
    {
        public FIDetailEdit()
        {
            InitializeComponent();
        }

        public FIDetailEdit(FIHeader fiHeader) //insert
        {
            InitializeComponent();
            Init();

            ArrangeHeaderFields(fiHeader);
            isInsert = true;

            currentHeader = fiHeader;
        }
        public FIDetailEdit(FIHeader fiHeader, FIDetail fIDetail) //update
        {
            InitializeComponent();
            Init();

            ArrangeHeaderFields(fiHeader);
            isInsert = false;

            currentHeader = fiHeader;

            txtDescription.Text = fIDetail.Description;
            txtActionReq.Text = fIDetail.ActionReq;
            txtActionCode.Text = fIDetail.ActionCode;
            dtpActionDate.Value = fIDetail.ActionDt;


            fIDetail.Owners = fIDetail.getOwners(fIDetail.Id, fIDetail.RevNo);

            foreach (Users thisOwner in fIDetail.Owners)
            {
                dgvOwners.Rows.Add(new object[] { thisOwner.Id, thisOwner.FullName, thisOwner.RoleName });
            }

            oldFIDetailRecord = fIDetail;
        }

        public bool isInsert = false;
        public bool success = false;

        public FIDetail newFIDetailRecord = new FIDetail();
        public FIDetail oldFIDetailRecord = new FIDetail();

        public FIHeader currentHeader = new FIHeader();

        public List<Users> ownersList = Users.GetUsersByRole(UserRole.IsAuditee);

        private void Init()
        {
            //FullName.Items.AddRange(Users.GetUsersComboboxItemsList(ownersList).ToArray<ComboboxItem>());
            FullName.Items.AddRange(ownersList.Select(i => i.FullName).OrderBy(i => i).ToArray());

            //var bs = new BindingSource();

            //bs.DataSource = ownersList;
            //bs.DataSource = Users.GetUsersComboboxItemsList(ownersList).ToArray<ComboboxItem>();

            //bs.DataSource = ownersList.Select(i => i.FullName);

            //FullName.DataSource = bs;

        }

        private void ArrangeHeaderFields(FIHeader selectedHeader)
        {
            txtHeaderTitle.Text = selectedHeader.Title;
            txtCategory.Text = selectedHeader.FICategory.Name;
        }

        private bool InsertInto_FIDetail_and_FIDetailOwners(FIDetail fiDetail)
        {
            if (InsertIntoTable_FIDetail(fiDetail) && InsertIntoTable_FIDetailOwners(fiDetail)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool InsertIntoTable_FIDetailSingleOwner(FIDetail fiDetail, Users SingleOwner) //INSERT [dbo].[FIDetail_Owners]
        {
            bool ret = false;

            //dgvOwners.Rows.Add(new object[] { thisOwner.Id, thisOwner.FullName, thisOwner.RoleName });
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FIDetail_Owners] ([FIDetailId], [RevNo], [OwnerId], [UsersId], [InsDate]) " +
                           "VALUES (@DetailId, @RevNo, @OwnerId, @InsUserId, getDate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@DetailId", fiDetail.Id);
                cmd.Parameters.AddWithValue("@RevNo", fiDetail.RevNo);
                cmd.Parameters.AddWithValue("@OwnerId", SingleOwner.Id);
                cmd.Parameters.AddWithValue("@InsUserId", UserInfo.userDetails.Id);

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

        private bool InsertIntoTable_FIDetailOwners(FIDetail fiDetail) //INSERT [dbo].[FIDetail_Owners]
        {
            bool ret = false;

            fiDetail.RevNo += 1;//==0:insert->1, >0:update->++

            int cnt = 0;

            foreach (Users thisOwner in fiDetail.Owners)
            {
                if (InsertIntoTable_FIDetailSingleOwner(fiDetail, thisOwner))
                {
                    cnt = cnt + 1;
                }
            }

            if (cnt == fiDetail.Owners.Count)
            {
                ret = true;
            }

            return ret;
        }

        private bool InsertIntoTable_FIDetail(FIDetail fiDetail) //INSERT [dbo].[FIDetail]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FIDetail] ([FIHeaderId],[Description],[ActionReq], [ActionDt], [ActionCode], [InsUserId], [InsDt],[UpdUserId], [UpdDt], [RevNo]) " +
                           "OUTPUT INSERTED.Id " + 
                           "VALUES " +
                           "(@HeaderId,encryptByPassPhrase(@passPhrase, convert(varchar(500), @Description)), encryptByPassPhrase(@passPhrase, convert(varchar(500), @ActionReq))," +
                           "@ActionDt, @ActionCode, @InsUserId, getDate(), @InsUserId, getDate(), 1 ) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@HeaderId", fiDetail.FIHeaderId);
                cmd.Parameters.AddWithValue("@Description", fiDetail.Description);
                cmd.Parameters.AddWithValue("@ActionReq", fiDetail.ActionReq);
                cmd.Parameters.AddWithValue("@ActionDt", fiDetail.ActionDt);
                cmd.Parameters.AddWithValue("@ActionCode", fiDetail.ActionCode);
                cmd.Parameters.AddWithValue("@InsUserId", UserInfo.userDetails.Id);

                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    fiDetail.Id = Convert.ToInt32(reader["Id"].ToString());
                }
                reader.Close();

                //int rowsAffected = cmd.ExecuteNonQuery();

                //if (rowsAffected > 0)
                if(fiDetail.Id > 0)
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

        private bool Update_FIDetail_and_FIDetailOwners(FIDetail fiDetail)
        {
            if (UpdateTable_Details(fiDetail) && InsertIntoTable_FIDetailOwners(fiDetail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool UpdateTable_Details(FIDetail detail)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[FIDetail] SET [Description] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @Description)), " +
                          "[ActionReq] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @ActionReq)), [ActionDt] = @ActionDt, [ActionCode] = @ActionCode, " + 
                          "[UpdUserId] = @UpdUserId, [UpdDt] = getDate(), [RevNo] = RevNo+1, [UseUpdTrigger] = 1 " +
                          "WHERE id=@id";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@id", detail.Id);
                cmd.Parameters.AddWithValue("@ActionDt", detail.ActionDt);
                cmd.Parameters.AddWithValue("@Description", detail.Description);
                cmd.Parameters.AddWithValue("@ActionReq", detail.ActionReq);
                cmd.Parameters.AddWithValue("@ActionCode", detail.ActionCode);
                cmd.Parameters.AddWithValue("@UpdUserId", UserInfo.userDetails.Id);

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

        public bool InsertIntoTable_DetailAtt(int DetailId, int OldRevNo, int UsersID)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FIDetail_Attachments] ([Name], [FileContents], [FIDetailId], [RevNo], [UsersID], [InsDate]) " +
                           "SELECT [Name], [FileContents], @DetailID, @OldRevNo+1, @UsersID, getDate() " +
                           "FROM [dbo].[FIDetail_Attachments] WHERE FIDetailId=@DetailID and RevNo= @OldRevNo";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@DetailID", DetailId);
                cmd.Parameters.AddWithValue("@OldRevNo", OldRevNo);
                cmd.Parameters.AddWithValue("@UsersID", UsersID);


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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a Description!");
                return;
            }

            if (txtActionReq.Text.Trim() == "")
            {
                MessageBox.Show("Please insert an Action Required!");
                return;
            }

            List<Users> newOwners = new List<Users>();
            for (int l = 0; l < dgvOwners.Rows.Count; l++)
            {
                if (dgvOwners.Rows[l].IsNewRow == false)
                {
                    newOwners.Add(new Users()
                    {
                        Id = Convert.ToInt32(dgvOwners.Rows[l].Cells["Id"].Value.ToString()),
                        FullName = dgvOwners.Rows[l].Cells["FullName"].Value.ToString(),
                        RoleName = dgvOwners.Rows[l].Cells["Role"].Value.ToString()
                    });
                }
            }

            if (newOwners.Count <= 0)
            {
                MessageBox.Show("Please insert at least one Owner!");
                return;
            }

            newFIDetailRecord = new FIDetail()
            {
                Id = oldFIDetailRecord.Id,
                Description = txtDescription.Text,
                ActionReq = txtActionReq.Text,
                ActionDt = dtpActionDate.Value,
                ActionCode = txtActionCode.Text,
                OwnersCnt = oldFIDetailRecord.OwnersCnt,
                Owners = newOwners,
                RevNo = oldFIDetailRecord.RevNo,
                FIHeaderId = currentHeader.Id,
                AttCnt = oldFIDetailRecord.AttCnt
            };

            if (isInsert) //insert
            {
                //if (InsertIntoTable_FIDetail(newFIDetailRecord))
                if(InsertInto_FIDetail_and_FIDetailOwners(newFIDetailRecord))
                {
                    MessageBox.Show("New F/I Detail inserted successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The New F/I Detail has not been inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //update
            {
                if (FIDetail.isEqual(oldFIDetailRecord, newFIDetailRecord) == false)
                {
                    //if (UpdateTable_Details(newFIDetailRecord))
                    if(Update_FIDetail_and_FIDetailOwners(newFIDetailRecord))
                    {
                        bool successful = true;
                        newFIDetailRecord.RevNo = newFIDetailRecord.RevNo + 1;
                        success = true;

                        if (oldFIDetailRecord.AttCnt > 0)
                        {
                            if (InsertIntoTable_DetailAtt(newFIDetailRecord.Id, oldFIDetailRecord.RevNo, UserInfo.userDetails.Id) == false)
                            {
                                successful = false;
                            }
                        }

                        if (successful)
                        {
                            MessageBox.Show("Detail updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Detail updated. Error while inserting attachments.");
                        }
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("The F/I Detail has not been updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Close();
                }
            }
        }

        private void dgvOwners_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgvOwners.Rows[e.RowIndex].Cells["FullName"];

                if (cb.Value != null)
                {
                    dgvOwners.Invalidate();
                }
            }               
        }

        private void dgvOwners_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvOwners.IsCurrentCellDirty)
            {
                bool commited = false;

                // This fires the cell value changed handler below
                try
                {
                    commited = dgvOwners.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Commited: " + commited + " / " + ex.Message);
                }
                //MessageBox.Show(dgvOwners.SelectedRows[0].Cells["FullName"].Value.ToString());

                dgvOwners.SelectedRows[0].Cells["Id"].Value = ownersList.Where(i => i.FullName == dgvOwners.SelectedRows[0].Cells["FullName"].Value.ToString()).First().Id;
                dgvOwners.SelectedRows[0].Cells["Role"].Value = ownersList.Where(i => i.FullName == dgvOwners.SelectedRows[0].Cells["FullName"].Value.ToString()).First().RoleName;

            }
        }
    }
}
