using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Servicos.Base;

namespace AlesCotas.Domain.Interfaces.Servicos
{
    public interface ISolicitacaoItemCRServico : IServico
    {
        public void Cadastrar(SolicitacaoItemCR entity);
        public void Atualizar(SolicitacaoItemCR entity);
        public SolicitacaoItemCR? Recuperar(int id);
        public List<SolicitacaoItemCR> Listar();
        public List<SolicitacaoItemCR> Listar(List<int> ids);
    }
}
