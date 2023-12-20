using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class ExtranjeroVotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acta_Extranjero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumMesa = table.Column<int>(nullable: false),
                    Instalacion = table.Column<DateTime>(nullable: false),
                    UrnaVacia = table.Column<bool>(nullable: false),
                    UrnaVista = table.Column<bool>(nullable: false),
                    PersonasVotaron = table.Column<int>(nullable: false),
                    SobreVotos = table.Column<int>(nullable: false),
                    Deposito = table.Column<DateTime>(nullable: false),
                    VotosUrnas = table.Column<int>(nullable: false),
                    Incidentes = table.Column<bool>(nullable: false),
                    DesIncidentes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acta_Extranjero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votos_Actas_Ext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdActaExt = table.Column<int>(nullable: false),
                    NoRegistrados = table.Column<int>(nullable: false),
                    Nulos = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    TotalSistema = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votos_Actas_Ext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votos_Actas_Ext_Acta_Extranjero_IdActaExt",
                        column: x => x.IdActaExt,
                        principalTable: "Acta_Extranjero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Votos_Ext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVotosActa = table.Column<int>(nullable: false),
                    IdPartido = table.Column<int>(nullable: false),
                    IdCoalicion = table.Column<int>(nullable: false),
                    IdCombinacion = table.Column<int>(nullable: false),
                    Votos = table.Column<int>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Votos_Ext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalle_Votos_Ext_Votos_Actas_Ext_IdVotosActa",
                        column: x => x.IdVotosActa,
                        principalTable: "Votos_Actas_Ext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Votos_Ext_IdVotosActa",
                table: "Detalle_Votos_Ext",
                column: "IdVotosActa");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Actas_Ext_IdActaExt",
                table: "Votos_Actas_Ext",
                column: "IdActaExt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Votos_Ext");

            migrationBuilder.DropTable(
                name: "Votos_Actas_Ext");

            migrationBuilder.DropTable(
                name: "Acta_Extranjero");
        }
    }
}
