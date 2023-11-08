﻿using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System;
using Wall_Net.Models;
using Wall_Net.DataAccess.SeedsData;

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
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lean2\\OneDrive\\Documentos\\WallNet-db.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Semillas de usuarios
            modelBuilder.Entity<User>().HasData(UserSeed.GetUsers());

            // Semillas de roles
             modelBuilder.Entity<Roles>().HasData(RoleSeed.GetRoles());

            // Semillas de cuentas
            modelBuilder.Entity<Account>().HasData(AccountSeed.GetAccounts());
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Leandro",
                    LastName = "Mumbach",
                    Email = "lean@email.com",
                    Password = "123456",
                    Points = 20,
                    Rol_Id = 1,
                },
                new User
                {
                    Id = 2,
                    FirstName = "Pepe",
                    LastName = "Gonzalez",
                    Email = "pepe@email.com",
                    Password = "123456",
                    Points = 20,
                    Rol_Id = 2,
                }
                );
            modelBuilder.Entity<Roles>().HasData(
                new Roles { Id = 1, Name = "Admin", Description = "Encargado de agregar y borrar usuarios" },
                new Roles { Id = 2, Name = "Regular", Description = "Cliente nuevo" },
                new Roles { Id = 3, Name = "Admin", Description = "Administrador de las transacciones" },
                new Roles { Id = 4, Name = "Regular", Description = "Cliente antiguo" }
                );
            modelBuilder.Entity<Account>().HasData(
                new Account {Id=1, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=2, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=3, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=4, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=5, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=6, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=7, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=8, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=9, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1}
            );
        }*/


    }
}