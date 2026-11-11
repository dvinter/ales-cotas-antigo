using AlesCotas.Application.DTOs.Filtros.Base;
using AlesCotas.Domain.Filtros.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlesCotas.Application.DTOs.Filtros
{
    public class UsuarioFiltroDto : FiltroDTO
    {
        public EFiltroStatus Status { get; set; }
        
        public string FiltroTexto { get; set; }
    }
}
