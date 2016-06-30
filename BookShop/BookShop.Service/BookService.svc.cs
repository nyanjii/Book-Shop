using System.Collections.Generic;
using System.Linq;
using BookShop.Contracts;
using BookShop.DAL.Core;
using BookShop.DAL.Entities;
using BookShop.DAL;
using System;

namespace BookShop.Service
{
    public class BookService : IBookService
    {
        IUnitOfWork uow = new UnitOfWork();

        public void Add(BookData item)
        {
            var book = new Book()
            {
                Title = item.Title,
                Author = item.Author,
                Cost = item.Cost,
                GenreId = item.GenreId,
                Genre = uow.Genres.Get(item.GenreId),
                LastUpdate = DateTime.Now
            };
            uow.Books.Add(book);
            uow.SaveChanges();
        }

        public void Delete(BookData item)
        {
            var book = new Book()
            {
                Id = item.Id
            };
            uow.Books.Delete(book);
            uow.SaveChanges();
        }

        public IEnumerable<BookData> GetAll()
        {
            var books = uow.Books.GetAll().ToList();            
            List<BookData> nBooks = new List<BookData>();

            books.ForEach(book => 
            {
                var genreName = uow.Genres.Get(book.GenreId).GenreName;
                BookData b = new BookData()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Title = book.Title,
                    Cost = book.Cost,
                    GenreId = book.GenreId,
                    GenreName = genreName
                };
                nBooks.Add(b);
            });

            return nBooks;
        }

        public BookData GetItem(int id)
        {
            var book = uow.Books.Get(id);
            var genreName = uow.Genres.Get(book.GenreId).GenreName;
            return new BookData()
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Cost = book.Cost,
                GenreId = book.GenreId,
                GenreName = genreName
            };
        }

        public void Update(BookData item)
        {
            var book = new Book()
            {
                Id = item.Id,
                Title = item.Title,
                Author = item.Author,
                Cost = item.Cost,
                GenreId = item.GenreId,
                Genre = uow.Genres.Get(item.GenreId),
                LastUpdate = DateTime.Now
            };
            uow.Books.Update(book);
            uow.SaveChanges();
        }

    }
}
