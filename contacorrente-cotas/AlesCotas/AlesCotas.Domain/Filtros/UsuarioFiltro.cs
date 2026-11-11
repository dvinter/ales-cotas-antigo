using AlesCotas.Domain.Filtros.Base;
using AlesCotas.Domain.Filtros.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlesCotas.Domain.Filtros
{
    public class UsuarioFiltro : Filtro
    {
        public string FiltroTexto { get; set; }
        public EFiltroStatus Status { get; set; }
    }
}
