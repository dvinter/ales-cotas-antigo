using AlesCotas.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Domain.Entities;
using AlesCotas.Application.Interfaces.Servicos;
using Microsoft.EntityFrameworkCore;
using AlesCotas.Application.DTOs.Users;
using AlesCotas.Domain.Filtros.Base;
using AlesCotas.Application.Servicos;
using Microsoft.AspNetCore.Authorization;
using AlesCotas.Domain.Constantes;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using AlesCotas.Application.DTOs;

namespace AlesCotas.MVC.Controllers.Users
{
    public class UsersController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IGabineteAppService _gabineteAppService;
        private readonly UserManager<Usuario> _userManager;
        private readonly IEmailSender _emailSender;
        public UsersController(IUsuarioAppService usuarioAppService, IGabineteAppService gabineteAppService, UserManager<Usuario> userManager, IEmailSender emailSender)
        {
            _usuarioAppService = usuarioAppService;
            _gabineteAppService = gabineteAppService;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Users");
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult ListUsers([Bind("FiltroTexto,Status,NumeroPagina")] UsuarioFiltroDto filtro)
        {
            ViewBag.filtro = filtro;
            var result = _usuarioAppService.Listar(filtro);
            return View("Views/Users/User/ListUsers.cshtml", result);
        }
        // POST: Gabinetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveUser([Bind("UserName,Nome,Email,IDGabiente,Role,Ativo,Setor,Id")] EditarUsuarioDto objModel)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrWhiteSpace(objModel.Id))
                {
                    IdentityResult result = await _usuarioAppService.Cadastrar(objModel);
                    if (result.Succeeded)
                    {
                        await SendChangePasswordEMail(objModel.Email);
                    }
                }
                else
                {
                    IdentityResult result = await _usuarioAppService.Atualizar(objModel, objModel.Id);
                }

                return RedirectToAction(nameof(ListUsers));
            }
            return RedirectToAction(nameof(FormUsers), objModel);
        }


        [HttpGet]
        public async Task<IActionResult> SendChangePasswordEmailAction(string email)
        {
            return Ok(await SendChangePasswordEMail(email));
        }

        private async Task<bool> SendChangePasswordEMail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // Don't reveal that the user does not exist or is not confirmed
                return false;
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ResetPassword",
            pageHandler: null,
                values: new { area = "Identity", code },
                protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(
                email,
                "Definição de senha",
                $"Por favor, defina sua senha clicando no link: {HtmlEncoder.Default.Encode(callbackUrl)}");

            return true;
        }
    


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuscarMatricula(string consultaMatricula)
        {
            ViewBag.gabinetes = _gabineteAppService.Listar(new GabineteFiltroDto { NumeroPagina = 1,  TamanhoPagina = int.MaxValue });
            
            //Consultar sistema ALES
            
            return View("Views/Users/User/FormUsers.cshtml", new EditarUsuarioDto 
            { 
                Ativo = true, 
                Email = consultaMatricula+"@email.com", 
                Nome = "Usuario Exmeplo "+consultaMatricula, 
                Role = "User", 
                Setor = "Setor", 
                UserName = consultaMatricula, 
                IDGabiente = null 
            });
        }

        public IActionResult FormUsers()
        {
            ViewBag.gabinetes = _gabineteAppService.Listar(new GabineteFiltroDto { NumeroPagina = 1, TamanhoPagina = int.MaxValue });
            return View("Views/Users/User/FormUsers.cshtml");
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.gabinetes = _gabineteAppService.Listar(new GabineteFiltroDto { NumeroPagina = 1, TamanhoPagina = int.MaxValue });
            var user = await _usuarioAppService.Recuperar(id);
            if (user != null)
                return View("Views/Users/User/FormUsers.cshtml", new EditarUsuarioDto { Ativo = user.IsAtivo, Email = user.Email, Id = user.Id, IDGabiente = user.IDGabinete, Nome = user.Nome, Role = user.Role, Setor = user.Setor, UserName = user.Matricula });
            else
                return RedirectToAction(nameof(ListGabinete));
        }

        [Authorize(Roles =UserRoles.ADMIN)]
        public async Task<IActionResult> Enable(string id)
        {
             var result = await _usuarioAppService.SetStatus(id,true);
            return RedirectToAction(nameof(ListUsers));
        }
        [Authorize(Roles = UserRoles.ADMIN)]
        public async Task<IActionResult> Disable(string id)
        {
            var result = await _usuarioAppService.SetStatus(id, false);
            return RedirectToAction(nameof(ListUsers));
        }
        [Authorize(Roles = UserRoles.ADMIN)]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _usuarioAppService.Apagar(id);
            return RedirectToAction(nameof(ListUsers));
        }
        [Authorize(Roles = UserRoles.ADMIN)]
        public IActionResult ListGabinete([Bind("FiltroTexto,Status,NumeroPagina")]GabineteFiltroDto filtro)
        {
            ViewBag.filtro = filtro;
            var result = _gabineteAppService.Listar(filtro);
            return View("Views/Users/Gabinete/ListGabinete.cshtml", result);
        }
        public IActionResult FormGabinete()
        {
            return View("Views/Users/Gabinete/FormGabinete.cshtml");
        }
        public IActionResult FormGabineteEdit()
        {
            return View("Views/Users/Gabinete/FormGabineteEdit.cshtml");
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        public async Task<IActionResult> EditGabinete(int id)
        {
            var gabinete = await _gabineteAppService.Recuperar(id);
            return View("Views/Users/Gabinete/FormGabinete.cshtml", new EditarGabineteDto {  IsAtivo = gabinete.IsAtivo, Nome = gabinete.Nome, IDGabinete = gabinete.IDGabinete  });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRoles.ADMIN)]
        public async Task<IActionResult> SalvarGabinete([Bind("IDGabinete,Nome,IsAtivo")] EditarGabineteDto objModel)
        {
            if (ModelState.IsValid)
            {
                if (!objModel.IDGabinete.HasValue || objModel.IDGabinete <=0)
                {
                    var result = await _gabineteAppService.Cadastrar(objModel);
                }
                else
                {
                    var result = await _gabineteAppService.Atualizar(objModel);
                }

                return RedirectToAction(nameof(ListGabinete));
            }
            return RedirectToAction(nameof(FormGabinete), objModel);
        }

    }
}
