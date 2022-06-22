using BookStoreData.Models;
using System.Collections.Generic;

namespace BookStoreData.Interfaces
{
    public interface IBookInterface
    {
        List<Book> GetAllBooks();

        Book GetBook(int id);

        bool AddNewBook(Book book);

        bool RemoveBook(int id);

        List<Book> UpdateBook(int id, Book book);

    }
}
