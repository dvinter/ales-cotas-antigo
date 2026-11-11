using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Servicos.Base;

namespace AlesCotas.Domain.Interfaces.Servicos
{
    public interface IGrampeamentoTipoServico : IServico
    {
        public List<GrampeamentoTipo> Listar();
        public GrampeamentoTipo? Recuperar(int id);
        public void Cadastrar(GrampeamentoTipo produto);
        public void Atualizar(GrampeamentoTipo produto);
        public bool Deletar(int id);
    }
}
