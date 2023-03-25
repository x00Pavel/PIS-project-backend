using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace video_pujcovna_back.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "VideTape");

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Reservations",
                type: "datetime(6)",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NameAndSurname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Name);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActorModelVideotapeModel",
                columns: table => new
                {
                    ActorsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    VideotapesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorModelVideotapeModel", x => new { x.ActorsId, x.VideotapesId });
                    table.ForeignKey(
                        name: "FK_ActorModelVideotapeModel_Actor_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorModelVideotapeModel_VideTape_VideotapesId",
                        column: x => x.VideotapesId,
                        principalTable: "VideTape",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GenreModelVideotapeModel",
                columns: table => new
                {
                    GenreName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VideotapesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreModelVideotapeModel", x => new { x.GenreName, x.VideotapesId });
                    table.ForeignKey(
                        name: "FK_GenreModelVideotapeModel_Genre_GenreName",
                        column: x => x.GenreName,
                        principalTable: "Genre",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreModelVideotapeModel_VideTape_VideotapesId",
                        column: x => x.VideotapesId,
                        principalTable: "VideTape",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                table: "Genre",
                column: "Name",
                values: new object[]
                {
                    "action",
                    "adventure",
                    "comedy"
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("4420a08f-d6e1-4b13-88bf-6f3fafae5278"), "1234", new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"), "honza@gmail.com" },
                    { new Guid("705d7a86-9984-4ea8-a539-f2d3a369e8a9"), "1234", new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"), "jan@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorModelVideotapeModel_VideotapesId",
                table: "ActorModelVideotapeModel",
                column: "VideotapesId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreModelVideotapeModel_VideotapesId",
                table: "GenreModelVideotapeModel",
                column: "VideotapesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorModelVideotapeModel");

            migrationBuilder.DropTable(
                name: "GenreModelVideotapeModel");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4420a08f-d6e1-4b13-88bf-6f3fafae5278"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("705d7a86-9984-4ea8-a539-f2d3a369e8a9"));

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "VideTape",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
