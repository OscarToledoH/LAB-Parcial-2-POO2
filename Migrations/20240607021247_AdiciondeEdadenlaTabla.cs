using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registro_de_Empleados.Migrations
{
    /// <inheritdoc />
    public partial class AdiciondeEdadenlaTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Empleados");
        }
    }
}
