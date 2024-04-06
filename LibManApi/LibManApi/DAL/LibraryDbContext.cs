using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
namespace LibManApi.DAL
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=LibMan.db");
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<EBook>().ToTable("EBooks");
            modelBuilder.Entity<PrintedBook>().ToTable("PrintedBooks");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<EBook> EBooks { get; set; }
        public DbSet<PrintedBook> PrintedBooks { get; set; }
    }
    
}

