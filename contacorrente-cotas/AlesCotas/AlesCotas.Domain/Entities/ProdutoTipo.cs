using AlesCotas.Domain.Entities.Base;
using AlesCotas.Domain.Exceptions;

namespace AlesCotas.Domain.Entities
{
    public sealed class ProdutoTipo : Entity
    {
        public int IDProdutoTipo { get; private set; }
        public string Nome { get; private set; }
        public string Unidade { get; private set; }
        public bool Ativo { get; private set; }
        public ICollection<Produto>? Produtos { get; set; }
        public ProdutoTipo(string nome, string unidade)
        {
            SetNome(nome);
            SetUnidade(unidade);
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

        private void SetUnidade(string unidade)
        {
            if (string.IsNullOrEmpty(unidade))
            {
                throw new AtributoObrigatorioException(unidade);
            }

            if (unidade.Length < 1 || unidade.Length > 5)
            {
                throw new StringTamanhoInvalidoException("Unidade", 1, 5);
            }
            Unidade = unidade;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}
