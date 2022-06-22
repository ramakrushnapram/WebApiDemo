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

        private IBookInterface _bookinterfce;
        public BookController(IBookInterface bookInterface)
        {
            _bookinterfce = bookInterface;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return _bookinterfce.GetAllBooks();
        }
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book= _bookinterfce.GetBook(id);

            if(book==null)
            {
                return NotFound();
            }
            return book;
        }
    }
}
