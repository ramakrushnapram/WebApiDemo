using BookStoreData.Interfaces;
using BookStoreData.Models;
using BookStoreData.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {

        private IBookInterface bookinterfce;
        public BookController(IBookInterface _bookInterface)
        {
            bookinterfce = _bookInterface;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return bookinterfce.GetAllBooks();
        }
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = bookinterfce.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }
            return book;
        }
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {

            if (bookinterfce.AddNewBook(book))
            {
                return book;
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Book>>  DeleteBook(int  id)
        {

            if (bookinterfce.RemoveBook(id))
            {
                return bookinterfce.GetAllBooks();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Book>> UpdateBook(int id,Book book)
        {
            var ubook = bookinterfce.UpdateBook(id, book);
            if (ubook!=null)
            {
                return ubook;
            }
            return NotFound();
        }
    }
}
