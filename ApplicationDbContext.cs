using Microsoft.EntityFrameworkCore;

namespace EventGenerationWithEF
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<RecurringEvent> RecurringEvents { get; set; }

        // Other DbSet properties

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the RecurringEvent entity and other configurations
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; }

        public ApplicationDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
