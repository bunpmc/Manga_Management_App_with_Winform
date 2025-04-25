using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Story> Stories { get; set; } = new List<Story>();
        public override string ToString()
        {
            return Name;
        }
    }
}
