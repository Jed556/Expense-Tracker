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
            this.BtnListView = new System.Windows.Forms.Button();
            this.BtnProfile = new System.Windows.Forms.Button();
            this.BtnUpdates = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Poppins", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.Location = new System.Drawing.Point(37, 48);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(248, 51);
            this.LbTitle.TabIndex = 0;
            this.LbTitle.Text = "Welcome User!";
            // 
            // BtnListView
            // 
            this.BtnListView.Location = new System.Drawing.Point(32, 140);
            this.BtnListView.Name = "BtnListView";
            this.BtnListView.Size = new System.Drawing.Size(193, 103);
            this.BtnListView.TabIndex = 1;
            this.BtnListView.Text = "View Lists";
            this.BtnListView.UseVisualStyleBackColor = true;
            this.BtnListView.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnProfile
            // 
            this.BtnProfile.Location = new System.Drawing.Point(254, 140);
            this.BtnProfile.Name = "BtnProfile";
            this.BtnProfile.Size = new System.Drawing.Size(193, 103);
            this.BtnProfile.TabIndex = 3;
            this.BtnProfile.Text = "Profile";
            this.BtnProfile.UseVisualStyleBackColor = true;
            // 
            // BtnUpdates
            // 
            this.BtnUpdates.Location = new System.Drawing.Point(35, 270);
            this.BtnUpdates.Name = "BtnUpdates";
            this.BtnUpdates.Size = new System.Drawing.Size(193, 103);
            this.BtnUpdates.TabIndex = 4;
            this.BtnUpdates.Text = "Updates";
            this.BtnUpdates.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(476, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 103);
            this.button1.TabIndex = 5;
            this.button1.Text = "Profile";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(254, 270);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 103);
            this.button2.TabIndex = 6;
            this.button2.Text = "Updates";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 451);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnUpdates);
            this.Controls.Add(this.BtnProfile);
            this.Controls.Add(this.BtnListView);
            this.Controls.Add(this.LbTitle);
            this.Name = "FrmHome";
            this.Text = "Expense Tracker";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Button BtnListView;
        private System.Windows.Forms.Button BtnProfile;
        private System.Windows.Forms.Button BtnUpdates;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}