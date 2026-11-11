using AlesCotas.Domain.Entities.Base;
using AlesCotas.Domain.Exceptions;

namespace AlesCotas.Domain.Entities
{
    public class Produto : Entity
    {
        public int IDProduto { get; private set; }
        public string Nome { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public bool Ativo { get; private set; }
        public int IDProdutoTipo { get; private set; }
        public ProdutoTipo Tipo { get; private set; }
        public ICollection<SolicitacaoItem> SolicitacaoItems { get; set; }

        public Produto(string nome, decimal valorUnitario)
        {
            SetNome(nome);
            SetValorUnitario(valorUnitario);
            Ativo = true;
        }

        private void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new AtributoObrigatorioException(nome);
            }

            if (nome.Length < 3 || nome.Length > 100)
            {
                throw new StringTamanhoInvalidoException("Nome", 3, 100);
            }

            Nome = nome;
        }

        private void SetValorUnitario(decimal valorUnitario)
        {
            ValorUnitario = valorUnitario;
        }

        public void Ativar()
        {
            Ativo = true;
        }
        public void Desativar()
        {
            Ativo = false;
        }
    }
}
