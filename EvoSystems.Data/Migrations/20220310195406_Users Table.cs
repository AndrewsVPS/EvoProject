using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoSystems.Data.Migrations
{
    public partial class UsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 3, 10, 16, 54, 6, 405, DateTimeKind.Local).AddTicks(8511)),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Nome", "Sigla" },
                values: new object[] { new Guid("acaf2a77-b7e8-4ca2-9698-3b3910df5142"), new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tecnologia Da Informação", "T.i" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
