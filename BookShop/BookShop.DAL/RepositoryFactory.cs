using BookShop.DAL.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;

namespace BookShop.DAL
{
    public class RepositoryFactory : IDisposable
    {
        private IWindsorContainer _container;

        public void Open(BookContext context)
        {
            _container = new WindsorContainer();
            _container.Register(Component.For<BookContext>().Instance(context));
            _container.Register(Classes.FromThisAssembly()
                .BasedOn(typeof(IRepository<>))
                .AllowMultipleMatches());        
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            return _container.Resolve<TRepository>();
        }

        public void Dispose()
        {
            if (_container == null) return;
            _container.Dispose();
            _container = null;
        }

        public void Close()
        {
            Dispose();
        }

    }
}
