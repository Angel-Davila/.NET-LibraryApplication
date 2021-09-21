using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using System.Data.Entity;

namespace Library.DAL
{
    public class LibraryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            var users = new List<User>
            {
                new User{FirstName = "Jerry",
                        LastName = "Powell",
                        Email = "scelerisque.lorem@turpisvitae.co.uk",
                        Address = "151-6190 Mattis. Ave",
                        PhoneNumber = "(724) 715-0238",
                        PostalCode = "233971"},

                new User{FirstName = "Marah",
                        LastName = "Maynard",
                        Email = "magna.suspendisse.tristique@inlobortistellus.edu",
                        Address = "604-2165 Nulla Rd.",
                        PhoneNumber = "(638) 366-2332",
                        PostalCode = "50925"},

                new User{FirstName = "Phelan Poole",
                        LastName = "Hope Randall",
                        Email = "nisl@vulputatenisi.edu",
                        Address = "P.O. Box 652, 1000 At Rd.",
                        PhoneNumber = "1-245-835-6445",
                        PostalCode = "5818"},

                new User{FirstName = "Stacey",
                        LastName = "Weiss",
                        Email = "augue@egestas.edu",
                        Address = "2217 Ac Street",
                        PhoneNumber = "(874) 823-2566",
                        PostalCode = "22351-32972"},

                new User{FirstName = "Mercedes",
                        LastName = "Daugherty",
                        Email = "ultrices@erosproin.org",
                        Address = "328-3490 Ornare. Rd.",
                        PhoneNumber = "(369) 544-6189",
                        PostalCode = "70925"}

            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book{Title="1984", Author="George Orwell", Date=DateTime.Parse("1949-06-08"), Genre="Dystopian", Price=9.99M, PageNumber=328},
                new Book{Title="To kill a mockingbird", Author="Harper Lee", Date=DateTime.Parse("1960-07-11"), Genre="Novel", Price=5.99M, PageNumber=281},
                new Book{Title="Lord of the Flies", Author="William Golding", Date=DateTime.Parse("1954-09-17"), Genre="Novel", Price=3.50M, PageNumber=224},
                new Book{Title="Dune", Author="Frank Herbert", Date=DateTime.Parse("1965-08-08"), Genre="Science Fiction", Price=10.99M, PageNumber=500},
                new Book{Title="Moby Dick", Author="Herman Melville", Date=DateTime.Parse("1851-09-18"), Genre="Novel", Price=3.99M, PageNumber=635},
                new Book{Title="Pride and Prejudice", Author="Jane Austen", Date=DateTime.Parse("1813-06-28"), Genre="Romance Novel", Price=15.99M, PageNumber=408},
            };
            books.ForEach(x => context.Books.Add(x));
            context.SaveChanges();

            var loans = new List<Loan>
            {
                new Loan{BookID=2, UserID=5, LoanDate=DateTime.Parse("2021-08-22"), ReturnDate=DateTime.Parse("2021-09-20")},
                new Loan{BookID=6, UserID=5, LoanDate=DateTime.Parse("2021-05-12"), ReturnDate=DateTime.Parse("2021-07-15")},
                new Loan{BookID=1, UserID=4, LoanDate=DateTime.Parse("2021-08-10"), ReturnDate=DateTime.Parse("2021-09-02")},
                new Loan{BookID=3, UserID=2, LoanDate=DateTime.Parse("2021-01-01"), ReturnDate=DateTime.Parse("2021-01-20")},
                new Loan{BookID=4, UserID=1, LoanDate=DateTime.Parse("2021-02-25"), ReturnDate=DateTime.Parse("2021-04-10")},
                new Loan{BookID=5, UserID=1, LoanDate=DateTime.Parse("2021-02-01"), ReturnDate=DateTime.Parse("2021-03-01")},
                new Loan{BookID=1, UserID=3, LoanDate=DateTime.Parse("2021-09-25"), ReturnDate=DateTime.Parse("2021-12-31")},
                new Loan{BookID=3, UserID=2, LoanDate=DateTime.Parse("2021-04-06"), ReturnDate=DateTime.Parse("2021-05-08")}
            };
            loans.ForEach(x => context.Loans.Add(x));
            context.SaveChanges();
        }
    }
}