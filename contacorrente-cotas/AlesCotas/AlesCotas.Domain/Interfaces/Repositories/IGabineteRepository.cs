using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlesCotas.Domain.Interfaces.Repositories
{
    public interface IGabineteRepository
    {
        Gabinete Atualizar(Gabinete entity);
        Task<Gabinete> Cadastrar(Gabinete entity);
        void Deletar(Gabinete entity);
        IQueryable<Gabinete> Listar(GabineteFiltro filtro);
        Task<Gabinete?> Recuperar(int id);
    }
}
