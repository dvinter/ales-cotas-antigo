using AlesCotas.Domain.Conta;
using AlesCotas.MVC.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.Auth
{
    public class AuthController : Controller
    {
        private readonly IAutenticar _autenticacaoServ;

        public AuthController(IAutenticar autenticar)
        {
            _autenticacaoServ = autenticar;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            var result = await _autenticacaoServ.Autenticar(model.Email, model.Senha);

            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Tentativa de login inválida!");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _autenticacaoServ.Logout();
            return Redirect("/Auth/Login");
        }

        public IActionResult Index()
        {
            return View("Views/Auth/Login.cshtml");
        }
        public IActionResult Forgot()
        {
            return View();
        }
    }
}
