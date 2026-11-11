using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros;
using AlesCotas.Domain.Interfaces.Servicos.Base;

namespace AlesCotas.Domain.Interfaces.Servicos
{
    public interface IProdutoTipoServico : IServico
    {
        public void Cadastrar(ProdutoTipo entity);
        public void Atualizar(ProdutoTipo entity);
        public void Deletar(int id);
        public IQueryable<ProdutoTipo> Listar(ProdutoTipoFiltro filtro);
        public ProdutoTipo? Recuperar(int id);
    }
}
