using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System;
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
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Pavi;Initial Catalog=WallNetDb;User ID=sa;Password=Root;Pooling=False;Trust Server Certificate=true");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Roles>().HasData(SeedData.SeedData.SeedsRoles());
            modelBuilder.Entity<FixedTermDeposit>().HasData(SeedData.SeedData.SeedsFixed());
            modelBuilder.Entity<User>().HasData(SeedData.SeedData.SeedsUsers());
            modelBuilder.Entity<Account>().HasData(SeedData.SeedData.SeedsAcounts());
            modelBuilder.Entity<Catalogue>().HasData(SeedData.SeedData.SeedsCatalogue());
            modelBuilder.Entity<Transaction>().HasData(SeedData.SeedData.SeedsTransaction());
        }

    }
   }
