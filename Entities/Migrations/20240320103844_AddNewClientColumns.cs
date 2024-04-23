using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class AddNewClientColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
             name: "RefreshToken",
             table: "Client",
             nullable: true);

            migrationBuilder.AddColumn<DateTime>(
             name: "TokenCreated",
             table: "Client",
             nullable: true);

            migrationBuilder.AddColumn<DateTime>(
             name: "TokenExpires",
             table: "Client",
             nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Client");

            migrationBuilder.DropColumn(
               name: "RefreshToken",
               table: "Client");

            migrationBuilder.DropColumn(
               name: "TokenCreated",
               table: "Client");

            migrationBuilder.DropColumn(
               name: "TokenExpires",
               table: "Client");
        }
    }
}
