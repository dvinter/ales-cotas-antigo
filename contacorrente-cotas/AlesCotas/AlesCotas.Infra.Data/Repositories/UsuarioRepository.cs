using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros;
using AlesCotas.Domain.Filtros.Enum;
using AlesCotas.Domain.Interfaces.Repositories;
using AlesCotas.Infra.Data.Context;
using AlesCotas.Infra.Data.Identity;
using AlesCotas.Infra.Data.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlesCotas.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly UserManager<Usuario> _userManager;

        public UsuarioRepository(ApplicationDbContext context, UserManager<Usuario> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public IQueryable<Usuario> Listar(UsuarioFiltro filtro)
        {
            var query = _userManager.Users.Include(e => e.Gabinete).AsQueryable();

            if (filtro.Status != Domain.Filtros.Enum.EFiltroStatus.Todos)
            {
                query = query.Where(e => e.IsAtivo == (filtro.Status == EFiltroStatus.Ativo));
            }

            if (!string.IsNullOrEmpty(filtro.FiltroTexto))
            {
                query = query.Where(e => e.UserName.Contains(filtro.FiltroTexto) || e.Matricula.Contains(filtro.FiltroTexto) || e.Email.Contains(filtro.FiltroTexto) || (e.Nome != null && e.Nome.Contains(filtro.FiltroTexto)));
            }

            return query.OrderByDescending(e => e.CreatedAt);
        }

        public async Task<Usuario?> Recuperar(string id)
        {
            return await _userManager.Users.Include(e => e.Gabinete).Where(e => e.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IdentityResult> Cadastrar(Usuario entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            var entry = await _userManager.CreateAsync(entity);

            return entry;

        }

        public async Task<IdentityResult> Atualizar(Usuario entity)
        {
            entity.UpdatedAt = DateTime.Now;
            var entry = await _userManager.UpdateAsync(entity);
            return entry;
        }

        public async Task<IdentityResult> Deletar(Usuario entity)
        {
            var entry = await _userManager.DeleteAsync(entity);
            return entry;
        }

        public async Task<IEnumerable<string>> GetRoles(Usuario entity)
        {
            return await this._userManager.GetRolesAsync(entity);
        }

        public IQueryable<UsuarioRoles> QueryRoles()
        {
            return this._databaseContext.UserRoles.Join(this._databaseContext.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => new UsuarioRoles
            {
                RoleId = r.Id,
                Role = r.Name,
                UsuarioId = ur.UserId
            });

        }

        public async Task<IdentityResult> AddRole(Usuario entity, string role)
        {
            return await this._userManager.AddToRoleAsync(entity, role);
        }

        public async Task<IdentityResult> RemoveRole(Usuario entity, string role)
        {
            return await this._userManager.RemoveFromRoleAsync(entity, role);
        }
    }
}
