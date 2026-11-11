using AlesCotas.Application.DTOs;
using AlesCotas.Application.Interfaces.Servicos;
using AlesCotas.Application.Servicos.Base;
using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Servicos;
using AlesCotas.Domain.Interfaces.UnitOfWork;
using AutoMapper;

namespace AlesCotas.Application.Servicos
{
    public class SolicitacaoItemCRAppServico : AppServico, ISolicitacaoItemCRAppServico
    {
        private readonly ISolicitacaoItemCRServico _servico;
        public SolicitacaoItemCRAppServico(IMapper mapper, IUnitOfWork uow, ISolicitacaoItemCRServico servico) : base(mapper, uow)
        {
            _servico = servico;
        }

        public SolicitacaoItemCRDTO Cadastrar(SolicitacaoItemCRDTO item)
        {
            try
            {
                var entity = _mapper.Map<SolicitacaoItemCR>(item);
                _servico.Cadastrar(entity);
                _unitOfWork.Commit();
                return _mapper.Map<SolicitacaoItemCRDTO>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SolicitacaoItemCRDTO> Listar(List<int> ids)
        {
            if (ids.Count == 0)
            {
                throw new Exception("Lista está vazia!");
            }

            try
            {
                var list = _servico.Listar(ids);
                return _mapper.Map<List<SolicitacaoItemCRDTO>>(list);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
