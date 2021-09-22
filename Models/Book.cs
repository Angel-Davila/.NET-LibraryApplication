using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        public int BookID { get; set; }

        [Display(Name = "Book title")]
        [StringLength(150, ErrorMessage = "Book title cannot be longer than 150 characters.")]
        public string Title { get; set; }

        [Display(Name = "Author name")]
        [StringLength(80, ErrorMessage = "Author name cannot be longer than 80 characters.")]
        public string Author { get; set; }

        [Display(Name = "Publishment date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Display(Name = "Selling price")]
        public decimal Price { get; set; }

        [Display(Name = "Total pages")]
        public int PageNumber { get; set; }

        [Display(Name = "Cover Image URL")]
        public string ImgCover { get; set; }
    }
}