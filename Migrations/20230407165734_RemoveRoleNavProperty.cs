using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace video_pujcovna_back.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoleNavProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserModelId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_UserModelId",
                table: "AspNetRoles");

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("5c4433b8-1480-4596-b10b-856fff5482ff"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("a4ec67de-4607-4775-9e83-3ad59426c993"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("f094d8a1-3552-43df-a27b-7448f72c467f"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("ffcf9bde-784e-4b60-a295-444fcf32f9f2"));

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "NameAndSurname" },
                values: new object[,]
                {
                    { new Guid("3161d162-3472-42d7-9fbd-5258aa6892f8"), "Honza" },
                    { new Guid("b2fd18ae-ff43-48bf-8e2a-5d2f495373ce"), "Tom Cruise" },
                    { new Guid("cd73fe57-3ea3-4788-9333-3bf5f9ce0493"), "Ivan" },
                    { new Guid("e87907e2-7018-4ba3-b03a-19de874e8fa8"), "Tom Hanks" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
                column: "ConcurrencyStamp",
                value: "718273aa-13f3-4f91-995f-e77ec031774d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                column: "ConcurrencyStamp",
                value: "15ae320a-2fe5-4ab2-a702-e118a25c91db");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"),
                column: "ConcurrencyStamp",
                value: "d047440d-101c-468a-bfa0-97d229bbcc61");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"),
                column: "ConcurrencyStamp",
                value: "0f68589c-754a-4716-9d7f-40b470eb7cc2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("3161d162-3472-42d7-9fbd-5258aa6892f8"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("b2fd18ae-ff43-48bf-8e2a-5d2f495373ce"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("cd73fe57-3ea3-4788-9333-3bf5f9ce0493"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("e87907e2-7018-4ba3-b03a-19de874e8fa8"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserModelId",
                table: "AspNetRoles",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "NameAndSurname" },
                values: new object[,]
                {
                    { new Guid("5c4433b8-1480-4596-b10b-856fff5482ff"), "Ivan" },
                    { new Guid("a4ec67de-4607-4775-9e83-3ad59426c993"), "Honza" },
                    { new Guid("f094d8a1-3552-43df-a27b-7448f72c467f"), "Tom Hanks" },
                    { new Guid("ffcf9bde-784e-4b60-a295-444fcf32f9f2"), "Tom Cruise" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e"),
                column: "UserModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"),
                column: "UserModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"),
                column: "UserModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"),
                column: "UserModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
                column: "ConcurrencyStamp",
                value: "9adeae96-bf4c-4245-9a46-3c61bc660a83");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                column: "ConcurrencyStamp",
                value: "37b2fcb4-777c-441e-b8f9-025d8c749891");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"),
                column: "ConcurrencyStamp",
                value: "5b2aa2b4-a1e2-4979-9837-15baeadd0651");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"),
                column: "ConcurrencyStamp",
                value: "440bb0c7-5fec-4b4c-b65b-ee4120e4a29a");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UserModelId",
                table: "AspNetRoles",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserModelId",
                table: "AspNetRoles",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
