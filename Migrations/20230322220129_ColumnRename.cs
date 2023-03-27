using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace video_pujcovna_back.Migrations
{
    /// <inheritdoc />
    public partial class ColumnRename : Migration
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

            migrationBuilder.DropTable(
                name: "RecordModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservations",
                table: "ReservationModel");

            migrationBuilder.DropIndex(
                name: "IX_ReservationModel_RecordId",
                table: "ReservationModel");

            migrationBuilder.RenameTable(
                name: "ReservationModel",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationModel_UserId",
                table: "Reservations",
                newName: "IX_ReservationModel_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "VideotapeId",
                table: "Reservations",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VideTape",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideTape", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "Priority" },
                values: new object[,]
                {
                    { new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e"), "Branch lead", "lead", 20 },
                    { new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"), "System administrator", "admin", 0 },
                    { new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"), "Regular employee", "employee", 40 },
                    { new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"), "Regular customer", "customer", 60 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationModel_VideotapeId",
                table: "Reservations",
                column: "VideotapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationModel_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationModel_VideTape_VideotapeId",
                table: "Reservations",
                column: "VideotapeId",
                principalTable: "VideTape",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationModel_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationModel_VideTape_VideotapeId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "VideTape");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_ReservationModel_VideotapeId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VideotapeId",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "ReservationModel");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationModel_UserId",
                table: "ReservationModel",
                newName: "IX_ReservationModel_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservations",
                table: "ReservationModel",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RecordModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordModel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationModel_RecordId",
                table: "ReservationModel",
                column: "RecordId");

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
