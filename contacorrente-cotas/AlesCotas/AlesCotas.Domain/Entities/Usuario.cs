using AlesCotas.Domain.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace AlesCotas.Domain.Entities
{
    public class Usuario : IdentityUser
    {
        public string Matricula { get => this.UserName; set => this.UserName = value; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Nome { get; set; }
        public bool IsAtivo { get; set; }
        public int? IDGabinete { get; set; }
        public Gabinete? Gabinete { get; set; }
        public string? Setor { get; set; }
    }

    public class UsuarioRoles
    {
        public string UsuarioId { get; set; }
        public string RoleId { get; set; }
        public string Role { get; set; }
    }
}
