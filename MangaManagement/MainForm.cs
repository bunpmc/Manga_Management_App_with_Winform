using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangaManagement.Data;
using MangaManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            SortOptions();

            ApplyFlatStyleToButton(btnAdd, Color.FromArgb(26, 188, 156));
            ApplyFlatStyleToButton(btnSearch, Color.FromArgb(52, 152, 219));

            Utils.Utils.CreateCategoryDropdown(OnCategoriesSelected);

            btnCategory.Click += (s, e) =>
            {
                Utils.Utils.ShowCategoryDropdown(btnCategory);
            };
            //this.BackColor = Color.Magenta;
            //this.TransparencyKey = Color.Magenta;
            LoadData();
        }

        private void SortOptions()
        {
            cmbSort.Items.Add("Theo tên A-Z");
            cmbSort.Items.Add("Theo Tác giả");
            cmbSort.SelectedIndex = 0;
        }

        private void ApplyFlatStyleToButton(Button btn, Color bgColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = bgColor;
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }
        private void OnCategoriesSelected(List<int> categoryIds)
        {
            string keyword = txtSearch.Text.Trim().ToUpper();
            string sortBy = cmbSort.SelectedItem?.ToString();
            LoadData(keyword, sortBy, categoryIds);
        }

        private void LoadData(string keyword = "", string sortBy = "", List<int> categoryIds = null)
        {       
            using var db = new ApplicationDbContext();
            var query = db.Stories.Include(s => s.Categories).AsQueryable();

            //Theo keyword 
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(s => s.Title.ToUpper().Contains(keyword.ToUpper()) || s.Author.ToUpper().Contains(keyword.ToUpper()));
            }

            //chon category
            if (categoryIds != null && categoryIds.Any())
            {
                query = query.Where(s => s.Categories.Any(c => categoryIds.Contains(c.Id)));
            }

            //Sap xep
            switch (sortBy)
            {
                case "Theo tên A-Z":
                    query = query.OrderBy(s => s.Title);
                    break;
                case "Theo Tác giả":
                    query = query.OrderBy(s => s.Author);
                    break;
                default:
                    query = query.OrderBy(s => s.Id);
                    break;
            }

            var result = query.ToList();

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn
            {
                Name = "Image",
                HeaderText = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 80
            };

            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add(imgCol);
            dataGridView1.Columns.Add("Title", "Title");
            dataGridView1.Columns.Add("Author", "Author");
            dataGridView1.Columns.Add("Category", "Category");
            dataGridView1.Columns.Add("Description", "Description");

            dataGridView1.RowTemplate.Height = 80;

            foreach (var s in result)
            {
                Image img = s.Image != null ? Utils.Utils.ByteArrayToImage(s.Image) : null;
                string categoryText = string.Join(", ", s.Categories.Select(c => c.Name));
                dataGridView1.Rows.Add(s.Id, img, s.Title, s.Author, categoryText, s.Description);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToUpper();
            string sortBy = cmbSort.SelectedItem?.ToString();
            LoadData(keyword, sortBy);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                var editForm = new EditForm(selectedId);
                editForm.ShowDialog();
                LoadData(txtSearch.Text.Trim(), cmbSort.SelectedItem?.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddForm();
            addForm.ShowDialog();
            LoadData(txtSearch.Text.Trim(), cmbSort.SelectedItem?.ToString());
        }
    }
}
