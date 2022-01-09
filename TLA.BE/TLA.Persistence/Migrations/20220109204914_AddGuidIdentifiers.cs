using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TLA.Persistence.Migrations
{
    public partial class AddGuidIdentifiers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GuidIdentifier",
                table: "Words",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GuidIdentifier",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GuidIdentifier",
                table: "Quizes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Words_GuidIdentifier",
                table: "Words",
                column: "GuidIdentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GuidIdentifier",
                table: "Users",
                column: "GuidIdentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_GuidIdentifier",
                table: "Quizes",
                column: "GuidIdentifier",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Words_GuidIdentifier",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Users_GuidIdentifier",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Quizes_GuidIdentifier",
                table: "Quizes");

            migrationBuilder.DropColumn(
                name: "GuidIdentifier",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "GuidIdentifier",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GuidIdentifier",
                table: "Quizes");
        }
    }
}
