using System.ComponentModel.DataAnnotations;

namespace AlesCotas.MVC.Models.Solicitacao
{
    public class CopiaReprograficaValidacao
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Insira um numero válido!")]
        public int IDSolicitacao { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public List<CopiaReprograficaValidacaoItem> Items { get; set; }
        public string Justificativa { get; set; }
    }

    public class CopiaReprograficaValidacaoItem
    {
        public int IDSolicitacaoItem { get; set; }
        public string? Tipo { get; set; }
        public string? Grampeamento { get; set; }
        public string? Anexo { get; set; }
        public decimal ValorMedio { get; set; }
        public int QuantidadeAutorizada { get; set; }
        public int QuantidadeSolicitada { get; set; }
    }
}
