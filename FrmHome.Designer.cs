namespace ExpenseTracker
{
    partial class FrmHome
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
            this.LbTitle = new System.Windows.Forms.Label();
            this.BtnLists = new System.Windows.Forms.Button();
            this.BtnProfile = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.BtnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Poppins", 20F);
            this.LbTitle.Location = new System.Drawing.Point(35, 46);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(232, 48);
            this.LbTitle.TabIndex = 0;
            this.LbTitle.Text = "Welcome User!";
            // 
            // BtnLists
            // 
            this.BtnLists.Location = new System.Drawing.Point(43, 137);
            this.BtnLists.Name = "BtnLists";
            this.BtnLists.Size = new System.Drawing.Size(160, 100);
            this.BtnLists.TabIndex = 1;
            this.BtnLists.Text = "View List";
            this.BtnLists.UseVisualStyleBackColor = true;
            this.BtnLists.Click += new System.EventHandler(this.BtnLists_Click);
            // 
            // BtnProfile
            // 
            this.BtnProfile.Enabled = false;
            this.BtnProfile.Location = new System.Drawing.Point(233, 137);
            this.BtnProfile.Name = "BtnProfile";
            this.BtnProfile.Size = new System.Drawing.Size(160, 100);
            this.BtnProfile.TabIndex = 2;
            this.BtnProfile.Text = "View Proifile";
            this.BtnProfile.UseVisualStyleBackColor = true;
            this.BtnProfile.Click += new System.EventHandler(this.BtnProfile_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(425, 137);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(160, 100);
            this.BtnUpdate.TabIndex = 3;
            this.BtnUpdate.Text = "Updates";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.Enabled = false;
            this.BtnAbout.Location = new System.Drawing.Point(43, 265);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(160, 100);
            this.BtnAbout.TabIndex = 4;
            this.BtnAbout.Text = "About";
            this.BtnAbout.UseVisualStyleBackColor = true;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // BtnLogout
            // 
            this.BtnLogout.Location = new System.Drawing.Point(233, 265);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(160, 100);
            this.BtnLogout.TabIndex = 5;
            this.BtnLogout.Text = "Logout";
            this.BtnLogout.UseVisualStyleBackColor = true;
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Controls.Add(this.BtnLogout);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnProfile);
            this.Controls.Add(this.BtnLists);
            this.Controls.Add(this.LbTitle);
            this.Name = "FrmHome";
            this.Text = "Expense Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Button BtnLists;
        private System.Windows.Forms.Button BtnProfile;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnAbout;
        private System.Windows.Forms.Button BtnLogout;
    }
}