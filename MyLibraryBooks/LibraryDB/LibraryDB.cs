using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class LibraryDB : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        

        public LibraryDB(DbContextOptions<LibraryDB> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}