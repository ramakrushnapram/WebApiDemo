using BookStoreData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreData.Interfaces
{
   public interface IBookInterface
    {
        List<Book> GetAllBooks();

        Book GetBook(int id);


    }
}
