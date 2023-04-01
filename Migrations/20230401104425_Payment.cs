using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace video_pujcovna_back.Migrations
{
    /// <inheritdoc />
    public partial class Payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("c38f1435-53ed-4829-9f04-0e1075e3b4e3"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("d40ab4e2-b723-4f11-aaee-d9e4f5ab394a"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("f0bc5c3f-1828-40bf-a9e3-6c78fd231c58"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("f8ff5b59-212d-4c75-9585-100ed7585650"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4420a08f-d6e1-4b13-88bf-6f3fafae5278"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("705d7a86-9984-4ea8-a539-f2d3a369e8a9"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "Reservations",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Price = table.Column<float>(type: "float", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaymentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "NameAndSurname" },
                values: new object[,]
                {
                    { new Guid("278dbfd6-d98a-494d-8a74-e1c77cf222a8"), "Honza" },
                    { new Guid("5a93a7f5-8977-41a2-a58d-dae3db86fb4a"), "Tom Hanks" },
                    { new Guid("9c3e266a-008b-405c-b966-ff373b16a86e"), "Ivan" },
                    { new Guid("b484f1c3-9d2d-4fb6-9aeb-f8bc2bf710a3"), "Tom Cruise" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("0244de64-baa0-457d-add5-27eb4e7b5779"), "1234", new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"), "jan@gmail.com" },
                    { new Guid("9fc08dc4-e291-4f84-89b2-8f9fce31d6a7"), "1234", new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"), "honza@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PaymentId",
                table: "Reservations",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentId",
                table: "Payment",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Payment_PaymentId",
                table: "Reservations",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Payment_PaymentId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PaymentId",
                table: "Reservations");

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("278dbfd6-d98a-494d-8a74-e1c77cf222a8"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("5a93a7f5-8977-41a2-a58d-dae3db86fb4a"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("9c3e266a-008b-405c-b966-ff373b16a86e"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("b484f1c3-9d2d-4fb6-9aeb-f8bc2bf710a3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0244de64-baa0-457d-add5-27eb4e7b5779"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9fc08dc4-e291-4f84-89b2-8f9fce31d6a7"));

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Reservations");

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "NameAndSurname" },
                values: new object[,]
                {
                    { new Guid("c38f1435-53ed-4829-9f04-0e1075e3b4e3"), "Tom Hanks" },
                    { new Guid("d40ab4e2-b723-4f11-aaee-d9e4f5ab394a"), "Honza" },
                    { new Guid("f0bc5c3f-1828-40bf-a9e3-6c78fd231c58"), "Tom Cruise" },
                    { new Guid("f8ff5b59-212d-4c75-9585-100ed7585650"), "Ivan" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("4420a08f-d6e1-4b13-88bf-6f3fafae5278"), "1234", new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"), "honza@gmail.com" },
                    { new Guid("705d7a86-9984-4ea8-a539-f2d3a369e8a9"), "1234", new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"), "jan@gmail.com" }
                });
        }
    }
}
