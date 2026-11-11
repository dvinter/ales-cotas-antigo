using AlesCotas.Domain.Filtros.Base;

namespace AlesCotas.Domain.Filtros
{
    public class ProdutoTipoFiltro : Filtro
    {
        public string? Nome { get; set; }
        public string? Unidade { get; set; }
    }
}
