namespace ExpenseTracker
{
    partial class FrmMain
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
            this.LbDeptID = new System.Windows.Forms.Label();
            this.LbDeptName = new System.Windows.Forms.Label();
            this.LbExpenseAmount = new System.Windows.Forms.Label();
            this.TxtExpenseID = new System.Windows.Forms.TextBox();
            this.TxtExpenseName = new System.Windows.Forms.TextBox();
            this.TxtExpenseAmount = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.LbTitle = new System.Windows.Forms.Label();
            this.BtnDel = new System.Windows.Forms.Button();
            this.TxtExpenseDate = new System.Windows.Forms.TextBox();
            this.lbExpenseDate = new System.Windows.Forms.Label();
            this.LbExpenseTag = new System.Windows.Forms.Label();
            this.CmbExpenseTag = new System.Windows.Forms.ComboBox();
            this.DgvTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTable)).BeginInit();
            this.SuspendLayout();
            // 
            // LbDeptID
            // 
            this.LbDeptID.AutoSize = true;
            this.LbDeptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbDeptID.Location = new System.Drawing.Point(46, 98);
            this.LbDeptID.Name = "LbDeptID";
            this.LbDeptID.Size = new System.Drawing.Size(70, 15);
            this.LbDeptID.TabIndex = 0;
            this.LbDeptID.Text = "Expense ID";
            // 
            // LbDeptName
            // 
            this.LbDeptName.AutoSize = true;
            this.LbDeptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbDeptName.Location = new System.Drawing.Point(173, 98);
            this.LbDeptName.Name = "LbDeptName";
            this.LbDeptName.Size = new System.Drawing.Size(41, 15);
            this.LbDeptName.TabIndex = 1;
            this.LbDeptName.Text = "Name";
            // 
            // LbExpenseAmount
            // 
            this.LbExpenseAmount.AutoSize = true;
            this.LbExpenseAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbExpenseAmount.Location = new System.Drawing.Point(623, 98);
            this.LbExpenseAmount.Name = "LbExpenseAmount";
            this.LbExpenseAmount.Size = new System.Drawing.Size(49, 15);
            this.LbExpenseAmount.TabIndex = 3;
            this.LbExpenseAmount.Text = "Amount";
            // 
            // TxtExpenseID
            // 
            this.TxtExpenseID.Location = new System.Drawing.Point(48, 116);
            this.TxtExpenseID.Name = "TxtExpenseID";
            this.TxtExpenseID.Size = new System.Drawing.Size(91, 20);
            this.TxtExpenseID.TabIndex = 4;
            this.TxtExpenseID.TextChanged += new System.EventHandler(this.TxtDeptID_TextChanged);
            // 
            // TxtExpenseName
            // 
            this.TxtExpenseName.Location = new System.Drawing.Point(175, 116);
            this.TxtExpenseName.Name = "TxtExpenseName";
            this.TxtExpenseName.Size = new System.Drawing.Size(238, 20);
            this.TxtExpenseName.TabIndex = 5;
            this.TxtExpenseName.TextChanged += new System.EventHandler(this.TxtDeptName_TextChanged);
            // 
            // TxtExpenseAmount
            // 
            this.TxtExpenseAmount.Location = new System.Drawing.Point(624, 116);
            this.TxtExpenseAmount.Name = "TxtExpenseAmount";
            this.TxtExpenseAmount.Size = new System.Drawing.Size(162, 20);
            this.TxtExpenseAmount.TabIndex = 7;
            this.TxtExpenseAmount.TextChanged += new System.EventHandler(this.TxtDeptBudget_TextChanged);
            // 
            // BtnSave
            // 
            this.BtnSave.Enabled = false;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BtnSave.Location = new System.Drawing.Point(289, 156);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(110, 40);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(49, 454);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(237, 30);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Enabled = false;
            this.BtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BtnSearch.Location = new System.Drawing.Point(49, 156);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(110, 40);
            this.BtnSearch.TabIndex = 10;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Enabled = false;
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BtnUpdate.Location = new System.Drawing.Point(169, 156);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(110, 40);
            this.BtnUpdate.TabIndex = 11;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.LbTitle.Location = new System.Drawing.Point(43, 32);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(147, 31);
            this.LbTitle.TabIndex = 12;
            this.LbTitle.Text = "Editing List";
            // 
            // BtnDel
            // 
            this.BtnDel.Enabled = false;
            this.BtnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BtnDel.Location = new System.Drawing.Point(409, 156);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(110, 40);
            this.BtnDel.TabIndex = 13;
            this.BtnDel.Text = "Delete";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // TxtExpenseDate
            // 
            this.TxtExpenseDate.Enabled = false;
            this.TxtExpenseDate.Location = new System.Drawing.Point(824, 116);
            this.TxtExpenseDate.Name = "TxtExpenseDate";
            this.TxtExpenseDate.Size = new System.Drawing.Size(137, 20);
            this.TxtExpenseDate.TabIndex = 15;
            this.TxtExpenseDate.Visible = false;
            // 
            // lbExpenseDate
            // 
            this.lbExpenseDate.AutoSize = true;
            this.lbExpenseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbExpenseDate.Location = new System.Drawing.Point(823, 98);
            this.lbExpenseDate.Name = "lbExpenseDate";
            this.lbExpenseDate.Size = new System.Drawing.Size(33, 15);
            this.lbExpenseDate.TabIndex = 14;
            this.lbExpenseDate.Text = "Date";
            this.lbExpenseDate.Visible = false;
            // 
            // LbExpenseTag
            // 
            this.LbExpenseTag.AutoSize = true;
            this.LbExpenseTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbExpenseTag.Location = new System.Drawing.Point(436, 98);
            this.LbExpenseTag.Name = "LbExpenseTag";
            this.LbExpenseTag.Size = new System.Drawing.Size(28, 15);
            this.LbExpenseTag.TabIndex = 17;
            this.LbExpenseTag.Text = "Tag";
            // 
            // CmbExpenseTag
            // 
            this.CmbExpenseTag.FormattingEnabled = true;
            this.CmbExpenseTag.Location = new System.Drawing.Point(437, 115);
            this.CmbExpenseTag.Name = "CmbExpenseTag";
            this.CmbExpenseTag.Size = new System.Drawing.Size(162, 21);
            this.CmbExpenseTag.TabIndex = 19;
            this.CmbExpenseTag.Text = "Select Tag";
            this.CmbExpenseTag.Layout += new System.Windows.Forms.LayoutEventHandler(this.CmbExpenseTag_Layout);
            // 
            // DgvTable
            // 
            this.DgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTable.Location = new System.Drawing.Point(49, 210);
            this.DgvTable.Name = "DgvTable";
            this.DgvTable.Size = new System.Drawing.Size(911, 142);
            this.DgvTable.TabIndex = 20;
            this.DgvTable.Layout += new System.Windows.Forms.LayoutEventHandler(this.DgvTable_Layout);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 523);
            this.Controls.Add(this.DgvTable);
            this.Controls.Add(this.CmbExpenseTag);
            this.Controls.Add(this.LbExpenseTag);
            this.Controls.Add(this.TxtExpenseDate);
            this.Controls.Add(this.lbExpenseDate);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.LbTitle);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtExpenseAmount);
            this.Controls.Add(this.TxtExpenseName);
            this.Controls.Add(this.TxtExpenseID);
            this.Controls.Add(this.LbExpenseAmount);
            this.Controls.Add(this.LbDeptName);
            this.Controls.Add(this.LbDeptID);
            this.Name = "FrmMain";
            this.Text = "Expense Tracker";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbDeptID;
        private System.Windows.Forms.Label LbDeptName;
        private System.Windows.Forms.Label LbExpenseAmount;
        private System.Windows.Forms.TextBox TxtExpenseID;
        private System.Windows.Forms.TextBox TxtExpenseName;
        private System.Windows.Forms.TextBox TxtExpenseAmount;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.TextBox TxtExpenseDate;
        private System.Windows.Forms.Label lbExpenseDate;
        private System.Windows.Forms.Label LbExpenseTag;
        private System.Windows.Forms.ComboBox CmbExpenseTag;
        private System.Windows.Forms.DataGridView DgvTable;
    }
}

