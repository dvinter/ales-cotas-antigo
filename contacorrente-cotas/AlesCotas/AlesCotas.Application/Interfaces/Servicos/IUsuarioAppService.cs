using AlesCotas.Application.Classes;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlesCotas.Application.Interfaces.Servicos
{
    public interface IUsuarioAppService
    {
        Task<UsuarioDto?> Recuperar(string id);
        Task<IdentityResult> Atualizar(EditarUsuarioDto entity, string id);
        Task<IdentityResult> Cadastrar(EditarUsuarioDto novoUsuario);
        ListaPaginada<UsuarioDto> Listar(UsuarioFiltroDto filtro);
        Task<IdentityResult> SetStatus(string id, bool status);
        Task<IdentityResult> Apagar(string id);
    }
}
