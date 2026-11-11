using AlesCotas.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace AlesCotas.MVC.Models.Solicitacao
{
    public class SolicitacaoValidacao
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        public int IDSolicitacao { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Insira um numero válido!")]
        public decimal ValorAtualizado { get; set; }
        public DateTime DataSolicitacao { get; set; }

        [StringLength(255, ErrorMessage = "Justificativa nao pode ter mais que 255 caractéres!")]
        public string? Justificativa { get; set; }
        public List<SolicitacaoItemDTO>? Items { get; set; }
    }
}
