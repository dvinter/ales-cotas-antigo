using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Servicos.Base;

namespace AlesCotas.Domain.Interfaces.Servicos
{
    public interface ISolicitacaoItemArquivoServico : IServico
    {
        public void Cadastrar(SolicitacaoItemArquivo entity);
        public void Atualizar(SolicitacaoItemArquivo entity);
        public SolicitacaoItemArquivo? Recuperar(int id);
        public List<SolicitacaoItemArquivo> Listar();
        public List<SolicitacaoItemArquivo> Listar(List<int> ids);
    }
}
