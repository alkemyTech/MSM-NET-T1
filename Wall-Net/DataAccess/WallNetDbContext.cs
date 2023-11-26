using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System;
using Wall_Net.Models;
using Amazon.Auth.AccessControlPolicy;

namespace Wall_Net.DataAccess
{
    public class WallNetDbContext : DbContext
    {
        public WallNetDbContext(DbContextOptions<WallNetDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Account> Accounts{ get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<FixedTermDeposit> FixedTerms { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Pavi;Initial Catalog=WalNetDb;User ID=sa;Password=Root;Pooling=False;Trust Server Certificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FixedTermDeposit>()
                .HasOne(p => p.User)
                .WithMany(p => p.FixedTermDeposits)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
                .HasOne(p => p.Account)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Roles>().HasData(SeedData.SeedData.SeedsRoles());
            modelBuilder.Entity<User>().HasData(SeedData.SeedData.SeedsUsers());
            modelBuilder.Entity<Account>().HasData(SeedData.SeedData.SeedsAcounts());
            modelBuilder.Entity<FixedTermDeposit>().HasData(SeedData.SeedData.SeedsFixed());
            modelBuilder.Entity<Catalogue>().HasData(SeedData.SeedData.SeedsCatalogue());
            modelBuilder.Entity<Transaction>().HasData(SeedData.SeedData.SeedsTransaction());

        }

    }
   }
