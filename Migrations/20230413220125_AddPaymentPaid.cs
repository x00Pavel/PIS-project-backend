using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace video_pujcovna_back.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentPaid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Payment",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
                column: "ConcurrencyStamp",
                value: "4a333b15-0db9-4bfa-a863-27a52922c5f9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                column: "ConcurrencyStamp",
                value: "2955b775-f73d-4f9a-86b7-1eb50657b5de");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"),
                column: "ConcurrencyStamp",
                value: "f938689a-07f9-4aae-b8ce-1012492c6862");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"),
                column: "ConcurrencyStamp",
                value: "2eca9b9e-b6a3-40de-950a-cccd546b5789");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Payment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
                column: "ConcurrencyStamp",
                value: "878fae24-bcb8-4ab6-8f56-2769d9aa5f49");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                column: "ConcurrencyStamp",
                value: "f049db18-76f2-4eaf-b341-a144a603a2b2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"),
                column: "ConcurrencyStamp",
                value: "e162aefe-0b55-4f39-90ae-985bfcac0504");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"),
                column: "ConcurrencyStamp",
                value: "b2741408-2c32-4ab0-bcb7-97e1e1044631");
        }
    }
}
