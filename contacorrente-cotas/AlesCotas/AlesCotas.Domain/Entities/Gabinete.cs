using AlesCotas.Domain.Entities.Base;

namespace AlesCotas.Domain.Entities
{
    public class Gabinete : Entity
    {
        public int IDGabinete { get; set; }
        public string Nome { get; set; }
        public bool IsAtivo { get; set; } = true;
        public ICollection<Usuario>? Usuarios { get; set; }

        //public Gabinete(string nome)
        //{
        //    Nome = nome;
        //    IsAtivo = true;
        //}
    }
}
