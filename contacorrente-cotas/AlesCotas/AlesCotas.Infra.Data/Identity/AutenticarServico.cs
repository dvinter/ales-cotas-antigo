using AlesCotas.Domain.Conta;
using Microsoft.AspNetCore.Identity;

namespace AlesCotas.Infra.Data.Identity
{
    //public class AutenticarServico : IAutenticar
    //{
    //    private readonly UserManager<ApplicationUser> _userManager;
    //    private readonly SignInManager<ApplicationUser> _signInManager;


    //    public AutenticarServico(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    //    {
    //        _userManager = userManager;
    //        _signInManager = signInManager;
    //    }

    //    public async Task<bool> Autenticar(string email, string senha)
    //    {
    //        var result = await _signInManager.PasswordSignInAsync(email, senha, false, lockoutOnFailure: false);

    //        return result.Succeeded;
    //    }

    //    public async Task<bool> RegistrarUsuario(string email, int matricula, string senha)
    //    {

    //        ApplicationUser usuario = new ApplicationUser
    //        {
    //            UserName = email
    //        };

    //        var result = await _userManager.CreateAsync(usuario, senha);

    //        if (result.Succeeded)
    //        {
    //            await _signInManager.SignInAsync(usuario, isPersistent: false);
    //        }

    //        return result.Succeeded;
    //    }

    //    public async Task Logout()
    //    {
    //        await _signInManager.SignOutAsync();
    //    }
    //}
}
