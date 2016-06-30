using BookShop.DAL.RepositoriesInterfaces;
using BookShop.DAL.Entities;
using BookShop.DAL.Core;

namespace BookShop.DAL.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(BookContext context) : base(context) { }
    }
}
