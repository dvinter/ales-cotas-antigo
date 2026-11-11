using AlesCotas.Application.Classes;
using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        private readonly ISolicitacaoAppServico _servico;

        public SolicitacaoController(ISolicitacaoAppServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public ActionResult<ListaPaginada<SolicitacaoDTO>> Listar([FromQuery] SolicitacaoFiltroDTO filtro)
        {
            return Ok(_servico.Listar(filtro));
        }

        [HttpPost]
        public ActionResult<ProdutoTipoDTO> Cadastrar([FromBody] SolicitacaoCadastroDTO solicitacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Objeto inválido!");
            }

            var resp = _servico.Cadastrar(solicitacao);
            return Ok(resp);
        }

        [HttpPost("Aprovar")]
        public ActionResult<bool> Aprovar([FromBody] int id)
        {
            return Ok(_servico.Aprovar(id));
        }

    }
}
