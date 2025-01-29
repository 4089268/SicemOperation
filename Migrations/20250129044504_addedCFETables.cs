using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SicemOperation.Migrations
{
    /// <inheritdoc />
    public partial class addedCFETables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CFE");

            migrationBuilder.EnsureSchema(
                name: "Global");

            migrationBuilder.CreateTable(
                name: "Cat_Organismos",
                schema: "Global",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    municipio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Organismos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Procesos",
                schema: "CFE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proceso = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Procesos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Tarifas",
                schema: "CFE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inactivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Tarifas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Zonas",
                schema: "CFE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Zonas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Medidores",
                schema: "CFE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idOrganismo = table.Column<int>(type: "int", nullable: false),
                    rPU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numMedidor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    latitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    longitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cargaConectada = table.Column<int>(type: "int", nullable: false),
                    demandaContratada = table.Column<int>(type: "int", nullable: false),
                    idTarifa = table.Column<int>(type: "int", nullable: false),
                    idProceso = table.Column<int>(type: "int", nullable: false),
                    idZona = table.Column<int>(type: "int", nullable: false),
                    inactivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Medidores", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cat_Medidores_Cat_Organismos_idOrganismo",
                        column: x => x.idOrganismo,
                        principalSchema: "Global",
                        principalTable: "Cat_Organismos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_Medidores_Cat_Procesos_idProceso",
                        column: x => x.idProceso,
                        principalSchema: "CFE",
                        principalTable: "Cat_Procesos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_Medidores_Cat_Tarifas_idTarifa",
                        column: x => x.idTarifa,
                        principalSchema: "CFE",
                        principalTable: "Cat_Tarifas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_Medidores_Cat_Zonas_idZona",
                        column: x => x.idZona,
                        principalSchema: "CFE",
                        principalTable: "Cat_Zonas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Opr_Consumos",
                schema: "CFE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idMedidor = table.Column<int>(type: "int", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "date", nullable: false),
                    consumo = table.Column<int>(type: "int", nullable: false),
                    importe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    demanda = table.Column<int>(type: "int", nullable: false),
                    af = table.Column<int>(type: "int", nullable: false),
                    mf = table.Column<int>(type: "int", nullable: false),
                    kvarh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fpPorc = table.Column<double>(type: "float", nullable: false),
                    fpMon = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dapMon = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opr_Consumos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Opr_Consumos_Cat_Medidores_idMedidor",
                        column: x => x.idMedidor,
                        principalSchema: "CFE",
                        principalTable: "Cat_Medidores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Global",
                table: "Cat_Organismos",
                columns: new[] { "id", "direccion", "municipio", "nombre" },
                values: new object[,]
                {
                    { 1, "SN/D", "Othon P. Blanco", "CAPA Othon P. Blanco" },
                    { 2, "SN/D", "Tulum", "CAPA Tulum" },
                    { 3, "SN/D", "Felipe Carrillo Puerto", "CAPA Felipe Carrillo Puerto" },
                    { 4, "SN/D", "Bacalar", "CAPA Bacalar" },
                    { 5, "SN/D", "Jose Maria Morelos", "CAPA Jose Maria Morelos" },
                    { 6, "SN/D", "Lazaro Cardenas", "CAPA Lazaro Cardenas" },
                    { 7, "SN/D", "Cozumel", "CAPA Cozumel" }
                });

            migrationBuilder.InsertData(
                schema: "CFE",
                table: "Cat_Procesos",
                columns: new[] { "id", "proceso" },
                values: new object[,]
                {
                    { 1, "OFICINAS" },
                    { 2, "RODUCCIÓN" },
                    { 3, "DISTRIBUCIÓN" },
                    { 4, "RESIDUAL" },
                    { 5, "TRATAMIENTO" }
                });

            migrationBuilder.InsertData(
                schema: "CFE",
                table: "Cat_Tarifas",
                columns: new[] { "id", "inactivo", "nombre" },
                values: new object[,]
                {
                    { 1, false, "GDMTH" },
                    { 2, false, "GDMTO" },
                    { 3, false, "PDBT" }
                });

            migrationBuilder.InsertData(
                schema: "CFE",
                table: "Cat_Zonas",
                columns: new[] { "id", "zona" },
                values: new object[,]
                {
                    { 1, "URBANA" },
                    { 2, "RURAL" }
                });

            migrationBuilder.UpdateData(
                schema: "System",
                table: "Usuarios",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$VWrSRkO2CvFke3lPkbn1fOzHC98e13lE0Pei9gn27UEDUI/odjBly");

            migrationBuilder.InsertData(
                schema: "CFE",
                table: "Cat_Medidores",
                columns: new[] { "id", "cargaConectada", "demandaContratada", "idOrganismo", "idProceso", "idTarifa", "idZona", "inactivo", "latitud", "longitud", "numMedidor", "rPU", "ubicacion" },
                values: new object[] { 1, 200, 200, 2, 1, 1, 1, false, null, null, "MY727A", "812080400696", "AV. TULUM/ESCORPION Y COBA" });

            migrationBuilder.InsertData(
                schema: "CFE",
                table: "Opr_Consumos",
                columns: new[] { "id", "af", "consumo", "dapMon", "demanda", "fechaFin", "fechaInicio", "fpMon", "fpPorc", "idMedidor", "importe", "kvarh", "mf" },
                values: new object[] { 1, 2024, 30899, 8004.36m, 127, new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1780.54m, 94.329999999999998, 1, 193705.0m, 30510.0m, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Medidores_idOrganismo",
                schema: "CFE",
                table: "Cat_Medidores",
                column: "idOrganismo");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Medidores_idProceso",
                schema: "CFE",
                table: "Cat_Medidores",
                column: "idProceso");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Medidores_idTarifa",
                schema: "CFE",
                table: "Cat_Medidores",
                column: "idTarifa");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Medidores_idZona",
                schema: "CFE",
                table: "Cat_Medidores",
                column: "idZona");

            migrationBuilder.CreateIndex(
                name: "IX_Opr_Consumos_idMedidor",
                schema: "CFE",
                table: "Opr_Consumos",
                column: "idMedidor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opr_Consumos",
                schema: "CFE");

            migrationBuilder.DropTable(
                name: "Cat_Medidores",
                schema: "CFE");

            migrationBuilder.DropTable(
                name: "Cat_Organismos",
                schema: "Global");

            migrationBuilder.DropTable(
                name: "Cat_Procesos",
                schema: "CFE");

            migrationBuilder.DropTable(
                name: "Cat_Tarifas",
                schema: "CFE");

            migrationBuilder.DropTable(
                name: "Cat_Zonas",
                schema: "CFE");

            migrationBuilder.UpdateData(
                schema: "System",
                table: "Usuarios",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$aYxcmSuSVeN5Jwx26us9AeLRWM8paUdZME5A4WR4uX7ung.qy3Nr6");
        }
    }
}
