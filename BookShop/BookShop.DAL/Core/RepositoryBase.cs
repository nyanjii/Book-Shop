using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BookShop.DAL.Core
{
    public class RepositoryBase<T> where T : Entity
    {

        protected BookContext context;
        protected DbSet<T> entities; 

        protected RepositoryBase(BookContext context)
        {
            this.context = context;
            entities = this.context.Set<T>();                
        }

        public void Add(T item)
        {
            entities.Add(item);
        }

        public void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(T item)
        {
            context.Entry(item).State = EntityState.Deleted;
        }

        public T Get(int id)
        {
            return entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
