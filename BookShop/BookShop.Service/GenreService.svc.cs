using System.Collections.Generic;
using System.Linq;
using BookShop.Contracts;
using BookShop.DAL.Entities;
using BookShop.DAL.Core;
using BookShop.DAL;
using System;

namespace BookShop.Service
{
    public class GenreService : IGenreService
    {
        IUnitOfWork uow = new UnitOfWork();

        public void Add(GenreData item)
        {
            var genre = new Genre()
            {
                GenreName = item.GenreName,
                DateOfCreating = DateTime.Now
            };
            uow.Genres.Add(genre);
            uow.SaveChanges();
        }

        public void Delete(GenreData item)
        {
            var genre = new Genre()
            {
                Id = item.Id
            };
            uow.Genres.Delete(genre);
            uow.SaveChanges();
        }

        public IEnumerable<GenreData> GetAll()
        {
            var genres = uow.Genres.GetAll().ToList();
            List<GenreData> nGenres = new List<GenreData>();

            genres.ForEach(genre =>
            {
                var g = new GenreData()
                {
                    Id = genre.Id,
                    GenreName = genre.GenreName
                };
                nGenres.Add(g);
            });

            return nGenres;
        }

        public GenreData GetItem(int id)
        {
            var genre = uow.Genres.Get(id);
            return new GenreData()
            {
                Id = genre.Id,
                GenreName = genre.GenreName
            };
        }

        public List<BookData> GetBooksOfGenre(int id)
        {
            List<BookData> gBooks = new List<BookData>();
            var books = uow.Genres.Get(id).Books.ToList();
            books.ForEach(book => 
            {
                BookData b = new BookData()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Title = book.Title,
                    Cost = book.Cost
                };
                gBooks.Add(b);
            });


            return gBooks;
        }
    }
}
