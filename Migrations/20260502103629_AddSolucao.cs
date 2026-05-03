using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W5i___Controle_de_Atendimentos.Migrations
{
    /// <inheritdoc />
    public partial class AddSolucao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Solucao",
                table: "Chamados",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_SetorID",
                table: "Chamados",
                column: "SetorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Setores_SetorID",
                table: "Chamados",
                column: "SetorID",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Setores_SetorID",
                table: "Chamados");

            migrationBuilder.DropIndex(
                name: "IX_Chamados_SetorID",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "Solucao",
                table: "Chamados");
        }
    }
}
