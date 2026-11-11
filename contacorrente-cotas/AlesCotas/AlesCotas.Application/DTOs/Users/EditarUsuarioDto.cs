using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlesCotas.Application.DTOs.Users
{
    public class EditarUsuarioDto
    {
        [Display(Name ="Id")]
        public string Id { get; set; }
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [Display(Name = "Usuário / Matrícula")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        ///// <summary>
        /////     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        /////     directly from your code. This API may change or be removed in future releases.
        ///// </summary>
        //[Required]
        //[StringLength(100, ErrorMessage = "A {0} precisa ter pelo menos {2} caracteres, e no máximo {1} caracteres.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Senha")]
        //public string Password { get; set; }

        ///// <summary>
        /////     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        /////     directly from your code. This API may change or be removed in future releases.
        ///// </summary>
        //[DataType(DataType.Password)]
        //[Display(Name = "Confirme a Senha")]
        //[Compare("Confirmação da Senha", ErrorMessage = "Confirmação da senha está diferente.")]
        //public string ConfirmPassword { get; set; }


        public int? IDGabiente { get; set; }

        [Display(Name ="Perfil do Usuário")]
        public string Role { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo {get; set; }  

        public string Setor { get; set; }
    }
}
