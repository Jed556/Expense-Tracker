namespace ExpenseTracker
{
    partial class FrmList
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
            this.DgvTable = new System.Windows.Forms.DataGridView();
            this.LbTitle = new System.Windows.Forms.Label();
            this.CmbExpenseTag = new System.Windows.Forms.ComboBox();
            this.LbExpenseTag = new System.Windows.Forms.Label();
            this.TxtExpenseDate = new System.Windows.Forms.TextBox();
            this.lbExpenseDate = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtExpenseAmount = new System.Windows.Forms.TextBox();
            this.TxtExpenseName = new System.Windows.Forms.TextBox();
            this.TxtExpenseID = new System.Windows.Forms.TextBox();
            this.LbExpenseAmount = new System.Windows.Forms.Label();
            this.LbDeptName = new System.Windows.Forms.Label();
            this.LbDeptID = new System.Windows.Forms.Label();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.CmbListName = new System.Windows.Forms.ComboBox();
            this.LbListName = new System.Windows.Forms.Label();
            this.TxtNewList = new System.Windows.Forms.TextBox();
            this.LbNewList = new System.Windows.Forms.Label();
            this.BtnCreateList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTable)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvTable
            // 
            this.DgvTable.AllowUserToResizeColumns = false;
            this.DgvTable.AllowUserToResizeRows = false;
            this.DgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTable.Location = new System.Drawing.Point(49, 261);
            this.DgvTable.Name = "DgvTable";
            this.DgvTable.Size = new System.Drawing.Size(911, 226);
            this.DgvTable.TabIndex = 21;
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.LbTitle.Location = new System.Drawing.Point(43, 32);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(159, 31);
            this.LbTitle.TabIndex = 22;
            this.LbTitle.Text = "Viewing List";
            // 
            // CmbExpenseTag
            // 
            this.CmbExpenseTag.FormattingEnabled = true;
            this.CmbExpenseTag.Location = new System.Drawing.Point(437, 160);
            this.CmbExpenseTag.Name = "CmbExpenseTag";
            this.CmbExpenseTag.Size = new System.Drawing.Size(162, 21);
            this.CmbExpenseTag.TabIndex = 33;
            this.CmbExpenseTag.Text = "Select Tag";
            // 
            // LbExpenseTag
            // 
            this.LbExpenseTag.AutoSize = true;
            this.LbExpenseTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbExpenseTag.Location = new System.Drawing.Point(436, 143);
            this.LbExpenseTag.Name = "LbExpenseTag";
            this.LbExpenseTag.Size = new System.Drawing.Size(28, 15);
            this.LbExpenseTag.TabIndex = 32;
            this.LbExpenseTag.Text = "Tag";
            // 
            // TxtExpenseDate
            // 
            this.TxtExpenseDate.Location = new System.Drawing.Point(824, 161);
            this.TxtExpenseDate.Name = "TxtExpenseDate";
            this.TxtExpenseDate.Size = new System.Drawing.Size(137, 20);
            this.TxtExpenseDate.TabIndex = 31;
            // 
            // lbExpenseDate
            // 
            this.lbExpenseDate.AutoSize = true;
            this.lbExpenseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbExpenseDate.Location = new System.Drawing.Point(823, 143);
            this.lbExpenseDate.Name = "lbExpenseDate";
            this.lbExpenseDate.Size = new System.Drawing.Size(33, 15);
            this.lbExpenseDate.TabIndex = 30;
            this.lbExpenseDate.Text = "Date";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Enabled = false;
            this.BtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BtnSearch.Location = new System.Drawing.Point(49, 201);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(110, 40);
            this.BtnSearch.TabIndex = 29;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtExpenseAmount
            // 
            this.TxtExpenseAmount.Location = new System.Drawing.Point(624, 161);
            this.TxtExpenseAmount.Name = "TxtExpenseAmount";
            this.TxtExpenseAmount.Size = new System.Drawing.Size(162, 20);
            this.TxtExpenseAmount.TabIndex = 28;
            // 
            // TxtExpenseName
            // 
            this.TxtExpenseName.Location = new System.Drawing.Point(175, 161);
            this.TxtExpenseName.Name = "TxtExpenseName";
            this.TxtExpenseName.Size = new System.Drawing.Size(238, 20);
            this.TxtExpenseName.TabIndex = 27;
            // 
            // TxtExpenseID
            // 
            this.TxtExpenseID.Location = new System.Drawing.Point(48, 161);
            this.TxtExpenseID.Name = "TxtExpenseID";
            this.TxtExpenseID.Size = new System.Drawing.Size(91, 20);
            this.TxtExpenseID.TabIndex = 26;
            this.TxtExpenseID.TextChanged += new System.EventHandler(this.TxtExpenseID_TextChanged);
            // 
            // LbExpenseAmount
            // 
            this.LbExpenseAmount.AutoSize = true;
            this.LbExpenseAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbExpenseAmount.Location = new System.Drawing.Point(623, 143);
            this.LbExpenseAmount.Name = "LbExpenseAmount";
            this.LbExpenseAmount.Size = new System.Drawing.Size(49, 15);
            this.LbExpenseAmount.TabIndex = 25;
            this.LbExpenseAmount.Text = "Amount";
            // 
            // LbDeptName
            // 
            this.LbDeptName.AutoSize = true;
            this.LbDeptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbDeptName.Location = new System.Drawing.Point(173, 143);
            this.LbDeptName.Name = "LbDeptName";
            this.LbDeptName.Size = new System.Drawing.Size(41, 15);
            this.LbDeptName.TabIndex = 24;
            this.LbDeptName.Text = "Name";
            // 
            // LbDeptID
            // 
            this.LbDeptID.AutoSize = true;
            this.LbDeptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbDeptID.Location = new System.Drawing.Point(46, 143);
            this.LbDeptID.Name = "LbDeptID";
            this.LbDeptID.Size = new System.Drawing.Size(70, 15);
            this.LbDeptID.TabIndex = 23;
            this.LbDeptID.Text = "Expense ID";
            // 
            // BtnEdit
            // 
            this.BtnEdit.Enabled = false;
            this.BtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BtnEdit.Location = new System.Drawing.Point(169, 201);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(110, 40);
            this.BtnEdit.TabIndex = 34;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Location = new System.Drawing.Point(49, 509);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(110, 30);
            this.BtnBack.TabIndex = 35;
            this.BtnBack.Text = "Back";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // CmbListName
            // 
            this.CmbListName.FormattingEnabled = true;
            this.CmbListName.Location = new System.Drawing.Point(47, 104);
            this.CmbListName.Name = "CmbListName";
            this.CmbListName.Size = new System.Drawing.Size(162, 21);
            this.CmbListName.TabIndex = 37;
            this.CmbListName.Text = "Select Tag";
            this.CmbListName.Layout += new System.Windows.Forms.LayoutEventHandler(this.CmbListName_Layout);
            // 
            // LbListName
            // 
            this.LbListName.AutoSize = true;
            this.LbListName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbListName.Location = new System.Drawing.Point(46, 87);
            this.LbListName.Name = "LbListName";
            this.LbListName.Size = new System.Drawing.Size(28, 15);
            this.LbListName.TabIndex = 36;
            this.LbListName.Text = "Tag";
            // 
            // TxtNewList
            // 
            this.TxtNewList.Location = new System.Drawing.Point(240, 105);
            this.TxtNewList.Name = "TxtNewList";
            this.TxtNewList.Size = new System.Drawing.Size(238, 20);
            this.TxtNewList.TabIndex = 39;
            // 
            // LbNewList
            // 
            this.LbNewList.AutoSize = true;
            this.LbNewList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbNewList.Location = new System.Drawing.Point(238, 87);
            this.LbNewList.Name = "LbNewList";
            this.LbNewList.Size = new System.Drawing.Size(54, 15);
            this.LbNewList.TabIndex = 38;
            this.LbNewList.Text = "New List";
            // 
            // BtnCreateList
            // 
            this.BtnCreateList.Location = new System.Drawing.Point(489, 105);
            this.BtnCreateList.Name = "BtnCreateList";
            this.BtnCreateList.Size = new System.Drawing.Size(90, 20);
            this.BtnCreateList.TabIndex = 40;
            this.BtnCreateList.Text = "Create";
            this.BtnCreateList.UseVisualStyleBackColor = true;
            this.BtnCreateList.Click += new System.EventHandler(this.BtnCreateList_Click);
            // 
            // FrmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 563);
            this.Controls.Add(this.BtnCreateList);
            this.Controls.Add(this.TxtNewList);
            this.Controls.Add(this.LbNewList);
            this.Controls.Add(this.CmbListName);
            this.Controls.Add(this.LbListName);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.CmbExpenseTag);
            this.Controls.Add(this.LbExpenseTag);
            this.Controls.Add(this.TxtExpenseDate);
            this.Controls.Add(this.lbExpenseDate);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.TxtExpenseAmount);
            this.Controls.Add(this.TxtExpenseName);
            this.Controls.Add(this.TxtExpenseID);
            this.Controls.Add(this.LbExpenseAmount);
            this.Controls.Add(this.LbDeptName);
            this.Controls.Add(this.LbDeptID);
            this.Controls.Add(this.LbTitle);
            this.Controls.Add(this.DgvTable);
            this.Name = "FrmList";
            this.Text = "FrmList";
            ((System.ComponentModel.ISupportInitialize)(this.DgvTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvTable;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.ComboBox CmbExpenseTag;
        private System.Windows.Forms.Label LbExpenseTag;
        private System.Windows.Forms.TextBox TxtExpenseDate;
        private System.Windows.Forms.Label lbExpenseDate;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtExpenseAmount;
        private System.Windows.Forms.TextBox TxtExpenseName;
        private System.Windows.Forms.TextBox TxtExpenseID;
        private System.Windows.Forms.Label LbExpenseAmount;
        private System.Windows.Forms.Label LbDeptName;
        private System.Windows.Forms.Label LbDeptID;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.ComboBox CmbListName;
        private System.Windows.Forms.Label LbListName;
        private System.Windows.Forms.TextBox TxtNewList;
        private System.Windows.Forms.Label LbNewList;
        private System.Windows.Forms.Button BtnCreateList;
    }
}