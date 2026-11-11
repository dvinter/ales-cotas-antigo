using AlesCotas.Domain.Entities.Base;

namespace AlesCotas.Domain.Entities
{
    public class SolicitacaoItemArquivo : Entity
    {
        public int IDSolicitacaoItemArquivo { get; set; }
        public string Url { get; set; }
        public int IDSolicitacaoItem { get; set; }
        public SolicitacaoItem Item { get; set; }

        public SolicitacaoItemArquivo()
        {
        }
    }
}
