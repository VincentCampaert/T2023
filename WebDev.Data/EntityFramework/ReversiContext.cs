using Microsoft.EntityFrameworkCore;
using WebDev.Data.Models;

namespace WebDev.Data.EntityFramework
{
    public class ReversiContext : DbContext
    {
        public ReversiContext(DbContextOptions<ReversiContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Game> Games { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Game>().ToTable("Game");
        }
    }
}
