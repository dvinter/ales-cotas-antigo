using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Application.Interfaces.Servicos;
using AlesCotas.Domain.Constantes.Solicitacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.Requests.Post.Ar
{
    [Authorize]
    public class PostArController : Controller
    {
        private readonly IProdutoAppServico _produtoServ;
        private readonly IProdutoTipoAppServico _produtoTipoServ;
        private readonly ISolicitacaoAppServico _solicitacaoServ;

        public PostArController(IProdutoAppServico produtoServ, IProdutoTipoAppServico produtoTipoServ, ISolicitacaoAppServico solicitacaoServ)
        {
            _produtoServ = produtoServ;
            _produtoTipoServ = produtoTipoServ;
            _solicitacaoServ = solicitacaoServ;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Requests", null);
        }
        public IActionResult ListRequestPostAr()
        {
            return View("Views/Requests/Post/Ar/ListRequestPostAr.cshtml");
        }
        public IActionResult PostArApproved()
        {
            return View("Views/Requests/Post/Ar/PostArApproved.cshtml");
        }
        public IActionResult PostArApprovedEdit()
        {
            return View("Views/Requests/Post/Ar/PostArApprovedEdit.cshtml");
        }
        public IActionResult PostCreateAr()
        {
            return View("Views/Requests/Post/Ar/PostCreateAr.cshtml");
        }
        public IActionResult PostEditAr(int id)
        {
            return View("Views/Requests/Post/Ar/PostEditAr.cshtml");
        }
        public IActionResult PostAr()
        {
            return View("Views/Requests/Post/Ar/PostAr.cshtml", _produtoServ.Listar("Postagem Ar"));
        }
        public ActionResult PostArHistory()
        {
            return View("Views/History/Post/Ar/PostArHistory.cshtml");
        }
        public ActionResult PostArHistoryDetail(int id)
        {
            return View("Views/History/Post/Ar/PostArHistoryDetail.cshtml");
        }

        [HttpGet()]
        public ActionResult CadastrarSolicitacao()
        {
            ViewBag.Items = _produtoServ.Listar(SolicitacaoTipos.PostagemAr);
            return View("Views/Requests/Post/Ar/FormPostAr.cshtml");
        }

        [HttpPost]
        public ActionResult CadastrarSolicitacao(SolicitacaoItemCadastroDTO solicitacaoItem)
        {
            var produto = _produtoServ.Recuperar(solicitacaoItem.IDProduto);

            solicitacaoItem.QuantidadeSolicitada = (int)(solicitacaoItem.ValorUnitario / produto.ValorUnitario);

            List<SolicitacaoItemCadastroDTO> items = new()
            {
                solicitacaoItem
            };

            SolicitacaoCadastroDTO solicitacao = new()
            {
                Tipo = SolicitacaoTipos.PostagemAr,
                Items = items
            };

            ModelState.Clear();
            TryValidateModel(solicitacaoItem);

            if (ModelState.IsValid)
            {

                _solicitacaoServ.Cadastrar(solicitacao);
                TempData["success"] = "Sucesso";
                return RedirectToAction(nameof(ListRequestPostAr));
            }

            return View("Views/Requests/Post/Ar/FormPostAr.cshtml");
        }

        [HttpPost]
        public ActionResult Cadastrar(ProdutoCadastroDTO produto)
        {

            var tipoId = _produtoTipoServ.Recuperar("Postagem Ar");

            if (tipoId == null)
            {
                TempData["error"] = "Erro na recuperação do tipo.";
                return RedirectToAction(nameof(PostAr));
            }

            produto.IDProdutoTipo = (int)tipoId;

            ModelState.Clear();
            TryValidateModel(produto);

            if (ModelState.IsValid)
            {

                try
                {
                    _produtoServ.Cadastrar(produto);
                    TempData["success"] = "Sucesso";
                    return RedirectToAction(nameof(PostAr));
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }

            return View("Views/Requests/Post/Ar/PostArCreate.cshtml");
        }

        [HttpGet()]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(PostAr));
            }

            var produto = _produtoServ.Recuperar((int)id);

            if (produto == null)
            {
                TempData["error"] = "Item não existe!";
                return RedirectToAction(nameof(PostAr));
            }

            return View("Views/Requests/Post/Ar/PostEditAr.cshtml", produto);

        }

        [HttpPost()]
        public ActionResult Editar(ProdutoDTO produto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _produtoServ.Atualizar(produto);
                    TempData["success"] = "Atualizado com sucesso!";
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return View("Views/Requests/Post/Ar/PostEditAr.cshtml", produto);
                }
            }
            else
            {
                TempData["error"] = "Erro";
                return View("Views/Requests/Post/Ar/PostEditAr.cshtml", produto);
            }

            return RedirectToAction(nameof(PostAr));
        }

        [HttpGet()]
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _produtoServ.Recuperar((int)id);

            if (produto == null)
            {
                return NotFound();
            }

            try
            {
                _produtoServ.Deletar((int)id);
                TempData["success"] = "Sucesso";
            }
            catch (Exception)
            {
                TempData["error"] = "Erro ao deletar!";
            }

            return RedirectToAction(nameof(PostAr));
        }
    }
}
