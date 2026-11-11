using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros;
using AlesCotas.Domain.Interfaces.Repositories;
using AlesCotas.Infra.Data.Context;
using AlesCotas.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AlesCotas.Infra.Data.Repositories
{
    internal class ProdutoTipoRepository : Repository<ProdutoTipo>, IProdutoTipoRepository
    {
        public ProdutoTipoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<ProdutoTipo> Listar(ProdutoTipoFiltro filtro)
        {
            IQueryable<ProdutoTipo> query = _entityContext.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                query = query.Where(e => e.Nome.Contains(filtro.Nome));
            }

            if (!string.IsNullOrEmpty(filtro.Unidade))
            {
                query = query.Where(e => e.Unidade.Contains(filtro.Unidade));
            }

            return query;
        }

        public ProdutoTipo? Recuperar(int id)
        {
            return _entityContext.Where(e => e.IDProdutoTipo == id).AsNoTracking().FirstOrDefault();
        }

        public void Cadastrar(ProdutoTipo entity)
        {
            _entityContext.Add(entity);
        }

        public void Atualizar(ProdutoTipo entity)
        {
            _entityContext.Update(entity);
        }

        public void Deletar(ProdutoTipo entity)
        {
            _entityContext.Remove(entity);
        }
    }
}
