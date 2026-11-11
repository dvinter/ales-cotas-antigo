using AlesCotas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlesCotas.Infra.Data.EntitiesConfiguration
{
    sealed internal class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // P.K
            builder.HasKey(p => p.IDProduto);

            // Propriedades
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired().UseCollation("SQL_LATIN1_GENERAL_CP1_CI_AI");
            builder.Property(p => p.ValorUnitario).HasPrecision(8, 2).IsRequired();

            // Datas
            builder.Property(p => p.CreatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();

            // Relacionamentos
            builder.HasOne(e => e.Tipo)
                .WithMany(e => e.Produtos)
                .HasForeignKey(e => e.IDProdutoTipo)
                .IsRequired();
        }
    }
}
