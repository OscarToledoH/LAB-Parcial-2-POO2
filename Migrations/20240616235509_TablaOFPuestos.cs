using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registro_de_Empleados.Migrations
{
    /// <inheritdoc />
    public partial class TablaOFPuestos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Areas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<int>(type: "int", nullable: false),
                    Personas = table.Column<int>(type: "int", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puestos");
        }
    }
}
