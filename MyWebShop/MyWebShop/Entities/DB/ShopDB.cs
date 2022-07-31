using Microsoft.EntityFrameworkCore;

namespace MyWebShop.Entities.DB
{
    public class ShopDB:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; } 

        public ShopDB(DbContextOptions<ShopDB> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
