﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cw10.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRole",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdRole",
                table: "Accounts");
        }
    }
}
