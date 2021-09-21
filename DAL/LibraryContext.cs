using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Library.Models;

namespace Library.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("LibraryContext")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}