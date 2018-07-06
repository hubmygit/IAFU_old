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

        public FIDetailEdit(FIHeader fiHeader)//insert
        {
            InitializeComponent();
            ArrangeHeaderFields(fiHeader);
            isInsert = true;

            currentHeader = fiHeader;
        }
        public FIDetailEdit(FIHeader fiHeader, FIDetail fIDetail)//update
        {
            InitializeComponent();
            ArrangeHeaderFields(fiHeader);
            isInsert = false;

            currentHeader = fiHeader;

            txtDescription.Text = fIDetail.Description;
            txtActionReq.Text = fIDetail.ActionReq;
            dtpActionDate.Value = fIDetail.ActionDt;

            oldFIDetailRecord = fIDetail;
        }

        public bool isInsert = false;
        public bool success = false;

        public FIDetail newFIDetailRecord = new FIDetail();
        public FIDetail oldFIDetailRecord = new FIDetail();

        public FIHeader currentHeader = new FIHeader();
        private void ArrangeHeaderFields(FIHeader selectedHeader)
        {
            txtHeaderTitle.Text = selectedHeader.Title;
            txtCategory.Text = selectedHeader.FICategory.Name;
        }

        private bool InsertIntoTable_FIDetail(FIDetail fiDetail) //INSERT [dbo].[FIHeader]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FIDetail] ([FIHeaderId],[Description],[ActionReq],[ActionDt],[InsUserId], [InsDt],[UpdUserId], [UpdDt], [RevNo]) VALUES " +
                           "(@HeaderId,encryptByPassPhrase(@passPhrase, convert(varchar(500), @Description)), encryptByPassPhrase(@passPhrase, convert(varchar(500), @ActionReq))," +
                           "@ActionDt, @InsUserId, getDate(), @InsUserId, getDate(), 1 ) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@HeaderId", fiDetail.FIHeaderId);
                cmd.Parameters.AddWithValue("@Description", fiDetail.Description);
                cmd.Parameters.AddWithValue("@ActionReq", fiDetail.ActionReq);
                cmd.Parameters.AddWithValue("@ActionDt", fiDetail.ActionDt);
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
        private bool UpdateTable_Details(FIDetail detail)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[FIDetail] SET [Description] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @Description)), " +
                          "[ActionReq] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @ActionReq)), [ActionDt] = @ActionDt, " + 
                          "[UpdUserId] = @UpdUserId, [UpdDt] = getDate(), [RevNo] = RevNo+1, [UseUpdTrigger] = 1" +
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

            newFIDetailRecord = new FIDetail()
            {
                Id = oldFIDetailRecord.Id,
                Description = txtDescription.Text,
                ActionReq = txtActionReq.Text,
                ActionDt = dtpActionDate.Value,
                RevNo = oldFIDetailRecord.RevNo,
                FIHeaderId = currentHeader.Id,
                AttCnt = oldFIDetailRecord.AttCnt
            };

            if (isInsert) //insert
            {
                if (InsertIntoTable_FIDetail(newFIDetailRecord))
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
                    if (UpdateTable_Details(newFIDetailRecord))
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
    }
}
