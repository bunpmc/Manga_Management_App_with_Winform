using Microsoft.EntityFrameworkCore;
using MangaManagement.Models;

namespace MangaManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "manga.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            Console.WriteLine( dbPath );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Story>()
                .HasMany(s => s.Categories)
                .WithMany(c => c.Stories)
                .UsingEntity(j => j.ToTable("StoryCategory"));

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action" },
                new Category { Id = 2, Name = "Adventure" },
                new Category { Id = 3, Name = "Comedy" },
                new Category { Id = 4, Name = "Drama" },
                new Category { Id = 5, Name = "Fantasy" },
                new Category { Id = 6, Name = "Romance" },
                new Category { Id = 7, Name = "School Life" },
                new Category { Id = 8, Name = "Slice of Life" },
                new Category { Id = 9, Name = "Shounen" },
                new Category { Id = 10, Name = "Shoujo" },
                new Category { Id = 11, Name = "Horror" },
                new Category { Id = 12, Name = "Mystery" },
                new Category { Id = 13, Name = "Sci-Fi" },
                new Category { Id = 14, Name = "Supernatural" },
                new Category { Id = 15, Name = "BL (Boys' Love)" },
                new Category { Id = 16, Name = "GL (Girls' Love)" },
                new Category { Id = 17, Name = "Historical" },
                new Category { Id = 18, Name = "Martial Arts" },
                new Category { Id = 19, Name = "Psychological" },
                new Category { Id = 20, Name = "Isekai" }
            );
        }

    }
}
