﻿namespace IAFollowUp
{
    partial class FIDetail_Revisions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIDetail_Revisions));
            this.dgvAudits = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IASentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Auditor1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Auditor2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supervisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCompleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblAudit = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.DetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailRevNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailActionDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailActionReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailUpdUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailUpdDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFIDetailsRev = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.HeaderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderUpdUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderUpdDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAudits
            // 
            this.dgvAudits.AllowUserToAddRows = false;
            this.dgvAudits.AllowUserToDeleteRows = false;
            this.dgvAudits.AllowUserToOrderColumns = true;
            this.dgvAudits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAudits.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAudits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAudits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Year,
            this.Company,
            this.AuditNumber,
            this.AuditType,
            this.IASentNumber,
            this.Title,
            this.ReportDt,
            this.Auditor1,
            this.Auditor2,
            this.Supervisor,
            this.IsCompleted});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAudits.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAudits.Location = new System.Drawing.Point(2, 27);
            this.dgvAudits.MultiSelect = false;
            this.dgvAudits.Name = "dgvAudits";
            this.dgvAudits.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAudits.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAudits.RowHeadersWidth = 15;
            this.dgvAudits.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvAudits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAudits.Size = new System.Drawing.Size(1254, 62);
            this.dgvAudits.TabIndex = 50;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 50;
            // 
            // Year
            // 
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Width = 60;
            // 
            // Company
            // 
            this.Company.HeaderText = "Company";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            this.Company.Width = 80;
            // 
            // AuditNumber
            // 
            this.AuditNumber.HeaderText = "Audit Number";
            this.AuditNumber.Name = "AuditNumber";
            this.AuditNumber.ReadOnly = true;
            this.AuditNumber.Width = 80;
            // 
            // AuditType
            // 
            this.AuditType.HeaderText = "Audit Type";
            this.AuditType.Name = "AuditType";
            this.AuditType.ReadOnly = true;
            // 
            // IASentNumber
            // 
            this.IASentNumber.HeaderText = "IASentNumber";
            this.IASentNumber.Name = "IASentNumber";
            this.IASentNumber.ReadOnly = true;
            this.IASentNumber.Width = 120;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 295;
            // 
            // ReportDt
            // 
            this.ReportDt.HeaderText = "Report Date";
            this.ReportDt.Name = "ReportDt";
            this.ReportDt.ReadOnly = true;
            // 
            // Auditor1
            // 
            this.Auditor1.HeaderText = "Auditor1";
            this.Auditor1.Name = "Auditor1";
            this.Auditor1.ReadOnly = true;
            // 
            // Auditor2
            // 
            this.Auditor2.HeaderText = "Auditor2";
            this.Auditor2.Name = "Auditor2";
            this.Auditor2.ReadOnly = true;
            // 
            // Supervisor
            // 
            this.Supervisor.HeaderText = "Supervisor";
            this.Supervisor.Name = "Supervisor";
            this.Supervisor.ReadOnly = true;
            // 
            // IsCompleted
            // 
            this.IsCompleted.HeaderText = "Completed";
            this.IsCompleted.Name = "IsCompleted";
            this.IsCompleted.ReadOnly = true;
            // 
            // lblAudit
            // 
            this.lblAudit.AutoSize = true;
            this.lblAudit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAudit.Location = new System.Drawing.Point(12, 3);
            this.lblAudit.Name = "lblAudit";
            this.lblAudit.Size = new System.Drawing.Size(46, 20);
            this.lblAudit.TabIndex = 51;
            this.lblAudit.Text = "Audit";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHeader.Location = new System.Drawing.Point(12, 92);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(62, 20);
            this.lblHeader.TabIndex = 53;
            this.lblHeader.Text = "Header";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToOrderColumns = true;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetailId,
            this.DetailRevNo,
            this.DetailDescription,
            this.DetailActionDt,
            this.DetailActionReq,
            this.DetailUpdUser,
            this.DetailUpdDate,
            this.AttCnt});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetails.Location = new System.Drawing.Point(2, 216);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetails.RowHeadersWidth = 15;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1254, 365);
            this.dgvDetails.TabIndex = 54;
            // 
            // DetailId
            // 
            this.DetailId.HeaderText = "Id";
            this.DetailId.Name = "DetailId";
            this.DetailId.ReadOnly = true;
            this.DetailId.Visible = false;
            // 
            // DetailRevNo
            // 
            this.DetailRevNo.HeaderText = "Rev No";
            this.DetailRevNo.Name = "DetailRevNo";
            this.DetailRevNo.ReadOnly = true;
            // 
            // DetailDescription
            // 
            this.DetailDescription.HeaderText = "Description";
            this.DetailDescription.Name = "DetailDescription";
            this.DetailDescription.ReadOnly = true;
            this.DetailDescription.Width = 500;
            // 
            // DetailActionDt
            // 
            this.DetailActionDt.HeaderText = "Action Date";
            this.DetailActionDt.Name = "DetailActionDt";
            this.DetailActionDt.ReadOnly = true;
            // 
            // DetailActionReq
            // 
            this.DetailActionReq.HeaderText = "Action Required";
            this.DetailActionReq.Name = "DetailActionReq";
            this.DetailActionReq.ReadOnly = true;
            // 
            // DetailUpdUser
            // 
            this.DetailUpdUser.HeaderText = "Update User";
            this.DetailUpdUser.Name = "DetailUpdUser";
            this.DetailUpdUser.ReadOnly = true;
            // 
            // DetailUpdDate
            // 
            this.DetailUpdDate.HeaderText = "Update Date";
            this.DetailUpdDate.Name = "DetailUpdDate";
            this.DetailUpdDate.ReadOnly = true;
            // 
            // AttCnt
            // 
            this.AttCnt.HeaderText = "Att";
            this.AttCnt.Name = "AttCnt";
            this.AttCnt.ReadOnly = true;
            // 
            // lblFIDetailsRev
            // 
            this.lblFIDetailsRev.AutoSize = true;
            this.lblFIDetailsRev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblFIDetailsRev.Location = new System.Drawing.Point(12, 193);
            this.lblFIDetailsRev.Name = "lblFIDetailsRev";
            this.lblFIDetailsRev.Size = new System.Drawing.Size(122, 20);
            this.lblFIDetailsRev.TabIndex = 55;
            this.lblFIDetailsRev.Text = "Detail Revisions";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HeaderId,
            this.HeaderTitle,
            this.HeaderCategory,
            this.HeaderUpdUser,
            this.HeaderUpdDt});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView2.Location = new System.Drawing.Point(2, 115);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView2.RowHeadersWidth = 15;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1254, 62);
            this.dataGridView2.TabIndex = 57;
            // 
            // HeaderId
            // 
            this.HeaderId.HeaderText = "Id";
            this.HeaderId.Name = "HeaderId";
            this.HeaderId.ReadOnly = true;
            this.HeaderId.Visible = false;
            this.HeaderId.Width = 50;
            // 
            // HeaderTitle
            // 
            this.HeaderTitle.HeaderText = "Title";
            this.HeaderTitle.Name = "HeaderTitle";
            this.HeaderTitle.ReadOnly = true;
            this.HeaderTitle.Width = 400;
            // 
            // HeaderCategory
            // 
            this.HeaderCategory.HeaderText = "Category";
            this.HeaderCategory.Name = "HeaderCategory";
            this.HeaderCategory.ReadOnly = true;
            this.HeaderCategory.Width = 200;
            // 
            // HeaderUpdUser
            // 
            this.HeaderUpdUser.HeaderText = "Upd User";
            this.HeaderUpdUser.Name = "HeaderUpdUser";
            this.HeaderUpdUser.ReadOnly = true;
            this.HeaderUpdUser.Width = 180;
            // 
            // HeaderUpdDt
            // 
            this.HeaderUpdDt.HeaderText = "Upd Dt";
            this.HeaderUpdDt.Name = "HeaderUpdDt";
            this.HeaderUpdDt.ReadOnly = true;
            this.HeaderUpdDt.Width = 150;
            // 
            // FIDetail_Revisions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 580);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.lblFIDetailsRev);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblAudit);
            this.Controls.Add(this.dgvAudits);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FIDetail_Revisions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FIDetail_Revisions";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAudits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditType;
        private System.Windows.Forms.DataGridViewTextBoxColumn IASentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Auditor1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Auditor2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supervisor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCompleted;
        private System.Windows.Forms.Label lblAudit;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailRevNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailActionDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailActionReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailUpdUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailUpdDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttCnt;
        private System.Windows.Forms.Label lblFIDetailsRev;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderUpdUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderUpdDt;
    }
}