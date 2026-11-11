using AlesCotas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlesCotas.Infra.Data.EntitiesConfiguration
{
    public class SolicitacaoItemArquivoConfiguration : IEntityTypeConfiguration<SolicitacaoItemArquivo>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoItemArquivo> builder)
        {
            // P.K
            builder.HasKey(e => e.IDSolicitacaoItemArquivo);

            // Propriedades
            builder.Property(p => p.Url).HasMaxLength(150).IsRequired();

            // Datas
            builder.Property(p => p.CreatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();

            // Relacionamentos
            builder.HasOne(i => i.Item)
                .WithOne(i => i.Arquivo)
                .HasForeignKey<SolicitacaoItemArquivo>(i => i.IDSolicitacaoItem);
        }
    }
}
