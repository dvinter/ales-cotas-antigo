using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlesCotas.Infra.Data.Migrations
{
    public partial class GrampeamentoItemCR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrampeamentoTipos",
                columns: table => new
                {
                    IDGrampeamentoTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "SQL_LATIN1_GENERAL_CP1_CI_AI"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrampeamentoTipos", x => x.IDGrampeamentoTipo);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacaoItemCR",
                columns: table => new
                {
                    IDSolicitacaoItemCR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSolicitacaoItem = table.Column<int>(type: "int", nullable: false),
                    IDGrampeamentoTipo = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoItemCR", x => x.IDSolicitacaoItemCR);
                    table.ForeignKey(
                        name: "FK_SolicitacaoItemCR_GrampeamentoTipos_IDGrampeamentoTipo",
                        column: x => x.IDGrampeamentoTipo,
                        principalTable: "GrampeamentoTipos",
                        principalColumn: "IDGrampeamentoTipo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitacaoItemCR_SolicitacaoItem_IDSolicitacaoItem",
                        column: x => x.IDSolicitacaoItem,
                        principalTable: "SolicitacaoItem",
                        principalColumn: "IDSolicitacaoItem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoItemCR_IDGrampeamentoTipo",
                table: "SolicitacaoItemCR",
                column: "IDGrampeamentoTipo");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoItemCR_IDSolicitacaoItem",
                table: "SolicitacaoItemCR",
                column: "IDSolicitacaoItem",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitacaoItemCR");

            migrationBuilder.DropTable(
                name: "GrampeamentoTipos");
        }
    }
}
