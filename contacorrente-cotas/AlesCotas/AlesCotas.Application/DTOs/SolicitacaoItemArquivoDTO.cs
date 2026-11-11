using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlesCotas.Application.DTOs
{
    public class SolicitacaoItemArquivoDTO
    {

        [JsonPropertyName("IDSolicitacaoItemArquivo")]
        public int IDSolicitacaoItemArquivo { get; set; }

        [StringLength(150, ErrorMessage = "Url não pode ser maior que 150 caractéres!")]
        [JsonPropertyName("Url")]
        public string Url { get; set; }

        [Required(ErrorMessage = "IDSolicitacaoItem é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        public int IDSolicitacaoItem { get; set; }
    }
}
