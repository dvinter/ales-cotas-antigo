using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Repositories.Base;

namespace AlesCotas.Domain.Interfaces.Repositories
{
    public interface ISolicitacaoItemCRRepository : IRepository<SolicitacaoItemCR>
    {
        public void Cadastrar(SolicitacaoItemCR entity);
        public void Atualizar(SolicitacaoItemCR entity);
        public SolicitacaoItemCR? Recuperar(int id);
        IQueryable<SolicitacaoItemCR> Listar();
        IQueryable<SolicitacaoItemCR> Listar(List<int> ids);
    }
}
