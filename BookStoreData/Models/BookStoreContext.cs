using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreData.Models
{
   public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> dbContextoptions):base(dbContextoptions)
         {
         }

        public DbSet <Book> Books { get; set; }
    }
}

