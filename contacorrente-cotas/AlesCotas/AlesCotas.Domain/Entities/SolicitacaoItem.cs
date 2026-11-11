using AlesCotas.Domain.Entities.Base;

namespace AlesCotas.Domain.Entities
{
    public sealed class SolicitacaoItem : Entity
    {
        public int IDSolicitacaoItem { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public int QuantidadeAutorizada { get; set; }
        public decimal ValorUnitario { get; set; }
        public int IDSolicitacao { get; set; }
        public Solicitacao Solicitacao { get; set; }
        public int IDProduto { get; set; }
        public Produto Produto { get; set; }
        public SolicitacaoItemArquivo? Arquivo { get; set; }
        public SolicitacaoItemCR? ItemCR { get; set; }

        public SolicitacaoItem()
        {
        }
    }
}
