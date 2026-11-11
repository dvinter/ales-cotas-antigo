using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Repositories;
using AlesCotas.Infra.Data.Context;
using AlesCotas.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AlesCotas.Infra.Data.Repositories
{
    public class SolicitacaoItemCRRepository : Repository<SolicitacaoItemCR>, ISolicitacaoItemCRRepository
    {
        public SolicitacaoItemCRRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Cadastrar(SolicitacaoItemCR entity)
        {
            _entityContext.Add(entity);
        }

        public void Atualizar(SolicitacaoItemCR entity)
        {
            _entityContext.Update(entity);
        }

        public SolicitacaoItemCR? Recuperar(int id)
        {
            return _entityContext.Where(e => e.IDSolicitacaoItemCR == id).AsNoTracking().FirstOrDefault();
        }

        public IQueryable<SolicitacaoItemCR> Listar()
        {
            return _entityContext;
        }

        public IQueryable<SolicitacaoItemCR> Listar(List<int> ids)
        {
            return _entityContext.Where(e => ids.Contains(e.IDSolicitacaoItem)).AsNoTracking();
        }
    }
}
