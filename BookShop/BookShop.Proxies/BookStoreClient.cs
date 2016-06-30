using System.Collections.Generic;
using BookShop.Contracts;
using System.ServiceModel;

namespace BookShop.Proxies
{
    public class BookStoreClient : ClientBase<IBookService>, IBookService
    {
        public void Add(BookData item)
        {
            Channel.Add(item);
        }

        public void Delete(BookData item)
        {
            Channel.Delete(item);
        }

        public IEnumerable<BookData> GetAll()
        {
            return Channel.GetAll();
        }

        public BookData GetItem(int id)
        {
            return Channel.GetItem(id);
        }

        public void Update(BookData item)
        {
            Channel.Update(item);
        }
    }
}
