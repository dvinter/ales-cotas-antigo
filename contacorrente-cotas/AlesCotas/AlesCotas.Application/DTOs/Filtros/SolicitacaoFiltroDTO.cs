using AlesCotas.Application.DTOs.Filtros.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlesCotas.Application.DTOs.Filtros
{
    public class SolicitacaoFiltroDTO : FiltroDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        [JsonPropertyName("IDProduto")]
        public int? IDSolicitacao { get; set; }

        [StringLength(25, ErrorMessage = "Status deve ter menos que 25 caracteres")]
        [JsonPropertyName("Status")]
        public string? Status { get; set; }

        [StringLength(25, ErrorMessage = "Status deve ter menos que 25 caracteres")]
        [JsonPropertyName("Tipo")]
        public string? Tipo { get; set; }

        [JsonPropertyName("DataValidação")]
        public DateTime? DataValidacao { get; set; }
    }
}
