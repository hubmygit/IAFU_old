﻿namespace IAFollowUp
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
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIupdate = new System.Windows.Forms.ToolStripMenuItem();
            this.MIshowFindings = new System.Windows.Forms.ToolStripMenuItem();
            this.MIattachments = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDtTo = new System.Windows.Forms.Label();
            this.lblDtFrom = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripCounter = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.IsCompleted});
            this.dgvAuditView.ContextMenuStrip = this.cmsOnGrid;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAuditView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAuditView.Location = new System.Drawing.Point(12, 67);
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
            this.dgvAuditView.Size = new System.Drawing.Size(1198, 549);
            this.dgvAuditView.TabIndex = 12;
            this.dgvAuditView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvAuditView_MouseDown);
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
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIupdate,
            this.MIshowFindings,
            this.MIattachments});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(175, 70);
            // 
            // MIupdate
            // 
            this.MIupdate.Name = "MIupdate";
            this.MIupdate.Size = new System.Drawing.Size(174, 22);
            this.MIupdate.Text = "Edit";
            this.MIupdate.Click += new System.EventHandler(this.MIupdate_Click);
            // 
            // MIshowFindings
            // 
            this.MIshowFindings.Name = "MIshowFindings";
            this.MIshowFindings.Size = new System.Drawing.Size(174, 22);
            this.MIshowFindings.Text = "Show Findings";
            this.MIshowFindings.Click += new System.EventHandler(this.MIshowFindings_Click);
            // 
            // MIattachments
            // 
            this.MIattachments.Name = "MIattachments";
            this.MIattachments.Size = new System.Drawing.Size(174, 22);
            this.MIattachments.Text = "Show Attachments";
            this.MIattachments.Click += new System.EventHandler(this.MIattachments_Click);
            // 
            // lblDtTo
            // 
            this.lblDtTo.AutoSize = true;
            this.lblDtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtTo.Location = new System.Drawing.Point(213, 25);
            this.lblDtTo.Name = "lblDtTo";
            this.lblDtTo.Size = new System.Drawing.Size(25, 16);
            this.lblDtTo.TabIndex = 42;
            this.lblDtTo.Text = "To";
            // 
            // lblDtFrom
            // 
            this.lblDtFrom.AutoSize = true;
            this.lblDtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtFrom.Location = new System.Drawing.Point(18, 25);
            this.lblDtFrom.Name = "lblDtFrom";
            this.lblDtFrom.Size = new System.Drawing.Size(39, 16);
            this.lblDtFrom.TabIndex = 41;
            this.lblDtFrom.Text = "From";
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(244, 20);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(123, 22);
            this.dtTo.TabIndex = 40;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(63, 20);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(123, 22);
            this.dtFrom.TabIndex = 39;
            this.dtFrom.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCounter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 606);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1222, 22);
            this.statusStrip1.TabIndex = 43;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripCounter
            // 
            this.toolStripCounter.Name = "toolStripCounter";
            this.toolStripCounter.Size = new System.Drawing.Size(118, 17);
            this.toolStripCounter.Text = "toolStripStatusLabel1";
            // 
            // Auditor_AuditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 628);
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

        private System.Windows.Forms.DataGridView dgvAuditView;
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
        private System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem MIupdate;
        private System.Windows.Forms.ToolStripMenuItem MIshowFindings;
        private System.Windows.Forms.ToolStripMenuItem MIattachments;
        private System.Windows.Forms.Label lblDtTo;
        private System.Windows.Forms.Label lblDtFrom;
        public System.Windows.Forms.DateTimePicker dtTo;
        public System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCounter;
    }
}