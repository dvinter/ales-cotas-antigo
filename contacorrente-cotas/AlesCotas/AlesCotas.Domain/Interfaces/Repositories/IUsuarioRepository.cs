using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros;
using Microsoft.AspNetCore.Identity;


namespace AlesCotas.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IdentityResult> Atualizar(Usuario entity);
        Task<IdentityResult> Cadastrar(Usuario entity);
        Task<IdentityResult> Deletar(Usuario entity);
        IQueryable<Usuario> Listar(UsuarioFiltro filtro);
        Task<Usuario?> Recuperar(string id);

        Task<IEnumerable<string>> GetRoles(Usuario entity);
        IQueryable<UsuarioRoles> QueryRoles();

        Task<IdentityResult> AddRole(Usuario entity, string role);
        Task<IdentityResult> RemoveRole(Usuario entity, string role);
    }
}
