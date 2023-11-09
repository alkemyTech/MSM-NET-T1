﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wall_Net.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FixedTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    closing_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nominalRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Rol_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreationDate", "IsBlocked", "Money", "User_Id" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 9, 16, 6, 6, 971, DateTimeKind.Local).AddTicks(1336), false, 1000m, 1 },
                    { 2, new DateTime(2023, 11, 9, 16, 6, 6, 971, DateTimeKind.Local).AddTicks(1356), false, 1000m, 1 },
                    { 3, new DateTime(2023, 11, 9, 16, 6, 6, 971, DateTimeKind.Local).AddTicks(1357), false, 1000m, 1 },
                    { 4, new DateTime(2023, 11, 9, 16, 6, 6, 971, DateTimeKind.Local).AddTicks(1358), false, 1000m, 1 },
                    { 5, new DateTime(2023, 11, 9, 16, 6, 6, 971, DateTimeKind.Local).AddTicks(1359), false, 1000m, 1 },
                    { 6, new DateTime(2023, 11, 9, 16, 6, 6, 971, DateTimeKind.Local).AddTicks(1362), false, 1000m, 1 },
                    { 7, new DateTime(2023, 11, 9, 16, 6, 6, 971, DateTimeKind.Local).AddTicks(1363), false, 1000m, 1 },
                    { 8, new DateTime(2023, 11, 9, 16, 6, 6, 971, DateTimeKind.Local).AddTicks(1364), false, 1000m, 1 },
                    { 9, new DateTime(2023, 11, 9, 16, 6, 6, 971, DateTimeKind.Local).AddTicks(1365), false, 1000m, 1 }
                });

            migrationBuilder.InsertData(
                table: "FixedTerms",
                columns: new[] { "Id", "account_id", "amount", "closing_date", "creation_date", "nominalRate", "state", "user_id" },
                values: new object[,]
                {
                    { 1, 1, 100m, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, "Inmovilizado", 1 },
                    { 2, 2, 150m, new DateTime(2023, 11, 9, 16, 6, 6, 971, DateTimeKind.Local).AddTicks(1393), new DateTime(2001, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m, "Activo", 2 },
                    { 3, 3, 200m, new DateTime(2023, 11, 9, 16, 6, 6, 971, DateTimeKind.Local).AddTicks(1395), new DateTime(2001, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, "Activo", 2 },
                    { 4, 4, 250m, new DateTime(2008, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2007, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 17m, "Invomilizado", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Points", "Rol_Id" },
                values: new object[,]
                {
                    { 1, "lean@email.com", "Leandro", "Mumbach", "123456", 20, 1 },
                    { 2, "pepe@email.com", "Pepe", "Gonzalez", "123456", 20, 1 }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Encargado de agregar y borrar usuarios", "Admin" },
                    { 2, "Cliente nuevo", "Regular" },
                    { 3, "Administrador de las transacciones", "Admin" },
                    { 4, "Cliente antiguo", "Regular" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "FixedTerms");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
