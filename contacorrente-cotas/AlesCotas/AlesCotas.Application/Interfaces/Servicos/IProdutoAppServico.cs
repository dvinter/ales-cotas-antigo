using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.Interfaces.Servicos.Base;

namespace AlesCotas.Application.Interfaces.Servicos
{
    public interface IProdutoAppServico : IAppServico
    {
        public List<ProdutoDTO> Listar(ProdutoFiltroDTO parametros);
        public List<ProdutoDTO> Listar(string tipo);
        public ProdutoDTO? Recuperar(int id);
        public ProdutoDTO Cadastrar(ProdutoCadastroDTO produto);
        public ProdutoDTO Atualizar(ProdutoDTO produto);
        public bool Deletar(int? id);
    }
}
