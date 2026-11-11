using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Repositories;
using AlesCotas.Infra.Data.Context;
using AlesCotas.Infra.Data.Repositories.Base;

namespace AlesCotas.Infra.Data.Repositories
{
    internal class SolicitacaoItemRepository : Repository<SolicitacaoItem>, ISolicitacaoItemRepository
    {
        public SolicitacaoItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Cadastrar(SolicitacaoItem entity)
        {
            _entityContext.Add(entity);
        }

        public void CadastrarBatch(List<SolicitacaoItem> items)
        {
            _entityContext.AddRange(items);
        }
        public void Atualizar(SolicitacaoItem entity)
        {
            _entityContext.Update(entity);
        }

        public void Deletar(SolicitacaoItem entity)
        {
            _entityContext.Remove(entity);
        }

        public IQueryable<SolicitacaoItem> Listar()
        {
            return _entityContext;
        }

        public SolicitacaoItem? Recuperar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
