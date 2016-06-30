using BookShop.DAL.Core;
using BookShop.DAL.RepositoriesInterfaces;
using BookShop.DAL.Entities;
using System;

namespace BookShop.DAL.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(BookContext context) : base(context) { }
    }
}
