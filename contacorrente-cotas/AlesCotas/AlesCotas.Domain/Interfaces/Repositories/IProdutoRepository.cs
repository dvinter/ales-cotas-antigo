using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros;
using AlesCotas.Domain.Interfaces.Repositories.Base;

namespace AlesCotas.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IQueryable<Produto> Listar();
        IQueryable<Produto> Listar(ProdutoFiltro filtro);
        Produto? Recuperar(int id);
        void Cadastrar(Produto entity);
        void Atualizar(Produto entity);
        void Deletar(Produto entity);
        public IQueryable<Produto>? ListarPorIds(int[] ids);
    }
}
