namespace AlesCotas.Domain.Exceptions
{
    public sealed class AtributoObrigatorioException : Exception
    {
        public AtributoObrigatorioException(string nome) : base($"{nome} é obrigatório!")
        {

        }
    }
}
