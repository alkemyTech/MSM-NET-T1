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

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8600),
                            IsBlocked = false,
                            Money = 1000m,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8620),
                            IsBlocked = false,
                            Money = 1000m,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8621),
                            IsBlocked = false,
                            Money = 1000m,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8622),
                            IsBlocked = false,
                            Money = 1000m,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8623),
                            IsBlocked = false,
                            Money = 1000m,
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8625),
                            IsBlocked = false,
                            Money = 1000m,
                            UserId = 6
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8626),
                            IsBlocked = false,
                            Money = 1000m,
                            UserId = 7
                        },
                        new
                        {
                            Id = 8,
                            CreationDate = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8626),
                            IsBlocked = false,
                            Money = 1000m,
                            UserId = 8
                        },
                        new
                        {
                            Id = 9,
                            CreationDate = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8627),
                            IsBlocked = false,
                            Money = 1000m,
                            UserId = 9
                        },
                        new
                        {
                            Id = 10,
                            CreationDate = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8629),
                            IsBlocked = false,
                            Money = 1000m,
                            UserId = 10
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

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
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

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("UserId");

                    b.ToTable("FixedTerms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            UserId = 1,
                            amount = 100m,
                            closing_date = new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            creation_date = new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            nominalRate = 12m,
                            state = "Inmovilizado"
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 2,
                            UserId = 2,
                            amount = 150m,
                            closing_date = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8687),
                            creation_date = new DateTime(2001, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            nominalRate = 5m,
                            state = "Activo"
                        },
                        new
                        {
                            Id = 3,
                            AccountId = 3,
                            UserId = 2,
                            amount = 200m,
                            closing_date = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8689),
                            creation_date = new DateTime(2001, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            nominalRate = 12m,
                            state = "Activo"
                        },
                        new
                        {
                            Id = 4,
                            AccountId = 4,
                            UserId = 1,
                            amount = 250m,
                            closing_date = new DateTime(2008, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            creation_date = new DateTime(2007, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            nominalRate = 17m,
                            state = "Invomilizado"
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

                    b.ToTable("Roles");

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

                    b.HasIndex("AccountId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionId = 1,
                            AccountId = 1,
                            Amount = 100.00m,
                            Concept = "Ejemplo de transacción 1",
                            Date = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8755),
                            Type = "topup",
                            UserId = 1
                        },
                        new
                        {
                            TransactionId = 2,
                            AccountId = 1,
                            Amount = 100.00m,
                            Concept = "Ejemplo de transacción 1",
                            Date = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8763),
                            Type = "topup",
                            UserId = 1
                        },
                        new
                        {
                            TransactionId = 3,
                            AccountId = 1,
                            Amount = 100.00m,
                            Concept = "Ejemplo de transacción 1",
                            Date = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8765),
                            Type = "topup",
                            UserId = 1
                        },
                        new
                        {
                            TransactionId = 4,
                            AccountId = 1,
                            Amount = 100.00m,
                            Concept = "Ejemplo de transacción 1",
                            Date = new DateTime(2023, 11, 24, 17, 54, 15, 56, DateTimeKind.Local).AddTicks(8766),
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

                    b.Property<decimal>("Points")
                        .HasColumnType("decimal(18,2)");

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
                            Password = "$2a$11$YlDwUdgGlX6BSyEJ6Uwe3.my1stHYBfn8BV.6EKRZS1La.RI8tM7.",
                            Points = 20m,
                            Rol_Id = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "pepe@email.com",
                            FirstName = "Pepe",
                            LastName = "Gonzalez",
                            Password = "$2a$11$xg62zNCv1agMSKX7zEV3o./CO7CZH0C9OiBTWo3ALDZQvE0xaMmKO",
                            Points = 20m,
                            Rol_Id = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "ana@email.com",
                            FirstName = "Ana",
                            LastName = "Lopez",
                            Password = "$2a$11$seQ7guV2Ys77yZJ1Q.Ut/.tEtUU5y1mzW.Tv92x42/zZwVuzmqy4O",
                            Points = 25m,
                            Rol_Id = 2
                        },
                        new
                        {
                            Id = 4,
                            Email = "carlos@email.com",
                            FirstName = "Carlos",
                            LastName = "Martinez",
                            Password = "$2a$11$9wQ/rf5TSSHaWSG1q95BoeY4sY6FuAdYW/ZTicXSs1rMtFWGE72.u",
                            Points = 18m,
                            Rol_Id = 1
                        },
                        new
                        {
                            Id = 5,
                            Email = "maria@email.com",
                            FirstName = "Maria",
                            LastName = "Rodriguez",
                            Password = "$2a$11$ys2fFIZm9AfaKTgAZ0Fj.eOC0OLs40MaXrQUPwexbMUhIUAO.bdjq",
                            Points = 22m,
                            Rol_Id = 2
                        },
                        new
                        {
                            Id = 6,
                            Email = "juan@email.com",
                            FirstName = "Juan",
                            LastName = "Perez",
                            Password = "$2a$11$KDl34yKRNyJqI3KF4P4iFeBOL1L7VHEa1QdTLz3xV0ZITzJDezvYC",
                            Points = 19m,
                            Rol_Id = 1
                        },
                        new
                        {
                            Id = 7,
                            Email = "laura@email.com",
                            FirstName = "Laura",
                            LastName = "Fernandez",
                            Password = "$2a$11$qLKNc/JsqgcFSJryM4n1y.rVCQ3ckQme4mtBNLRU7xREgUqmkzXiq",
                            Points = 24m,
                            Rol_Id = 2
                        },
                        new
                        {
                            Id = 8,
                            Email = "diego@email.com",
                            FirstName = "Diego",
                            LastName = "Gomez",
                            Password = "$2a$11$/ddLOQJBVuavWBBnEEXQyefD2CStH85xveE1Z1XnmQ0notc0.116C",
                            Points = 21m,
                            Rol_Id = 1
                        },
                        new
                        {
                            Id = 9,
                            Email = "carmen@email.com",
                            FirstName = "Carmen",
                            LastName = "Ruiz",
                            Password = "$2a$11$TDIiEFzMT7WJI0jondkcteUk4yleAbWpQ26eOH.YS3TeoBPSordm.",
                            Points = 20m,
                            Rol_Id = 2
                        },
                        new
                        {
                            Id = 10,
                            Email = "sergio@email.com",
                            FirstName = "Sergio",
                            LastName = "Lopez",
                            Password = "$2a$11$EvEEFH5rcfyF2eUhOGFg8OLTClDYlRjb5deihPYiNSplAMo.tHyuG",
                            Points = 23m,
                            Rol_Id = 1
                        },
                        new
                        {
                            Id = 11,
                            Email = "luisa@email.com",
                            FirstName = "Luisa",
                            LastName = "Garcia",
                            Password = "$2a$11$olegngSX0vPoZopLp4P70OtJIYxIEtzYbtaZlnG9vHOMJ7jZN9UM.",
                            Points = 19m,
                            Rol_Id = 2
                        },
                        new
                        {
                            Id = 12,
                            Email = "alejandro@email.com",
                            FirstName = "Alejandro",
                            LastName = "Sanchez",
                            Password = "$2a$11$YDa9SYSlrY3nzH3r8urHgeuDrP6IdgvXj8lAbqau42QQHqrRJ4cNO",
                            Points = 18m,
                            Rol_Id = 1
                        },
                        new
                        {
                            Id = 13,
                            Email = "martina@email.com",
                            FirstName = "Martina",
                            LastName = "Hernandez",
                            Password = "$2a$11$V6Q/0eI2bcyuuWyDFQhQ.upxXzw0PIyj00jriSEyZxhFpTJeGgNM.",
                            Points = 22m,
                            Rol_Id = 2
                        },
                        new
                        {
                            Id = 14,
                            Email = "roberto@email.com",
                            FirstName = "Roberto",
                            LastName = "Diaz",
                            Password = "$2a$11$nVBZQMDeZA0nQilxHLhBJuhLhXGlzjmVG58cvQvQQGpoCp2dBzmRe",
                            Points = 25m,
                            Rol_Id = 1
                        },
                        new
                        {
                            Id = 15,
                            Email = "isabel@email.com",
                            FirstName = "Isabel",
                            LastName = "Flores",
                            Password = "$2a$11$wofF3lDnwNvGdp43NVzPb.FM58r.ZGhc4py4SvK/z4repswhEqCQa",
                            Points = 20m,
                            Rol_Id = 2
                        });
                });

            modelBuilder.Entity("Wall_Net.Models.Account", b =>
                {
                    b.HasOne("Wall_Net.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wall_Net.Models.FixedTermDeposit", b =>
                {
                    b.HasOne("Wall_Net.Models.Account", "Account")
                        .WithMany("FixedTermDeposit")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wall_Net.Models.User", "User")
                        .WithMany("FixedTermDeposits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wall_Net.Models.Transaction", b =>
                {
                    b.HasOne("Wall_Net.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Wall_Net.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wall_Net.Models.Account", b =>
                {
                    b.Navigation("FixedTermDeposit");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Wall_Net.Models.User", b =>
                {
                    b.Navigation("FixedTermDeposits");
                });
#pragma warning restore 612, 618
        }
    }
}