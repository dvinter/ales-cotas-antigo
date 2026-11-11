using AlesCotas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlesCotas.Infra.Data.EntitiesConfiguration
{
    sealed internal class SolicitacaoConfiguration : IEntityTypeConfiguration<Solicitacao>
    {
        public void Configure(EntityTypeBuilder<Solicitacao> builder)
        {

            // P.K
            builder.HasKey(p => p.IDSolicitacao);

            // Propriedades
            builder.Property(p => p.Status).HasMaxLength(25).IsRequired();
            builder.Property(p => p.Tipo).HasMaxLength(50).IsRequired();
            builder.Property(p => p.ValorSolicitado).HasPrecision(8, 2).IsRequired();
            builder.Property(p => p.ValorAprovado).HasPrecision(8, 2).IsRequired();
            builder.Property(p => p.Justificativa).HasMaxLength(255);

            // Datas
            builder.Property(p => p.CreatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();
            builder.Property(p => p.DataValidacao).HasColumnType("datetime2").HasPrecision(0);
        }
    }
}
