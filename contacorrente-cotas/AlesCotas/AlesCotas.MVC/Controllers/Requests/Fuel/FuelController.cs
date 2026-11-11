using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.Interfaces.Servicos;
using AlesCotas.Domain.Constantes.Solicitacao;
using AlesCotas.MVC.Models.Solicitacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.Requests.Fuel
{
    [Authorize]
    public class FuelController : Controller
    {
        private readonly IProdutoAppServico _produtoServ;
        private readonly IProdutoTipoAppServico _produtoTipoServ;
        private readonly ISolicitacaoAppServico _solicitacaoServ;

        public FuelController(IProdutoAppServico produtoServ, IProdutoTipoAppServico produtoTipoServ, ISolicitacaoAppServico solicitacaoServ)
        {
            _produtoServ = produtoServ;
            _produtoTipoServ = produtoTipoServ;
            _solicitacaoServ = solicitacaoServ;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Requests", null);
        }
        public IActionResult ListRequestFuel(int pagina = 1, string gabinete = "")
        {
            SolicitacaoFiltroDTO filtro = new()
            {
                NumeroPagina = pagina,
                TamanhoPagina = 10,
                Tipo = SolicitacaoTipos.Combustivel,
                Status = SolicitacaoStatus.Pendente
            };

            var viewModel = new SolicitacaoListagem()
            {
                Filtro = filtro,
                Lista = _solicitacaoServ.Listar(filtro)
            };

            return View("Views/Requests/Fuel/ListRequestFuel.cshtml", viewModel);
        }
        public IActionResult Fuel()
        {
            return View("Views/Requests/Fuel/Fuel.cshtml", _produtoServ.Listar("Combustível"));
        }
        public IActionResult FuelCreate()
        {
            return View("Views/Requests/Fuel/FuelCreate.cshtml");
        }
        public ActionResult FuelHistory()
        {
            SolicitacaoFiltroDTO filtro = new()
            {
                NumeroPagina = 1,
                TamanhoPagina = 10,
                Tipo = SolicitacaoTipos.Combustivel
            };
            return View("Views/History/Fuel/FuelHistory.cshtml", _solicitacaoServ.Listar(filtro));
        }
        public ActionResult FuelHistoryDetail(int id)
        {
            return View("Views/History/Fuel/FuelHistoryDetail.cshtml");
        }

        [HttpGet()]
        public ActionResult CadastrarSolicitacao(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Informe um ID Válido!";
                RedirectToAction(nameof(Fuel));
            }

            if (id != null)
            {
                ViewBag.Produto = _produtoServ.Recuperar((int)id);
            }

            return View("Views/Requests/Fuel/FormFuel.cshtml");
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
                Tipo = SolicitacaoTipos.Combustivel,
                Items = items
            };

            ModelState.Clear();
            TryValidateModel(solicitacaoItem);

            if (ModelState.IsValid)
            {

                _solicitacaoServ.Cadastrar(solicitacao);
                TempData["success"] = "Sucesso";
                return RedirectToAction(nameof(ListRequestFuel));
            }

            return View("Views/Requests/Fuel/FormFuel.cshtml");
        }

        [HttpPost()]
        public ActionResult EditarSolicitacao(SolicitacaoDTO solicitacao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _solicitacaoServ.Atualizar(solicitacao);
                    TempData["success"] = "Atualizado com sucesso!";
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return View("Views/Requests/Fuel/FuelApproved.cshtml", solicitacao);
                }
            }
            else
            {
                TempData["error"] = "Erro";
                return View("Views/Requests/Fuel/FuelApproved.cshtml", solicitacao);
            }

            return RedirectToAction(nameof(Fuel));
        }

        [HttpPost]
        public ActionResult Cadastrar(ProdutoCadastroDTO produto)
        {

            var tipoId = _produtoTipoServ.Recuperar("Combustivel");

            if (tipoId == null)
            {
                TempData["error"] = "Erro na recuperação do tipo.";
                return RedirectToAction(nameof(FuelCreate));
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
                    return RedirectToAction(nameof(Fuel));
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }

            return View("Views/Requests/Fuel/FuelCreate.cshtml");
        }

        [HttpGet()]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(Fuel));
            }

            var produto = _produtoServ.Recuperar((int)id);

            if (produto == null)
            {
                TempData["error"] = "Item não existe!";
                return RedirectToAction(nameof(Fuel));
            }

            ViewBag.Nome = produto.Nome;
            return View("Views/Requests/Fuel/FuelEdit.cshtml", produto);
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
                    return View("Views/Requests/Fuel/FuelEdit.cshtml", produto);
                }
            }
            else
            {
                TempData["error"] = "Erro";
                return View("Views/Requests/Fuel/FuelEdit.cshtml", produto);
            }

            return RedirectToAction(nameof(Fuel));
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

            return RedirectToAction(nameof(Fuel));
        }

        [HttpGet()]
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(ListRequestFuel));
            }

            var solicitacao = _solicitacaoServ.Recuperar((int)id);
            ViewBag.Solicitacao = solicitacao;

            if (solicitacao == null)
            {
                TempData["error"] = "Item não existe!";
                return RedirectToAction(nameof(ListRequestFuel));
            }

            return View("Views/Requests/Fuel/FuelApproved.cshtml", new SolicitacaoValidacao()
            {
                IDSolicitacao = solicitacao.IDSolicitacao,
                Justificativa = solicitacao.Justificativa,
                ValorAtualizado = solicitacao.ValorSolicitado
            });
        }

        [HttpGet()]
        public ActionResult Aprovar(int? id)
        {

            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(ListRequestFuel));
            }

            try
            {
                _solicitacaoServ.Aprovar((int)id);
                TempData["success"] = "Solicitacao Aprovada!!";

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(Url.Action("ListRequestFuel", "Fuel"));
                }
                else
                {
                    return RedirectToAction(nameof(ListRequestFuel));
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(Url.Action("ListRequestFuel", "Fuel"));
                }
                else
                {
                    return RedirectToAction(nameof(ListRequestFuel));
                }
            }
        }

        [HttpPost()]
        public ActionResult Aprovar(SolicitacaoValidacao solicitacao)
        {
            var entity = _solicitacaoServ.Recuperar(solicitacao.IDSolicitacao);

            if (entity == null)
            {
                TempData["error"] = "Não existe uma solicitação com ID informado!";
                return RedirectToAction(nameof(ListRequestFuel));
            }

            entity.ValorAprovado = solicitacao.ValorAtualizado;

            if (string.IsNullOrEmpty(solicitacao.Justificativa))
            {
                solicitacao.Justificativa = "Sem Justificativa";
            }

            entity.Justificativa = solicitacao.Justificativa;

            try
            {
                _solicitacaoServ.Aprovar(entity);
                TempData["success"] = "Aprovado!";
                RedirectToAction(nameof(ListRequestFuel));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction(nameof(ListRequestFuel));
            }

            return RedirectToAction(nameof(ListRequestFuel));
        }

        [HttpPost()]
        public ActionResult Negar(SolicitacaoValidacao solicitacao)
        {
            var entity = _solicitacaoServ.Recuperar(solicitacao.IDSolicitacao);

            if (entity == null)
            {
                TempData["error"] = "Não existe uma solicitação com ID informado!";
                return RedirectToAction(nameof(ListRequestFuel));
            }

            if (string.IsNullOrEmpty(solicitacao.Justificativa))
            {
                solicitacao.Justificativa = "Sem Justificativa";
            }

            entity.Justificativa = solicitacao.Justificativa;

            try
            {
                _solicitacaoServ.Negar(entity);
                TempData["error"] = "Cancelada!";
                RedirectToAction(nameof(ListRequestFuel));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction(nameof(ListRequestFuel));
            }

            return RedirectToAction(nameof(ListRequestFuel));
        }

        [HttpGet()]
        public ActionResult Negar(int? id)
        {

            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(ListRequestFuel));
            }

            try
            {
                _solicitacaoServ.Negar((int)id);
                TempData["success"] = "Solicitacao Negada!!";

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(Url.Action("ListRequestFuel", "Fuel"));
                }
                else
                {
                    return RedirectToAction(nameof(ListRequestFuel));
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(Url.Action("ListRequestFuel", "Fuel"));
                }
                else
                {
                    return RedirectToAction(nameof(ListRequestFuel));
                }
            }
        }

    }
}
