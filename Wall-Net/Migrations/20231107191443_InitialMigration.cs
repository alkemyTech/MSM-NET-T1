using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wall_Net.Migrations
{
    public partial class InitialMigration : Migration
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
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
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
                columns: new[] { "Id", "CreationDate", "IsBlocked", "Money", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 7, 16, 14, 43, 147, DateTimeKind.Local).AddTicks(3507), false, 1000m, 1 },
                    { 2, new DateTime(2023, 11, 7, 16, 14, 43, 147, DateTimeKind.Local).AddTicks(3520), false, 1000m, 1 },
                    { 3, new DateTime(2023, 11, 7, 16, 14, 43, 147, DateTimeKind.Local).AddTicks(3521), false, 1000m, 1 },
                    { 4, new DateTime(2023, 11, 7, 16, 14, 43, 147, DateTimeKind.Local).AddTicks(3522), false, 1000m, 1 },
                    { 5, new DateTime(2023, 11, 7, 16, 14, 43, 147, DateTimeKind.Local).AddTicks(3523), false, 1000m, 1 },
                    { 6, new DateTime(2023, 11, 7, 16, 14, 43, 147, DateTimeKind.Local).AddTicks(3524), false, 1000m, 1 },
                    { 7, new DateTime(2023, 11, 7, 16, 14, 43, 147, DateTimeKind.Local).AddTicks(3525), false, 1000m, 1 },
                    { 8, new DateTime(2023, 11, 7, 16, 14, 43, 147, DateTimeKind.Local).AddTicks(3526), false, 1000m, 1 },
                    { 9, new DateTime(2023, 11, 7, 16, 14, 43, 147, DateTimeKind.Local).AddTicks(3527), false, 1000m, 1 }
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
                name: "roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
