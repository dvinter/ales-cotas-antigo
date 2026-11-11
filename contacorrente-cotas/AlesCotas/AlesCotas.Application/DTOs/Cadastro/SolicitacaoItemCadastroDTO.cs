using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlesCotas.Application.DTOs.Cadastro
{
    public class SolicitacaoItemCadastroDTO
    {

        [Range(0, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        [JsonPropertyName("QuantidadeSolicitada")]
        public int QuantidadeSolicitada { get; set; }

        [Required(ErrorMessage = "Valor Unitário é obrigatório!")]
        [Range(0, 999999.99, ErrorMessage = "Insira um valor válido!")]
        [JsonPropertyName("ValorUnitario")]
        public decimal ValorUnitario { get; set; }

        [Required(ErrorMessage = "IDProduto é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        [JsonPropertyName("IDProduto")]
        public int IDProduto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        [JsonPropertyName("IDGrampeamentoTipo")]
        public int? IDGrampeamentoTipo { get; set; }

    }
}
