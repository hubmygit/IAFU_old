namespace IAFollowUp
{
    partial class AuditRevisions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditRevisions));
            this.dgvAuditRevView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RevNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.InsUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbUpdUser = new System.Windows.Forms.ComboBox();
            this.lblUpdUser = new System.Windows.Forms.Label();
            this.lblUpdDtTo = new System.Windows.Forms.Label();
            this.lblUpdDtFrom = new System.Windows.Forms.Label();
            this.dtpUpdDtTo = new System.Windows.Forms.DateTimePicker();
            this.dtpUpdDtFrom = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditRevView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAuditRevView
            // 
            this.dgvAuditRevView.AllowUserToAddRows = false;
            this.dgvAuditRevView.AllowUserToDeleteRows = false;
            this.dgvAuditRevView.AllowUserToOrderColumns = true;
            this.dgvAuditRevView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditRevView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAuditRevView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditRevView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.AuditID,
            this.RevNo,
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
            this.InsUser,
            this.InsDt,
            this.UpdUser,
            this.UpdDt});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAuditRevView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAuditRevView.Location = new System.Drawing.Point(1, 103);
            this.dgvAuditRevView.MultiSelect = false;
            this.dgvAuditRevView.Name = "dgvAuditRevView";
            this.dgvAuditRevView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditRevView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAuditRevView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditRevView.Size = new System.Drawing.Size(1209, 500);
            this.dgvAuditRevView.TabIndex = 13;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 50;
            // 
            // AuditID
            // 
            this.AuditID.HeaderText = "Audit ID";
            this.AuditID.Name = "AuditID";
            this.AuditID.ReadOnly = true;
            this.AuditID.Visible = false;
            // 
            // RevNo
            // 
            this.RevNo.HeaderText = "Rev No";
            this.RevNo.Name = "RevNo";
            this.RevNo.ReadOnly = true;
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
            // InsUser
            // 
            this.InsUser.HeaderText = "Ins User";
            this.InsUser.Name = "InsUser";
            this.InsUser.ReadOnly = true;
            // 
            // InsDt
            // 
            this.InsDt.HeaderText = "Ins Date";
            this.InsDt.Name = "InsDt";
            this.InsDt.ReadOnly = true;
            // 
            // UpdUser
            // 
            this.UpdUser.HeaderText = "Upd User";
            this.UpdUser.Name = "UpdUser";
            this.UpdUser.ReadOnly = true;
            // 
            // UpdDt
            // 
            this.UpdDt.HeaderText = "Upd Date";
            this.UpdDt.Name = "UpdDt";
            this.UpdDt.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCounter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 606);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1222, 22);
            this.statusStrip1.TabIndex = 44;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripCounter
            // 
            this.toolStripCounter.Name = "toolStripCounter";
            this.toolStripCounter.Size = new System.Drawing.Size(0, 17);
            // 
            // cbUpdUser
            // 
            this.cbUpdUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUpdUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbUpdUser.FormattingEnabled = true;
            this.cbUpdUser.Location = new System.Drawing.Point(474, 40);
            this.cbUpdUser.Name = "cbUpdUser";
            this.cbUpdUser.Size = new System.Drawing.Size(179, 24);
            this.cbUpdUser.TabIndex = 54;
            this.cbUpdUser.SelectedIndexChanged += new System.EventHandler(this.cbUpdUser_SelectedIndexChanged);
            // 
            // lblUpdUser
            // 
            this.lblUpdUser.AutoSize = true;
            this.lblUpdUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblUpdUser.Location = new System.Drawing.Point(408, 42);
            this.lblUpdUser.Name = "lblUpdUser";
            this.lblUpdUser.Size = new System.Drawing.Size(66, 16);
            this.lblUpdUser.TabIndex = 55;
            this.lblUpdUser.Text = "Upd User";
            // 
            // lblUpdDtTo
            // 
            this.lblUpdDtTo.AutoSize = true;
            this.lblUpdDtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblUpdDtTo.Location = new System.Drawing.Point(198, 42);
            this.lblUpdDtTo.Name = "lblUpdDtTo";
            this.lblUpdDtTo.Size = new System.Drawing.Size(25, 16);
            this.lblUpdDtTo.TabIndex = 53;
            this.lblUpdDtTo.Text = "To";
            // 
            // lblUpdDtFrom
            // 
            this.lblUpdDtFrom.AutoSize = true;
            this.lblUpdDtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblUpdDtFrom.Location = new System.Drawing.Point(18, 43);
            this.lblUpdDtFrom.Name = "lblUpdDtFrom";
            this.lblUpdDtFrom.Size = new System.Drawing.Size(39, 16);
            this.lblUpdDtFrom.TabIndex = 52;
            this.lblUpdDtFrom.Text = "From";
            // 
            // dtpUpdDtTo
            // 
            this.dtpUpdDtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpUpdDtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUpdDtTo.Location = new System.Drawing.Point(229, 38);
            this.dtpUpdDtTo.Name = "dtpUpdDtTo";
            this.dtpUpdDtTo.Size = new System.Drawing.Size(103, 22);
            this.dtpUpdDtTo.TabIndex = 51;
            this.dtpUpdDtTo.ValueChanged += new System.EventHandler(this.dtUpdDtTo_ValueChanged);
            // 
            // dtpUpdDtFrom
            // 
            this.dtpUpdDtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpUpdDtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUpdDtFrom.Location = new System.Drawing.Point(63, 38);
            this.dtpUpdDtFrom.Name = "dtpUpdDtFrom";
            this.dtpUpdDtFrom.Size = new System.Drawing.Size(103, 22);
            this.dtpUpdDtFrom.TabIndex = 50;
            this.dtpUpdDtFrom.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpUpdDtFrom.ValueChanged += new System.EventHandler(this.dtpUpdDtFrom_ValueChanged);
            // 
            // AuditRevisions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 628);
            this.Controls.Add(this.cbUpdUser);
            this.Controls.Add(this.lblUpdUser);
            this.Controls.Add(this.lblUpdDtTo);
            this.Controls.Add(this.lblUpdDtFrom);
            this.Controls.Add(this.dtpUpdDtTo);
            this.Controls.Add(this.dtpUpdDtFrom);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvAuditRevView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuditRevisions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Audit Revisions";
            this.Load += new System.EventHandler(this.AuditRevisions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditRevView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAuditRevView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RevNo;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn InsUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdDt;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCounter;
        private System.Windows.Forms.ComboBox cbUpdUser;
        private System.Windows.Forms.Label lblUpdUser;
        private System.Windows.Forms.Label lblUpdDtTo;
        private System.Windows.Forms.Label lblUpdDtFrom;
        public System.Windows.Forms.DateTimePicker dtpUpdDtTo;
        public System.Windows.Forms.DateTimePicker dtpUpdDtFrom;
    }
}