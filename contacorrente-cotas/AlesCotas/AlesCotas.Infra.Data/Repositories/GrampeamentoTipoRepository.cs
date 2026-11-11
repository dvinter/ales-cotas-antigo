using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Repositories;
using AlesCotas.Infra.Data.Context;
using AlesCotas.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AlesCotas.Infra.Data.Repositories
{
    public class GrampeamentoTipoRepository : Repository<GrampeamentoTipo>, IGrampeamentoTipoRepository
    {
        public GrampeamentoTipoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<GrampeamentoTipo> Listar()
        {
            return _entityContext;
        }

        public GrampeamentoTipo? Recuperar(int id)
        {
            return _entityContext.Where(e => e.IDGrampeamentoTipo == id).AsNoTracking().FirstOrDefault();
        }

        public void Cadastrar(GrampeamentoTipo entity)
        {
            _entityContext.Add(entity);
        }

        public void Atualizar(GrampeamentoTipo entity)
        {
            _entityContext.Update(entity);
        }

        public void Deletar(GrampeamentoTipo entity)
        {
            _entityContext.Remove(entity);
        }
    }
}
