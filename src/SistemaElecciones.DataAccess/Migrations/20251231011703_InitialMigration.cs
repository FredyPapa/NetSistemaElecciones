using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaElecciones.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoCampania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    usuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuarioActualizacionId = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCampania", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    usuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuarioActualizacionId = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denominacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    HoraFin = table.Column<TimeOnly>(type: "time", nullable: false),
                    EstadoCampaniaId = table.Column<int>(type: "int", nullable: false),
                    PermiteVotoBlanco = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    usuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuarioActualizacionId = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campania_EstadoCampania_EstadoCampaniaId",
                        column: x => x.EstadoCampaniaId,
                        principalTable: "EstadoCampania",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trabajador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SexoId = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FotoUrl = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    usuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuarioActualizacionId = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trabajador_Sexo_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaniaId = table.Column<int>(type: "int", nullable: false),
                    TrabajadorId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    usuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuarioActualizacionId = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidato_Campania_CampaniaId",
                        column: x => x.CampaniaId,
                        principalTable: "Campania",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Candidato_Trabajador_TrabajadorId",
                        column: x => x.TrabajadorId,
                        principalTable: "Trabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Padron",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaniaId = table.Column<int>(type: "int", nullable: false),
                    TrabajadorId = table.Column<int>(type: "int", nullable: false),
                    EstadoVoto = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    usuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuarioActualizacionId = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padron", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Padron_Campania_CampaniaId",
                        column: x => x.CampaniaId,
                        principalTable: "Campania",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Padron_Trabajador_TrabajadorId",
                        column: x => x.TrabajadorId,
                        principalTable: "Trabajador",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "EstadoCampania",
                columns: new[] { "Id", "Descripcion", "Estado", "FechaActualizacion", "FechaCreacion", "usuarioActualizacionId", "usuarioCreacionId" },
                values: new object[,]
                {
                    { 1, "Vigente", true, null, new DateTime(2025, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, "Finalizado", true, null, new DateTime(2025, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Sexo",
                columns: new[] { "Id", "Descripcion", "Estado", "FechaActualizacion", "FechaCreacion", "usuarioActualizacionId", "usuarioCreacionId" },
                values: new object[,]
                {
                    { 1, "Masculino", true, null, new DateTime(2025, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, "Femenino", true, null, new DateTime(2025, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campania_EstadoCampaniaId",
                table: "Campania",
                column: "EstadoCampaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_CampaniaId",
                table: "Candidato",
                column: "CampaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_TrabajadorId",
                table: "Candidato",
                column: "TrabajadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Padron_CampaniaId",
                table: "Padron",
                column: "CampaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Padron_TrabajadorId",
                table: "Padron",
                column: "TrabajadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_SexoId",
                table: "Trabajador",
                column: "SexoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Padron");

            migrationBuilder.DropTable(
                name: "Campania");

            migrationBuilder.DropTable(
                name: "Trabajador");

            migrationBuilder.DropTable(
                name: "EstadoCampania");

            migrationBuilder.DropTable(
                name: "Sexo");
        }
    }
}
