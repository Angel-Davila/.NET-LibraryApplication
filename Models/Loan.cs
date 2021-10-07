using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Loan
    {
        public int LoanID { get; set; }
                
        public int UserID { get; set; }

        public int BookID { get; set; }

        public string LoanDescription { get; set; }

        [DataType(DataType.DateTime)]
        private DateTime? date;
        
        [Display(Name = "Loan date")]
        public DateTime? LoanDate 
        {   
            get { return date ?? DateTime.Now; } 
            set { date = value; } 
        }

        [Display(Name = "Return date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReturnDate { get; set; }

        public virtual User User { get; set; }

        public virtual Book Book { get; set; }

        public Loan()
        {
            LoanDate = DateTime.Now;
        }
        
    }
        
}