﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SessionIdAddedInOrderHeaderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "OrderHeaders");
        }
    }
}
