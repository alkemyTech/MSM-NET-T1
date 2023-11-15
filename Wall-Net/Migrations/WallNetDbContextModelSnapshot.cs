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

                    b.HasIndex("User_Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(805),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(819),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(820),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(821),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(822),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(825),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(826),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 8,
                            CreationDate = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(827),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        },
                        new
                        {
                            Id = 9,
                            CreationDate = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(828),
                            IsBlocked = false,
                            Money = 1000m,
                            User_Id = 1
                        });
                });

            modelBuilder.Entity("Wall_Net.Models.Catalogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Points")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Catalogues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "imagen1.jpg",
                            Points = 100m,
                            ProductDescription = "Producto 1"
                        },
                        new
                        {
                            Id = 2,
                            Image = "imagen2.jpg",
                            Points = 90m,
                            ProductDescription = "Producto 2"
                        },
                        new
                        {
                            Id = 3,
                            Image = "imagen3.jpg",
                            Points = 80m,
                            ProductDescription = "Producto 3"
                        },
                        new
                        {
                            Id = 4,
                            Image = "imagen4.jpg",
                            Points = 70m,
                            ProductDescription = "Producto 4"
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
                            closing_date = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(863),
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
                            closing_date = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(864),
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

            modelBuilder.Entity("Wall_Net.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Concept")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ToAccountId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionId = 1,
                            AccountId = 1,
                            Amount = 100.00m,
                            Concept = "Ejemplo de transacción 1",
                            Date = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(922),
                            Type = "topup",
                            UserId = 1
                        },
                        new
                        {
                            TransactionId = 2,
                            AccountId = 1,
                            Amount = 100.00m,
                            Concept = "Ejemplo de transacción 1",
                            Date = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(925),
                            Type = "topup",
                            UserId = 1
                        },
                        new
                        {
                            TransactionId = 3,
                            AccountId = 1,
                            Amount = 100.00m,
                            Concept = "Ejemplo de transacción 1",
                            Date = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(926),
                            Type = "topup",
                            UserId = 1
                        },
                        new
                        {
                            TransactionId = 4,
                            AccountId = 1,
                            Amount = 100.00m,
                            Concept = "Ejemplo de transacción 1",
                            Date = new DateTime(2023, 11, 15, 11, 34, 26, 54, DateTimeKind.Local).AddTicks(927),
                            Type = "topup",
                            UserId = 1
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

            modelBuilder.Entity("Wall_Net.Models.Account", b =>
                {
                    b.HasOne("Wall_Net.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
