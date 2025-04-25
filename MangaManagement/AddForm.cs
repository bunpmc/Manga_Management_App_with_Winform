using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangaManagement.Data;
using MangaManagement.Models;
using MangaManagement.Utils;

namespace MangaManagement
{
    public partial class AddForm : Form
    {
        private List<int> selectedCategoryIds = new List<int>();
        public AddForm()
        {
            InitializeComponent();

            this.Load += AddForm_Load;

            Utils.Utils.CreateCategoryDropdown(OnCategoriesSelected);
            btnCategory.Click += (s, e) =>
            {
                Utils.Utils.ShowCategoryDropdown(btnCategory);
            };
            //this.BackColor = Color.Magenta;
            //this.TransparencyKey = Color.Magenta;
        }
        private void OnCategoriesSelected(List<int> categoryIds)
        {
            selectedCategoryIds = categoryIds;
        }
        private void AddForm_Load(object sender, EventArgs e)
        {
            using var db = new ApplicationDbContext();
            var categories = db.Categories.ToList();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                    {
                        MangaPicture.Image = new Bitmap(Image.FromStream(fs));
                    }
                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show(ex.Message, "Upload image failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                    selectedCategoryIds.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Title, Author và Category!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new ApplicationDbContext();
            var story = new Story
            {
                Title = txtName.Text,
                Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? "Not Enter" : txtDescription.Text,
                Author = txtAuthor.Text,
                Image = MangaPicture.Image != null ? Utils.Utils.ImageToByteArray(MangaPicture.Image) : null,
                Categories = db.Categories
                   .Where(c => selectedCategoryIds.Contains(c.Id))
                   .ToList()
            };

            db.Stories.Add(story);
            db.SaveChanges();

            this.Close();
        }
    }
}
