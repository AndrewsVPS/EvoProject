using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoSystems.Data.Migrations
{
    public partial class CommonFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Departamento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Departamento",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departamento",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departamento");
        }
    }
}
