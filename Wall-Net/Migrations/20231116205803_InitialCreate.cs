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
                    table.ForeignKey(
                        name: "FK_Accounts_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixedTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    closing_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nominalRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixedTerms_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FixedTerms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Points", "Rol_Id" },
                values: new object[,]
                {
                    { 1, "lean@email.com", "Leandro", "Mumbach", "123456", 20, 1 },
                    { 2, "pepe@email.com", "Pepe", "Gonzalez", "123456", 20, 1 },
                    { 3, "sandra@email.com", "Sandra", "Gonzalez", "123456", 20, 1 },
                    { 4, "juan@email.com", "Juan", "Gonzalez", "123456", 20, 1 },
                    { 5, "martin@email.com", "Martin", "Gonzalez", "123456", 20, 2 },
                    { 6, "fede@email.com", "Fede", "Gonzalez", "123456", 20, 2 },
                    { 7, "jose@email.com", "Jose", "Gonzalez", "123456", 20, 2 },
                    { 8, "mica@email.com", "Mica", "Gonzalez", "123456", 20, 2 },
                    { 9, "sofia@email.com", "Sofia", "Gonzalez", "123456", 20, 2 }
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

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreationDate", "IsBlocked", "Money", "User_Id" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 16, 17, 58, 2, 747, DateTimeKind.Local).AddTicks(8377), false, 1000m, 1 },
                    { 2, new DateTime(2023, 11, 16, 17, 58, 2, 747, DateTimeKind.Local).AddTicks(8419), false, 1000m, 2 },
                    { 3, new DateTime(2023, 11, 16, 17, 58, 2, 747, DateTimeKind.Local).AddTicks(8422), false, 1000m, 3 },
                    { 4, new DateTime(2023, 11, 16, 17, 58, 2, 747, DateTimeKind.Local).AddTicks(8425), false, 1000m, 4 },
                    { 5, new DateTime(2023, 11, 16, 17, 58, 2, 747, DateTimeKind.Local).AddTicks(8427), false, 1000m, 5 },
                    { 6, new DateTime(2023, 11, 16, 17, 58, 2, 747, DateTimeKind.Local).AddTicks(8433), false, 1000m, 6 },
                    { 7, new DateTime(2023, 11, 16, 17, 58, 2, 747, DateTimeKind.Local).AddTicks(8436), false, 1000m, 7 },
                    { 8, new DateTime(2023, 11, 16, 17, 58, 2, 747, DateTimeKind.Local).AddTicks(8439), false, 1000m, 8 },
                    { 9, new DateTime(2023, 11, 16, 17, 58, 2, 747, DateTimeKind.Local).AddTicks(8442), false, 1000m, 9 }
                });

            migrationBuilder.InsertData(
                table: "FixedTerms",
                columns: new[] { "Id", "AccountId", "UserId", "amount", "closing_date", "creation_date", "nominalRate", "state" },
                values: new object[,]
                {
                    { 1, 1, 1, 100m, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, "Inmovilizado" },
                    { 2, 2, 2, 150m, new DateTime(2023, 11, 16, 17, 58, 2, 747, DateTimeKind.Local).AddTicks(8795), new DateTime(2001, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m, "Activo" },
                    { 3, 3, 2, 200m, new DateTime(2023, 11, 16, 17, 58, 2, 747, DateTimeKind.Local).AddTicks(8800), new DateTime(2001, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, "Activo" },
                    { 4, 4, 1, 250m, new DateTime(2008, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2007, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 17m, "Invomilizado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_User_Id",
                table: "Accounts",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FixedTerms_AccountId",
                table: "FixedTerms",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedTerms_UserId",
                table: "FixedTerms",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FixedTerms");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
