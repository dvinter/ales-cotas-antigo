using AlesCotas.Application.Classes;
using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Filtros;

namespace AlesCotas.MVC.Models.Solicitacao
{
    public class SolicitacaoListagem
    {
        public ListaPaginada<SolicitacaoDTO> Lista { get; set; }
        public SolicitacaoFiltroDTO Filtro { get; set; }
    }
}
