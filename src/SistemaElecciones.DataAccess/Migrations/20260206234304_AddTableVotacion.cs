using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaElecciones.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTableVotacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Votaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaniaId = table.Column<int>(type: "int", nullable: false),
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    usuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuarioActualizacionId = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votaciones_Campania_CampaniaId",
                        column: x => x.CampaniaId,
                        principalTable: "Campania",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Votaciones_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votaciones_CampaniaId",
                table: "Votaciones",
                column: "CampaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Votaciones_CandidatoId",
                table: "Votaciones",
                column: "CandidatoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votaciones");
        }
    }
}
