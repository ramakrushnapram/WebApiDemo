using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreData.Models
{
   public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublicationYear { get; set; }
        public bool IsAvilable { get; set; }
        public string CallNumber { get; set; }

    }
}
