using MangaManagement.Utils;

namespace MangaManagement
{
    partial class MainForm
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
            dataGridView1 = new DataGridView();
            txtSearch = new TextBox();
            cmbSort = new ComboBox();
            btnAdd = new RoundedButton();
            btnSearch = new RoundedButton();
            btnCategory = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 118);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(851, 332);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Location = new Point(513, 25);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Manga Name or Author";
            txtSearch.Size = new Size(223, 31);
            txtSearch.TabIndex = 1;
            // 
            // cmbSort
            // 
            cmbSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbSort.FormattingEnabled = true;
            cmbSort.Location = new Point(513, 62);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(162, 33);
            cmbSort.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Teal;
            btnAdd.BorderRadius = 5;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(12, 36);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(225, 43);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add a new Manga";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.Teal;
            btnSearch.BorderRadius = 5;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(742, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(97, 37);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnCategory
            // 
            btnCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCategory.ForeColor = SystemColors.ActiveCaptionText;
            btnCategory.Location = new Point(685, 63);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(154, 32);
            btnCategory.TabIndex = 5;
            btnCategory.Text = "Category ▼\r\n";
            btnCategory.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(851, 450);
            Controls.Add(btnCategory);
            Controls.Add(btnAdd);
            Controls.Add(cmbSort);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dataGridView1);
            ForeColor = Color.Snow;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manga Management";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private DataGridView dataGridView1;
        private TextBox txtSearch;
        private ComboBox cmbSort;
        private RoundedButton btnAdd;
        private RoundedButton btnSearch;
        private Button btnCategory;
    }
}