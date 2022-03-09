using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoSystems.Data.Migrations
{
    public partial class UpadateDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("acaf2a77-b7e8-4ca2-9698-3b3910df5142"),
                column: "DateCreated",
                value: new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("acaf2a77-b7e8-4ca2-9698-3b3910df5142"),
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
