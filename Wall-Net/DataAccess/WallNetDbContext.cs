using Microsoft.EntityFrameworkCore;
using Wall_Net.Models;

namespace Wall_Net.DataAccess
{
    public class WallNetDbContext : DbContext
    {
        public WallNetDbContext(DbContextOptions<WallNetDbContext> options) : base(options)
        {

        }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<FixedTermDeposit> FixedTerms { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-48IVMU9;Initial Catalog=WallNet-DB;Persist Security Info=True;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Roles>().HasData(SeedData.SeedData.SeedsRoles());
            modelBuilder.Entity<Account>().HasData(SeedData.SeedData.SeedsAcounts());
            modelBuilder.Entity<FixedTermDeposit>().HasData(SeedData.SeedData.SeedsFixed());
            modelBuilder.Entity<Catalogue>().HasData(SeedData.SeedData.SeedsCatalogue());
            modelBuilder.Entity<Transaction>().HasData(SeedData.SeedData.SeedsTransaction());
        }

    }
   }
