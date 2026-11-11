using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros;
using AlesCotas.Domain.Interfaces.Repositories;
using AlesCotas.Infra.Data.Context;
using AlesCotas.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AlesCotas.Infra.Data.Repositories
{
    internal class SolicitacaoRepository : Repository<Solicitacao>, ISolicitacaoRepository
    {
        public SolicitacaoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<Solicitacao> Listar(SolicitacaoFiltro filtro)
        {
            var query = _entityContext.Include(p => p.Items).ThenInclude(i => i.Produto).AsQueryable();

            if (filtro.IDSolicitacao.HasValue)
            {
                query = query.Where(e => e.IDSolicitacao == filtro.IDSolicitacao);
            }

            if (!string.IsNullOrEmpty(filtro.Tipo))
            {
                query = query.Where(e => e.Tipo.Contains(filtro.Tipo));
            }

            if (!string.IsNullOrEmpty(filtro.Status))
            {
                query = query.Where(e => e.Status.Contains(filtro.Status));
            }

            return query.OrderByDescending(e => e.CreatedAt);
        }

        public Solicitacao? Recuperar(int id)
        {
            return _entityContext.AsNoTracking().Where(e => e.IDSolicitacao == id)
                .Include(s => s.Items)
                .ThenInclude(i => i.Produto)
                .ThenInclude(p => p.Tipo).FirstOrDefault();
        }
        public void Cadastrar(Solicitacao entity)
        {
            _entityContext.Add(entity);
        }
        public void Atualizar(Solicitacao entity)
        {
            _entityContext.Update(entity);
        }

        public void Deletar(Solicitacao entity)
        {
            _entityContext.Remove(entity);
        }
    }
}
