using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlesCotas.Infra.Data.Migrations
{
    public partial class PopulaTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ProdutoTipo (Nome, Unidade, Ativo,CreatedAt, UpdatedAt) values ('Combustível', 'L', 1, GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO ProdutoTipo (Nome, Unidade, Ativo,CreatedAt, UpdatedAt) values ('Copia Reprografica', 'UN', 1, GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO ProdutoTipo (Nome, Unidade, Ativo,CreatedAt, UpdatedAt) values ('Passagem Aerea', 'UN', 1, GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO ProdutoTipo (Nome, Unidade, Ativo,CreatedAt, UpdatedAt) values ('Periodicos', 'UN', 1, GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO ProdutoTipo (Nome, Unidade, Ativo,CreatedAt, UpdatedAt) values ('Diaria', 'UN', 1, GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO ProdutoTipo (Nome, Unidade, Ativo,CreatedAt, UpdatedAt) values ('Material Expediente', 'UN', 1, GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO ProdutoTipo (Nome, Unidade, Ativo,CreatedAt, UpdatedAt) values ('Postagem Ar', 'UN', 1, GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO ProdutoTipo (Nome, Unidade, Ativo,CreatedAt, UpdatedAt) values ('Postagem Simples', 'UN', 1, GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO ProdutoTipo (Nome, Unidade, Ativo,CreatedAt, UpdatedAt) values ('Telefonia', 'UN', 1, GETDATE(), GETDATE())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ProdutoTipo");
        }
    }
}
