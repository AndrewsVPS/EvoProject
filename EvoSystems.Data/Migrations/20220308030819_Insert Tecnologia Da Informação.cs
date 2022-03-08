using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoSystems.Data.Migrations
{
    public partial class InsertTecnologiaDaInformação : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departamento",
                columns: new[] { "Id", "Nome", "Silgla" },
                values: new object[] { new Guid("acaf2a77-b7e8-4ca2-9698-3b3910df5142"), "Tecnologia Da Informação", "T.I" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departamento",
                keyColumn: "Id",
                keyValue: new Guid("acaf2a77-b7e8-4ca2-9698-3b3910df5142"));
        }
    }
}
