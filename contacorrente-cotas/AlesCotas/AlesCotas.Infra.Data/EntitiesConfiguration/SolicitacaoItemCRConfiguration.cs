using AlesCotas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlesCotas.Infra.Data.EntitiesConfiguration
{
    public class SolicitacaoItemCRConfiguration : IEntityTypeConfiguration<SolicitacaoItemCR>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoItemCR> builder)
        {

            // P.K
            builder.HasKey(e => e.IDSolicitacaoItemCR);

            // Datas
            builder.Property(p => p.CreatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();

            // Relacionamentos
            builder.HasOne(i => i.Item)
                .WithOne(i => i.ItemCR)
                .HasForeignKey<SolicitacaoItemCR>(i => i.IDSolicitacaoItem);

            builder.HasOne(i => i.GrampeamentoTipo)
                .WithMany(i => i.SolicitacaoItemCRs)
                .HasForeignKey(i => i.IDGrampeamentoTipo);
        }
    }
}
