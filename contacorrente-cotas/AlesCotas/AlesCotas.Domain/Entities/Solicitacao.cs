using AlesCotas.Domain.Constantes.Solicitacao;
using AlesCotas.Domain.Entities.Base;
using AlesCotas.Domain.Exceptions;

namespace AlesCotas.Domain.Entities
{
    public sealed class Solicitacao : Entity
    {
        public int IDSolicitacao { get; set; }
        public string Status { get; set; }
        public string Tipo { get; set; }
        public decimal ValorSolicitado { get; set; }
        public decimal ValorAprovado { get; set; }
        public DateTime? DataValidacao { get; set; }
        public ICollection<SolicitacaoItem> Items { get; set; }
        public string Justificativa { get; set; }

        public Solicitacao()
        {

        }
        public Solicitacao(string status, DateTime? dataValidacao, string tipo)
        {
            SetStatus(status);
            SetDataValidacao(dataValidacao);
            SetTipo(tipo);
        }
        public Solicitacao(string status, DateTime? dataValidacao, string tipo, List<SolicitacaoItem> items)
        {
            SetStatus(status);
            SetDataValidacao(dataValidacao);
            SetTipo(tipo);
            SetItems(items);
        }
        private void SetStatus(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                throw new AtributoObrigatorioException(status);
            }

            if (status.Length < 3 || status.Length > 25)
            {
                throw new StringTamanhoInvalidoException("Status", 3, 100);
            }

            Status = status;
        }

        private void SetDataValidacao(DateTime? dataValidacao)
        {
            DataValidacao = dataValidacao;
        }

        private void SetTipo(string tipo)
        {
            if (string.IsNullOrEmpty(tipo))
            {
                throw new AtributoObrigatorioException(tipo);
            }

            if (tipo.Length < 3 || tipo.Length > 25)
            {
                throw new StringTamanhoInvalidoException("Tipo", 3, 100);
            }
            Tipo = tipo;
        }

        private void SetItems(List<SolicitacaoItem> items)
        {
            Items = items;
        }

        public void Aprovar()
        {
            Status = SolicitacaoStatus.Aprovado;
            DataValidacao = DateTime.Now;
        }

        public void AprovacaoParcial()
        {
            Status = SolicitacaoStatus.AprovadoParcial;
            DataValidacao = DateTime.Now;
        }

        public void Negar()
        {
            Status = SolicitacaoStatus.Cancelada;
            DataValidacao = DateTime.Now;
        }
    }
}
