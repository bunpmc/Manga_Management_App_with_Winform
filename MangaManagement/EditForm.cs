using MangaManagement.Data;
using MangaManagement.Models;
using MangaManagement.Utils;

namespace MangaManagement
{
    public partial class EditForm : Form
    {
        private int _mangaId = 0;
        private List<int> selectedCategoryIds = new List<int>();
        public EditForm(int mangaId)
        {
            InitializeComponent();

            _mangaId = mangaId;

            Utils.Utils.CreateCategoryDropdown(OnCategoriesSelected);
            btnCategory.Click += (s, e) =>
            {
                Utils.Utils.ShowCategoryDropdown(btnCategory);
            };

            LoadManga();
        }

        private void LoadManga()
        {
            using var db = new ApplicationDbContext();
            var story = db.Stories.Find(_mangaId);

            if (story != null)
            {
                txtDescription.Text = story.Description;
                txtAuthor.Text = story.Author;
                txtName.Text = story.Title;
                MangaPicture.Image = story.Image != null ? Utils.Utils.ByteArrayToImage(story.Image) : null;
            }
        }

        private void OnCategoriesSelected(List<int> categoriesId) 
        {
            selectedCategoryIds = categoriesId;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = _mangaId;
            using var db = new ApplicationDbContext();
            var story = db.Stories.Find(id);
                        
            if (story != null)
            {
                story.Title = string.IsNullOrEmpty(txtDescription.Text) ? story.Title : txtDescription.Text;
                story.Description = string.IsNullOrEmpty(txtName.Text) ? story.Description : txtName.Text;
                if (MangaPicture.Image != null)
                    story.Image = Utils.Utils.ImageToByteArray(MangaPicture.Image);

                var currentCategoryIds = story.Categories.Select(c => c.Id).ToList();

                if (currentCategoryIds.Count != selectedCategoryIds.Count ||
                    !currentCategoryIds.Except(selectedCategoryIds).Any())
                {
                    story.Categories = db.Categories
                                       .Where(c => selectedCategoryIds.Contains(c.Id))
                                       .ToList();
                }

                db.SaveChanges();
            }

            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = _mangaId;
            using var db = new ApplicationDbContext();
            var story = db.Stories.Find(id);

            if (story != null)
            {
                db.Stories.Remove(story);
                db.SaveChanges();
            }

            this.Close();
        }
    }
}
