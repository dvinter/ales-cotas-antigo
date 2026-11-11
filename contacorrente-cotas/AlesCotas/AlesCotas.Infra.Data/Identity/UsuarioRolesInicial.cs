using AlesCotas.Domain.Conta;
using AlesCotas.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AlesCotas.Infra.Data.Identity
{
    public class UsuarioRolesInicial : IUsuarioRolesInicial
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsuarioRolesInicial(RoleManager<IdentityRole> roleManager, UserManager<Usuario> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void IncluirUsuarios()
        {

            if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                Usuario user = new()
                {
                    UserName = "usuario",
                    Email = "usuario@mail.com",
                    NormalizedUserName = "USUARIO",
                    NormalizedEmail = "MAILMAIL@MAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Matricula = "11111111",
                    Nome = "usuario normal nome completo"
                };

                IdentityResult result = _userManager.CreateAsync(user, "Numsey#2022").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Usuario").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("adminsupremo@localhost").Result == null)
            {
                Usuario user = new Usuario()
                {
                    UserName = "AdminSupremo",
                    Email = "adminsupremo@localhost",
                    NormalizedUserName = "ADMINSUPREMO",
                    NormalizedEmail = "ADMINSUPREMO@MAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Matricula = "99999999",
                    Nome = "Nome completo Admin supremo"
                };

                IdentityResult result = _userManager.CreateAsync(user, "Adminadmin#2022").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public void IncluirPerfis()
        {
            if (!_roleManager.RoleExistsAsync("Usuario").Result)
            {

                IdentityRole role = new()
                {
                    Name = "Usuario",
                    NormalizedName = "USUARIO"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {

                IdentityRole role = new()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
