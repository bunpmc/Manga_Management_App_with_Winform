namespace MangaManagement
{
    partial class EditForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MangaPicture = new PictureBox();
            btnDelete = new Button();
            btnBrowse = new Button();
            btnSave = new Button();
            openFileDialog1 = new OpenFileDialog();
            txtAuthor = new TextBox();
            txtName = new TextBox();
            txtDescription = new TextBox();
            btnCategory = new Button();
            ((System.ComponentModel.ISupportInitialize)MangaPicture).BeginInit();
            SuspendLayout();
            // 
            // MangaPicture
            // 
            MangaPicture.BorderStyle = BorderStyle.FixedSingle;
            MangaPicture.Location = new Point(12, 14);
            MangaPicture.Name = "MangaPicture";
            MangaPicture.Size = new Size(142, 205);
            MangaPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            MangaPicture.TabIndex = 2;
            MangaPicture.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(478, 14);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(12, 236);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(142, 37);
            btnBrowse.TabIndex = 7;
            btnBrowse.Text = "Browse Image";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(478, 75);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnEdit_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(173, 78);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.PlaceholderText = "Author";
            txtAuthor.Size = new Size(277, 31);
            txtAuthor.TabIndex = 15;
            // 
            // txtName
            // 
            txtName.Location = new Point(173, 17);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(277, 31);
            txtName.TabIndex = 14;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(173, 192);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Description";
            txtDescription.ScrollBars = ScrollBars.Both;
            txtDescription.Size = new Size(277, 141);
            txtDescription.TabIndex = 13;
            // 
            // btnCategory
            // 
            btnCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCategory.ForeColor = SystemColors.ActiveCaptionText;
            btnCategory.Location = new Point(173, 138);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(277, 32);
            btnCategory.TabIndex = 20;
            btnCategory.Text = "Category ▼\r\n";
            btnCategory.UseVisualStyleBackColor = true;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 364);
            Controls.Add(btnCategory);
            Controls.Add(txtAuthor);
            Controls.Add(txtName);
            Controls.Add(txtDescription);
            Controls.Add(btnSave);
            Controls.Add(btnBrowse);
            Controls.Add(btnDelete);
            Controls.Add(MangaPicture);
            Name = "EditForm";
            Text = "Manga Editing";
            ((System.ComponentModel.ISupportInitialize)MangaPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox MangaPicture;
        private Button btnDelete;
        private Button btnBrowse;
        private Button btnSave;
        private OpenFileDialog openFileDialog1;
        private TextBox txtAuthor;
        private TextBox txtName;
        private TextBox txtDescription;
        private Button btnCategory;
    }
}
