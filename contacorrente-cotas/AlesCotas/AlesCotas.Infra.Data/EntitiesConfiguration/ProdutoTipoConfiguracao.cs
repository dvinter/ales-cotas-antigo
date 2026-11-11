using AlesCotas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlesCotas.Infra.Data.EntitiesConfiguration
{
    sealed internal class ProdutoTipoConfiguracao : IEntityTypeConfiguration<ProdutoTipo>
    {
        public void Configure(EntityTypeBuilder<ProdutoTipo> builder)
        {
            // P.K
            builder.HasKey(p => p.IDProdutoTipo);

            // Propriedades
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired().UseCollation("SQL_LATIN1_GENERAL_CP1_CI_AI");
            builder.Property(p => p.Unidade).HasMaxLength(5).IsRequired();
            builder.Property(p => p.Ativo).IsRequired();

            // Datas
            builder.Property(p => p.CreatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();
        }
    }
}
