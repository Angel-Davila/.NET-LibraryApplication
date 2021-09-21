using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
    {
        public int BookID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        public int PageNumber { get; set; }
    }
}