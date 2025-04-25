using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangaManagement.Data;
using MangaManagement.Models;

namespace MangaManagement.Utils
{
    public static class Utils
    {
        private static ToolStripDropDown categoryDropdown;
        private static Action<int> onCategorySelected;
        private static List<int> selectedCategoryIds = new List<int>();

        public static byte[] ImageToByteArray(Image image)
        {
            using var ms = new MemoryStream();
            using (var bitmap = new Bitmap(image))
            {
                bitmap.Save(ms, ImageFormat.Png);
            }
            return ms.ToArray();
        }

        public static Image ByteArrayToImage(byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        public static void CreateCategoryDropdown(Action<List<int>> onSelectCategories)
        {
            categoryDropdown = new ToolStripDropDown();
            selectedCategoryIds.Clear();

            // Panel chứa các checkbox (scroll được)
            var scrollablePanel = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // Bảng chứa checkbox
            var hostPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 2,
                Padding = new Padding(10),
                BackColor = Color.White,
                Dock = DockStyle.Top
            };

            using var db = new ApplicationDbContext();
            var categories = db.Categories.OrderBy(c => c.Name).ToList();

            foreach (var cat in categories)
            {
                var chk = new CheckBox
                {
                    Text = cat.Name,
                    AutoSize = true,
                    Tag = cat,
                    Font = new Font("Segoe UI", 10),
                    Margin = new Padding(5)
                };

                chk.CheckedChanged += (s, e) =>
                {
                    var c = (Category)((CheckBox)s).Tag;
                    if (chk.Checked)
                    {
                        if (!selectedCategoryIds.Contains(c.Id))
                            selectedCategoryIds.Add(c.Id);
                    }
                    else
                    {
                        selectedCategoryIds.Remove(c.Id);
                    }
                };

                hostPanel.Controls.Add(chk);
            }

            scrollablePanel.Controls.Add(hostPanel);

            // Nút lọc cố định dưới
            var btnFilter = new Button
            {
                Text = "Lọc",
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Margin = new Padding(10),
                Height = 40,
                Width = 100,
                Anchor = AnchorStyles.Bottom
            };

            btnFilter.Click += (s, e) =>
            {
                categoryDropdown.Close();
                onSelectCategories?.Invoke(new List<int>(selectedCategoryIds));
            };

            // Panel gói cả scroll + button
            var containerPanel = new Panel
            {
                Width = 400,
                Height = 300,
                BackColor = Color.White
            };
            scrollablePanel.Height = 240; // phần dành cho scroll (còn lại là nút Lọc)

            containerPanel.Controls.Add(scrollablePanel);
            containerPanel.Controls.Add(btnFilter);

            scrollablePanel.Dock = DockStyle.Top;
            btnFilter.Dock = DockStyle.Bottom;

            // Gắn vào dropdown
            var host = new ToolStripControlHost(containerPanel)
            {
                AutoSize = false,
                Width = 400,
                Height = 300
            };

            categoryDropdown.Items.Clear();
            categoryDropdown.Items.Add(host);
        }

        public static void ShowCategoryDropdown(Button btn)
        {
            if (categoryDropdown != null)
            {
                var pt = btn.PointToScreen(Point.Empty);
                categoryDropdown.Show(pt.X, pt.Y + btn.Height);
            }
        }
        private static void CategoryLabel_Click(object sender, EventArgs e)
        {
            var cat = ((Label)sender).Tag as Category;
            onCategorySelected?.Invoke(cat.Id);
            categoryDropdown.Close();
        }
    }
}
