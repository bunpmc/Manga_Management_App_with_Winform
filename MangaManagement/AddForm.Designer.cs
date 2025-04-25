namespace MangaManagement
{
    partial class AddForm
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
            btnSave = new Button();
            btnBrowse = new Button();
            MangaPicture = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            txtAuthor = new TextBox();
            txtName = new TextBox();
            txtDescription = new TextBox();
            btnCategory = new Button();
            ((System.ComponentModel.ISupportInitialize)MangaPicture).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(491, 43);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnAdd_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(12, 237);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(142, 37);
            btnBrowse.TabIndex = 14;
            btnBrowse.Text = "Browse Image";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // MangaPicture
            // 
            MangaPicture.BorderStyle = BorderStyle.FixedSingle;
            MangaPicture.Location = new Point(12, 12);
            MangaPicture.Name = "MangaPicture";
            MangaPicture.Size = new Size(142, 205);
            MangaPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            MangaPicture.TabIndex = 11;
            MangaPicture.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(173, 71);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.PlaceholderText = "Author";
            txtAuthor.Size = new Size(286, 31);
            txtAuthor.TabIndex = 18;
            // 
            // txtName
            // 
            txtName.Location = new Point(173, 12);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(286, 31);
            txtName.TabIndex = 17;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(173, 193);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Description";
            txtDescription.ScrollBars = ScrollBars.Both;
            txtDescription.Size = new Size(286, 147);
            txtDescription.TabIndex = 16;
            // 
            // btnCategory
            // 
            btnCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCategory.ForeColor = SystemColors.ActiveCaptionText;
            btnCategory.Location = new Point(173, 133);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(286, 32);
            btnCategory.TabIndex = 19;
            btnCategory.Text = "Category ▼\r\n";
            btnCategory.UseVisualStyleBackColor = true;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 381);
            Controls.Add(btnCategory);
            Controls.Add(txtAuthor);
            Controls.Add(txtName);
            Controls.Add(txtDescription);
            Controls.Add(btnSave);
            Controls.Add(btnBrowse);
            Controls.Add(MangaPicture);
            Name = "AddForm";
            Text = "Add Manga";
            ((System.ComponentModel.ISupportInitialize)MangaPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnBrowse;
        private PictureBox MangaPicture;
        private OpenFileDialog openFileDialog1;
        private TextBox txtAuthor;
        private TextBox txtName;
        private TextBox txtDescription;
        private Button btnCategory;
    }
}