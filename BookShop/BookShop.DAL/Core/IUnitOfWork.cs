using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.DAL.Entities;

namespace BookShop.DAL.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> Repository {get; }
        void SaveChanges();        
    }
}
