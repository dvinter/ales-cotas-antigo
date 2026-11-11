using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Repositories.Base;

namespace AlesCotas.Domain.Interfaces.Repositories
{
    public interface ISolicitacaoItemArquivoRepository : IRepository<SolicitacaoItemArquivo>
    {
        IQueryable<SolicitacaoItemArquivo> Listar();
        IQueryable<SolicitacaoItemArquivo> Listar(List<int> ids);
        SolicitacaoItemArquivo? Recuperar(int id);
        void Cadastrar(SolicitacaoItemArquivo entity);
        void Atualizar(SolicitacaoItemArquivo entity);
        void Deletar(SolicitacaoItemArquivo entity);
    }
}
