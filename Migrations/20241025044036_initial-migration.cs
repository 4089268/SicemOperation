using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SicemOperation.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Operation");

            migrationBuilder.EnsureSchema(
                name: "System");

            migrationBuilder.CreateTable(
                name: "Cat_Incidencia",
                schema: "Operation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grupo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Incidencia", x => x.id);
                });

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
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inactivo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Opr_Incidencia",
                schema: "Operation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ultimaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    eliminado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tipoIncidenciaId = table.Column<int>(type: "int", nullable: false),
                    oficinaId = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opr_Incidencia", x => x.id);
                    table.ForeignKey(
                        name: "FK_Opr_Incidencia_Cat_Incidencia_tipoIncidenciaId",
                        column: x => x.tipoIncidenciaId,
                        principalSchema: "Operation",
                        principalTable: "Cat_Incidencia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opr_Incidencia_Oficinas_oficinaId",
                        column: x => x.oficinaId,
                        principalSchema: "System",
                        principalTable: "Oficinas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opr_Incidencia_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalSchema: "System",
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Operation",
                table: "Cat_Incidencia",
                columns: new[] { "id", "descripcion", "grupo", "nombre" },
                values: new object[,]
                {
                    { 1, "En tomas domiciliarias", "Numero de Fugas", "fugaTomaDomiciliaria" },
                    { 2, "En lineas de Conduccion", "Numero de Fugas", "fugaLineaConduccion" },
                    { 3, "En redes de distribucion", "Numero de Fugas", "fugaLineaDistribucion" },
                    { 4, "Subestaciones electricas", "Fallas en equipos electromecanicos en agua potable", "fallaAguaPotableElectrica" },
                    { 5, "Centro de control de motores", "Fallas en equipos electromecanicos en agua potable", "fallaAguaPotableCentroControl" },
                    { 6, "Equipo de bombeo", "Fallas en equipos electromecanicos en agua potable", "fallaAguaPotableBombeo" },
                    { 7, "Subestaciones electricas", "Fallas en equipos electromecanicos en aguas residuales", "fallaAguaResidualElectrica" },
                    { 8, "Centro de control de motores", "Fallas en equipos electromecanicos en aguas residuales", "fallaAguaResidualCentroControl" },
                    { 9, "Equipo de bombeo", "Fallas en equipos electromecanicos en aguas residuales", "fallaAguaResidualBombeo" },
                    { 10, "Rebosamientos de agua residual atendidos", "Recoleccion aguas residuales", "recoleccionResidualAtendido" },
                    { 11, "Colectores desasolvados (mts)", "Recoleccion aguas residuales", "recoleccionResidualColector" },
                    { 12, "Pozos de visita desasolvados", "Recoleccion aguas residuales", "recoleccionResidualVisita" },
                    { 13, "Equipos en pretratamiento", "Fallas en plantas de tratamiento de aguas residuales", "fallaTratamientoEquipos" },
                    { 14, "Sistema de aereacion", "Fallas en plantas de tratamiento de aguas residuales", "fallaTratamientoAereacion" },
                    { 15, "Equipos de recirculacion", "Fallas en plantas de tratamiento de aguas residuales", "fallaTratamientoRecirculacion" },
                    { 16, "Sistema de sedimentacion", "Fallas en plantas de tratamiento de aguas residuales", "fallaTratamientoSedimentacion" },
                    { 17, "Sistema de desinfeccion", "Fallas en plantas de tratamiento de aguas residuales", "fallaTratamientoDesinfeccion" }
                });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Oficinas",
                columns: new[] { "id", "alias", "inactivo", "nombre" },
                values: new object[] { 1, null, null, "Oficina de prueba" });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Usuarios",
                columns: new[] { "id", "correo", "inactivo", "nombre", "password" },
                values: new object[] { 1, "admin@email.com", null, "administrador", "$2a$11$aYxcmSuSVeN5Jwx26us9AeLRWM8paUdZME5A4WR4uX7ung.qy3Nr6" });

            migrationBuilder.CreateIndex(
                name: "IX_Opr_Incidencia_oficinaId",
                schema: "Operation",
                table: "Opr_Incidencia",
                column: "oficinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Opr_Incidencia_tipoIncidenciaId",
                schema: "Operation",
                table: "Opr_Incidencia",
                column: "tipoIncidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Opr_Incidencia_usuarioId",
                schema: "Operation",
                table: "Opr_Incidencia",
                column: "usuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opr_Incidencia",
                schema: "Operation");

            migrationBuilder.DropTable(
                name: "Cat_Incidencia",
                schema: "Operation");

            migrationBuilder.DropTable(
                name: "Oficinas",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "System");
        }
    }
}
