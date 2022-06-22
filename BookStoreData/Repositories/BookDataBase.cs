using BookStoreData.Interfaces;
using BookStoreData.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreData.Repositories
{
    public class BookDataBase : IBookInterface
    {
        private BookStoreContext db;
        public BookDataBase(BookStoreContext _db)
        {
            this.db = _db;
        }

        public bool AddNewBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return true;
        }

        public List<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id);
        }

        public bool RemoveBook(int id)
        {
            var book = GetBook(id);
            if (book == null)
            {
                return false;
            }
            db.Books.Remove(book);
            db.SaveChanges();
            return true;
        }

        public List<Book> UpdateBook(int id, Book book)
        {
            if (this.RemoveBook(id))
            {
                this.AddNewBook(book);
                db.SaveChanges();
                return db.Books.ToList();
            }
            return db.Books.ToList();
        }
    }
}
