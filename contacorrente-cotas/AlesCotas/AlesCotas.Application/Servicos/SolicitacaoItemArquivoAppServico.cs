using AlesCotas.Application.DTOs;
using AlesCotas.Application.Interfaces.Servicos;
using AlesCotas.Application.Servicos.Base;
using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Servicos;
using AlesCotas.Domain.Interfaces.UnitOfWork;
using AutoMapper;

namespace AlesCotas.Application.Servicos
{
    public class SolicitacaoItemArquivoAppServico : AppServico, ISolicitacaoItemArquivoAppServico
    {
        private readonly ISolicitacaoItemArquivoServico _servico;
        public SolicitacaoItemArquivoAppServico(IMapper mapper, IUnitOfWork uow, ISolicitacaoItemArquivoServico servico) : base(mapper, uow)
        {
            _servico = servico;
        }

        public SolicitacaoItemArquivoDTO Cadastrar(SolicitacaoItemArquivoDTO solicitacaoItemArquivo)
        {
            var entity = _mapper.Map<SolicitacaoItemArquivo>(solicitacaoItemArquivo);
            try
            {
                _servico.Cadastrar(entity);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<SolicitacaoItemArquivoDTO>(entity);
        }

        public List<SolicitacaoItemArquivoDTO> Listar(List<int> ids)
        {
            if (ids.Count == 0)
            {
                throw new Exception("Lista está vazia!");
            }

            try
            {
                var list = _servico.Listar(ids);
                return _mapper.Map<List<SolicitacaoItemArquivoDTO>>(list);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
