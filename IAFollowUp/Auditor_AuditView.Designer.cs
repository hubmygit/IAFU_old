namespace IAFollowUp
{
    partial class Auditor_AuditView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auditor_AuditView));
            this.dgvAuditView = new System.Windows.Forms.DataGridView();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIupdate = new System.Windows.Forms.ToolStripMenuItem();
            this.MIattachments = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MIshowFindings = new System.Windows.Forms.ToolStripMenuItem();
            this.MIfinalizeAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.MIRevisions = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDtTo = new System.Windows.Forms.Label();
            this.lblDtFrom = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbCompanies = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.lblYear = new System.Windows.Forms.Label();
            this.cbAuditor1 = new System.Windows.Forms.ComboBox();
            this.lblAuditor1 = new System.Windows.Forms.Label();
            this.chbCompleted = new System.Windows.Forms.CheckBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnTitleSearch = new System.Windows.Forms.Button();
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
            this.RevNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditView)).BeginInit();
            this.cmsOnGrid.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAuditView
            // 
            this.dgvAuditView.AllowUserToAddRows = false;
            this.dgvAuditView.AllowUserToDeleteRows = false;
            this.dgvAuditView.AllowUserToOrderColumns = true;
            this.dgvAuditView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAuditView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAuditView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.IsCompleted,
            this.RevNo,
            this.AttCnt});
            this.dgvAuditView.ContextMenuStrip = this.cmsOnGrid;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAuditView.Location = new System.Drawing.Point(12, 89);
            this.dgvAuditView.MultiSelect = false;
            this.dgvAuditView.Name = "dgvAuditView";
            this.dgvAuditView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAuditView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditView.Size = new System.Drawing.Size(1198, 508);
            this.dgvAuditView.TabIndex = 12;
            this.dgvAuditView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvAuditView_SortCompare);
            this.dgvAuditView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvAuditView_MouseDown);
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIupdate,
            this.MIattachments,
            this.toolStripSeparator1,
            this.MIshowFindings,
            this.MIfinalizeAudit,
            this.MIRevisions});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(208, 120);
            // 
            // MIupdate
            // 
            this.MIupdate.Name = "MIupdate";
            this.MIupdate.Size = new System.Drawing.Size(207, 22);
            this.MIupdate.Text = "Edit";
            this.MIupdate.Click += new System.EventHandler(this.MIupdate_Click);
            // 
            // MIattachments
            // 
            this.MIattachments.Name = "MIattachments";
            this.MIattachments.Size = new System.Drawing.Size(207, 22);
            this.MIattachments.Text = "Attachments";
            this.MIattachments.Click += new System.EventHandler(this.MIattachments_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            // 
            // MIshowFindings
            // 
            this.MIshowFindings.Name = "MIshowFindings";
            this.MIshowFindings.Size = new System.Drawing.Size(207, 22);
            this.MIshowFindings.Text = "Findings / Improvements";
            this.MIshowFindings.Click += new System.EventHandler(this.MIshowFindings_Click);
            // 
            // MIfinalizeAudit
            // 
            this.MIfinalizeAudit.Name = "MIfinalizeAudit";
            this.MIfinalizeAudit.Size = new System.Drawing.Size(207, 22);
            this.MIfinalizeAudit.Text = "Finalize Audit";
            this.MIfinalizeAudit.Click += new System.EventHandler(this.MIfinalizeAudit_Click);
            // 
            // MIRevisions
            // 
            this.MIRevisions.Name = "MIRevisions";
            this.MIRevisions.Size = new System.Drawing.Size(207, 22);
            this.MIRevisions.Text = "Revisions";
            this.MIRevisions.Visible = false;
            this.MIRevisions.Click += new System.EventHandler(this.MIRevisions_Click);
            // 
            // lblDtTo
            // 
            this.lblDtTo.AutoSize = true;
            this.lblDtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtTo.Location = new System.Drawing.Point(583, 21);
            this.lblDtTo.Name = "lblDtTo";
            this.lblDtTo.Size = new System.Drawing.Size(25, 16);
            this.lblDtTo.TabIndex = 42;
            this.lblDtTo.Text = "To";
            // 
            // lblDtFrom
            // 
            this.lblDtFrom.AutoSize = true;
            this.lblDtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtFrom.Location = new System.Drawing.Point(403, 21);
            this.lblDtFrom.Name = "lblDtFrom";
            this.lblDtFrom.Size = new System.Drawing.Size(39, 16);
            this.lblDtFrom.TabIndex = 41;
            this.lblDtFrom.Text = "From";
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(614, 16);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(103, 22);
            this.dtTo.TabIndex = 40;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(448, 16);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(103, 22);
            this.dtFrom.TabIndex = 39;
            this.dtFrom.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCounter,
            this.toolStripMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 600);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1222, 22);
            this.statusStrip1.TabIndex = 43;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripCounter
            // 
            this.toolStripCounter.Name = "toolStripCounter";
            this.toolStripCounter.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripMessage
            // 
            this.toolStripMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.toolStripMessage.ForeColor = System.Drawing.Color.Salmon;
            this.toolStripMessage.Name = "toolStripMessage";
            this.toolStripMessage.Size = new System.Drawing.Size(429, 21);
            this.toolStripMessage.Text = "Double-Click on Audit To View Findings / Imrovements";
            this.toolStripMessage.Visible = false;
            // 
            // cbCompanies
            // 
            this.cbCompanies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompanies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbCompanies.FormattingEnabled = true;
            this.cbCompanies.Location = new System.Drawing.Point(218, 17);
            this.cbCompanies.Name = "cbCompanies";
            this.cbCompanies.Size = new System.Drawing.Size(156, 24);
            this.cbCompanies.TabIndex = 45;
            this.cbCompanies.SelectedIndexChanged += new System.EventHandler(this.cbCompanies_SelectedIndexChanged);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.Location = new System.Drawing.Point(146, 20);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(66, 16);
            this.lblCompany.TabIndex = 44;
            this.lblCompany.Text = "Company";
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(53, 16);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(61, 22);
            this.dtpYear.TabIndex = 47;
            this.dtpYear.ValueChanged += new System.EventHandler(this.dtpYear_ValueChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblYear.Location = new System.Drawing.Point(9, 20);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(37, 16);
            this.lblYear.TabIndex = 46;
            this.lblYear.Text = "Year";
            // 
            // cbAuditor1
            // 
            this.cbAuditor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuditor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbAuditor1.FormattingEnabled = true;
            this.cbAuditor1.Location = new System.Drawing.Point(881, 18);
            this.cbAuditor1.Name = "cbAuditor1";
            this.cbAuditor1.Size = new System.Drawing.Size(179, 24);
            this.cbAuditor1.TabIndex = 48;
            this.cbAuditor1.SelectedIndexChanged += new System.EventHandler(this.cbAuditor1_SelectedIndexChanged);
            // 
            // lblAuditor1
            // 
            this.lblAuditor1.AutoSize = true;
            this.lblAuditor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAuditor1.Location = new System.Drawing.Point(815, 20);
            this.lblAuditor1.Name = "lblAuditor1";
            this.lblAuditor1.Size = new System.Drawing.Size(60, 16);
            this.lblAuditor1.TabIndex = 49;
            this.lblAuditor1.Text = "Auditor 1";
            // 
            // chbCompleted
            // 
            this.chbCompleted.AutoSize = true;
            this.chbCompleted.Checked = true;
            this.chbCompleted.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chbCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbCompleted.Location = new System.Drawing.Point(1105, 20);
            this.chbCompleted.Name = "chbCompleted";
            this.chbCompleted.Size = new System.Drawing.Size(93, 20);
            this.chbCompleted.TabIndex = 50;
            this.chbCompleted.Text = "Completed";
            this.chbCompleted.ThreeState = true;
            this.chbCompleted.UseVisualStyleBackColor = true;
            this.chbCompleted.CheckStateChanged += new System.EventHandler(this.chbCompleted_CheckStateChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTitle.Location = new System.Drawing.Point(83, 57);
            this.txtTitle.MaxLength = 500;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(405, 26);
            this.txtTitle.TabIndex = 51;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTitle.Location = new System.Drawing.Point(18, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(38, 20);
            this.lblTitle.TabIndex = 52;
            this.lblTitle.Text = "Title";
            // 
            // btnTitleSearch
            // 
            this.btnTitleSearch.Location = new System.Drawing.Point(506, 60);
            this.btnTitleSearch.Name = "btnTitleSearch";
            this.btnTitleSearch.Size = new System.Drawing.Size(55, 23);
            this.btnTitleSearch.TabIndex = 53;
            this.btnTitleSearch.Text = "Search";
            this.btnTitleSearch.UseVisualStyleBackColor = true;
            this.btnTitleSearch.Click += new System.EventHandler(this.btnTitleSearch_Click);
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
            this.Title.Width = 200;
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
            this.IsCompleted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsCompleted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // RevNo
            // 
            this.RevNo.HeaderText = "Rev No";
            this.RevNo.Name = "RevNo";
            this.RevNo.ReadOnly = true;
            this.RevNo.Visible = false;
            // 
            // AttCnt
            // 
            this.AttCnt.HeaderText = "Att";
            this.AttCnt.Name = "AttCnt";
            this.AttCnt.ReadOnly = true;
            // 
            // Auditor_AuditView
            // 
            this.AcceptButton = this.btnTitleSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 622);
            this.Controls.Add(this.btnTitleSearch);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.chbCompleted);
            this.Controls.Add(this.cbAuditor1);
            this.Controls.Add(this.lblAuditor1);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cbCompanies);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblDtTo);
            this.Controls.Add(this.lblDtFrom);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.dgvAuditView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Auditor_AuditView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Audit View";
            this.Load += new System.EventHandler(this.Auditor_AuditView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditView)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem MIupdate;
        private System.Windows.Forms.ToolStripMenuItem MIshowFindings;
        private System.Windows.Forms.ToolStripMenuItem MIattachments;
        private System.Windows.Forms.Label lblDtTo;
        private System.Windows.Forms.Label lblDtFrom;
        public System.Windows.Forms.DateTimePicker dtTo;
        public System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCounter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MIfinalizeAudit;
        private System.Windows.Forms.ComboBox cbCompanies;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cbAuditor1;
        private System.Windows.Forms.Label lblAuditor1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnTitleSearch;
        public System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem MIRevisions;
        public System.Windows.Forms.CheckBox chbCompleted;
        public System.Windows.Forms.DataGridView dgvAuditView;
        public System.Windows.Forms.ToolStripStatusLabel toolStripMessage;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn RevNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttCnt;
    }
}