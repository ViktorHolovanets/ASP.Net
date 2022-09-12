using Microsoft.EntityFrameworkCore;

namespace SportSite.Models.Db
{
    public class Db:DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<TimeOfWork> TimeOfWorks { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<TypeSport> TypeSports { get; set; }
        public Db(DbContextOptions<Db> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
