using System.ComponentModel.DataAnnotations;

namespace AlesCotas.Application.DTOs.Filtros.Base
{
    public class FiltroDTO
    {
        [Required(ErrorMessage = "Numero da pagina é obrigatório!")]
        [Range(0, int.MaxValue, ErrorMessage = "Digite um numero válido!")]
        public int NumeroPagina { get; set; } = 1;

        [Required(ErrorMessage = "Tamanho da pagina é obrigatório!")]
        [Range(0, int.MaxValue, ErrorMessage = "Digite um numero válido!")]
        public int TamanhoPagina { get; set; } = 50;
    }
}
