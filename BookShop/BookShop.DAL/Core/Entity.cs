using System;

namespace BookShop.DAL.Core
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime DateOfCreating { get; set; }
    }
}
