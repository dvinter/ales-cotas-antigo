using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlesCotas.Application.DTOs.Users
{
    public class UsuarioDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Email { get; set; }
        public bool IsAtivo { get; set; }
        public string GabineteName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? IDGabinete { get; set; }
        public string Setor { get; set; }
        public string Role { get; set; }
    }
}
