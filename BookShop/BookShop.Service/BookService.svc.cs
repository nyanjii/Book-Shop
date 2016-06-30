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
                DateOfCreating = DateTime.Now
            };
            uow.Repository.Add(book);
            uow.SaveChanges();
        }

        public void Delete(BookData item)
        {
            var book = new Book()
            {
                Id = item.Id
            };
            uow.Repository.Delete(book);
            uow.SaveChanges();
        }

        public IEnumerable<BookData> GetAll()
        {
            var books = uow.Repository.GetAll().ToList();
            List<BookData> nBooks = new List<BookData>();

            books.ForEach(book => 
            {
                BookData b = new BookData()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Title = book.Title,
                    Cost = book.Cost
                };
                nBooks.Add(b);
            });

            return nBooks;
        }

        public BookData GetItem(int id)
        {
            var book = uow.Repository.Get(id);

            return new BookData()
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Cost = book.Cost
            };
        }

        public void Update(BookData item)
        {
            var book = new Book()
            {
                Id = item.Id,
                Title = item.Title,
                Author = item.Author,
                Cost = item.Cost
            };
            uow.Repository.Update(book);
            uow.SaveChanges();
        }
    }
}
