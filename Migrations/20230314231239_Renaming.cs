using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace video_pujcovna_back.Migrations
{
    /// <inheritdoc />
    public partial class Renaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationModel_RecordModel_RecordId",
                table: "ReservationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationModel_Users_UserId",
                table: "ReservationModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationModel",
                table: "ReservationModel");

            migrationBuilder.RenameTable(
                name: "ReservationModel",
                newName: "reservations");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationModel_UserId",
                table: "reservations",
                newName: "IX_reservations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationModel_RecordId",
                table: "reservations",
                newName: "IX_reservations_RecordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservations",
                table: "reservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_RecordModel_RecordId",
                table: "reservations",
                column: "RecordId",
                principalTable: "RecordModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_Users_UserId",
                table: "reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_RecordModel_RecordId",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_Users_UserId",
                table: "reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservations",
                table: "reservations");

            migrationBuilder.RenameTable(
                name: "reservations",
                newName: "ReservationModel");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_UserId",
                table: "ReservationModel",
                newName: "IX_ReservationModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_RecordId",
                table: "ReservationModel",
                newName: "IX_ReservationModel_RecordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationModel",
                table: "ReservationModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationModel_RecordModel_RecordId",
                table: "ReservationModel",
                column: "RecordId",
                principalTable: "RecordModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationModel_Users_UserId",
                table: "ReservationModel",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
