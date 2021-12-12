using BibliotekaWPF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BibliotekaWPF.ViewModel
{
    class BookModel
    {
        IList<Book> books = new List<Book>();

        private User currentUser { get; set; }
       

        public List<string> GetAllBooks()
        {
            List<string> books = new List<string>();
            using ( var context = new Context.AppContext())
            {
                var query = (from b in context.Books select b.Title).ToList();
                foreach(string book in query)
                {
                    books.Add(book);
                }
            }
                return books;
        }

        public List<string> GetFillteredBooks(string name)
        {
            List<string> books = new List<string>();
            using (var context = new Context.AppContext())
            {
                var query = (from b in context.Books where b.Title.Contains(name) select b.Title).ToList();
                foreach (string book in query)
                {
                    books.Add(book);
                }
            }
            return books;

        }

        public void BuyBook(string bookName)
        {
            using (var context = new Context.AppContext())
            {
                var book = (from b in context.Books where b.Title == bookName select b).First();
                if (book.Available > 0)
                {
                    book.Available--;
                    context.Attach(book).State = EntityState.Modified;
                    var newPurchase = new Purchase() { UserId = Views.Navbar.getUser().Id, BookId = book.Id, Date = DateTime.Now };
                    context.Purchases.Add(newPurchase);
                }
            }
        }

        public void BorrowBook(string bookName)
        {
            using (var context = new Context.AppContext())
            {
                var book = (from b in context.Books where b.Title == bookName select b).First();
                if (book.Available > 0)
                {
                    book.Available--;
                    context.Attach(book).State = EntityState.Modified;
                    var newLoan = new Loan() { IdBook = book.Id, IdUser = Views.Navbar.getUser().Id, DateOfLoan = DateTime.Now, UserReturn = DateTime.Now, ReturnDate = DateTime.Now.AddDays(14) };
                    context.Loans.Add(newLoan);
                    context.SaveChanges();
                }
               
            }
        }
    }
}
