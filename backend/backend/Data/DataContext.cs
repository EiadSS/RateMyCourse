using backend.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; } // Corrected the DbSet name to plural form "Users"
        public DbSet<Post> Post { get; set; } // Corrected the DbSet name to plural form "Users"
        public DbSet<Course> Course { get; set; } // Corrected the DbSet name to plural form "Users"
    }
}
