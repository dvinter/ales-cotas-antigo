using AlesCotas.Application.Classes;
using AlesCotas.Application.DTOs;
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
    public class ProdutoTipoAppServico : AppServico, IProdutoTipoAppServico
    {
        protected IProdutoTipoServico _servico;

        public ProdutoTipoAppServico(IMapper mapper, IUnitOfWork uow, IProdutoTipoServico servico) : base(mapper, uow)
        {
            _servico = servico;
        }

        public ListaPaginada<ProdutoTipoDTO> Listar(ProdutoTipoFiltroDTO parametros)
        {
            var filtro = _mapper.Map<ProdutoTipoFiltro>(parametros);
            try
            {
                var lista = _servico.Listar(filtro);

                return new ListaPaginada<ProdutoTipoDTO>(
                    _mapper.Map<List<ProdutoTipoDTO>>(
                        lista
                        .Skip((parametros.NumeroPagina - 1) * parametros.TamanhoPagina)
                        .Take(parametros.TamanhoPagina).ToList()),
                    lista.Count(),
                    parametros.NumeroPagina,
                    parametros.TamanhoPagina);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProdutoTipoDTO? Recuperar(int id)
        {
            if (id <= 0 || id > int.MaxValue)
            {
                throw new Exception("Digite um ID Válido");
            }

            try
            {
                var entity = _servico.Recuperar(id);

                if (entity == null)
                {
                    return null;
                }

                return _mapper.Map<ProdutoTipoDTO>(entity);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao recuperar os dados");
            }
        }

        public int? Recuperar(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("Nome nao pode ser vazio!");
            }

            try
            {

                ProdutoTipoFiltro filtro = new()
                {
                    Nome = nome,
                    NumeroPagina = 1,
                    TamanhoPagina = 10
                };

                var entity = _servico.Listar(filtro).FirstOrDefault();

                if (entity == null)
                {
                    return null;
                }

                return entity.IDProdutoTipo;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao recuperar os dados");
            }
        }

        public ProdutoTipoDTO Cadastrar(ProdutoTipoDTO tipo)
        {
            var entity = _mapper.Map<ProdutoTipo>(tipo);
            try
            {
                _servico.Cadastrar(entity);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<ProdutoTipoDTO>(entity);
        }

        public ProdutoTipoDTO Atualizar(ProdutoTipoDTO tipo)
        {
            var entity = _mapper.Map<ProdutoTipo>(tipo);

            try
            {
                _servico.Atualizar(entity);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<ProdutoTipoDTO>(entity);
        }

        public bool Remover(int? id)
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
