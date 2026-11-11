using AlesCotas.Application.Classes;
using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.Interfaces.Servicos.Base;

namespace AlesCotas.Application.Interfaces.Servicos
{
    public interface ISolicitacaoAppServico : IAppServico
    {
        public ListaPaginada<SolicitacaoDTO> Listar(SolicitacaoFiltroDTO filtro);
        public SolicitacaoDTO Cadastrar(SolicitacaoCadastroDTO solicitacao);
        public SolicitacaoDTO Atualizar(SolicitacaoDTO solicitacao);
        public SolicitacaoDTO? Recuperar(int id);
        public bool Aprovar(int id);
        public void Aprovar(SolicitacaoDTO solicitacao);
        public bool Negar(int id);
        public void Negar(SolicitacaoDTO solicitacao);
    }
}
