using Microsoft.EntityFrameworkCore;

namespace Filters.Models.DB
{
    public class Db:DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }
        public Db(DbContextOptions<Db> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
