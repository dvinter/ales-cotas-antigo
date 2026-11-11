using System.ComponentModel.DataAnnotations;

namespace AlesCotas.MVC.Models.Auth
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Email é obrigatória!")]
        [EmailAddress(ErrorMessage = "Email invalido!")]
        public string Email { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Insira um número válido!")]
        public int Matricula { get; set; }

        [Required(ErrorMessage = "Senha é inválida!")]
        [StringLength(20, ErrorMessage = "A {0} deve ter pelo menos {2} e, no máximo, {1} caractéres!", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
