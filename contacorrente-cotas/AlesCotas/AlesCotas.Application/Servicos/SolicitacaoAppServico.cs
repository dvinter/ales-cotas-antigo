using AlesCotas.Application.Classes;
using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.Interfaces.Servicos;
using AlesCotas.Application.Servicos.Base;
using AlesCotas.Domain.Constantes.Solicitacao;
using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros;
using AlesCotas.Domain.Interfaces.Servicos;
using AlesCotas.Domain.Interfaces.UnitOfWork;
using AutoMapper;
using System.Collections.ObjectModel;

namespace AlesCotas.Application.Servicos
{
    public class SolicitacaoAppServico : AppServico, ISolicitacaoAppServico
    {
        private readonly ISolicitacaoServico _solicitacaoServico;

        public SolicitacaoAppServico(IUnitOfWork uow, IMapper mapper, ISolicitacaoServico solicitacaoServico) : base(mapper, uow)
        {
            _solicitacaoServico = solicitacaoServico;
        }

        public ListaPaginada<SolicitacaoDTO> Listar(SolicitacaoFiltroDTO filtro)
        {

            try
            {
                var entities = _solicitacaoServico.Listar(_mapper.Map<SolicitacaoFiltro>(filtro));
                var dtos = _mapper.Map<List<SolicitacaoDTO>>(entities);
                return ListaPaginada<SolicitacaoDTO>.ToListaPaginada(dtos.AsQueryable(), filtro.NumeroPagina, filtro.TamanhoPagina);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SolicitacaoDTO Cadastrar(SolicitacaoCadastroDTO solicitacao)
        {
            if (solicitacao.Items == null || solicitacao.Items.Count == 0)
            {
                throw new Exception("Pelo menos 1 item precisa ser informado");
            }

            Solicitacao entity = new(SolicitacaoStatus.Pendente,
                null,
                solicitacao.Tipo,
                _mapper.Map<List<SolicitacaoItem>>(solicitacao.Items));

            try
            {
                _solicitacaoServico.Cadastrar(entity);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<SolicitacaoDTO>(entity);
        }

        public SolicitacaoDTO Atualizar(SolicitacaoDTO solicitacao)
        {
            if (solicitacao.Items == null || solicitacao.Items.Count == 0)
            {
                throw new Exception("Pelo menos 1 item precisa ser informado");
            }

            ICollection<SolicitacaoItem> items = new Collection<SolicitacaoItem>();

            foreach (var item in solicitacao.Items)
            {
                items.Add(_mapper.Map<SolicitacaoItem>(item));
            }

            Solicitacao entity = new()
            {
                IDSolicitacao = solicitacao.IDSolicitacao,
                Status = solicitacao.Status,
                Tipo = solicitacao.Tipo,
                ValorSolicitado = solicitacao.ValorSolicitado,
                ValorAprovado = solicitacao.ValorAprovado,
                DataValidacao = null,
                Items = items
            };

            try
            {
                _solicitacaoServico.Atualizar(entity);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<SolicitacaoDTO>(entity);
        }

        public SolicitacaoDTO? Recuperar(int id)
        {
            if (id <= 0 || id > int.MaxValue)
            {
                throw new Exception("Digite um ID Válido");
            }

            try
            {
                var entity = _solicitacaoServico.Recuperar(id);

                if (entity == null)
                {
                    return null;
                }

                return _mapper.Map<SolicitacaoDTO>(entity);
                //var dto = new SolicitacaoDTO
                //{
                //    IDSolicitacao = entity.IDSolicitacao,
                //    Tipo = entity.Tipo,
                //    Status = entity.Status,
                //    Items = (List<SolicitacaoItemDTO>?)entity.Items,
                //    ValorSolicitado = entity.ValorSolicitado,
                //    ValorAprovado = entity.ValorAprovado,
                //    Justificativa = entity.Justificativa,
                //    CreatedAt = entity.CreatedAt
                //};

                //return dto;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao recuperar os dados");
            }
        }


        public bool Aprovar(int id)
        {
            var entity = _unitOfWork.SolicitacaoRepository.Recuperar(id);

            if (entity == null)
            {
                throw new Exception("Não existe uma solicitação com esse ID");
            }

            try
            {
                _solicitacaoServico.Aprovar(entity);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public void Aprovar(SolicitacaoDTO solicitacao)
        {

            if (solicitacao == null)
            {
                throw new Exception("Não existe uma solicitação com esse ID");
            }

            try
            {
                _solicitacaoServico.Aprovar(_mapper.Map<Solicitacao>(solicitacao));
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Negar(SolicitacaoDTO solicitacao)
        {

            if (solicitacao == null)
            {
                throw new Exception("Não existe uma solicitação com esse ID");
            }

            try
            {
                _solicitacaoServico.Negar(_mapper.Map<Solicitacao>(solicitacao));
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Negar(int id)
        {
            var entity = _unitOfWork.SolicitacaoRepository.Recuperar(id);

            if (entity == null)
            {
                throw new Exception("Não existe uma solicitação com esse ID");
            }

            try
            {
                _solicitacaoServico.Negar(entity);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }
    }
}
