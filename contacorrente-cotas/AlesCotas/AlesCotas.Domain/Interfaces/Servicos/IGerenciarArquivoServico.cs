using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Servicos.Base;

namespace AlesCotas.Domain.Interfaces.Servicos
{
    public interface IGerenciarArquivoServico : IServico
    {
        public string Upload();
        public string Upload(Solicitacao solicitacao);
        public bool DeletarArquivo();
    }
}
