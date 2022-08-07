using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class LibraryDB : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }

        public LibraryDB(DbContextOptions<LibraryDB> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}