namespace IAFollowUp
{
    partial class InsertNewAudit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertNewAudit));
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cbCompanies = new System.Windows.Forms.ComboBox();
            this.lblAuditNumber = new System.Windows.Forms.Label();
            this.txtAuditNumber = new System.Windows.Forms.TextBox();
            this.lblAuditType = new System.Windows.Forms.Label();
            this.cbAuditTypes = new System.Windows.Forms.ComboBox();
            this.txtIASentNumber = new System.Windows.Forms.TextBox();
            this.lblIASentNumber = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblReportDate = new System.Windows.Forms.Label();
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblAuditor1 = new System.Windows.Forms.Label();
            this.cbAuditor1 = new System.Windows.Forms.ComboBox();
            this.lblAuditor2 = new System.Windows.Forms.Label();
            this.cbAuditor2 = new System.Windows.Forms.ComboBox();
            this.lblSupervisor = new System.Windows.Forms.Label();
            this.cbSupervisor = new System.Windows.Forms.ComboBox();
            this.btnEraseAuditor2 = new System.Windows.Forms.Button();
            this.btnEraseSupervisor = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(144, 115);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(184, 22);
            this.dtpYear.TabIndex = 2;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.Location = new System.Drawing.Point(50, 166);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(66, 16);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.Text = "Company";
            // 
            // cbCompanies
            // 
            this.cbCompanies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompanies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbCompanies.FormattingEnabled = true;
            this.cbCompanies.Location = new System.Drawing.Point(144, 163);
            this.cbCompanies.Name = "cbCompanies";
            this.cbCompanies.Size = new System.Drawing.Size(184, 24);
            this.cbCompanies.TabIndex = 3;
            // 
            // lblAuditNumber
            // 
            this.lblAuditNumber.AutoSize = true;
            this.lblAuditNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAuditNumber.Location = new System.Drawing.Point(27, 229);
            this.lblAuditNumber.Name = "lblAuditNumber";
            this.lblAuditNumber.Size = new System.Drawing.Size(89, 16);
            this.lblAuditNumber.TabIndex = 4;
            this.lblAuditNumber.Text = "Audit Number";
            // 
            // txtAuditNumber
            // 
            this.txtAuditNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtAuditNumber.Location = new System.Drawing.Point(144, 226);
            this.txtAuditNumber.MaxLength = 3;
            this.txtAuditNumber.Name = "txtAuditNumber";
            this.txtAuditNumber.Size = new System.Drawing.Size(184, 22);
            this.txtAuditNumber.TabIndex = 4;
            // 
            // lblAuditType
            // 
            this.lblAuditType.AutoSize = true;
            this.lblAuditType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAuditType.Location = new System.Drawing.Point(43, 289);
            this.lblAuditType.Name = "lblAuditType";
            this.lblAuditType.Size = new System.Drawing.Size(73, 16);
            this.lblAuditType.TabIndex = 6;
            this.lblAuditType.Text = "Audit Type";
            // 
            // cbAuditTypes
            // 
            this.cbAuditTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuditTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbAuditTypes.FormattingEnabled = true;
            this.cbAuditTypes.Location = new System.Drawing.Point(144, 286);
            this.cbAuditTypes.Name = "cbAuditTypes";
            this.cbAuditTypes.Size = new System.Drawing.Size(184, 24);
            this.cbAuditTypes.TabIndex = 5;
            // 
            // txtIASentNumber
            // 
            this.txtIASentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtIASentNumber.Location = new System.Drawing.Point(144, 341);
            this.txtIASentNumber.MaxLength = 3;
            this.txtIASentNumber.Name = "txtIASentNumber";
            this.txtIASentNumber.Size = new System.Drawing.Size(184, 22);
            this.txtIASentNumber.TabIndex = 6;
            // 
            // lblIASentNumber
            // 
            this.lblIASentNumber.AutoSize = true;
            this.lblIASentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblIASentNumber.Location = new System.Drawing.Point(15, 344);
            this.lblIASentNumber.Name = "lblIASentNumber";
            this.lblIASentNumber.Size = new System.Drawing.Size(101, 16);
            this.lblIASentNumber.TabIndex = 8;
            this.lblIASentNumber.Text = "IA Sent Number";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTitle.Location = new System.Drawing.Point(205, 33);
            this.txtTitle.MaxLength = 500;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(468, 26);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTitle.Location = new System.Drawing.Point(140, 36);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(38, 20);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Title";
            // 
            // lblReportDate
            // 
            this.lblReportDate.AutoSize = true;
            this.lblReportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblReportDate.Location = new System.Drawing.Point(420, 121);
            this.lblReportDate.Name = "lblReportDate";
            this.lblReportDate.Size = new System.Drawing.Size(81, 16);
            this.lblReportDate.TabIndex = 12;
            this.lblReportDate.Text = "Report Date";
            // 
            // dtpReportDate
            // 
            this.dtpReportDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpReportDate.CustomFormat = "dd.MM.yyyy";
            this.dtpReportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportDate.Location = new System.Drawing.Point(529, 115);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.Size = new System.Drawing.Size(184, 22);
            this.dtpReportDate.TabIndex = 7;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblYear.Location = new System.Drawing.Point(79, 120);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(37, 16);
            this.lblYear.TabIndex = 0;
            this.lblYear.Text = "Year";
            // 
            // lblAuditor1
            // 
            this.lblAuditor1.AutoSize = true;
            this.lblAuditor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAuditor1.Location = new System.Drawing.Point(441, 166);
            this.lblAuditor1.Name = "lblAuditor1";
            this.lblAuditor1.Size = new System.Drawing.Size(60, 16);
            this.lblAuditor1.TabIndex = 14;
            this.lblAuditor1.Text = "Auditor 1";
            // 
            // cbAuditor1
            // 
            this.cbAuditor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuditor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbAuditor1.FormattingEnabled = true;
            this.cbAuditor1.Location = new System.Drawing.Point(529, 163);
            this.cbAuditor1.Name = "cbAuditor1";
            this.cbAuditor1.Size = new System.Drawing.Size(184, 24);
            this.cbAuditor1.TabIndex = 8;
            // 
            // lblAuditor2
            // 
            this.lblAuditor2.AutoSize = true;
            this.lblAuditor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAuditor2.Location = new System.Drawing.Point(441, 229);
            this.lblAuditor2.Name = "lblAuditor2";
            this.lblAuditor2.Size = new System.Drawing.Size(60, 16);
            this.lblAuditor2.TabIndex = 16;
            this.lblAuditor2.Text = "Auditor 2";
            // 
            // cbAuditor2
            // 
            this.cbAuditor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuditor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbAuditor2.FormattingEnabled = true;
            this.cbAuditor2.Location = new System.Drawing.Point(529, 226);
            this.cbAuditor2.Name = "cbAuditor2";
            this.cbAuditor2.Size = new System.Drawing.Size(184, 24);
            this.cbAuditor2.TabIndex = 9;
            // 
            // lblSupervisor
            // 
            this.lblSupervisor.AutoSize = true;
            this.lblSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblSupervisor.Location = new System.Drawing.Point(428, 289);
            this.lblSupervisor.Name = "lblSupervisor";
            this.lblSupervisor.Size = new System.Drawing.Size(73, 16);
            this.lblSupervisor.TabIndex = 18;
            this.lblSupervisor.Text = "Supervisor";
            // 
            // cbSupervisor
            // 
            this.cbSupervisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbSupervisor.FormattingEnabled = true;
            this.cbSupervisor.Location = new System.Drawing.Point(529, 286);
            this.cbSupervisor.Name = "cbSupervisor";
            this.cbSupervisor.Size = new System.Drawing.Size(184, 24);
            this.cbSupervisor.TabIndex = 10;
            // 
            // btnEraseAuditor2
            // 
            this.btnEraseAuditor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnEraseAuditor2.Location = new System.Drawing.Point(735, 226);
            this.btnEraseAuditor2.Name = "btnEraseAuditor2";
            this.btnEraseAuditor2.Size = new System.Drawing.Size(59, 23);
            this.btnEraseAuditor2.TabIndex = 20;
            this.btnEraseAuditor2.Text = "Clear";
            this.btnEraseAuditor2.UseVisualStyleBackColor = true;
            this.btnEraseAuditor2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEraseSupervisor
            // 
            this.btnEraseSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnEraseSupervisor.Location = new System.Drawing.Point(735, 286);
            this.btnEraseSupervisor.Name = "btnEraseSupervisor";
            this.btnEraseSupervisor.Size = new System.Drawing.Size(59, 23);
            this.btnEraseSupervisor.TabIndex = 21;
            this.btnEraseSupervisor.Text = "Clear";
            this.btnEraseSupervisor.UseVisualStyleBackColor = true;
            this.btnEraseSupervisor.Click += new System.EventHandler(this.btnEraseSupervisor_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::IAFollowUp.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(351, 438);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // InsertNewAudit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 508);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEraseSupervisor);
            this.Controls.Add(this.btnEraseAuditor2);
            this.Controls.Add(this.cbSupervisor);
            this.Controls.Add(this.lblSupervisor);
            this.Controls.Add(this.cbAuditor2);
            this.Controls.Add(this.lblAuditor2);
            this.Controls.Add(this.cbAuditor1);
            this.Controls.Add(this.lblAuditor1);
            this.Controls.Add(this.dtpReportDate);
            this.Controls.Add(this.lblReportDate);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtIASentNumber);
            this.Controls.Add(this.lblIASentNumber);
            this.Controls.Add(this.cbAuditTypes);
            this.Controls.Add(this.lblAuditType);
            this.Controls.Add(this.txtAuditNumber);
            this.Controls.Add(this.lblAuditNumber);
            this.Controls.Add(this.cbCompanies);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.lblYear);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InsertNewAudit";
            this.Text = "New Audit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cbCompanies;
        private System.Windows.Forms.Label lblAuditNumber;
        private System.Windows.Forms.TextBox txtAuditNumber;
        private System.Windows.Forms.Label lblAuditType;
        private System.Windows.Forms.ComboBox cbAuditTypes;
        private System.Windows.Forms.TextBox txtIASentNumber;
        private System.Windows.Forms.Label lblIASentNumber;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblReportDate;
        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblAuditor1;
        private System.Windows.Forms.ComboBox cbAuditor1;
        private System.Windows.Forms.Label lblAuditor2;
        private System.Windows.Forms.ComboBox cbAuditor2;
        private System.Windows.Forms.Label lblSupervisor;
        private System.Windows.Forms.ComboBox cbSupervisor;
        private System.Windows.Forms.Button btnEraseAuditor2;
        private System.Windows.Forms.Button btnEraseSupervisor;
        public System.Windows.Forms.Button btnSave;
    }
}