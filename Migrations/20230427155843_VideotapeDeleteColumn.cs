using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace video_pujcovna_back.Migrations
{
    /// <inheritdoc />
    public partial class VideotapeDeleteColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "VideTape",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
                column: "ConcurrencyStamp",
                value: "4f5bc7f3-5dd4-4fca-b958-368abd153827");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                column: "ConcurrencyStamp",
                value: "68d485e8-eb8b-4179-af3c-a7fe7c38c3ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"),
                column: "ConcurrencyStamp",
                value: "24ee761c-c924-4594-9506-ca0ae2524b17");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"),
                column: "ConcurrencyStamp",
                value: "54b5f832-ddaf-4ebe-99e9-f194ef570122");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "VideTape");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
                column: "ConcurrencyStamp",
                value: "f9c59c1f-a03b-4fb2-92d9-8c22e97e18df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                column: "ConcurrencyStamp",
                value: "a8c618a2-eb6a-42cc-83b0-e2ba4e8dd734");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"),
                column: "ConcurrencyStamp",
                value: "211a6d99-e5d6-4732-8a9c-aed3b8e1caba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"),
                column: "ConcurrencyStamp",
                value: "fb2160e0-752a-4360-9e61-30d02d63875e");
        }
    }
}
