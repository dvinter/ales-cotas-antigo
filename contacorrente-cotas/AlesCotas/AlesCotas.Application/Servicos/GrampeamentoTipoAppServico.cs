using AlesCotas.Application.DTOs;
using AlesCotas.Application.Interfaces.Servicos;
using AlesCotas.Application.Servicos.Base;
using AlesCotas.Domain.Interfaces.Servicos;
using AlesCotas.Domain.Interfaces.UnitOfWork;
using AutoMapper;

namespace AlesCotas.Application.Servicos
{
    public class GrampeamentoTipoAppServico : AppServico, IGrampeamentoTipoAppServico
    {
        private readonly IGrampeamentoTipoServico _servico;

        public GrampeamentoTipoAppServico(IMapper mapper, IUnitOfWork uow, IGrampeamentoTipoServico servico) : base(mapper, uow)
        {
            _servico = servico;
        }

        public List<GrampeamentoTipoDTO> Listar()
        {
            try
            {
                var entityList = _servico.Listar().ToList();
                return _mapper.Map<List<GrampeamentoTipoDTO>>(entityList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GrampeamentoTipoDTO? Recuperar(int id)
        {
            try
            {
                var entity = _servico.Recuperar(id);

                if (entity == null)
                {
                    return null;
                }

                return _mapper.Map<GrampeamentoTipoDTO>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
