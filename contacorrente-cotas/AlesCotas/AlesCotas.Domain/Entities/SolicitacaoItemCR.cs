using AlesCotas.Domain.Entities.Base;

namespace AlesCotas.Domain.Entities
{
    public class SolicitacaoItemCR : Entity
    {
        public int IDSolicitacaoItemCR { get; set; }
        public int IDSolicitacaoItem { get; set; }
        public SolicitacaoItem Item { get; set; }
        public int IDGrampeamentoTipo { get; set; }
        public GrampeamentoTipo GrampeamentoTipo { get; set; }

        public SolicitacaoItemCR()
        {
        }

        public SolicitacaoItemCR(int iDSolicitacaoItemCR, int iDSolicitacaoItem,
            int iDGrampeamentoTipo)
        {
            IDSolicitacaoItemCR = iDSolicitacaoItemCR;
            IDSolicitacaoItem = iDSolicitacaoItem;
            IDGrampeamentoTipo = iDGrampeamentoTipo;
        }
    }
}
