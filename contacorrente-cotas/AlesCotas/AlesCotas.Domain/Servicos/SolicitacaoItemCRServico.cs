using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Servicos;
using AlesCotas.Domain.Interfaces.UnitOfWork;
using AlesCotas.Domain.Servicos.Base;

namespace AlesCotas.Domain.Servicos
{
    public class SolicitacaoItemCRServico : Servico, ISolicitacaoItemCRServico
    {
        public SolicitacaoItemCRServico(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Cadastrar(SolicitacaoItemCR entity)
        {
            _unitOfWork.SolicitacaoItemCRRepository.Cadastrar(entity);
        }

        public void Atualizar(SolicitacaoItemCR entity)
        {
            _unitOfWork.SolicitacaoItemCRRepository.Atualizar(entity);
        }

        public SolicitacaoItemCR? Recuperar(int id)
        {
            if (id <= 0 || id > int.MaxValue)
            {
                throw new Exception("Digite um Id Válido");
            }

            return _unitOfWork.SolicitacaoItemCRRepository.Recuperar(id);
        }

        public List<SolicitacaoItemCR> Listar()
        {
            return _unitOfWork.SolicitacaoItemCRRepository.Listar().ToList();
        }

        public List<SolicitacaoItemCR> Listar(List<int> ids)
        {
            return _unitOfWork.SolicitacaoItemCRRepository.Listar(ids).ToList();
        }
    }
}
