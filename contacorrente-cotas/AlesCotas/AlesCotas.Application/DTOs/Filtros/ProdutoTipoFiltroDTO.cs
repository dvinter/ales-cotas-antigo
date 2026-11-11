using AlesCotas.Application.DTOs.Filtros.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlesCotas.Application.DTOs.Filtros
{
    public class ProdutoTipoFiltroDTO : FiltroDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "ID Inválido!")]
        [JsonPropertyName("IDProdutoTipo")]
        public int IDProdutoTipo { get; set; }

        [StringLength(100, ErrorMessage = "O nome deve ser menor que 100 caracteres")]
        [JsonPropertyName("Nome")]
        public string? Nome { get; set; }
    }
}
