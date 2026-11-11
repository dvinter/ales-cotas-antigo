using AlesCotas.Application.DTOs.Filtros.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlesCotas.Application.DTOs.Filtros
{
    public class ProdutoFiltroDTO : FiltroDTO
    {

        [Range(0, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        [JsonPropertyName("IDProduto")]
        public int IDProduto { get; set; }

        [StringLength(100, ErrorMessage = "Nome nao pode ser maior que 100 caracteres")]
        [JsonPropertyName("Nome")]
        public string? Nome { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Insira um valor válido!")]
        [JsonPropertyName("ValorUnitario")]
        public decimal? ValorUnitario { get; set; }

        [StringLength(100, ErrorMessage = "Tipo nao pode ser maior que 100 caracteres")]
        [JsonPropertyName("Tipo")]
        public string? Tipo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        [JsonPropertyName("IDProdutoTipo")]
        public int? IDProdutoTipo { get; set; }
    }
}
