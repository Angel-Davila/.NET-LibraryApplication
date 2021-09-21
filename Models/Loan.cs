using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Loan
    {
        public int LoanID { get; set; }
                
        public int UserID { get; set; }

        public int BookID { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public virtual User User { get; set; }

        public virtual Book Book { get; set; }
    }
}