using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudAudiovisuales.Migrations
{
    /// <inheritdoc />
    public partial class NullableFKModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "equipos_ibfk_1",
                table: "equipos");

            migrationBuilder.DropForeignKey(
                name: "equipos_ibfk_2",
                table: "equipos");

            migrationBuilder.DropForeignKey(
                name: "equipos_ibfk_3",
                table: "equipos");

            migrationBuilder.DropForeignKey(
                name: "modelos_ibfk_1",
                table: "modelos");

            migrationBuilder.DropForeignKey(
                name: "rentadevolucion_ibfk_1",
                table: "rentadevolucion");

            migrationBuilder.DropForeignKey(
                name: "rentadevolucion_ibfk_2",
                table: "rentadevolucion");

            migrationBuilder.DropForeignKey(
                name: "rentadevolucion_ibfk_3",
                table: "rentadevolucion");

            migrationBuilder.AddForeignKey(
                name: "equipos_ibfk_1",
                table: "equipos",
                column: "TipoEquipoID",
                principalTable: "tiposdeequipos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "equipos_ibfk_2",
                table: "equipos",
                column: "MarcaID",
                principalTable: "marcas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "equipos_ibfk_3",
                table: "equipos",
                column: "ModeloID",
                principalTable: "modelos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "modelos_ibfk_1",
                table: "modelos",
                column: "MarcaID",
                principalTable: "marcas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "rentadevolucion_ibfk_1",
                table: "rentadevolucion",
                column: "EmpleadoID",
                principalTable: "empleados",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "rentadevolucion_ibfk_2",
                table: "rentadevolucion",
                column: "EquipoID",
                principalTable: "equipos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "rentadevolucion_ibfk_3",
                table: "rentadevolucion",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "equipos_ibfk_1",
                table: "equipos");

            migrationBuilder.DropForeignKey(
                name: "equipos_ibfk_2",
                table: "equipos");

            migrationBuilder.DropForeignKey(
                name: "equipos_ibfk_3",
                table: "equipos");

            migrationBuilder.DropForeignKey(
                name: "modelos_ibfk_1",
                table: "modelos");

            migrationBuilder.DropForeignKey(
                name: "rentadevolucion_ibfk_1",
                table: "rentadevolucion");

            migrationBuilder.DropForeignKey(
                name: "rentadevolucion_ibfk_2",
                table: "rentadevolucion");

            migrationBuilder.DropForeignKey(
                name: "rentadevolucion_ibfk_3",
                table: "rentadevolucion");

            migrationBuilder.AddForeignKey(
                name: "equipos_ibfk_1",
                table: "equipos",
                column: "TipoEquipoID",
                principalTable: "tiposdeequipos",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "equipos_ibfk_2",
                table: "equipos",
                column: "MarcaID",
                principalTable: "marcas",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "equipos_ibfk_3",
                table: "equipos",
                column: "ModeloID",
                principalTable: "modelos",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "modelos_ibfk_1",
                table: "modelos",
                column: "MarcaID",
                principalTable: "marcas",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "rentadevolucion_ibfk_1",
                table: "rentadevolucion",
                column: "EmpleadoID",
                principalTable: "empleados",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "rentadevolucion_ibfk_2",
                table: "rentadevolucion",
                column: "EquipoID",
                principalTable: "equipos",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "rentadevolucion_ibfk_3",
                table: "rentadevolucion",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "ID");
        }
    }
}
