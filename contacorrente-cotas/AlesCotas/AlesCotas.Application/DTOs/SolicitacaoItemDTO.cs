using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlesCotas.Application.DTOs
{
    public sealed class SolicitacaoItemDTO
    {
        [JsonPropertyName("IDSolicitacaoItem")]
        public int IDSolicitacaoItem { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        [JsonPropertyName("QuantidadeSolicitada")]
        public int QuantidadeSolicitada { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        [JsonPropertyName("QuantidadeAutorizada")]
        public int QuantidadeAutorizada { get; set; }

        [JsonPropertyName("Status")]
        public string? Status { get; set; }

        [Range(1, (double)decimal.MaxValue, ErrorMessage = "Insira um numero válido!")]
        [JsonPropertyName("ValorUnitario")]
        public decimal? ValorUnitario { get; set; }

        [Required(ErrorMessage = "Produto é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        [JsonPropertyName("IDProduto")]
        public int IDProduto { get; set; }

        [JsonPropertyName("Produto")]
        public ProdutoDTO Produto { get; set; }

        public int? IDSolicitacaoItemArquivo { get; set; }
    }
}
