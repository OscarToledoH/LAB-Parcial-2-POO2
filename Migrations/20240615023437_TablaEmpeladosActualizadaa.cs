using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registro_de_Empleados.Migrations
{
    /// <inheritdoc />
    public partial class TablaEmpeladosActualizadaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "numero",
                table: "Empleados",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "Puesto",
                table: "Empleados",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Empleados",
                newName: "numero");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Empleados",
                newName: "Puesto");

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
