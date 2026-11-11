using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace AlesCotas.Application.Classes
{
    public class ListaPaginada<T> : List<T> where T : class
    {
        [JsonPropertyName("PaginaAtual")]
        public int PaginaAtual { get; set; }

        [JsonPropertyName("TotalPaginas")]
        public int TotalPaginas { get; set; }

        [JsonPropertyName("TamanhoPagina")]
        public int TamanhoPagina { get; set; }

        [JsonPropertyName("TotalRegistros")]
        public int TotalRegistros { get; set; }

        [JsonPropertyName("TemAnterior")]
        public bool TemAnterior => PaginaAtual > 1;

        [JsonPropertyName("TemProxima")]
        public bool TemProxima => PaginaAtual < TotalPaginas;

        public ListaPaginada()
        {
        }
        public ListaPaginada(List<T> items, int totalRegistros, int paginaAtual, int tamanhoPagina)
        {
            TotalRegistros = totalRegistros;
            TamanhoPagina = tamanhoPagina;
            PaginaAtual = paginaAtual;
            TotalPaginas = (int)Math.Ceiling(totalRegistros / (double)tamanhoPagina);
            AddRange(items);
        }
        public static ListaPaginada<T> ToListaPaginada(IQueryable<T> source, int paginaAtual, int tamanhoPagina)
        {

            var totalRegistros = source.Count();
            var items = source.Skip((paginaAtual - 1) * tamanhoPagina).Take(tamanhoPagina).ToList();

            return new ListaPaginada<T>(items, totalRegistros, paginaAtual, tamanhoPagina);

        }
        public static async Task<ListaPaginada<T>> ToListaPaginadaAsync(IQueryable<T> source, int paginaAtual, int tamanhoPagina)
        {

            var totalRegistros = source.Count();
            var items = await source.Skip((paginaAtual - 1) * tamanhoPagina).Take(tamanhoPagina).ToListAsync();

            return new ListaPaginada<T>(items, totalRegistros, paginaAtual, tamanhoPagina);

        }
    }

}
