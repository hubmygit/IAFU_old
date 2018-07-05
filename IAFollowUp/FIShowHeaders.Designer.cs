namespace IAFollowUp
{
    partial class FIShowHeaders
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIShowHeaders));
            this.dgvHeaders = new System.Windows.Forms.DataGridView();
            this.HeaderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIeditHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHeaders = new System.Windows.Forms.Label();
            this.btnNewHeader = new System.Windows.Forms.Button();
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
            this.lblDetails = new System.Windows.Forms.Label();
            this.btnNewDetail = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.DetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailActionDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailActionReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailUpdUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailUpdDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIeditDetail = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeaders)).BeginInit();
            this.cmsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.cmsDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHeaders
            // 
            this.dgvHeaders.AllowUserToAddRows = false;
            this.dgvHeaders.AllowUserToDeleteRows = false;
            this.dgvHeaders.AllowUserToOrderColumns = true;
            this.dgvHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHeaders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHeaders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeaders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HeaderId,
            this.HeaderTitle,
            this.HeaderCategory,
            this.UpdUser,
            this.UpdDt});
            this.dgvHeaders.ContextMenuStrip = this.cmsHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHeaders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHeaders.Location = new System.Drawing.Point(0, 103);
            this.dgvHeaders.MultiSelect = false;
            this.dgvHeaders.Name = "dgvHeaders";
            this.dgvHeaders.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHeaders.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHeaders.RowHeadersWidth = 15;
            this.dgvHeaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHeaders.Size = new System.Drawing.Size(1067, 250);
            this.dgvHeaders.TabIndex = 13;
            this.dgvHeaders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHeaders_CellClick);
            this.dgvHeaders.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvHeaders_MouseDown);
            // 
            // HeaderId
            // 
            this.HeaderId.HeaderText = "Id";
            this.HeaderId.Name = "HeaderId";
            this.HeaderId.ReadOnly = true;
            this.HeaderId.Visible = false;
            // 
            // HeaderTitle
            // 
            this.HeaderTitle.HeaderText = "Title";
            this.HeaderTitle.Name = "HeaderTitle";
            this.HeaderTitle.ReadOnly = true;
            this.HeaderTitle.Width = 500;
            // 
            // HeaderCategory
            // 
            this.HeaderCategory.HeaderText = "Category";
            this.HeaderCategory.Name = "HeaderCategory";
            this.HeaderCategory.ReadOnly = true;
            this.HeaderCategory.Width = 350;
            // 
            // UpdUser
            // 
            this.UpdUser.HeaderText = "Update User";
            this.UpdUser.Name = "UpdUser";
            this.UpdUser.ReadOnly = true;
            // 
            // UpdDt
            // 
            this.UpdDt.HeaderText = "Update Date";
            this.UpdDt.Name = "UpdDt";
            this.UpdDt.ReadOnly = true;
            // 
            // cmsHeader
            // 
            this.cmsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIeditHeader});
            this.cmsHeader.Name = "cmsHeader";
            this.cmsHeader.Size = new System.Drawing.Size(95, 26);
            // 
            // MIeditHeader
            // 
            this.MIeditHeader.Name = "MIeditHeader";
            this.MIeditHeader.Size = new System.Drawing.Size(94, 22);
            this.MIeditHeader.Text = "Edit";
            this.MIeditHeader.Click += new System.EventHandler(this.MIeditHeader_Click);
            // 
            // lblHeaders
            // 
            this.lblHeaders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeaders.AutoSize = true;
            this.lblHeaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHeaders.Location = new System.Drawing.Point(436, 75);
            this.lblHeaders.Name = "lblHeaders";
            this.lblHeaders.Size = new System.Drawing.Size(100, 25);
            this.lblHeaders.TabIndex = 47;
            this.lblHeaders.Text = "Headers";
            // 
            // btnNewHeader
            // 
            this.btnNewHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnNewHeader.Location = new System.Drawing.Point(1084, 196);
            this.btnNewHeader.Name = "btnNewHeader";
            this.btnNewHeader.Size = new System.Drawing.Size(158, 51);
            this.btnNewHeader.TabIndex = 48;
            this.btnNewHeader.Text = "New Header";
            this.btnNewHeader.UseVisualStyleBackColor = true;
            this.btnNewHeader.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvAudits
            // 
            this.dgvAudits.AllowUserToAddRows = false;
            this.dgvAudits.AllowUserToDeleteRows = false;
            this.dgvAudits.AllowUserToOrderColumns = true;
            this.dgvAudits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAudits.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAudits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAudits.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAudits.Location = new System.Drawing.Point(0, 0);
            this.dgvAudits.MultiSelect = false;
            this.dgvAudits.Name = "dgvAudits";
            this.dgvAudits.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAudits.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAudits.RowHeadersWidth = 15;
            this.dgvAudits.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvAudits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAudits.Size = new System.Drawing.Size(1254, 63);
            this.dgvAudits.TabIndex = 49;
            this.dgvAudits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAudits_CellClick);
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
            // lblDetails
            // 
            this.lblDetails.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDetails.Location = new System.Drawing.Point(436, 404);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(85, 25);
            this.lblDetails.TabIndex = 51;
            this.lblDetails.Text = "Details";
            // 
            // btnNewDetail
            // 
            this.btnNewDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnNewDetail.Location = new System.Drawing.Point(1084, 532);
            this.btnNewDetail.Name = "btnNewDetail";
            this.btnNewDetail.Size = new System.Drawing.Size(158, 51);
            this.btnNewDetail.TabIndex = 52;
            this.btnNewDetail.Text = "New Detail";
            this.btnNewDetail.UseVisualStyleBackColor = true;
            this.btnNewDetail.Click += new System.EventHandler(this.btnNewDetail_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToOrderColumns = true;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetailId,
            this.DetailDescription,
            this.DetailActionDt,
            this.DetailActionReq,
            this.DetailUpdUser,
            this.DetailUpdDate});
            this.dgvDetails.ContextMenuStrip = this.cmsDetail;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetails.Location = new System.Drawing.Point(0, 432);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDetails.RowHeadersWidth = 15;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1067, 250);
            this.dgvDetails.TabIndex = 53;
            // 
            // DetailId
            // 
            this.DetailId.HeaderText = "Id";
            this.DetailId.Name = "DetailId";
            this.DetailId.ReadOnly = true;
            this.DetailId.Visible = false;
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
            // cmsDetail
            // 
            this.cmsDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIeditDetail});
            this.cmsDetail.Name = "cmsHeader";
            this.cmsDetail.Size = new System.Drawing.Size(95, 26);
            // 
            // MIeditDetail
            // 
            this.MIeditDetail.Name = "MIeditDetail";
            this.MIeditDetail.Size = new System.Drawing.Size(94, 22);
            this.MIeditDetail.Text = "Edit";
            this.MIeditDetail.Click += new System.EventHandler(this.MIeditDetail_Click);
            // 
            // FIShowHeaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 682);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.btnNewDetail);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.dgvAudits);
            this.Controls.Add(this.btnNewHeader);
            this.Controls.Add(this.lblHeaders);
            this.Controls.Add(this.dgvHeaders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FIShowHeaders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Findings and Improvements Headers";
            this.Load += new System.EventHandler(this.FIShowHeaders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeaders)).EndInit();
            this.cmsHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.cmsDetail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHeaders;
        private System.Windows.Forms.ContextMenuStrip cmsHeader;
        private System.Windows.Forms.ToolStripMenuItem MIeditHeader;
        private System.Windows.Forms.Label lblHeaders;
        private System.Windows.Forms.Button btnNewHeader;
        private System.Windows.Forms.DataGridView dgvAudits;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdDt;
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
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Button btnNewDetail;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailActionDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailActionReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailUpdUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailUpdDate;
        private System.Windows.Forms.ContextMenuStrip cmsDetail;
        private System.Windows.Forms.ToolStripMenuItem MIeditDetail;
    }
}