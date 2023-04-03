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
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "NameAndSurname" },
                values: new object[,]
                {
                    { new Guid("06c259c4-036b-4d51-ad35-ba078885c665"), "Ivan" },
                    { new Guid("703ddcb9-9300-450b-968b-efae7eabb41c"), "Honza" },
                    { new Guid("9d609a7b-1de9-4db1-940e-9dec79021331"), "Tom Cruise" },
                    { new Guid("9f93df1d-590b-4ca6-90a5-f70fb63a5b9b"), "Tom Hanks" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("5a9e39e3-f799-46bb-80a1-f086642d96f0"), "1234", new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"), "jan@gmail.com" },
                    { new Guid("af9284ea-db6d-474f-9847-3240c6a3a370"), "1234", new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"), "honza@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PaymentId",
                table: "Reservations",
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
                keyValue: new Guid("06c259c4-036b-4d51-ad35-ba078885c665"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("703ddcb9-9300-450b-968b-efae7eabb41c"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("9d609a7b-1de9-4db1-940e-9dec79021331"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("9f93df1d-590b-4ca6-90a5-f70fb63a5b9b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5a9e39e3-f799-46bb-80a1-f086642d96f0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af9284ea-db6d-474f-9847-3240c6a3a370"));

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
