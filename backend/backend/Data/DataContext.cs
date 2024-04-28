using backend.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opitions) : base(opitions)
        {
            
        }
        public DbSet<User> User { get; set; }
    }
}
