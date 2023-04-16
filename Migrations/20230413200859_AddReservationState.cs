using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace video_pujcovna_back.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "Reservations",
                newName: "DateTo");

            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "Reservations",
                newName: "DateFrom");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Reservations",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "DateTo",
                table: "Reservations",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "DateFrom",
                table: "Reservations",
                newName: "ReservationDate");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
                column: "ConcurrencyStamp",
                value: "178b90dc-5499-4134-80f8-4f66a1de5970");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                column: "ConcurrencyStamp",
                value: "456d3a9b-f221-48a3-ac7c-75e68b28ce59");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"),
                column: "ConcurrencyStamp",
                value: "a663ed28-99b9-49bb-8b6c-57a1a368e28e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"),
                column: "ConcurrencyStamp",
                value: "b62d38b8-e922-4161-a4ee-dd49bfd6935c");
        }
    }
}
