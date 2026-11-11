using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlesCotas.Application.DTOs
{
    public sealed class SolicitacaoDTO
    {
        [JsonPropertyName("IDSolicitacao")]
        public int IDSolicitacao { get; set; }

        [Required(ErrorMessage = "Tipo é obrigatório")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "O Tipo deve estar entre 3 e 25 caracteres")]
        [JsonPropertyName("Tipo")]
        public string? Tipo { get; set; }

        [JsonPropertyName("Status")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "Precisa de pelo menos 1 item")]
        [JsonPropertyName("Items")]
        public List<SolicitacaoItemDTO>? Items { get; set; }

        [JsonPropertyName("ValorSolicitado")]
        public decimal ValorSolicitado { get; set; }

        [JsonPropertyName("ValorAprovado")]
        public decimal ValorAprovado { get; set; }

        [StringLength(255, ErrorMessage = "O campo não pode ter mais que 255 caractéres!")]
        [JsonPropertyName("Justificativa")]
        public string? Justificativa { get; set; }

        [JsonPropertyName("CreatedAt")]
        public DateTime? CreatedAt { get; set; }
    }
}
