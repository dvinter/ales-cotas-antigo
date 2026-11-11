using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Repositories.Base;

namespace AlesCotas.Domain.Interfaces.Repositories
{
    public interface ISolicitacaoItemRepository : IRepository<SolicitacaoItem>
    {
        public IQueryable<SolicitacaoItem> Listar();
        public SolicitacaoItem? Recuperar(int id);
        public void Cadastrar(SolicitacaoItem entity);
        public void CadastrarBatch(List<SolicitacaoItem> items);
        public void Atualizar(SolicitacaoItem entity);
        public void Deletar(SolicitacaoItem entity);
    }
}
