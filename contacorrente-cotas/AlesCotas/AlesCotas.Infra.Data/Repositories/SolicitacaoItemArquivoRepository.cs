using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Repositories;
using AlesCotas.Infra.Data.Context;
using AlesCotas.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AlesCotas.Infra.Data.Repositories
{
    public class SolicitacaoItemArquivoRepository : Repository<SolicitacaoItemArquivo>, ISolicitacaoItemArquivoRepository
    {
        public SolicitacaoItemArquivoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<SolicitacaoItemArquivo> Listar()
        {
            return _entityContext;
        }

        public SolicitacaoItemArquivo? Recuperar(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(SolicitacaoItemArquivo entity)
        {
            _entityContext.Add(entity);
        }

        public void Atualizar(SolicitacaoItemArquivo entity)
        {
            _entityContext.Update(entity);
        }

        public void Deletar(SolicitacaoItemArquivo entity)
        {
            _entityContext.Remove(entity);
        }

        public IQueryable<SolicitacaoItemArquivo> Listar(List<int> ids)
        {
            return _entityContext.Where(e => ids.Contains(e.IDSolicitacaoItem)).AsNoTracking();
        }
    }
}
