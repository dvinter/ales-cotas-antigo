namespace AlesCotas.Domain.Conta
{
    public interface IAutenticar
    {
        public Task<bool> Autenticar(string email, string senha);
        public Task<bool> RegistrarUsuario(string email, int matricula, string senha);
        public Task Logout();
    }
}
