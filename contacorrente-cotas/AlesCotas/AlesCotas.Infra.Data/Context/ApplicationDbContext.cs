using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Entities.Base;
using AlesCotas.Infra.Data.Identity;
using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlesCotas.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Mapeamento ORM
        public DbSet<ProdutoTipo> ProdutoTipo { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Solicitacao> Solicitacao { get; set; }
        public DbSet<SolicitacaoItem> SolicitacaoItem { get; set; }
        public DbSet<SolicitacaoItemArquivo> SolicitacaoItemArquivos { get; set; }
        public DbSet<Gabinete> Gabinetes { get; set; }
        public DbSet<Domain.Entities.Usuario> Usuarios { get; set; }
        public DbSet<GrampeamentoTipo> GrampeamentoTipos { get; set; }
        public DbSet<SolicitacaoItemCR> SolicitacaoItemCR { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                //entity.HasOne(x => x.Usuario).WithOne().HasForeignKey<ApplicationUser>(x => x.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            });
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
        .Where(e => e.Entity is Entity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((Entity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((Entity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property("CreatedAt").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

    }
}
