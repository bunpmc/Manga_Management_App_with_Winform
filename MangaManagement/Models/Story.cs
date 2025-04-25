using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaManagement.Models
{
    public class Story
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public byte[]? Image { get; set; }
    }
}
