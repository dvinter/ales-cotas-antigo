using AlesCotas.Domain.Filtros.Base;

namespace AlesCotas.Domain.Filtros
{
    public class SolicitacaoFiltro : Filtro
    {
        public int? IDSolicitacao { get; set; }
        public string? Status { get; set; }
        public string? Tipo { get; set; }
        public DateTime? DataValidacao { get; set; }
    }
}
