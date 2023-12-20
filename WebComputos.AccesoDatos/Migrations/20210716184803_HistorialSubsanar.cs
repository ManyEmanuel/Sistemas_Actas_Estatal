using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class HistorialSubsanar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Solicitud",
                table: "Votos_Actas_Ext",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Solicitud",
                table: "Votos_Actas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Solicitud",
                table: "Votos_Acta_RP",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Solicitud",
                table: "Recepcion_Paquete",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Solicitud",
                table: "Actas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Solicitud",
                table: "Acta_RP",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HistorialSubsanar",
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
                    RP = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialSubsanar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialSubsanar_Casillas_CasillaId",
                        column: x => x.CasillaId,
                        principalTable: "Casillas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialSubsanar_Causales_recuento_IdCausal",
                        column: x => x.IdCausal,
                        principalTable: "Causales_recuento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialSubsanar_Tipos_Eleccion_TipoEleccionId",
                        column: x => x.TipoEleccionId,
                        principalTable: "Tipos_Eleccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialSubsanar_CasillaId",
                table: "HistorialSubsanar",
                column: "CasillaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialSubsanar_IdCausal",
                table: "HistorialSubsanar",
                column: "IdCausal");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialSubsanar_TipoEleccionId",
                table: "HistorialSubsanar",
                column: "TipoEleccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialSubsanar");

            migrationBuilder.DropColumn(
                name: "Solicitud",
                table: "Votos_Actas_Ext");

            migrationBuilder.DropColumn(
                name: "Solicitud",
                table: "Votos_Actas");

            migrationBuilder.DropColumn(
                name: "Solicitud",
                table: "Votos_Acta_RP");

            migrationBuilder.DropColumn(
                name: "Solicitud",
                table: "Recepcion_Paquete");

            migrationBuilder.DropColumn(
                name: "Solicitud",
                table: "Actas");

            migrationBuilder.DropColumn(
                name: "Solicitud",
                table: "Acta_RP");
        }
    }
}
