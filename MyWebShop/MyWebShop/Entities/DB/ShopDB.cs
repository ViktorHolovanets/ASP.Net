using Microsoft.EntityFrameworkCore;

namespace MyWebShop.Entities.DB
{
    public class ShopDB:DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; } 
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; } 

        public ShopDB(DbContextOptions<ShopDB> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
