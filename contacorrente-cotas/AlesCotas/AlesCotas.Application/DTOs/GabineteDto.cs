using AlesCotas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlesCotas.Application.DTOs
{
    public class GabineteDto
    {
        public int IDGabinete { get; set; }
        public string Nome { get; set; }
        public bool IsAtivo { get; set; } = true;
        public int QtdUsuarios { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

    }

    public class EditarGabineteDto
    {
        public int? IDGabinete { get; set; }
        public string Nome { get; set; }
        public bool IsAtivo { get; set; } = true;
    }
}
