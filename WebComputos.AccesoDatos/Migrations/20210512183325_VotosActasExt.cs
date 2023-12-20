using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class VotosActasExt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Actas_Ext_Acta_Extranjero_IdActaExt",
                table: "Votos_Actas_Ext");

            migrationBuilder.DropIndex(
                name: "IX_Votos_Actas_Ext_IdActaExt",
                table: "Votos_Actas_Ext");

            migrationBuilder.DropColumn(
                name: "IdActaExt",
                table: "Votos_Actas_Ext");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdActaExt",
                table: "Votos_Actas_Ext",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Actas_Ext_IdActaExt",
                table: "Votos_Actas_Ext",
                column: "IdActaExt");

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Actas_Ext_Acta_Extranjero_IdActaExt",
                table: "Votos_Actas_Ext",
                column: "IdActaExt",
                principalTable: "Acta_Extranjero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
