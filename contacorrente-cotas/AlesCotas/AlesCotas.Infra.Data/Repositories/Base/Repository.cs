using AlesCotas.Domain.Interfaces.Repositories.Base;
using AlesCotas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AlesCotas.Infra.Data.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _entityContext;
        protected readonly ApplicationDbContext _databaseContext;
        public Repository(ApplicationDbContext context)
        {
            _entityContext = context.Set<T>();
            _databaseContext = context;
        }


    }
}
