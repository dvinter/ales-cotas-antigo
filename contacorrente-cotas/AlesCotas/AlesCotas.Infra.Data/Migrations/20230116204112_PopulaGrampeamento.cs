using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlesCotas.Infra.Data.Migrations
{
    public partial class PopulaGrampeamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Grampeamentos
            migrationBuilder.Sql("INSERT INTO GrampeamentoTipos (Nome, CreatedAt, UpdatedAt) values ('Grampo-E', GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO GrampeamentoTipos (Nome, CreatedAt, UpdatedAt) values ('Grampo-D', GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO GrampeamentoTipos (Nome, CreatedAt, UpdatedAt) values ('Grampo-L', GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO GrampeamentoTipos (Nome, CreatedAt, UpdatedAt) values ('Grampo-S', GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO GrampeamentoTipos (Nome, CreatedAt, UpdatedAt) values ('S/Grampo', GETDATE(), GETDATE())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM GrampeamentoTipos");
        }
    }
}
