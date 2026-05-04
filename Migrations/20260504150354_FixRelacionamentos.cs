using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace W5i___Controle_de_Atendimentos.Migrations
{
    /// <inheritdoc />
    public partial class FixRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Funcionario = table.Column<string>(type: "text", nullable: false),
                    DataCheckIn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataCheckOut = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TotalChamadosCriados = table.Column<int>(type: "integer", nullable: true),
                    TotalChamadosResolvidos = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prioridades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    TempoEstimadoHoras = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chamados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    SetorID = table.Column<int>(type: "integer", nullable: false),
                    PrioridadeID = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Solucao = table.Column<string>(type: "text", nullable: true),
                    AtendimentoCriacaoId = table.Column<int>(type: "integer", nullable: true),
                    AtendimentoResolucaoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chamados_Atendimentos_AtendimentoCriacaoId",
                        column: x => x.AtendimentoCriacaoId,
                        principalTable: "Atendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamados_Atendimentos_AtendimentoResolucaoId",
                        column: x => x.AtendimentoResolucaoId,
                        principalTable: "Atendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamados_Prioridades_PrioridadeID",
                        column: x => x.PrioridadeID,
                        principalTable: "Prioridades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamados_Setores_SetorID",
                        column: x => x.SetorID,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_AtendimentoCriacaoId",
                table: "Chamados",
                column: "AtendimentoCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_AtendimentoResolucaoId",
                table: "Chamados",
                column: "AtendimentoResolucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_PrioridadeID",
                table: "Chamados",
                column: "PrioridadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_SetorID",
                table: "Chamados",
                column: "SetorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamados");

            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Prioridades");

            migrationBuilder.DropTable(
                name: "Setores");
        }
    }
}
