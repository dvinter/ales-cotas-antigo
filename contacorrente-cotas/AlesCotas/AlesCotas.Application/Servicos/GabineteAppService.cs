using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.DTOs;
using AlesCotas.Application.Servicos.Base;
using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Exceptions;
using AlesCotas.Domain.Filtros;
using AlesCotas.Domain.Interfaces.Servicos;
using AlesCotas.Domain.Interfaces.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlesCotas.Application.Interfaces.Servicos;
using Microsoft.EntityFrameworkCore;
using AlesCotas.Application.Classes;
using AlesCotas.Application.DTOs.Users;

namespace AlesCotas.Application.Servicos
{
  

    public class GabineteAppService : AppServico, IGabineteAppService
    {
        protected IGabineteService _servico;

        public GabineteAppService(IMapper mapper, IUnitOfWork uow, IGabineteService servico) : base(mapper, uow)
        {
            _servico = servico;
        }

        public  ListaPaginada<GabineteDto> Listar(GabineteFiltroDto parametros)
        {
            var filtro = _mapper.Map<GabineteFiltro>(parametros);

            var query = _servico.Listar(filtro).Include(x => x.Usuarios).Select(x => new GabineteDto
            {
                IDGabinete = x.IDGabinete,
                Nome = x.Nome,
                IsAtivo = x.IsAtivo,
                QtdUsuarios = x.Usuarios.Count(),
                CreatedAt = x.CreatedAt,
                UpdateAt = x.UpdatedAt
            });

            query = query.OrderBy(x=> x.Nome).ThenByDescending(x => x.UpdateAt);

            return ListaPaginada<GabineteDto>.ToListaPaginada(query, filtro.NumeroPagina, filtro.TamanhoPagina);

        }

        public async Task<GabineteDto> Recuperar(int id)
        {

            try
            {
                var entity = await _servico.Recuperar(id);

                if (entity == null)
                {
                    return null;
                }

                return _mapper.Map<GabineteDto>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GabineteDto> Cadastrar(EditarGabineteDto model)
        {
            var entity = new Gabinete {
                IsAtivo = model.IsAtivo,
                Nome = model.Nome,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            try
            {
                var entry = await  _servico.Cadastrar(entity);
                _unitOfWork.Commit();

                return _mapper.Map<GabineteDto>(entry);
            }
            catch (Exception)
            {
                throw;
            }

            
        }

        public async Task<GabineteDto> Atualizar(EditarGabineteDto model)
        {
            if (!model.IDGabinete.HasValue || model.IDGabinete <=0)
            {
                throw new Exception("Digite um Id Válido");
            }

            var entity = await _servico.Recuperar(model.IDGabinete.Value);
            try
            {
                entity.Nome = model.Nome;
                entity.IsAtivo = model.IsAtivo;
                entity.UpdatedAt = DateTime.Now;

                _servico.Atualizar(entity);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<GabineteDto>(entity);
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
