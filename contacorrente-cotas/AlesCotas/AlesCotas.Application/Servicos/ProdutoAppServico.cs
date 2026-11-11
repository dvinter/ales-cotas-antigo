using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.Interfaces.Servicos;
using AlesCotas.Application.Servicos.Base;
using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Exceptions;
using AlesCotas.Domain.Filtros;
using AlesCotas.Domain.Interfaces.Servicos;
using AlesCotas.Domain.Interfaces.UnitOfWork;
using AutoMapper;

namespace AlesCotas.Application.Servicos
{
    public class ProdutoAppServico : AppServico, IProdutoAppServico
    {
        protected IProdutoServico _servico;

        public ProdutoAppServico(IMapper mapper, IUnitOfWork uow, IProdutoServico servico) : base(mapper, uow)
        {
            _servico = servico;
        }

        public List<ProdutoDTO> Listar(string tipo)
        {

            try
            {
                ProdutoFiltroDTO filtroDTO = new()
                {
                    NumeroPagina = 1,
                    TamanhoPagina = 300,
                    Tipo = tipo
                };
                return _mapper.Map<List<ProdutoDTO>>(_servico.Listar(
                    _mapper.Map<ProdutoFiltro>(filtroDTO)
                    ));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ProdutoDTO> Listar(ProdutoFiltroDTO parametros)
        {
            var filtro = _mapper.Map<ProdutoFiltro>(parametros);
            try
            {
                return _mapper.Map<List<ProdutoDTO>>(_servico.Listar(filtro));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProdutoDTO? Recuperar(int id)
        {

            try
            {
                var entity = _servico.Recuperar(id);

                if (entity == null)
                {
                    return null;
                }

                return _mapper.Map<ProdutoDTO>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProdutoDTO Cadastrar(ProdutoCadastroDTO produto)
        {
            var entity = _mapper.Map<Produto>(produto);
            try
            {
                _servico.Cadastrar(entity);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<ProdutoDTO>(entity);
        }

        public ProdutoDTO Atualizar(ProdutoDTO produto)
        {
            produto.Ativo ??= true;

            var entity = _mapper.Map<Produto>(produto);

            try
            {
                _servico.Atualizar(entity);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<ProdutoDTO>(entity);
        }

        public bool Deletar(int? id)
        {
            if (id == null || id <= 0 || id > int.MaxValue)
            {
                throw new Exception("Digite um Id Válido");
            }

            try
            {
                _servico.Deletar((int)id);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw new RegraNegocioException();
            }

            return true;
        }
    }
}
