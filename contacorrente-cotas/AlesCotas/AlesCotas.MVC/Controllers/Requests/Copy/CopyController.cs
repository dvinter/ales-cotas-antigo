using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.Interfaces.Servicos;
using AlesCotas.Domain.Constantes.Solicitacao;
using AlesCotas.MVC.Models.Solicitacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AlesCotas.MVC.Controllers.Requests.Copy
{
    [Authorize]
    public class CopyController : Controller
    {
        private readonly IProdutoAppServico _produtoServ;
        private readonly IProdutoTipoAppServico _produtoTipoServ;
        private readonly ISolicitacaoAppServico _solicitacaoServ;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISolicitacaoItemArquivoAppServico _solicitacaoItemArquivoServ;
        private readonly ISolicitacaoItemCRAppServico _solicitacaoItemCRServ;
        private readonly IGrampeamentoTipoAppServico _grampeamentoTipoServ;

        public CopyController(IProdutoAppServico produtoServ,
            IProdutoTipoAppServico produtoTipoServ,
            ISolicitacaoAppServico solicitacaoServ, IWebHostEnvironment webHostEnvironment,
            ISolicitacaoItemArquivoAppServico solicitacaoItemArquivoServ,
            IGrampeamentoTipoAppServico grampeamentoTipoServ,
            ISolicitacaoItemCRAppServico solicitacaoItemCRServ)
        {
            _produtoServ = produtoServ;
            _produtoTipoServ = produtoTipoServ;
            _solicitacaoServ = solicitacaoServ;
            _webHostEnvironment = webHostEnvironment;
            _solicitacaoItemArquivoServ = solicitacaoItemArquivoServ;
            _grampeamentoTipoServ = grampeamentoTipoServ;
            _solicitacaoItemCRServ = solicitacaoItemCRServ;
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Requests", null);
        }
        public IActionResult ListRequestCopy(int pagina = 1, string gabinete = "")
        {
            SolicitacaoFiltroDTO filtro = new()
            {
                NumeroPagina = pagina,
                TamanhoPagina = 10,
                Tipo = SolicitacaoTipos.CopiaReprografica,
                Status = SolicitacaoStatus.Pendente
            };
            return View("Views/Requests/Copy/ListRequestCopy.cshtml", _solicitacaoServ.Listar(filtro));
        }
        public IActionResult Copy()
        {
            return View("Views/Requests/Copy/Copy.cshtml", _produtoServ.Listar("Copia reprografica"));
        }
        public IActionResult CopyCreate()
        {
            return View("Views/Requests/Copy/CopyCreate.cshtml");
        }
        public ActionResult FormCopy()
        {
            ViewBag.SelectItems = new SelectList(_produtoServ.Listar("Copia reprografica"), "IDProduto", "Nome");
            return View("Views/Requests/Copy/FormCopy.cshtml");
        }
        public IActionResult CopyApproved()
        {

            return View("Views/Requests/Copy/CopyApproved.cshtml");
        }
        public ActionResult CopyHistory()
        {
            return View("Views/History/Copy/HistoryCopy.cshtml");
        }
        public ActionResult CopyHistoryDetail()
        {
            return View("Views/History/Copy/HistoryCopyDetail.cshtml");
        }
        [HttpGet()]
        public ActionResult CadastrarSolicitacao()
        {

            ViewBag.Items = _produtoServ.Listar("Copia reprografica");
            ViewBag.Grampeamentos = _grampeamentoTipoServ.Listar();
            return View("Views/Requests/Copy/FormCopy.cshtml");
        }

        [HttpPost()]
        public ActionResult CadastrarSolicitacao([FromForm] dynamic form)
        {

            var items = JsonConvert.DeserializeObject<List<SolicitacaoItemCadastroDTO>>(HttpContext.Request.Form["items"]);

            if (items == null || items.Count == 0)
            {
                TempData["error"] = "Items nao podem estar vazios!";
                return Json(Url.Action("CadastrarSolicitacao", "Copy"));
            }

            if (items.FindIndex(i => i.QuantidadeSolicitada <= 0) != -1)
            {
                TempData["error"] = "Quantidade inválida para um ou mais items!";
                return Json(Url.Action("CadastrarSolicitacao", "Copy"));
            }

            if (HttpContext.Request.Form.Files.Count <= 0)
            {
                TempData["error"] = "Não há arquivos a serem carregados!";
                return Json(Url.Action("CadastrarSolicitacao", "Copy"));
            }

            var arquivos = Request.Form.Files;

            //if (HttpContext.Request.Form.Files.Count > 0)
            //{

            //    string fileName;

            //    for (int i = 0; i < files.Count; i++)
            //    {
            //        var file = files[i];
            //        fileName = Path.Combine(_webHostEnvironment.WebRootPath + "\\Arquivos\\CR\\" + file.FileName);

            //        using var stream = new FileStream(fileName, FileMode.Create);
            //        file.CopyTo(stream);
            //    }
            //}

            SolicitacaoCadastroDTO solicitacao = new()
            {
                Tipo = SolicitacaoTipos.CopiaReprografica,
                Items = items
            };


            try
            {

                var solicitacaoCadastrada = _solicitacaoServ.Cadastrar(solicitacao);

                string fileName = "";
                string caminho = Path.Combine(_webHostEnvironment.WebRootPath + "\\Arquivos\\CopiaReprografica\\" + solicitacaoCadastrada.IDSolicitacao);

                for (int i = 0; i < arquivos.Count; i++)
                {
                    var item = solicitacaoCadastrada.Items[i];
                    var file = arquivos[i];
                    fileName = Path.Combine(caminho + "\\" + file.FileName);

                    if (!Directory.Exists(caminho))
                    {
                        Directory.CreateDirectory(caminho);
                    }

                    using var stream = new FileStream(fileName, FileMode.Create);
                    file.CopyTo(stream);

                    SolicitacaoItemArquivoDTO itemArquivo = new()
                    {
                        IDSolicitacaoItem = item.IDSolicitacaoItem,
                        Url = file.FileName
                    };

                    SolicitacaoItemCRDTO itemCR = new()
                    {
                        IDSolicitacaoItem = item.IDSolicitacaoItem,
                        IDGrampeamentoTipo = (int)items[i].IDGrampeamentoTipo
                    };

                    _solicitacaoItemArquivoServ.Cadastrar(itemArquivo);
                    _solicitacaoItemCRServ.Cadastrar(itemCR);
                }

                TempData["success"] = "Sucesso!";

                return Json(Url.Action("ListRequestCopy", "Copy"));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.ToString();
                return Json(Url.Action("CadastrarSolicitacao", "Copy"));
            }

        }

        [HttpPost]
        public ActionResult Cadastrar(ProdutoCadastroDTO produto)
        {

            var tipoId = _produtoTipoServ.Recuperar("Copia reprografica");

            if (tipoId == null)
            {
                TempData["error"] = "Erro na recuperação do tipo.";
                return RedirectToAction(nameof(CopyCreate));
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
                    return RedirectToAction(nameof(Copy));
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }

            return View("Views/Requests/Copy/CopyCreate.cshtml");
        }

        [HttpGet()]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(Copy));
            }

            var produto = _produtoServ.Recuperar((int)id);

            if (produto == null)
            {
                TempData["error"] = "Item não existe!";
                return RedirectToAction(nameof(Copy));
            }

            return View("Views/Requests/Copy/CopyEdit.cshtml", produto);

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
                    return View("Views/Requests/Copy/CopyEdit.cshtml", produto);
                }
            }
            else
            {
                TempData["error"] = ModelState.Values.First().RawValue;
                return View("Views/Requests/Copy/CopyEdit.cshtml", produto);
            }

            return RedirectToAction(nameof(Copy));
        }

        [HttpGet()]
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Copy));
            }

            var produto = _produtoServ.Recuperar((int)id);

            if (produto == null)
            {
                return RedirectToAction(nameof(Copy));
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

            return RedirectToAction(nameof(Copy));
        }

        [HttpGet()]
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(ListRequestCopy));
            }

            var solicitacao = _solicitacaoServ.Recuperar((int)id);
            ViewBag.Solicitacao = solicitacao;

            if (solicitacao == null)
            {
                TempData["error"] = "Item não existe!";
                return RedirectToAction(nameof(ListRequestCopy));
            }

            // Carregar os arquivos e os grampeamentos
            var arquivos = _solicitacaoItemArquivoServ.Listar(solicitacao.Items.Select(element => element.IDSolicitacaoItem).ToList());
            var itemsCR = _solicitacaoItemCRServ.Listar(solicitacao.Items.Select(element => element.IDSolicitacaoItem).ToList());

            CopiaReprograficaValidacao viewModel = new()
            {
                IDSolicitacao = solicitacao.IDSolicitacao,
                DataSolicitacao = (DateTime)solicitacao.CreatedAt,
                Items = new List<CopiaReprograficaValidacaoItem>(),
                Justificativa = solicitacao.Justificativa
            };

            foreach (var item in solicitacao.Items)
            {
                var itemCr = itemsCR.Find(e => e.IDSolicitacaoItem == item.IDSolicitacaoItem);
                var grampeamento = _grampeamentoTipoServ.Recuperar(itemCr.IDGrampeamentoTipo);

                viewModel.Items.Add(
                    new CopiaReprograficaValidacaoItem()
                    {
                        IDSolicitacaoItem = item.IDSolicitacaoItem,
                        Tipo = item.Produto.Tipo.Nome,
                        Grampeamento = grampeamento.Nome,
                        Anexo = $"/Arquivos/CopiaReprografica/{solicitacao.IDSolicitacao}/{arquivos.Find(arq => arq.IDSolicitacaoItem == item.IDSolicitacaoItem).Url}",
                        QuantidadeSolicitada = item.QuantidadeSolicitada,
                        ValorMedio = item.Produto.ValorUnitario,
                        QuantidadeAutorizada = item.QuantidadeSolicitada
                    }
                );
            }

            return View("Views/Requests/Copy/CopyApproved.cshtml", viewModel);
        }

        [HttpGet()]
        public ActionResult Aprovar(int? id)
        {

            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(ListRequestCopy));
            }

            try
            {
                _solicitacaoServ.Aprovar((int)id);
                TempData["success"] = "Solicitacao Aprovada!!";
                return Json(Url.Action("ListRequestCopy", "Copy"));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return Json(Url.Action("ListRequestCopy", "Copy"));
            }
        }

        [HttpGet()]
        public ActionResult Negar(int? id)
        {

            if (id == null)
            {
                TempData["error"] = "Id Invalido!";
                return RedirectToAction(nameof(ListRequestCopy));
            }

            try
            {
                _solicitacaoServ.Negar((int)id);
                TempData["success"] = "Solicitacao Aprovada!!";
                return Json(Url.Action("ListRequestCopy", "Copy"));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return Json(Url.Action("ListRequestCopy", "Copy"));
            }
        }

        [HttpPost]
        public ActionResult Aprovar(CopiaReprograficaValidacao validacao)
        {
            if (validacao.Items.FindIndex(item => item.QuantidadeAutorizada < 0 || item.QuantidadeAutorizada > int.MaxValue) != -1)
            {
                TempData["error"] = "Uma das quantidades possue um valor invalido!";
                return RedirectToAction("Detalhes", new { id = validacao.IDSolicitacao });
            }

            var solicitacao = _solicitacaoServ.Recuperar(validacao.IDSolicitacao);

            if (solicitacao == null)
            {
                TempData["error"] = "Não existe uma solicitação com este ID!";
                return RedirectToAction("Detalhes", new { id = validacao.IDSolicitacao });
            }

            solicitacao.Justificativa = validacao.Justificativa;

            foreach (var item in solicitacao.Items)
            {
                var validacaoItem = validacao.Items.Find(element => element.IDSolicitacaoItem == item.IDSolicitacaoItem);

                item.QuantidadeAutorizada = validacaoItem.QuantidadeAutorizada;
            }

            try
            {
                _solicitacaoServ.Aprovar(solicitacao);
                TempData["success"] = "Aprovado!";
                return RedirectToAction(nameof(ListRequestCopy));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction(nameof(ListRequestCopy));
            }
        }

        public ActionResult Negar(CopiaReprograficaValidacao validacao)
        {
            if (validacao.Items.FindIndex(item => item.QuantidadeAutorizada < 0 || item.QuantidadeAutorizada > int.MaxValue) != -1)
            {
                TempData["error"] = "Uma das quantidades possue um valor invalido!";
                return RedirectToAction("Detalhes", new { id = validacao.IDSolicitacao });
            }

            var solicitacao = _solicitacaoServ.Recuperar(validacao.IDSolicitacao);

            if (solicitacao == null)
            {
                TempData["error"] = "Não existe uma solicitação com este ID!";
                return RedirectToAction("Detalhes", new { id = validacao.IDSolicitacao });
            }

            solicitacao.Justificativa = validacao.Justificativa;

            foreach (var item in solicitacao.Items)
            {
                var validacaoItem = validacao.Items.Find(element => element.IDSolicitacaoItem == item.IDSolicitacaoItem);

                item.QuantidadeAutorizada = validacaoItem.QuantidadeAutorizada;
            }

            try
            {
                _solicitacaoServ.Negar(solicitacao);
                TempData["success"] = "Solicitação negada com sucesso!";
                return RedirectToAction(nameof(ListRequestCopy));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction(nameof(ListRequestCopy));
            }
        }
    }
}
