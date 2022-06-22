using BookStoreData.Interfaces;
using BookStoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreData.Repositories
{
    public class BookRepository : IBookInterface
    {

        List<Book> books = new List<Book>()
        {
            new Book{Id=1,Title="There Will Be Blood",Author="jyo",PublicationYear="2005",CallNumber="9494774470"},           
            new Book{Id=1,Title="Trainspotting",Author="Antony",PublicationYear="1998",CallNumber="9494774470"},
            new Book{Id=2,Title="Delicatessen ",Author="Tom",PublicationYear="1905",CallNumber="9494774470"},
            new Book{Id=3,Title="Requiem for a Dream",Author="candy",PublicationYear="2018",CallNumber="9494774470"},
            new Book{Id=4,Title="A Clockwork Orange",Author="melody",PublicationYear="2003",CallNumber="9494774470"},
            new Book{Id=5,Title="Naked Lunch",Author="dragon",PublicationYear="2034",CallNumber="9494774470"},
        };
        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }
    }
}
