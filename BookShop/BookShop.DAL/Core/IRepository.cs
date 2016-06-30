using System.Collections.Generic;

namespace BookShop.DAL.Core
{
    public interface IRepository<T>
    {
        void Add(T item);

        void Update(T item);

        void Delete(T item);

        T Get (int id);

        IEnumerable<T> GetAll();

    }
}
