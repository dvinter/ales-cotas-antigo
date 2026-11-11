using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros.Enum;
using AlesCotas.Domain.Filtros;
using AlesCotas.Infra.Data.Context;
using AlesCotas.Infra.Data.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlesCotas.Domain.Interfaces.Repositories;

namespace AlesCotas.Infra.Data.Repositories
{
  

    public class GabineteRepository : Repository<Gabinete>, IGabineteRepository
    {
        public GabineteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<Gabinete> Listar(GabineteFiltro filtro)
        {

            var query = _entityContext.AsQueryable();

            if (filtro.Status != Domain.Filtros.Enum.EFiltroStatus.Todos)
            {
                query = query.Where(e => e.IsAtivo == (filtro.Status == EFiltroStatus.Ativo));
            }

            if (!string.IsNullOrEmpty(filtro.FiltroTexto))
            {
                query = query.Where(e => e.Nome.Contains(filtro.FiltroTexto));
            }

            return query;
        }

        public async Task<Gabinete?> Recuperar(int id)
        {
            return await _entityContext.FirstOrDefaultAsync(e => e.IDGabinete.Equals(id));
        }

        public async Task<Gabinete> Cadastrar(Gabinete entity)
        {
            var entry = await _entityContext.AddAsync(entity);
            return entry.Entity;

        }

        public Gabinete Atualizar(Gabinete entity)
        {
            var entry = _entityContext.Update(entity);
            return entry.Entity;
        }

        public void Deletar(Gabinete entity)
        {
            _entityContext.Remove(entity);
        }
    }
}
