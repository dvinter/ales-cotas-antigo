using AlesCotas.Application.Classes;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.DTOs;
using AlesCotas.Application.Interfaces.Servicos;
using AlesCotas.Application.Servicos.Base;
using AlesCotas.Domain.Filtros;
using AlesCotas.Domain.Interfaces.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlesCotas.Application.DTOs.Users;
using AlesCotas.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using AlesCotas.Domain.Interfaces.Repositories;
using AlesCotas.Domain.Interfaces.Servicos;
using AlesCotas.Domain.Servicos;
using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Domain.Constantes.Solicitacao;
using AlesCotas.Domain.Entities;
using System.Collections.ObjectModel;
using AlesCotas.Domain.Constantes;
using Microsoft.EntityFrameworkCore;

namespace AlesCotas.Application.Servicos
{
   

    public class UsuarioAppService : AppServico, IUsuarioAppService
    {
        private readonly IUsuarioServico _usuarioServico;
        public UsuarioAppService(IMapper mapper, IUnitOfWork uow, IUsuarioServico usuarioServico) : base(mapper, uow)
        {
            _usuarioServico = usuarioServico;
        }
        public async Task<UsuarioDto> Recuperar(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Digite um ID Válido");
            }

            try
            {
                var entity = await _usuarioServico.Recuperar(id);

                if (entity == null)
                {
                    return null;
                }
                else
                {
                    var dto = _mapper.Map<UsuarioDto>(entity);
                    var role = await _usuarioServico.GetRole(entity);
                    dto.Role = role;
                    return dto;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao recuperar os dados");
            }
        }

        public ListaPaginada<UsuarioDto> Listar(UsuarioFiltroDto filtro)
        {
            try
            {
                var entities = _usuarioServico.Listar(_mapper.Map<UsuarioFiltro>(filtro));
                var query = entities.Join(_usuarioServico.ListarRoles(), u => u.Id, r => r.UsuarioId, (u, r) => new UsuarioDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    GabineteName = u.Gabinete.Nome,
                    Nome = u.Nome,
                    IsAtivo = u.IsAtivo,
                    IDGabinete = u.IDGabinete,
                    Matricula = u.Matricula,
                    CreatedAt = u.CreatedAt,
                    Setor = u.Setor,
                    UpdatedAt = u.UpdatedAt,
                    Role = r.Role
                });
                

                //var dtos = _mapper.Map<List<UsuarioDto>>(entities);
                return ListaPaginada<UsuarioDto>.ToListaPaginada(query, filtro.NumeroPagina, filtro.TamanhoPagina);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IdentityResult> Cadastrar(EditarUsuarioDto novoUsuario)
        {
            if (String.IsNullOrEmpty(novoUsuario.UserName))
            {
                throw new Exception("Login do usuário deve ser informado");
            }

            var newUser = new Usuario
            {
                UserName = novoUsuario.UserName,
                Email = novoUsuario.Email,
                IDGabinete = novoUsuario.IDGabiente,
                Nome = novoUsuario.Nome,
                IsAtivo = novoUsuario.Ativo
            };

            try
            {
                var result = await _usuarioServico.Cadastrar(newUser);
                if (result.Succeeded)
                {
                    var resultRole = await _usuarioServico.SetRole(newUser, novoUsuario.Role);
                    if (!resultRole.Succeeded)
                    {
                        string msg = String.Join('\n', result.Errors.SelectMany(x => x.Code + "/" + x.Description));
                        throw new Exception(msg);
                    }
                    _unitOfWork.Commit();

                    return result;
                }
                else
                {
                    string msg = String.Join('\n', result.Errors.SelectMany(x => x.Code + "/" + x.Description));
                    throw new Exception(msg);
                }
            }
            catch (Exception)
            {
                throw;
            }

            
        }

        public async Task<IdentityResult> SetStatus(string id, bool status)
        {
            var user = await _usuarioServico.Recuperar(id);
            user.IsAtivo = status;
            return await _usuarioServico.Atualizar(user);
        }


        public async Task<IdentityResult> Apagar(string id)
        {
            return await _usuarioServico.Deletar(id);
        }

        public async Task<IdentityResult> Atualizar(EditarUsuarioDto entity, string id)
        {

            var usuarioAtual = await _usuarioServico.Recuperar(id);

            if (usuarioAtual == null)
                throw new Exception("Usuário não encontrado com id " + id);

            usuarioAtual.Email = entity.Email;
            usuarioAtual.Nome = entity.Nome;
            usuarioAtual.IsAtivo = entity.Ativo;
            usuarioAtual.IDGabinete = entity.IDGabiente;

            try
            {
                var result = await _usuarioServico.Atualizar(usuarioAtual);
                if (!result.Succeeded)
                {
                    string msg = String.Join('\n', result.Errors.SelectMany(x => x.Code + "/" + x.Description));
                    throw new Exception(msg);
                }


                _unitOfWork.Commit();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
