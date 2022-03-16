using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoSystems.Data.Migrations
{
    public partial class DepartamentosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 3, 13, 21, 52, 48, 503, DateTimeKind.Local).AddTicks(1314)),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionários",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 3, 13, 21, 52, 48, 507, DateTimeKind.Local).AddTicks(120)),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    RG = table.Column<string>(maxLength: 100, nullable: false),
                    Foto = table.Column<string>(nullable: true),
                    DepartamentoId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionários", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionários_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionários_DepartamentoId",
                table: "Funcionários",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionários");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
