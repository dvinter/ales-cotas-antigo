using AlesCotas.Application.Classes;
using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Filtros;

namespace AlesCotas.Application.Interfaces.Servicos
{
    public interface IProdutoTipoAppServico
    {
        public ProdutoTipoDTO Cadastrar(ProdutoTipoDTO tipo);
        public ProdutoTipoDTO Atualizar(ProdutoTipoDTO tipo);
        public bool Remover(int? id);
        public ListaPaginada<ProdutoTipoDTO> Listar(ProdutoTipoFiltroDTO filtro);
        public ProdutoTipoDTO? Recuperar(int id);
        public int? Recuperar(string nome);
    }
}
