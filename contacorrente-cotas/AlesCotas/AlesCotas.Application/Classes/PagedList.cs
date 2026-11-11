namespace AlesCotas.Application.Classes
{
    public class PagedList<T> : List<T>
    {

        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalRegistros { get; set; }
        public bool TemAnterior => PaginaAtual > 1;
        public bool TemProxima => PaginaAtual < TotalPaginas;

        public PagedList(List<T> items, int totalRegistros, int paginaAtual, int tamanhoPagina)
        {
            TotalRegistros = totalRegistros;
            PaginaAtual = paginaAtual;
            TamanhoPagina = tamanhoPagina;
            TotalPaginas = (int)Math.Ceiling(totalRegistros / (double)tamanhoPagina);
            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IQueryable<T> source, int paginaAtual, int tamanhoPagina)
        {

            var totalRegistros = source.Count();
            var items = source.Skip((paginaAtual - 1) * tamanhoPagina).Take(tamanhoPagina).ToList();

            return new PagedList<T>(items, totalRegistros, paginaAtual, tamanhoPagina);

        }
    }
}
