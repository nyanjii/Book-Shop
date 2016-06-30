using BookShop.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Proxies
{
    public class BookGenreClient : ClientBase<IGenreService>, IGenreService
    {
        public void Add(GenreData item)
        {
            Channel.Add(item);
        }

        public void Delete(GenreData item)
        {
            Channel.Delete(item);
        }

        public IEnumerable<GenreData> GetAll()
        {
            return Channel.GetAll();
        }

        public List<BookData> GetBooksOfGenre(int id)
        {
            return Channel.GetBooksOfGenre(id);
        }

        public GenreData GetItem(int id)
        {
            return Channel.GetItem(id);
        }
    }
}
