using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlesCotas.Application.DTOs
{
    public class ProdutoTipoDTO
    {

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve estar entre 3 e 100 caracteres")]
        [JsonPropertyName("Nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Unidade é obrigatório")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Unidade deve possuir entre 1 e 10 caracteres")]
        [JsonPropertyName("Unidade")]
        public string? Unidade { get; set; }
    }
}
