using AlesCotas.Application.Classes;
using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoTipoController : ControllerBase
    {
        private readonly IProdutoTipoAppServico _servico;

        public ProdutoTipoController(IProdutoTipoAppServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public ActionResult<ListaPaginada<ProdutoTipoDTO>> Listar([FromQuery] ProdutoTipoFiltroDTO filtro)
        {
            return Ok(_servico.Listar(filtro));
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoTipoDTO> GetById(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest("Id nao pode ser negativo!");
            }
            var tipo = _servico.Recuperar((int)id);
            if (tipo == null)
            {
                return BadRequest("Não existe um tipo com esse ID");
            }
            return Ok(tipo);
        }

        [HttpPost]
        public ActionResult<ProdutoTipoDTO> Cadastrar([FromBody] ProdutoTipoDTO tipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Objeto inválido!");
            }

            var tipoEntity = _servico.Cadastrar(tipo);
            return Ok(tipoEntity);
        }

        [HttpPut]
        public ActionResult<ProdutoTipoDTO> Atualizar([FromBody] ProdutoTipoDTO tipo)
        {
            if (tipo == null)
            {
                return BadRequest("Objeto Invalido");
            }

            var tipoEntity = _servico.Atualizar(tipo);
            return Ok(tipoEntity);
        }

        [HttpDelete]
        public ActionResult<bool> Remover([FromQuery] int? id)
        {
            if (id == null)
            {
                return BadRequest("ID Nao pode ser nulo");
            }

            var response = _servico.Remover((int)id);
            return Ok(response);
        }

    }
}
