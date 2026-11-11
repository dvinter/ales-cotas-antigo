using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros;
using AlesCotas.Domain.Interfaces.Repositories.Base;

namespace AlesCotas.Domain.Interfaces.Repositories
{
    public interface ISolicitacaoRepository : IRepository<Solicitacao>
    {
        IQueryable<Solicitacao> Listar(SolicitacaoFiltro filtro);
        Solicitacao? Recuperar(int id);
        void Cadastrar(Solicitacao entity);
        void Atualizar(Solicitacao entity);
        void Deletar(Solicitacao entity);
    }
}
