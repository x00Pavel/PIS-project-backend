using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace video_pujcovna_back.Migrations
{
    /// <inheritdoc />
    public partial class RoleNavProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("03b01b0b-7907-4fe8-8942-8ae1a2e7da0a"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("43675344-4d56-4e2e-ae7e-3bc5a9d62e39"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("af944a99-cb51-44cb-8b65-3d7e2103fe8b"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("e5a4a0de-ec3a-41f3-92af-df5e428904dd"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"), new Guid("3d296e24-21ba-448b-a4e1-055973cf6699") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), new Guid("c1124ec4-e024-45fb-ab35-592a3ecfe9b7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e"), new Guid("c1293246-f660-4e46-8b64-49c024d3d796") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"), new Guid("c1293246-f660-4e46-8b64-49c024d3d796") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), new Guid("c1293246-f660-4e46-8b64-49c024d3d796") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e"), new Guid("c57501c1-eb34-4539-a230-5bca8bafafae") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), new Guid("c57501c1-eb34-4539-a230-5bca8bafafae") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3d296e24-21ba-448b-a4e1-055973cf6699"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c1124ec4-e024-45fb-ab35-592a3ecfe9b7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c1293246-f660-4e46-8b64-49c024d3d796"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c57501c1-eb34-4539-a230-5bca8bafafae"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"), 0, "9adeae96-bf4c-4245-9a46-3c61bc660a83", "jan@gmail.com", false, false, null, null, null, null, null, false, null, false, "Jan" },
                    { new Guid("63df0b47-06bb-45a4-8826-790231938dde"), 0, "37b2fcb4-777c-441e-b8f9-025d8c749891", "pavel@gmail.com", false, false, null, null, null, null, null, false, null, false, "Pavel" },
                    { new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"), 0, "5b2aa2b4-a1e2-4979-9837-15baeadd0651", "honza@gmail.com", false, false, null, null, null, null, null, false, null, false, "Honza" },
                    { new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"), 0, "440bb0c7-5fec-4b4c-b65b-ee4120e4a29a", "petr@gmail.com", false, false, null, null, null, null, null, false, null, false, "Petr" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e"), new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550") },
                    { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550") },
                    { new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e"), new Guid("63df0b47-06bb-45a4-8826-790231938dde") },
                    { new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"), new Guid("63df0b47-06bb-45a4-8826-790231938dde") },
                    { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), new Guid("63df0b47-06bb-45a4-8826-790231938dde") },
                    { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c") },
                    { new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"), new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc") }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e"), new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e"), new Guid("63df0b47-06bb-45a4-8826-790231938dde") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"), new Guid("63df0b47-06bb-45a4-8826-790231938dde") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), new Guid("63df0b47-06bb-45a4-8826-790231938dde") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"), new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63df0b47-06bb-45a4-8826-790231938dde"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"));

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "NameAndSurname" },
                values: new object[,]
                {
                    { new Guid("03b01b0b-7907-4fe8-8942-8ae1a2e7da0a"), "Tom Hanks" },
                    { new Guid("43675344-4d56-4e2e-ae7e-3bc5a9d62e39"), "Tom Cruise" },
                    { new Guid("af944a99-cb51-44cb-8b65-3d7e2103fe8b"), "Ivan" },
                    { new Guid("e5a4a0de-ec3a-41f3-92af-df5e428904dd"), "Honza" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3d296e24-21ba-448b-a4e1-055973cf6699"), 0, "e2418128-45ec-4103-9f4a-fa83fa881fee", "petr@gmail.com", false, false, null, null, null, null, null, false, null, false, "Petr" },
                    { new Guid("c1124ec4-e024-45fb-ab35-592a3ecfe9b7"), 0, "16ef2bbe-5b7d-4bf1-9641-8e0439b6e44f", "honza@gmail.com", false, false, null, null, null, null, null, false, null, false, "Honza" },
                    { new Guid("c1293246-f660-4e46-8b64-49c024d3d796"), 0, "43f478c1-a67e-4050-a416-1b4b930e6958", "pavel@gmail.com", false, false, null, null, null, null, null, false, null, false, "Pavel" },
                    { new Guid("c57501c1-eb34-4539-a230-5bca8bafafae"), 0, "f2cffca7-5df2-4c5c-b037-7238c5fd9b17", "jan@gmail.com", false, false, null, null, null, null, null, false, null, false, "Jan" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"), new Guid("3d296e24-21ba-448b-a4e1-055973cf6699") },
                    { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), new Guid("c1124ec4-e024-45fb-ab35-592a3ecfe9b7") },
                    { new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e"), new Guid("c1293246-f660-4e46-8b64-49c024d3d796") },
                    { new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"), new Guid("c1293246-f660-4e46-8b64-49c024d3d796") },
                    { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), new Guid("c1293246-f660-4e46-8b64-49c024d3d796") },
                    { new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e"), new Guid("c57501c1-eb34-4539-a230-5bca8bafafae") },
                    { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), new Guid("c57501c1-eb34-4539-a230-5bca8bafafae") }
                });
        }
    }
}
