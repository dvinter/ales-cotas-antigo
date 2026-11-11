using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.Interfaces.Servicos;
using AlesCotas.Domain.Constantes.Solicitacao;
using AlesCotas.MVC.Models.Solicitacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.Requests.Material
{
    [Authorize]
    public class MaterialController : Controller
    {
        private readonly IProdutoAppServico _produtoServ;
        private readonly IProdutoTipoAppServico _produtoTipoServ;
        private readonly ISolicitacaoAppServico _solicitacaoServ;

        public MaterialController(IProdutoAppServico produtoServ, IProdutoTipoAppServico produtoTipoServ, ISolicitacaoAppServico solicitacaoServ)
        {
            _produtoServ = produtoServ;
            _produtoTipoServ = produtoTipoServ;
            _solicitacaoServ = solicitacaoServ;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Requests", null);
        }
        public IActionResult ListRequestMaterial(int pagina = 1, string gabinete = "")
        {
            SolicitacaoFiltroDTO filtro = new()
            {
                NumeroPagina = pagina,
                TamanhoPagina = 10,
                Tipo = SolicitacaoTipos.MaterialExpediente,
                Status = SolicitacaoStatus.Pendente
            };
            return View("Views/Requests/Material/ListRequestMaterial.cshtml", _solicitacaoServ.Listar(filtro));
        }

        [HttpGet]
        public IActionResult Material()
        {
            return View("Views/Requests/Material/Material.cshtml", _produtoServ.Listar(SolicitacaoTipos.MaterialExpediente));
        }
        public IActionResult MaterialApproved()
        {
            return View("Views/Requests/Material/MaterialApproved.cshtml");
        }
        public IActionResult MaterialCreate()
        {
            return View("Views/Requests/Material/MaterialCreate.cshtml");
        }
        public ActionResult FormMaterial()
        {
            ViewBag.Items = _produtoServ.Listar(SolicitacaoTipos.MaterialExpediente);
            return View("Views/Requests/Material/FormMaterial.cshtml");
        }
        public ActionResult FormMaterialEdit(int id)
        {
            return View("Views/Requests/Material/FormMaterialEdit.cshtml");
        }
        public ActionResult MaterialHistory()
        {
            return View("Views/History/Material/MaterialHistory.cshtml");
        }
        public ActionResult MaterialHistoryDetail(int id)
        {
            return View("Views/History/Material/MaterialHistoryDetail.cshtml");
        }

        [HttpPost]
        public ActionResult Cadastrar(ProdutoCadastroDTO produto)
        {

            var tipoId = _produtoTipoServ.Recuperar(SolicitacaoTipos.MaterialExpediente);

            if (tipoId == null)
            {
                TempData["error"] = "Erro na recuperação do tipo.";
                return RedirectToAction(nameof(MaterialCreate));
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
                    return RedirectToAction(nameof(Material));
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }

            return View("Views/Requests/Material/MaterialCreate.cshtml");
        }

        [HttpGet()]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(Material));
            }

            var produto = _produtoServ.Recuperar((int)id);

            if (produto == null)
            {
                TempData["error"] = "Item não existe!";
                return RedirectToAction(nameof(Material));
            }

            return View("Views/Requests/Material/MaterialEdit.cshtml", produto);

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
                    return View("Views/Requests/Material/MaterialEdit.cshtml", produto);
                }
            }
            else
            {
                TempData["error"] = "Erro";
                return View("Views/Requests/Material/MaterialEdit.cshtml", produto);
            }

            return RedirectToAction(nameof(Material));
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

            return RedirectToAction(nameof(Material));
        }

        [HttpPost]
        public ActionResult CadastrarSolicitacao([FromBody] List<SolicitacaoItemCadastroDTO> items)
        {

            if (items.FindIndex(i => i.QuantidadeSolicitada == 0) != -1)
            {
                TempData["error"] = "Item nao pode ter quantidade negativa";
                return Json(Url.Action("FormMaterial", "Material"));
            }

            SolicitacaoCadastroDTO solicitacao = new()
            {
                Tipo = SolicitacaoTipos.MaterialExpediente,
                Items = items
            };

            try
            {
                _solicitacaoServ.Cadastrar(solicitacao);
                TempData["success"] = "Sucesso";
                return Json(Url.Action("ListRequestMaterial", "Material"));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.ToString();
                return Json(Url.Action("FormMaterial", "Material"));
            }
        }

        [HttpGet()]
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(ListRequestMaterial));
            }

            var solicitacao = _solicitacaoServ.Recuperar((int)id);
            ViewBag.Solicitacao = solicitacao;

            if (solicitacao == null)
            {
                TempData["error"] = "Item não existe!";
                return RedirectToAction(nameof(ListRequestMaterial));
            }

            return View("Views/Requests/Material/MaterialApproved.cshtml", new SolicitacaoValidacao()
            {
                IDSolicitacao = solicitacao.IDSolicitacao,
                Justificativa = solicitacao.Justificativa,
                ValorAtualizado = solicitacao.ValorSolicitado,
                DataSolicitacao = (DateTime)solicitacao.CreatedAt,
                Items = solicitacao.Items
            });
        }

        [HttpGet()]
        public ActionResult Aprovar(int? id)
        {

            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(ListRequestMaterial));
            }

            try
            {
                _solicitacaoServ.Aprovar((int)id);
                TempData["success"] = "Solicitacao Aprovada!!";

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(Url.Action("ListRequestMaterial", "Material"));
                }
                else
                {
                    return RedirectToAction(nameof(ListRequestMaterial));
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(Url.Action("ListRequestMaterial", "Material"));
                }
                else
                {
                    return RedirectToAction(nameof(ListRequestMaterial));
                }
            }
        }

        [HttpPost()]
        public ActionResult Aprovar(SolicitacaoValidacao validacao)
        {

            var solicitacaoEntity = _solicitacaoServ.Recuperar(validacao.IDSolicitacao);

            if (solicitacaoEntity == null)
            {
                TempData["error"] = "Não existe uma solicitação com o ID informado!";
                return RedirectToAction(nameof(ListRequestMaterial));
            }

            // Checar se alguma quantidade está negativa
            if (validacao.Items.FindAll(i => i.QuantidadeAutorizada < 0).Any())
            {
                TempData["error"] = "Quantidade não pode ser menor que 0!";
                return RedirectToAction("Detalhes", new { id = validacao.IDSolicitacao });
            }

            for (int i = 0; i < validacao.Items.Count; i++)
            {
                solicitacaoEntity.Items[i].QuantidadeAutorizada = validacao.Items[i].QuantidadeAutorizada;
            }

            solicitacaoEntity.Justificativa = validacao.Justificativa;

            try
            {
                _solicitacaoServ.Aprovar(solicitacaoEntity);
                TempData["success"] = "Aprovado!";
                RedirectToAction(nameof(ListRequestMaterial));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            return RedirectToAction(nameof(ListRequestMaterial));
        }

        [HttpPost()]
        public ActionResult Negar(SolicitacaoValidacao validacao)
        {

            var solicitacaoEntity = _solicitacaoServ.Recuperar(validacao.IDSolicitacao);

            if (solicitacaoEntity == null)
            {
                TempData["error"] = "Não existe uma solicitação com o ID informado!";
                return RedirectToAction(nameof(ListRequestMaterial));
            }

            // Checar se alguma quantidade está negativa
            //if (validacao.Items.FindAll(i => i.QuantidadeSolicitada <= 0).Any())
            //{
            //    TempData["error"] = "Algum produto possui uma quantidade inválida!";
            //    return RedirectToAction(nameof(ListRequestMaterial));
            //}

            //for (int i = 0; i < validacao.Items.Count; i++)
            //{
            //    //if (solicitacaoEntity.Items[i].Quantidade != validacao.Items[i].Quantidade)
            //    //{
            //    //    solicitacaoEntity.Tipo = SolicitacaoStatus.AprovadoParcial;
            //    //}

            //    solicitacaoEntity.Items[i].QuantidadeSolicitada = validacao.Items[i].QuantidadeSolicitada;
            //}

            solicitacaoEntity.Justificativa = validacao.Justificativa;

            try
            {
                _solicitacaoServ.Negar(solicitacaoEntity);
                TempData["success"] = "Solicitação Negada!";
                RedirectToAction(nameof(ListRequestMaterial));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            return RedirectToAction(nameof(ListRequestMaterial));
        }

        [HttpGet()]
        public ActionResult Negar(int? id)
        {

            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(ListRequestMaterial));
            }

            try
            {
                _solicitacaoServ.Negar((int)id);
                TempData["success"] = "Solicitacao Negada!!";

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(Url.Action("ListRequestMaterial", "Material"));
                }
                else
                {
                    return RedirectToAction(nameof(ListRequestMaterial));
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(Url.Action("ListRequestMaterial", "Material"));
                }
                else
                {
                    return RedirectToAction(nameof(ListRequestMaterial));
                }
            }
        }

    }
}
