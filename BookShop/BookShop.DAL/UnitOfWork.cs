﻿using System;
using BookShop.DAL.Core;
using BookShop.DAL.Entities;
using BookShop.DAL.Repositories;

namespace BookShop.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private BookContext _context;
        private IRepository<Book> _bookRepository;
        private IRepository<Genre> _genreRepository;
        private RepositoryFactory _factory;
        private bool _disposed = false;

        public IRepository<Book> Books
        {
            get
            {
                if (_bookRepository == null)
                {
                    _factory.Open(_context);
                    _bookRepository = _factory.GetRepository<BookRepository>();
                    _factory.Close();
                }
                return _bookRepository;
            }
        }
        public IRepository<Genre> Genres
        {
            get
            {
                if (_genreRepository == null)
                {
                    _factory.Open(_context);
                    _genreRepository = _factory.GetRepository<GenreRepository>();
                    _factory.Close();
                }
                return _genreRepository;
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
