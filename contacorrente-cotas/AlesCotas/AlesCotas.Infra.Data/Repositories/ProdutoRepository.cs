using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros;
using AlesCotas.Domain.Interfaces.Repositories;
using AlesCotas.Infra.Data.Context;
using AlesCotas.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AlesCotas.Infra.Data.Repositories
{
    internal class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<Produto> Listar()
        {
            return _entityContext;
        }
        public IQueryable<Produto> Listar(ProdutoFiltro filtro)
        {
            var query = _entityContext.Include(p => p.Tipo).Where(p => p.Ativo == true).AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                query = query.Where(e => e.Nome.Contains(filtro.Nome));
            }

            if (filtro.ValorUnitario.HasValue)
            {

                query = query.Where(e => e.ValorUnitario == filtro.ValorUnitario);
            }

            if (!string.IsNullOrEmpty(filtro.Tipo))
            {
                query = query.Where(e => e.Tipo.Nome.Contains(filtro.Tipo)); ;
            }
            return query.OrderBy(e => e.Nome).AsNoTracking();
        }

        public Produto? Recuperar(int id)
        {
            return _entityContext.Where(e => e.IDProduto == id).Include(e => e.Tipo).AsNoTracking().FirstOrDefault();
        }

        public void Cadastrar(Produto entity)
        {
            _entityContext.Add(entity);
        }

        public void Atualizar(Produto entity)
        {
            _entityContext.Update(entity);
        }

        public void Deletar(Produto entity)
        {
            _entityContext.Remove(entity);
        }

        public IQueryable<Produto>? ListarPorIds(int[] ids)
        {
            return _entityContext.Where(p => ids.Contains(p.IDProduto)).Include(p => p.Tipo).AsNoTracking();
        }
    }
}
