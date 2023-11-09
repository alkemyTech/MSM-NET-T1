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
        public DbSet<FixedTermDeposit> FixedTerms { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MILI\\SQLEXPRESS;Initial Catalog=Wall-Net;Pooling=False;Integrated Security=True;Trust Server Certificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(SeedData.SeedData.SeedsUsers());
            modelBuilder.Entity<Roles>().HasData(SeedData.SeedData.SeedsRoles());
            modelBuilder.Entity<Account>().HasData(SeedData.SeedData.SeedsAcounts());
            modelBuilder.Entity<FixedTermDeposit>().HasData(SeedData.SeedData.SeedsFixed());
        }


    }
}
