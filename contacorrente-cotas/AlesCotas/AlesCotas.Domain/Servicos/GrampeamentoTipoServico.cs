using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Servicos;
using AlesCotas.Domain.Interfaces.UnitOfWork;
using AlesCotas.Domain.Servicos.Base;

namespace AlesCotas.Domain.Servicos
{
    public class GrampeamentoTipoServico : Servico, IGrampeamentoTipoServico
    {
        public GrampeamentoTipoServico(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<GrampeamentoTipo> Listar()
        {
            return _unitOfWork.GrampeamentoTipoRepository.Listar().ToList();
        }

        public GrampeamentoTipo? Recuperar(int id)
        {
            if (id <= 0 || id > int.MaxValue)
            {
                throw new Exception("Digite um Id Válido");
            }

            return _unitOfWork.GrampeamentoTipoRepository.Recuperar(id);
        }

        public void Cadastrar(GrampeamentoTipo entity)
        {
            _unitOfWork.GrampeamentoTipoRepository.Cadastrar(entity);
        }

        public void Atualizar(GrampeamentoTipo entity)
        {
            _unitOfWork.GrampeamentoTipoRepository.Atualizar(entity);
        }

        public bool Deletar(int id)
        {
            var entity = Recuperar(id);

            if (entity == null)
            {
                throw new Exception("Não existe um tipo com esse ID!");
            }

            _unitOfWork.GrampeamentoTipoRepository.Deletar(entity);
            return true;
        }
    }
}
