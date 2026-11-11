using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlesCotas.Application.DTOs
{
    public class ProdutoDTO
    {
        [Required(ErrorMessage = "ID é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        [JsonPropertyName("IDProduto")]
        public int? IDProduto { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve possuir entre 3 e 100 caracteres")]
        [JsonPropertyName("Nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Valor Unitário é obrigatório!")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Insira um decimal válido!")]
        [JsonPropertyName("ValorUnitario")]
        public decimal ValorUnitario { get; set; }

        [JsonPropertyName("Ativo")]
        public bool? Ativo { get; set; }

        //[Required(ErrorMessage = "Tipo é obrigatorio!")]
        [Range(0, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        [JsonPropertyName("IDTipoProduto")]
        public int? IDProdutoTipo { get; set; }

        [JsonPropertyName("Tipo")]
        public ProdutoTipoDTO? Tipo { get; set; }

        [StringLength(250, ErrorMessage = "O campo deve ter entre 3 e 250 caracteres")]
        [JsonPropertyName("Descricao")]
        public string? Descricao { get; set; }
    }
}
