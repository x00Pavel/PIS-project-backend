using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace video_pujcovna_back.Migrations
{
    /// <inheritdoc />
    public partial class VideotapeUpdatedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Count",
                table: "VideTape",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CountryOfOrigin",
                table: "VideTape",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "VideTape",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "VideTape",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "VideTape",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "VideTape",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
                column: "ConcurrencyStamp",
                value: "e1ca8a91-70aa-44aa-8e6e-e4ac50d9dbba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                column: "ConcurrencyStamp",
                value: "fd8834aa-b42e-4762-9651-9da7a9c723e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"),
                column: "ConcurrencyStamp",
                value: "6ff16c75-5ab9-4241-b4ca-88c6a9bf0189");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"),
                column: "ConcurrencyStamp",
                value: "51b96487-7874-423c-af53-e8a3c4da9c84");

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("30b4eff8-93e7-44aa-8eb6-f4ad3e7a414a"), "Main stock description", "Main stock" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Id",
                keyValue: new Guid("30b4eff8-93e7-44aa-8eb6-f4ad3e7a414a"));

            migrationBuilder.DropColumn(
                name: "Count",
                table: "VideTape");

            migrationBuilder.DropColumn(
                name: "CountryOfOrigin",
                table: "VideTape");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "VideTape");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "VideTape");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "VideTape");

            migrationBuilder.DropColumn(
                name: "year",
                table: "VideTape");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
                column: "ConcurrencyStamp",
                value: "e348de5e-13a1-4bda-96b9-49d7cc42abb3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                column: "ConcurrencyStamp",
                value: "6414b7d7-760b-4f3f-bcb5-cac2d10616d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"),
                column: "ConcurrencyStamp",
                value: "b27f5822-ebf9-46b6-8545-60365b33c2b5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"),
                column: "ConcurrencyStamp",
                value: "06ee8ebb-2d34-4b01-9150-153ddb7f2a08");
        }
    }
}
