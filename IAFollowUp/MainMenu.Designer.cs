namespace IAFollowUp
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.auditorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertNewAuditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.administratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRevisionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auditorsToolStripMenuItem,
            this.auditeesToolStripMenuItem,
            this.administratorToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(603, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // auditorsToolStripMenuItem
            // 
            this.auditorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auditViewToolStripMenuItem,
            this.insertNewAuditToolStripMenuItem});
            this.auditorsToolStripMenuItem.Name = "auditorsToolStripMenuItem";
            this.auditorsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.auditorsToolStripMenuItem.Tag = "1";
            this.auditorsToolStripMenuItem.Text = "Auditors";
            this.auditorsToolStripMenuItem.Visible = false;
            // 
            // auditViewToolStripMenuItem
            // 
            this.auditViewToolStripMenuItem.Name = "auditViewToolStripMenuItem";
            this.auditViewToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.auditViewToolStripMenuItem.Tag = "";
            this.auditViewToolStripMenuItem.Text = "Audit View";
            this.auditViewToolStripMenuItem.Click += new System.EventHandler(this.auditViewToolStripMenuItem_Click);
            // 
            // insertNewAuditToolStripMenuItem
            // 
            this.insertNewAuditToolStripMenuItem.Name = "insertNewAuditToolStripMenuItem";
            this.insertNewAuditToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.insertNewAuditToolStripMenuItem.Text = "Insert New Audit";
            this.insertNewAuditToolStripMenuItem.Click += new System.EventHandler(this.insertNewAuditToolStripMenuItem_Click);
            // 
            // auditeesToolStripMenuItem
            // 
            this.auditeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem1});
            this.auditeesToolStripMenuItem.Name = "auditeesToolStripMenuItem";
            this.auditeesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.auditeesToolStripMenuItem.Tag = "2";
            this.auditeesToolStripMenuItem.Text = "Auditees";
            this.auditeesToolStripMenuItem.Visible = false;
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            this.testToolStripMenuItem1.Size = new System.Drawing.Size(96, 22);
            this.testToolStripMenuItem1.Tag = "1";
            this.testToolStripMenuItem1.Text = "Test";
            // 
            // administratorToolStripMenuItem
            // 
            this.administratorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewRevisionsToolStripMenuItem});
            this.administratorToolStripMenuItem.Name = "administratorToolStripMenuItem";
            this.administratorToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.administratorToolStripMenuItem.Tag = "3";
            this.administratorToolStripMenuItem.Text = "Administrator";
            this.administratorToolStripMenuItem.Visible = false;
            // 
            // viewRevisionsToolStripMenuItem
            // 
            this.viewRevisionsToolStripMenuItem.Name = "viewRevisionsToolStripMenuItem";
            this.viewRevisionsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.viewRevisionsToolStripMenuItem.Text = "View Audits/ Revisions";
            this.viewRevisionsToolStripMenuItem.Click += new System.EventHandler(this.viewRevisionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(603, 404);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Internal Audit";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem auditorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem administratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertNewAuditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewRevisionsToolStripMenuItem;
    }
}