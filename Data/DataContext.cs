using Microsoft.EntityFrameworkCore;
using recipesv2.Models;

namespace recipesv2.Data
{
    public class DataContext : DbContext
    {
        public string ConnectionString { get; set; }

        public DbSet<User> Users { get; set; }

        public DataContext(IConfiguration configuration)
        {
            this.ConnectionString = configuration.GetConnectionString("windows_database")!;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }
    }
}
