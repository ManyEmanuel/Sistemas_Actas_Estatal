using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class HistorialModificaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialModificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCasilla = table.Column<int>(nullable: false),
                    Concepto = table.Column<int>(nullable: false),
                    TipoEleccion = table.Column<int>(nullable: false),
                    Estatus = table.Column<int>(nullable: false),
                    FechaSolicitud = table.Column<DateTime>(nullable: false),
                    FechaAprobacion = table.Column<DateTime>(nullable: false),
                    UsuarioRegistro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialModificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialModificaciones_Casillas_IdCasilla",
                        column: x => x.IdCasilla,
                        principalTable: "Casillas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialModificaciones_AspNetUsers_UsuarioRegistro",
                        column: x => x.UsuarioRegistro,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialModificaciones_IdCasilla",
                table: "HistorialModificaciones",
                column: "IdCasilla");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialModificaciones_UsuarioRegistro",
                table: "HistorialModificaciones",
                column: "UsuarioRegistro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialModificaciones");
        }
    }
}
