using System.Data.Entity;
using BookShop.DAL.Entities;
using BookShop.DAL.Core;
using System;

namespace BookShop.DAL
{
    public class BookContextInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            Book b1 = new Book() { Title = "Harry Potter", Author = "J. K. Rowling", Cost = 17, DateOfCreating = DateTime.Now };
            Book b2 = new Book() { Title = "Great Expectations", Author = "Charles Dickens", Cost = 172, DateOfCreating = DateTime.Now };
            Book b3 = new Book() { Title = "Cloud Atlas", Author = "David Mitchel", Cost = 149, DateOfCreating = DateTime.Now };

            IUnitOfWork uow = new UnitOfWork();

            uow.Repository.Add(b1);
            uow.Repository.Add(b2);
            uow.Repository.Add(b3);

            uow.SaveChanges();

        }
    }
}
