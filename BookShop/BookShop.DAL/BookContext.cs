using BookShop.DAL.Entities;
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

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasMany(g => g.Books).WithOptional(b => b.Genre);
        }
    }
}
