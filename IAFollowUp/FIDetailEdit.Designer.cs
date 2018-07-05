namespace IAFollowUp
{
    partial class FIDetailEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIDetailEdit));
            this.txtHeaderTitle = new System.Windows.Forms.TextBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDetailDescription = new System.Windows.Forms.Label();
            this.dtpActionDate = new System.Windows.Forms.DateTimePicker();
            this.lblActionDate = new System.Windows.Forms.Label();
            this.lblActionReq = new System.Windows.Forms.Label();
            this.txtActionReq = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHeaderTitle
            // 
            this.txtHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtHeaderTitle.Location = new System.Drawing.Point(226, 31);
            this.txtHeaderTitle.MaxLength = 500;
            this.txtHeaderTitle.Multiline = true;
            this.txtHeaderTitle.Name = "txtHeaderTitle";
            this.txtHeaderTitle.ReadOnly = true;
            this.txtHeaderTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHeaderTitle.Size = new System.Drawing.Size(468, 72);
            this.txtHeaderTitle.TabIndex = 21;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHeaderTitle.Location = new System.Drawing.Point(112, 60);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(95, 20);
            this.lblHeaderTitle.TabIndex = 34;
            this.lblHeaderTitle.Text = "Header Title";
            // 
            // txtCategory
            // 
            this.txtCategory.Enabled = false;
            this.txtCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtCategory.Location = new System.Drawing.Point(226, 127);
            this.txtCategory.MaxLength = 3;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(184, 22);
            this.txtCategory.TabIndex = 42;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCategory.Location = new System.Drawing.Point(134, 127);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(73, 20);
            this.lblCategory.TabIndex = 41;
            this.lblCategory.Text = "Category";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDetails.Location = new System.Drawing.Point(361, 195);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(85, 25);
            this.lblDetails.TabIndex = 49;
            this.lblDetails.Text = "Details";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDescription.Location = new System.Drawing.Point(229, 233);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(468, 72);
            this.txtDescription.TabIndex = 50;
            // 
            // lblDetailDescription
            // 
            this.lblDetailDescription.AutoSize = true;
            this.lblDetailDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDetailDescription.Location = new System.Drawing.Point(118, 259);
            this.lblDetailDescription.Name = "lblDetailDescription";
            this.lblDetailDescription.Size = new System.Drawing.Size(89, 20);
            this.lblDetailDescription.TabIndex = 51;
            this.lblDetailDescription.Text = "Description";
            // 
            // dtpActionDate
            // 
            this.dtpActionDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpActionDate.CustomFormat = "dd.MM.yyyy";
            this.dtpActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpActionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActionDate.Location = new System.Drawing.Point(229, 443);
            this.dtpActionDate.Name = "dtpActionDate";
            this.dtpActionDate.Size = new System.Drawing.Size(184, 22);
            this.dtpActionDate.TabIndex = 52;
            // 
            // lblActionDate
            // 
            this.lblActionDate.AutoSize = true;
            this.lblActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblActionDate.Location = new System.Drawing.Point(114, 444);
            this.lblActionDate.Name = "lblActionDate";
            this.lblActionDate.Size = new System.Drawing.Size(93, 20);
            this.lblActionDate.TabIndex = 53;
            this.lblActionDate.Text = "Action Date";
            // 
            // lblActionReq
            // 
            this.lblActionReq.AutoSize = true;
            this.lblActionReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblActionReq.Location = new System.Drawing.Point(84, 364);
            this.lblActionReq.Name = "lblActionReq";
            this.lblActionReq.Size = new System.Drawing.Size(123, 20);
            this.lblActionReq.TabIndex = 54;
            this.lblActionReq.Text = "Action Required";
            // 
            // txtActionReq
            // 
            this.txtActionReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtActionReq.Location = new System.Drawing.Point(229, 338);
            this.txtActionReq.MaxLength = 500;
            this.txtActionReq.Multiline = true;
            this.txtActionReq.Name = "txtActionReq";
            this.txtActionReq.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtActionReq.Size = new System.Drawing.Size(468, 72);
            this.txtActionReq.TabIndex = 55;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::IAFollowUp.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(729, 444);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 60);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FIDetailEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 535);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtActionReq);
            this.Controls.Add(this.lblActionReq);
            this.Controls.Add(this.dtpActionDate);
            this.Controls.Add(this.lblActionDate);
            this.Controls.Add(this.lblDetailDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblHeaderTitle);
            this.Controls.Add(this.txtHeaderTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FIDetailEdit";
            this.Text = "FIDetailEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHeaderTitle;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDetailDescription;
        private System.Windows.Forms.DateTimePicker dtpActionDate;
        private System.Windows.Forms.Label lblActionDate;
        private System.Windows.Forms.Label lblActionReq;
        private System.Windows.Forms.TextBox txtActionReq;
        private System.Windows.Forms.Button btnSave;
    }
}