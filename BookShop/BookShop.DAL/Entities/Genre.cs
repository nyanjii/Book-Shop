using System.Collections.Generic;
using BookShop.DAL.Core;

namespace BookShop.DAL.Entities
{
    public class Genre: Entity
    {
        public string GenreName { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Genre()
        {
            Books = new List<Book>();
        }
    }
}
