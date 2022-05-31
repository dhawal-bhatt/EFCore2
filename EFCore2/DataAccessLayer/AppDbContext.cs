
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=DESKTOP-4N0SPP3\\SQLEXPRESS;Initial Catalog=EFCoreDb2s;Integrated Security=True");


            }
        }
    }
}
