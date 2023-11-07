using Microsoft.EntityFrameworkCore;
using Wall_Net.Models;

namespace Wall_Net.DataAccess
{
    public class WallNetDbContext : DbContext
    {
        public WallNetDbContext(DbContextOptions<WallNetDbContext> options) : base(options)
        {
           
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Account> Accounts{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Pavi;Initial Catalog=WallNet-db;User ID=sa;Password=Root;Pooling=False;Trust Server Certificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(SeedData.SeedData.SeedsUsers());
            modelBuilder.Entity<Roles>().HasData(SeedData.SeedData.SeedsRoles());
            modelBuilder.Entity<Account>().HasData(SeedData.SeedData.SeedsAcounts());
        }


    }
}
