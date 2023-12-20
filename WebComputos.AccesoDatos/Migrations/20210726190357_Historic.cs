using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class Historic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminar",
                table: "HistorialSubsanar",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estatus",
                table: "HistorialSubsanar",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "HistoricoRestablecer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCausal = table.Column<int>(nullable: false),
                    CasillaId = table.Column<int>(nullable: false),
                    TipoEleccionId = table.Column<int>(nullable: false),
                    Causal1 = table.Column<bool>(nullable: false),
                    Causal2 = table.Column<bool>(nullable: false),
                    Causal3 = table.Column<bool>(nullable: false),
                    Causal4 = table.Column<bool>(nullable: false),
                    Causal5 = table.Column<bool>(nullable: false),
                    Causal6 = table.Column<bool>(nullable: false),
                    Causal7 = table.Column<bool>(nullable: false),
                    Causal8 = table.Column<bool>(nullable: false),
                    Causal9 = table.Column<bool>(nullable: false),
                    Causal10 = table.Column<bool>(nullable: false),
                    Causal11 = table.Column<bool>(nullable: false),
                    Total_Causales = table.Column<int>(nullable: false),
                    Recuento_Total = table.Column<bool>(nullable: false),
                    RP = table.Column<bool>(nullable: false),
                    UsuarioRegistro = table.Column<string>(nullable: true),
                    FechaHora = table.Column<DateTime>(nullable: false),
                    IdHistorial = table.Column<int>(nullable: false),
                    Estatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoRestablecer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoRestablecer_Casillas_CasillaId",
                        column: x => x.CasillaId,
                        principalTable: "Casillas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoRestablecer_Causales_recuento_IdCausal",
                        column: x => x.IdCausal,
                        principalTable: "Causales_recuento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoRestablecer_HistorialSubsanar_IdHistorial",
                        column: x => x.IdHistorial,
                        principalTable: "HistorialSubsanar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoRestablecer_Tipos_Eleccion_TipoEleccionId",
                        column: x => x.TipoEleccionId,
                        principalTable: "Tipos_Eleccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoRestablecer_AspNetUsers_UsuarioRegistro",
                        column: x => x.UsuarioRegistro,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoRestablecer_CasillaId",
                table: "HistoricoRestablecer",
                column: "CasillaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoRestablecer_IdCausal",
                table: "HistoricoRestablecer",
                column: "IdCausal");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoRestablecer_IdHistorial",
                table: "HistoricoRestablecer",
                column: "IdHistorial");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoRestablecer_TipoEleccionId",
                table: "HistoricoRestablecer",
                column: "TipoEleccionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoRestablecer_UsuarioRegistro",
                table: "HistoricoRestablecer",
                column: "UsuarioRegistro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoRestablecer");

            migrationBuilder.DropColumn(
                name: "Eliminar",
                table: "HistorialSubsanar");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "HistorialSubsanar");
        }
    }
}
