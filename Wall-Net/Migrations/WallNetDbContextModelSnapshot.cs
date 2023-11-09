﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wall_Net.DataAccess;

#nullable disable

namespace Wall_Net.Migrations
{
    [DbContext(typeof(WallNetDbContext))]
    partial class WallNetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Wall_Net.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<decimal>("Money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2023, 11, 9, 18, 47, 59, 749, DateTimeKind.Local).AddTicks(8988),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2023, 11, 9, 18, 47, 59, 749, DateTimeKind.Local).AddTicks(9003),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2023, 11, 9, 18, 47, 59, 749, DateTimeKind.Local).AddTicks(9004),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2023, 11, 9, 18, 47, 59, 749, DateTimeKind.Local).AddTicks(9005),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(2023, 11, 9, 18, 47, 59, 749, DateTimeKind.Local).AddTicks(9006),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(2023, 11, 9, 18, 47, 59, 749, DateTimeKind.Local).AddTicks(9009),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(2023, 11, 9, 18, 47, 59, 749, DateTimeKind.Local).AddTicks(9010),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 8,
                            CreationDate = new DateTime(2023, 11, 9, 18, 47, 59, 749, DateTimeKind.Local).AddTicks(9011),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 9,
                            CreationDate = new DateTime(2023, 11, 9, 18, 47, 59, 749, DateTimeKind.Local).AddTicks(9012),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        });
                });

            modelBuilder.Entity("Wall_Net.Models.FixedTermDeposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("account_id")
                        .HasColumnType("int");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("closing_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("creation_date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("nominalRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FixedTerms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            account_id = 1,
                            amount = 100m,
                            closing_date = new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            creation_date = new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            nominalRate = 12m,
                            state = "Inmovilizado",
                            user_id = 1
                        },
                        new
                        {
                            Id = 2,
                            account_id = 2,
                            amount = 150m,
                            closing_date = new DateTime(2023, 11, 9, 18, 47, 59, 749, DateTimeKind.Local).AddTicks(9038),
                            creation_date = new DateTime(2001, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            nominalRate = 5m,
                            state = "Activo",
                            user_id = 2
                        },
                        new
                        {
                            Id = 3,
                            account_id = 3,
                            amount = 200m,
                            closing_date = new DateTime(2023, 11, 9, 18, 47, 59, 749, DateTimeKind.Local).AddTicks(9039),
                            creation_date = new DateTime(2001, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            nominalRate = 12m,
                            state = "Activo",
                            user_id = 2
                        },
                        new
                        {
                            Id = 4,
                            account_id = 4,
                            amount = 250m,
                            closing_date = new DateTime(2008, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            creation_date = new DateTime(2007, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            nominalRate = 17m,
                            state = "Invomilizado",
                            user_id = 1
                        });
                });

            modelBuilder.Entity("Wall_Net.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Encargado de agregar y borrar usuarios",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Cliente nuevo",
                            Name = "Regular"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Administrador de las transacciones",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Cliente antiguo",
                            Name = "Regular"
                        });
                });

            modelBuilder.Entity("Wall_Net.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Rol_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "lean@email.com",
                            FirstName = "Leandro",
                            LastName = "Mumbach",
                            Password = "123456",
                            Points = 20,
                            Rol_Id = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "pepe@email.com",
                            FirstName = "Pepe",
                            LastName = "Gonzalez",
                            Password = "123456",
                            Points = 20,
                            Rol_Id = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
