using System.Data.Entity;

namespace BookShop.DAL
{
    public class BookContext : DbContext
    {
        static BookContext()
        {
            Database.SetInitializer<BookContext>(new BookContextInitializer());
        }

        public BookContext() : base("BooksDBConnection") { }

        public DbSet<Entities.Book> Books { get; set; }
    }
}
