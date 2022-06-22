using Microsoft.EntityFrameworkCore;

namespace BookStoreData.Models
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> dbContextoptions) : base(dbContextoptions)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}

