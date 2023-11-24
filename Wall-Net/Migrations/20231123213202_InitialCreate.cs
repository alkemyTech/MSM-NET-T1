using System;
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
                name: "Catalogues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogues", x => x.Id);
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Concept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ToAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
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
                    { 1, new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(2972), false, 1000m, 1 },
                    { 2, new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(2984), false, 1000m, 1 },
                    { 3, new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(2985), false, 1000m, 1 },
                    { 4, new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(2986), false, 1000m, 1 },
                    { 5, new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(2986), false, 1000m, 1 },
                    { 6, new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(2989), false, 1000m, 1 },
                    { 7, new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(2990), false, 1000m, 1 },
                    { 8, new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(2991), false, 1000m, 1 },
                    { 9, new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(2992), false, 1000m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Catalogues",
                columns: new[] { "Id", "Image", "Points", "ProductDescription" },
                values: new object[,]
                {
                    { 1, "imagen1.jpg", 100m, "Producto 1" },
                    { 2, "imagen2.jpg", 90m, "Producto 2" },
                    { 3, "imagen3.jpg", 80m, "Producto 3" },
                    { 4, "imagen4.jpg", 70m, "Producto 4" }
                });

            migrationBuilder.InsertData(
                table: "FixedTerms",
                columns: new[] { "Id", "account_id", "amount", "closing_date", "creation_date", "nominalRate", "state", "user_id" },
                values: new object[,]
                {
                    { 1, 1, 100m, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, "Inmovilizado", 1 },
                    { 2, 2, 150m, new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(3017), new DateTime(2001, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m, "Activo", 2 },
                    { 3, 3, 200m, new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(3019), new DateTime(2001, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, "Activo", 2 },
                    { 4, 4, 250m, new DateTime(2008, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2007, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 17m, "Invomilizado", 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Encargado de agregar y borrar usuarios", "Admin" },
                    { 2, "Cliente nuevo", "Regular" },
                    { 3, "Administrador de las transacciones", "Admin" },
                    { 4, "Cliente antiguo", "Regular" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccountId", "Amount", "Concept", "Date", "ToAccountId", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 100.00m, "Ejemplo de transacción 1", new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(3071), null, "topup", 1 },
                    { 2, 1, 100.00m, "Ejemplo de transacción 1", new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(3075), null, "topup", 1 },
                    { 3, 1, 100.00m, "Ejemplo de transacción 1", new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(3076), null, "topup", 1 },
                    { 4, 1, 100.00m, "Ejemplo de transacción 1", new DateTime(2023, 11, 23, 18, 32, 2, 740, DateTimeKind.Local).AddTicks(3077), null, "topup", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Points", "Rol_Id" },
                values: new object[,]
                {
                    { 1, "lean@email.com", "Leandro", "Mumbach", "123456", 20, 1 },
                    { 2, "pepe@email.com", "Pepe", "Gonzalez", "123456", 20, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Catalogues");

            migrationBuilder.DropTable(
                name: "FixedTerms");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
