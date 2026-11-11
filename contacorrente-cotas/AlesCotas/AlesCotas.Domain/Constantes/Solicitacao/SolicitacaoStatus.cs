namespace AlesCotas.Domain.Constantes.Solicitacao
{
    public static class SolicitacaoStatus
    {
        public static string Pendente { get { return "Em Andamento"; } }
        public static string Aprovado { get { return "Aprovada"; } }
        public static string Cancelada { get { return "Cancelada"; } }
        public static string AprovadoParcial { get { return "Aprovada Parcialmente"; } }
    }
}
