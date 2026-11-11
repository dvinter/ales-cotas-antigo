using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlesCotas.Application.DTOs.Cadastro
{
    public class SolicitacaoCadastroDTO
    {

        [Required(ErrorMessage = "Tipo de solicitação é obrigatório")]
        [StringLength(20, ErrorMessage = "Tipo deve ter, no maximo, 20 caracteres")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Precisa de pelo menos 1 item")]
        [JsonPropertyName("Items")]
        public List<SolicitacaoItemCadastroDTO> Items { get; set; }
    }
}
