using AlesCotas.Application.DTOs;
using AlesCotas.Application.Interfaces.Servicos.Base;

namespace AlesCotas.Application.Interfaces.Servicos
{
    public interface ISolicitacaoItemCRAppServico : IAppServico
    {
        public SolicitacaoItemCRDTO Cadastrar(SolicitacaoItemCRDTO item);
        public List<SolicitacaoItemCRDTO> Listar(List<int> ids);
    }
}
