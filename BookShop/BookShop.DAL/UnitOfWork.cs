using System;
using BookShop.DAL.Core;
using BookShop.DAL.Entities;
using BookShop.DAL.Repositories;

namespace BookShop.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private BookContext _context;
        private IRepository<Book> _repository;
        private RepositoryFactory _factory;
        private bool _disposed = false;

        public IRepository<Book> Repository
        {
            get
            {
                if (_repository == null)
                {
                    _factory.Open(_context);
                    _repository = _factory.GetRepository<BookRepository>();
                    _factory.Close();
                }
                return _repository;
            }
        }


        public UnitOfWork()
        {
            _context = new BookContext();
            _factory = new RepositoryFactory();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();   
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
