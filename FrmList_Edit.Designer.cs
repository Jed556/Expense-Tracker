namespace ExpenseTracker
{
    partial class FrmList_Edit
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
            this.LbDeptName = new System.Windows.Forms.Label();
            this.LbExpenseAmount = new System.Windows.Forms.Label();
            this.TxtExpenseName = new System.Windows.Forms.TextBox();
            this.TxtExpenseAmount = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.LbTitle = new System.Windows.Forms.Label();
            this.BtnDel = new System.Windows.Forms.Button();
            this.TxtExpenseDate = new System.Windows.Forms.TextBox();
            this.lbExpenseDate = new System.Windows.Forms.Label();
            this.LbExpenseTag = new System.Windows.Forms.Label();
            this.CmbExpenseTag = new System.Windows.Forms.ComboBox();
            this.DgvTable = new System.Windows.Forms.DataGridView();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TxtTotalAmount = new System.Windows.Forms.TextBox();
            this.LbTotalAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTable)).BeginInit();
            this.SuspendLayout();
            // 
            // LbDeptName
            // 
            this.LbDeptName.AutoSize = true;
            this.LbDeptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbDeptName.Location = new System.Drawing.Point(47, 98);
            this.LbDeptName.Name = "LbDeptName";
            this.LbDeptName.Size = new System.Drawing.Size(41, 15);
            this.LbDeptName.TabIndex = 1;
            this.LbDeptName.Text = "Name";
            // 
            // LbExpenseAmount
            // 
            this.LbExpenseAmount.AutoSize = true;
            this.LbExpenseAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbExpenseAmount.Location = new System.Drawing.Point(497, 98);
            this.LbExpenseAmount.Name = "LbExpenseAmount";
            this.LbExpenseAmount.Size = new System.Drawing.Size(49, 15);
            this.LbExpenseAmount.TabIndex = 3;
            this.LbExpenseAmount.Text = "Amount";
            // 
            // TxtExpenseName
            // 
            this.TxtExpenseName.Location = new System.Drawing.Point(49, 116);
            this.TxtExpenseName.Name = "TxtExpenseName";
            this.TxtExpenseName.Size = new System.Drawing.Size(238, 20);
            this.TxtExpenseName.TabIndex = 5;
            this.TxtExpenseName.TextChanged += new System.EventHandler(this.TxtExpenseName_TextChanged);
            // 
            // TxtExpenseAmount
            // 
            this.TxtExpenseAmount.Location = new System.Drawing.Point(498, 116);
            this.TxtExpenseAmount.Name = "TxtExpenseAmount";
            this.TxtExpenseAmount.Size = new System.Drawing.Size(162, 20);
            this.TxtExpenseAmount.TabIndex = 7;
            this.TxtExpenseAmount.TextChanged += new System.EventHandler(this.TxtExpenseAmount_TextChanged);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Enabled = false;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BtnAdd.Location = new System.Drawing.Point(169, 153);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(110, 40);
            this.BtnAdd.TabIndex = 8;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(49, 454);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(110, 30);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "Back";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Enabled = false;
            this.BtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BtnSearch.Location = new System.Drawing.Point(405, 153);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(110, 40);
            this.BtnSearch.TabIndex = 10;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Visible = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Enabled = false;
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BtnUpdate.Location = new System.Drawing.Point(49, 153);
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
            this.LbTitle.Text = "List Viewer";
            // 
            // BtnDel
            // 
            this.BtnDel.Enabled = false;
            this.BtnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BtnDel.Location = new System.Drawing.Point(289, 153);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(110, 40);
            this.BtnDel.TabIndex = 13;
            this.BtnDel.Text = "Delete";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // TxtExpenseDate
            // 
            this.TxtExpenseDate.Location = new System.Drawing.Point(698, 116);
            this.TxtExpenseDate.Name = "TxtExpenseDate";
            this.TxtExpenseDate.Size = new System.Drawing.Size(137, 20);
            this.TxtExpenseDate.TabIndex = 15;
            this.TxtExpenseDate.TextChanged += new System.EventHandler(this.TxtExpenseDate_TextChanged);
            // 
            // lbExpenseDate
            // 
            this.lbExpenseDate.AutoSize = true;
            this.lbExpenseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbExpenseDate.Location = new System.Drawing.Point(697, 98);
            this.lbExpenseDate.Name = "lbExpenseDate";
            this.lbExpenseDate.Size = new System.Drawing.Size(33, 15);
            this.lbExpenseDate.TabIndex = 14;
            this.lbExpenseDate.Text = "Date";
            // 
            // LbExpenseTag
            // 
            this.LbExpenseTag.AutoSize = true;
            this.LbExpenseTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbExpenseTag.Location = new System.Drawing.Point(310, 98);
            this.LbExpenseTag.Name = "LbExpenseTag";
            this.LbExpenseTag.Size = new System.Drawing.Size(28, 15);
            this.LbExpenseTag.TabIndex = 17;
            this.LbExpenseTag.Text = "Tag";
            // 
            // CmbExpenseTag
            // 
            this.CmbExpenseTag.FormattingEnabled = true;
            this.CmbExpenseTag.Location = new System.Drawing.Point(311, 115);
            this.CmbExpenseTag.Name = "CmbExpenseTag";
            this.CmbExpenseTag.Size = new System.Drawing.Size(162, 21);
            this.CmbExpenseTag.TabIndex = 19;
            this.CmbExpenseTag.Text = "Select Tag";
            // 
            // DgvTable
            // 
            this.DgvTable.AllowUserToResizeColumns = false;
            this.DgvTable.AllowUserToResizeRows = false;
            this.DgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTable.Location = new System.Drawing.Point(49, 210);
            this.DgvTable.Name = "DgvTable";
            this.DgvTable.Size = new System.Drawing.Size(911, 226);
            this.DgvTable.TabIndex = 20;
            this.DgvTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTable_CellClick);
            this.DgvTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTable_CellValueChanged);
            this.DgvTable.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvTable_UserAddedRow);
            this.DgvTable.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvTable_UserDeletedRow);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(176, 454);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(110, 30);
            this.BtnSave.TabIndex = 21;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtTotalAmount
            // 
            this.TxtTotalAmount.Location = new System.Drawing.Point(860, 460);
            this.TxtTotalAmount.Name = "TxtTotalAmount";
            this.TxtTotalAmount.ReadOnly = true;
            this.TxtTotalAmount.Size = new System.Drawing.Size(100, 20);
            this.TxtTotalAmount.TabIndex = 22;
            // 
            // LbTotalAmount
            // 
            this.LbTotalAmount.AutoSize = true;
            this.LbTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LbTotalAmount.Location = new System.Drawing.Point(821, 463);
            this.LbTotalAmount.Name = "LbTotalAmount";
            this.LbTotalAmount.Size = new System.Drawing.Size(34, 15);
            this.LbTotalAmount.TabIndex = 23;
            this.LbTotalAmount.Text = "Total";
            // 
            // FrmList_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 523);
            this.Controls.Add(this.LbTotalAmount);
            this.Controls.Add(this.TxtTotalAmount);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.DgvTable);
            this.Controls.Add(this.CmbExpenseTag);
            this.Controls.Add(this.LbExpenseTag);
            this.Controls.Add(this.TxtExpenseDate);
            this.Controls.Add(this.lbExpenseDate);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.LbTitle);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.TxtExpenseAmount);
            this.Controls.Add(this.TxtExpenseName);
            this.Controls.Add(this.LbExpenseAmount);
            this.Controls.Add(this.LbDeptName);
            this.MaximizeBox = false;
            this.Name = "FrmList_Edit";
            this.Text = "Expense Tracker";
            ((System.ComponentModel.ISupportInitialize)(this.DgvTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LbDeptName;
        private System.Windows.Forms.Label LbExpenseAmount;
        private System.Windows.Forms.TextBox TxtExpenseName;
        private System.Windows.Forms.TextBox TxtExpenseAmount;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.TextBox TxtExpenseDate;
        private System.Windows.Forms.Label lbExpenseDate;
        private System.Windows.Forms.Label LbExpenseTag;
        private System.Windows.Forms.ComboBox CmbExpenseTag;
        private System.Windows.Forms.DataGridView DgvTable;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TxtTotalAmount;
        private System.Windows.Forms.Label LbTotalAmount;
    }
}

