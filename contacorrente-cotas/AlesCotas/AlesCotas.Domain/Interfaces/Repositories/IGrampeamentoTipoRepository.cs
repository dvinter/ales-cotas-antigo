using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Repositories.Base;

namespace AlesCotas.Domain.Interfaces.Repositories
{
    public interface IGrampeamentoTipoRepository : IRepository<GrampeamentoTipo>
    {
        public IQueryable<GrampeamentoTipo> Listar();
        public GrampeamentoTipo? Recuperar(int id);
        void Cadastrar(GrampeamentoTipo tipo);
        void Atualizar(GrampeamentoTipo tipo);
        void Deletar(GrampeamentoTipo tipo);
    }
}
