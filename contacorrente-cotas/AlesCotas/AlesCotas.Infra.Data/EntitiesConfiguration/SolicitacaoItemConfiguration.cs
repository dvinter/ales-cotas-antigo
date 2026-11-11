using AlesCotas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlesCotas.Infra.Data.EntitiesConfiguration
{
    sealed internal class SolicitacaoItemConfiguration : IEntityTypeConfiguration<SolicitacaoItem>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoItem> builder)
        {
            // P.K
            builder.HasKey(p => p.IDSolicitacaoItem);

            // Propriedades
            builder.Property(p => p.QuantidadeSolicitada).IsRequired();
            builder.Property(p => p.QuantidadeAutorizada).IsRequired();
            builder.Property(p => p.ValorUnitario).HasPrecision(8, 2).IsRequired();

            // Datas
            builder.Property(p => p.CreatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();

            // Relacionamentos
            builder.HasOne(e => e.Solicitacao)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.IDSolicitacao)
                .IsRequired();

            builder.HasOne(e => e.Produto)
                .WithMany(e => e.SolicitacaoItems)
                .HasForeignKey(e => e.IDProduto)
                .IsRequired();
        }
    }
}
