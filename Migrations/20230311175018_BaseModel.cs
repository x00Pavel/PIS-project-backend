﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace video_pujcovna_back.Migrations
{
    /// <inheritdoc />
    public partial class BaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");
        }
    }
}
