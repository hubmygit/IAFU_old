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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIShowHeaders));
            this.dgvHeaders = new System.Windows.Forms.DataGridView();
            this.HeaderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIeditHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHeaders = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
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
            this.lblAudits = new System.Windows.Forms.Label();
            this.UpdUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeaders)).BeginInit();
            this.cmsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudits)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHeaders
            // 
            this.dgvHeaders.AllowUserToAddRows = false;
            this.dgvHeaders.AllowUserToDeleteRows = false;
            this.dgvHeaders.AllowUserToOrderColumns = true;
            this.dgvHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHeaders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHeaders.Location = new System.Drawing.Point(0, 328);
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
            this.dgvHeaders.Size = new System.Drawing.Size(1064, 292);
            this.dgvHeaders.TabIndex = 13;
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
            this.lblHeaders.AutoSize = true;
            this.lblHeaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHeaders.Location = new System.Drawing.Point(469, 291);
            this.lblHeaders.Name = "lblHeaders";
            this.lblHeaders.Size = new System.Drawing.Size(100, 25);
            this.lblHeaders.TabIndex = 47;
            this.lblHeaders.Text = "Headers";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnNew.Location = new System.Drawing.Point(1114, 461);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(107, 52);
            this.btnNew.TabIndex = 48;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvAudits
            // 
            this.dgvAudits.AllowUserToAddRows = false;
            this.dgvAudits.AllowUserToDeleteRows = false;
            this.dgvAudits.AllowUserToOrderColumns = true;
            this.dgvAudits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAudits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAudits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            this.Supervisor});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAudits.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAudits.Location = new System.Drawing.Point(0, 37);
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
            this.dgvAudits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAudits.Size = new System.Drawing.Size(1242, 225);
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
            // lblAudits
            // 
            this.lblAudits.AutoSize = true;
            this.lblAudits.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAudits.Location = new System.Drawing.Point(521, 9);
            this.lblAudits.Name = "lblAudits";
            this.lblAudits.Size = new System.Drawing.Size(94, 25);
            this.lblAudits.TabIndex = 50;
            this.lblAudits.Text = "Audit(s)";
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
            // FIShowHeaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 622);
            this.Controls.Add(this.lblAudits);
            this.Controls.Add(this.dgvAudits);
            this.Controls.Add(this.btnNew);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHeaders;
        private System.Windows.Forms.ContextMenuStrip cmsHeader;
        private System.Windows.Forms.ToolStripMenuItem MIeditHeader;
        private System.Windows.Forms.Label lblHeaders;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvAudits;
        private System.Windows.Forms.Label lblAudits;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderCategory;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdDt;
    }
}