using AlesCotas.Domain.Interfaces.Repositories;

namespace AlesCotas.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProdutoTipoRepository ProdutoTipoRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        ISolicitacaoRepository SolicitacaoRepository { get; }
        ISolicitacaoItemRepository SolicitacaoItemRepository { get; }
        ISolicitacaoItemArquivoRepository SolicitacaoItemArquivoRepository { get; }
        IGabineteRepository GabineteRepository { get; }

        IUsuarioRepository UsuarioRepository { get; }

        IGrampeamentoTipoRepository GrampeamentoTipoRepository { get; }
        ISolicitacaoItemCRRepository SolicitacaoItemCRRepository { get; }
        void Commit();
        void Dispose();
        void IniciarTransacao();
        void CommitTransacao();
        void RollbackTransacao();
    }
}
