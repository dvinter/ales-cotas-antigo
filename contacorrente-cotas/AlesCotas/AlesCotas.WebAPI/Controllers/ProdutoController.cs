using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppServico _servico;
        public ProdutoController(IProdutoAppServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public ActionResult<List<ProdutoTipoDTO>> Listar([FromQuery] ProdutoFiltroDTO filtro)
        {
            try
            {
                return Ok(_servico.Listar(filtro));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoDTO> Recuperar(int id)
        {
            try
            {
                return Ok(_servico.Recuperar(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult<ProdutoDTO> Cadastrar(ProdutoCadastroDTO produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo inválido!");
            }

            try
            {
                return Ok(_servico.Cadastrar(produto));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public ActionResult<ProdutoDTO> Atualizar([FromBody] ProdutoDTO produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo inválido!");
            }

            try
            {
                return Ok(_servico.Atualizar(produto));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public ActionResult<bool> Remover([FromQuery] int id)
        {

            try
            {
                return Ok(_servico.Deletar((int)id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
