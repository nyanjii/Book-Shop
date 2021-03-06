﻿using BookShop.DAL.Core;

namespace BookShop.DAL.Entities
{
    public class Book: Entity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Cost { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
