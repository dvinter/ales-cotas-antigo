using AlesCotas.Domain.Entities.Base;

namespace AlesCotas.Domain.Entities
{
    public class GrampeamentoTipo : Entity
    {
        public int IDGrampeamentoTipo { get; set; }
        public string Nome { get; set; }
        public ICollection<SolicitacaoItemCR>? SolicitacaoItemCRs { get; set; }

        public GrampeamentoTipo()
        {
        }

        public GrampeamentoTipo(string nome)
        {
            Nome = nome;
        }
    }
}
