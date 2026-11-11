using AlesCotas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlesCotas.Infra.Data.EntitiesConfiguration
{
    public class GrampeamentoTipoConfiguration : IEntityTypeConfiguration<GrampeamentoTipo>
    {
        public void Configure(EntityTypeBuilder<GrampeamentoTipo> builder)
        {

            // P.K
            builder.HasKey(e => e.IDGrampeamentoTipo);

            // Propriedades
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired().UseCollation("SQL_LATIN1_GENERAL_CP1_CI_AI");

            // Datas
            builder.Property(p => p.CreatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime2").HasPrecision(0).IsRequired();
        }
    }
}
