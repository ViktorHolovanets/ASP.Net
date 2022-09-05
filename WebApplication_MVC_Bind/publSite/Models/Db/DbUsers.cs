using Microsoft.EntityFrameworkCore;

namespace publSite.Models.Db
{
    public class DbUsers:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbUsers(DbContextOptions<DbUsers> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
