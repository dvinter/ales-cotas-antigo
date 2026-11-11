using AlesCotas.Domain.Filtros.Base;

namespace AlesCotas.Domain.Filtros
{
    public class ProdutoFiltro : Filtro
    {
        public string? Nome { get; set; }
        public decimal? ValorUnitario { get; set; }
        public int? IDProdutoTipo { get; set; }
        public string? Tipo { get; set; }
    }
}
