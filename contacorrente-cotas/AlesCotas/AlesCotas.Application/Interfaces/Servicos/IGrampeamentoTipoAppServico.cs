using AlesCotas.Application.DTOs;
using AlesCotas.Application.Interfaces.Servicos.Base;

namespace AlesCotas.Application.Interfaces.Servicos
{
    public interface IGrampeamentoTipoAppServico : IAppServico
    {
        public List<GrampeamentoTipoDTO> Listar();
        public GrampeamentoTipoDTO? Recuperar(int id);
    }
}
