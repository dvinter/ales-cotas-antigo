namespace AlesCotas.Domain.Exceptions
{
    public sealed class StringTamanhoInvalidoException : Exception
    {
        public StringTamanhoInvalidoException(string str, short minLength, short maxLength) :
            base($"{str} deve possuir entre {minLength} e {maxLength} caracteres")
        {

        }
    }
}
