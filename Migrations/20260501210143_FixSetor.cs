using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W5i___Controle_de_Atendimentos.Migrations
{
    /// <inheritdoc />
    public partial class FixSetor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Setores",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "setorID",
                table: "Setores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tempoEstimadoHoras",
                table: "Prioridades",
                newName: "TempoEstimadoHoras");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Prioridades",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "prioridadeID",
                table: "Prioridades",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "titulo",
                table: "Chamados",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Chamados",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "setorID",
                table: "Chamados",
                newName: "SetorID");

            migrationBuilder.RenameColumn(
                name: "prioridadeID",
                table: "Chamados",
                newName: "PrioridadeID");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Chamados",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "dataCriacao",
                table: "Chamados",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "chamadoID",
                table: "Chamados",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataConclusao",
                table: "Chamados",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_PrioridadeID",
                table: "Chamados",
                column: "PrioridadeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Prioridades_PrioridadeID",
                table: "Chamados",
                column: "PrioridadeID",
                principalTable: "Prioridades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Prioridades_PrioridadeID",
                table: "Chamados");

            migrationBuilder.DropIndex(
                name: "IX_Chamados_PrioridadeID",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "DataConclusao",
                table: "Chamados");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Setores",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Setores",
                newName: "setorID");

            migrationBuilder.RenameColumn(
                name: "TempoEstimadoHoras",
                table: "Prioridades",
                newName: "tempoEstimadoHoras");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Prioridades",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Prioridades",
                newName: "prioridadeID");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Chamados",
                newName: "titulo");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Chamados",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "SetorID",
                table: "Chamados",
                newName: "setorID");

            migrationBuilder.RenameColumn(
                name: "PrioridadeID",
                table: "Chamados",
                newName: "prioridadeID");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Chamados",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Chamados",
                newName: "dataCriacao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Chamados",
                newName: "chamadoID");
        }
    }
}
