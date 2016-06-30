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
            Genre g1 = new Genre() { GenreName = "aaa", LastUpdate = DateTime.Now };
            Genre g2 = new Genre() { GenreName = "bbb", LastUpdate = DateTime.Now };

            IUnitOfWork uow = new UnitOfWork();

            uow.Genres.Add(g1);
            uow.Genres.Add(g2);

            Book b1 = new Book() { Title = "Harry Potter", Author = "J. K. Rowling", Cost = 17, LastUpdate = DateTime.Now, Genre = g1, GenreId = g1.Id };
            Book b2 = new Book() { Title = "Great Expectations", Author = "Charles Dickens", Cost = 172, LastUpdate = DateTime.Now, Genre = g1, GenreId = g1.Id };
            Book b3 = new Book() { Title = "Cloud Atlas", Author = "David Mitchel", Cost = 149, LastUpdate = DateTime.Now, Genre = g2, GenreId = g2.Id };

            uow.Books.Add(b1);
            uow.Books.Add(b2);
            uow.Books.Add(b3);

            uow.SaveChanges();
        }
    }
}
