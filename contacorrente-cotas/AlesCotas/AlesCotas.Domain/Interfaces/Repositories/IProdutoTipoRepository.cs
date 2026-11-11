using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros;
using AlesCotas.Domain.Interfaces.Repositories.Base;

namespace AlesCotas.Domain.Interfaces.Repositories
{
    public interface IProdutoTipoRepository : IRepository<ProdutoTipo>
    {
        IQueryable<ProdutoTipo> Listar(ProdutoTipoFiltro filtro);
        ProdutoTipo? Recuperar(int id);
        void Cadastrar(ProdutoTipo entity);
        void Atualizar(ProdutoTipo entity);
        void Deletar(ProdutoTipo entity);
    }
}
