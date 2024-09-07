using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SicemOperation.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Operation");

            migrationBuilder.EnsureSchema(
                name: "System");

            migrationBuilder.CreateTable(
                name: "Oficinas",
                schema: "System",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inactivo = table.Column<bool>(type: "bit", nullable: true),
                    ultimaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficinas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "System",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inactivo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Incidencia",
                schema: "Operation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fugaTomaDomiciliaria = table.Column<int>(type: "int", nullable: false),
                    fugaLineaConduccion = table.Column<int>(type: "int", nullable: false),
                    fugaLineaDistribucion = table.Column<int>(type: "int", nullable: false),
                    fallaAguaPotableElectrica = table.Column<int>(type: "int", nullable: false),
                    fallaAguaPotableCentroControl = table.Column<int>(type: "int", nullable: false),
                    fallaAguaPotableBombeo = table.Column<int>(type: "int", nullable: false),
                    fallaAguaResidualPotableElectrica = table.Column<int>(type: "int", nullable: false),
                    fallaAguaResidualCentroControl = table.Column<int>(type: "int", nullable: false),
                    fallaAguaResidualBombeo = table.Column<int>(type: "int", nullable: false),
                    recoleccionResidualAtendido = table.Column<int>(type: "int", nullable: false),
                    recoleccionResidualColector = table.Column<int>(type: "int", nullable: false),
                    recoleccionResidualVisita = table.Column<int>(type: "int", nullable: false),
                    fallaTratamientoEquipos = table.Column<int>(type: "int", nullable: false),
                    fallaTratamientoAereacion = table.Column<int>(type: "int", nullable: false),
                    fallTratamientoRecirculacion = table.Column<int>(type: "int", nullable: false),
                    fallTratamientoSedimentacion = table.Column<int>(type: "int", nullable: false),
                    fallTratamientoDesinfeccion = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ultimaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    eliminado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    oficinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencia", x => x.id);
                    table.ForeignKey(
                        name: "FK_Incidencia_Oficinas_oficinaId",
                        column: x => x.oficinaId,
                        principalSchema: "System",
                        principalTable: "Oficinas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Oficinas",
                columns: new[] { "id", "alias", "inactivo", "nombre" },
                values: new object[] { 1, null, null, "Oficina de prueba" });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Usuarios",
                columns: new[] { "id", "apellidos", "correo", "inactivo", "nombre", "password" },
                values: new object[] { 1, null, "admin@email.com", null, "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Incidencia_oficinaId",
                schema: "Operation",
                table: "Incidencia",
                column: "oficinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidencia",
                schema: "Operation");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Oficinas",
                schema: "System");
        }
    }
}
