using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Interfaces.Repositories;
using AlesCotas.Domain.Interfaces.UnitOfWork;
using AlesCotas.Infra.Data.Context;
using AlesCotas.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace AlesCotas.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        // DbContext
        private readonly ApplicationDbContext _context;

        // Repositorios
        private ProdutoTipoRepository _produtoTipoRepo;
        private ProdutoRepository _produtoRepo;
        private SolicitacaoRepository _solicitacaoRepo;
        private SolicitacaoItemRepository _solicitacaoItemRepo;
        private SolicitacaoItemArquivoRepository _solicitacaoItemArquivoRepo;
        private UsuarioRepository _usuarioRepository;
        private GabineteRepository _gabineteRepository;
        private UserManager<Usuario> _userManager;
        private GrampeamentoTipoRepository _grampeamentoTipoRepo;
        private SolicitacaoItemCRRepository _solicitacaItemCrRepo;


        // Transaction
        private IDbContextTransaction? _transaction;

        public UnitOfWork(ApplicationDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepo ??= new ProdutoRepository(_context);
            }
        }

        public IProdutoTipoRepository ProdutoTipoRepository
        {
            get
            {
                return _produtoTipoRepo ??= new ProdutoTipoRepository(_context);
            }
        }

        public ISolicitacaoRepository SolicitacaoRepository
        {
            get
            {
                return _solicitacaoRepo ??= new SolicitacaoRepository(_context);
            }
        }

        public ISolicitacaoItemRepository SolicitacaoItemRepository
        {
            get
            {
                return _solicitacaoItemRepo ??= new SolicitacaoItemRepository(_context);
            }
        }

        public ISolicitacaoItemArquivoRepository SolicitacaoItemArquivoRepository
        {
            get
            {
                return _solicitacaoItemArquivoRepo ??= new SolicitacaoItemArquivoRepository(_context);
            }
        }

        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                return _usuarioRepository ??= new UsuarioRepository(_context, _userManager);
            }
        }

        public IGabineteRepository GabineteRepository
        {
            get
            {
                return _gabineteRepository ??= new GabineteRepository(_context);
            }
        }

        public IGrampeamentoTipoRepository GrampeamentoTipoRepository
        {
            get
            {
                return _grampeamentoTipoRepo ??= new GrampeamentoTipoRepository(_context);
            }
        }

        public ISolicitacaoItemCRRepository SolicitacaoItemCRRepository
        {
            get
            {
                return _solicitacaItemCrRepo ??= new SolicitacaoItemCRRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
            //_context.ChangeTracker.Clear();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void IniciarTransacao()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransacao()
        {
            if (_transaction == null)
            {
                throw new Exception("Não há nenhuma transação ocorrendo");
            }

            _transaction.Commit();
            _transaction = null;
        }

        public void RollbackTransacao()
        {
            if (_transaction == null)
            {
                throw new Exception("Não há uma transação ocorrendo");
            }

            _transaction.Rollback();
            _transaction = null;
        }
    }
}
