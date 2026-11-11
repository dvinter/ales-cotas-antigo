using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlesCotas.Application.DTOs
{
    public class SolicitacaoItemCRDTO
    {

        [Range(0, int.MaxValue, ErrorMessage = "Digite um numero válido!")]
        [JsonPropertyName("IDSolicitacaoItemCr")]
        public int IDSolicitacaoItemCR { get; set; }

        [Required(ErrorMessage = "IDSolicitacaoItem é obrigatório!")]
        [Range(0, int.MaxValue, ErrorMessage = "Digite um numero válido!")]
        [JsonPropertyName("IDSolicitacaoItem")]
        public int IDSolicitacaoItem { get; set; }

        [Required(ErrorMessage = "IDGrampeamentoTipo é obrigatório!")]
        [Range(0, int.MaxValue, ErrorMessage = "Digite um numero válido!")]
        [JsonPropertyName("IDGrampeamentoTipo")]
        public int IDGrampeamentoTipo { get; set; }
    }
}
