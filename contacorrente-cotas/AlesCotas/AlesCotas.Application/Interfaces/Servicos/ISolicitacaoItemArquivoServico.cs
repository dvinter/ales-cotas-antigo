using AlesCotas.Application.DTOs;
using AlesCotas.Application.Interfaces.Servicos.Base;

namespace AlesCotas.Application.Interfaces.Servicos
{
    public interface ISolicitacaoItemArquivoAppServico : IAppServico
    {
        public SolicitacaoItemArquivoDTO Cadastrar(SolicitacaoItemArquivoDTO solicitacaoItemArquivo);
        public List<SolicitacaoItemArquivoDTO> Listar(List<int> ids);
    }
}
