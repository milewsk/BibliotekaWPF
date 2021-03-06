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
            using (var context = new Context.AppContext())
            {
                var query = (from b in context.Books select b.Title).ToList();
                foreach (string book in query)
                {
                    books.Add(book);
                }
            }
            return books;
        }

        public Dictionary<int, string> GetBooks1()
        {
            Dictionary<int, string> books = new Dictionary<int, string>();
            using (var context = new Context.AppContext())
            {
                var query = (from b in context.Books  select b).ToList();
                foreach (Book book in query)
                {
                    var title = (from b in context.Books where b.Id == book.Id select b.Title).FirstOrDefault();
                    books.Add(book.Id, $"Tytuł: {title}");
                }
            }
            return books;
        }

        public bool AddBook(string title, string authorName, string authorSurname, string yearPubStr, string priceStr, string Category, string quantityStr)
        {
            int price, quantity, yearPub;

            bool tp1 = int.TryParse(priceStr, out price);
            bool tp2 = int.TryParse(quantityStr, out quantity);
            bool tp3 = int.TryParse(yearPubStr, out yearPub);
            if (tp1 && tp2 && tp3) {
                using (var context = new Context.AppContext())
                {
                    var bookExist = (from x in context.Books where 
                                     x.Title == title && x.Category.Name == Category
                                     && x.Price == price && yearPub == x.YearPublished
                                     select x).Any();
                    if (bookExist)
                    {
                        var book = (from x in context.Books where x.Title == title && x.Price == price && yearPub == x.YearPublished select x).First();
                        book.Available += quantity;
                        context.Attach(book).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        Category catNew;
                        Author authorNew;
                        var category = (from x in context.Categories where x.Name == Category select x).Any();
                        var author1 = (from x in context.Authors where x.Name == authorName && x.Surname == authorSurname select x).Any();
                        if (!category)
                        {
                             catNew = new Category() { Name = Category };
                            context.Categories.Add(catNew);
                            context.SaveChanges();
                        }
                        else
                        {
                            catNew = (from c in context.Categories where Category == c.Name select c).First();
                        }
                        if (!author1)
                        {
                            authorNew = new Author() { Name = authorName, Surname = authorSurname };
                            context.Authors.Add(authorNew);
                            context.SaveChanges();
                        }
                        else authorNew = (from a in context.Authors where a.Surname == authorSurname && a.Name == authorName select a).First();

                        Book newBook = new Book() { Title = title, Available = quantity, YearPublished = yearPub, IdCategory = catNew.Id, AuthorId = authorNew.Id, Price = price};
                        context.Books.Add(newBook);
                        context.SaveChanges();
                    
                    }
                }
            }
            else
            {
                //złe wprowadzenie liczby 
                return false;
            }
            return true;
        }
        public bool DeleteBook(string title, string quantity)
        {
            int quan;
            bool tryPar = int.TryParse(quantity, out quan);
            if (tryPar) {
                using (var context = new Context.AppContext())
                {
                    var bookExist = (from x in context.Books where x.Title == title select x).Any();
                    if (bookExist)
                    {
                        var book = (from x in context.Books where x.Title == title select x).First();
                        var bookQuantity = (from x in context.Books where x.Title == title select x.Available).First();
                        if (bookQuantity <= quan)
                        {
                            book.Available = 0;
                            context.Attach(book).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        else {
                            book.Available = bookQuantity - quan;
                            context.Attach(book).State = EntityState.Modified;
                            context.SaveChanges();
                        }

                        //pomyślnie
                    }
                    else
                    {
                        //tytuł nie istnieje
                        return false;
                    }

                }
            }
            else
            {
                //zły numer
                return false;
            }

            return true;
        }
        public List<string> GetLoans() {
            List<string> loans = new List<string>();
            using (var context = new Context.AppContext())
            {
                var query = (from b in context.Loans where b.IdUser == Views.Navbar.getUser().Id select b).ToList();
                foreach (Loan loan in query)
                {
                    var title = (from b in context.Books where b.Id == loan.IdBook select b.Title).FirstOrDefault();
                    loans.Add($"Tytuł: {title}, Data wypożyczenia: {loan.DateOfLoan}, Termin zwrotu: {loan.ReturnDate}");
                }
            }
            return loans;
        }

        public Dictionary<int, string> GetLoans1()
        {
            Dictionary<int, string> loans = new Dictionary<int, string>();
            using (var context = new Context.AppContext())
            {
                var query = (from b in context.Loans where b.IdUser == Views.Navbar.getUser().Id select b).ToList();
                foreach (Loan loan in query)
                {
                    var title = (from b in context.Books where b.Id == loan.IdBook select b.Title).FirstOrDefault();
                    loans.Add(loan.Id, $"Tytuł: {title}, Data wypożyczenia: {loan.DateOfLoan.ToShortDateString()}, Termin zwrotu: {loan.ReturnDate.ToShortDateString()}");
                }
            }
            return loans;
        }

        public bool isReturned(int id)
        {
            using (var context = new Context.AppContext())
            {
                var query = (from b in context.Loans where b.Id == id select b).First();
                if (query.IsReturned == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public string getUserReturnDate(int id)
        {
            if (isReturned(id))
            {
                using (var context = new Context.AppContext())
                {
                    var query = (from b in context.Loans where b.Id == id select b).First();
                    return query.UserReturn.ToShortDateString();
                }
            }
            return "-";
        }

        public string showPenaltyPrice(int id)
        {
            string price = "-";
            using (var context = new Context.AppContext())
            {
                var isPenaltyExist = (from pen in context.Penalties where pen.LoanID == id select pen).Any();
                if (isPenaltyExist)
                {
                    var PenUpdate = (from pen in context.Penalties where pen.LoanID == id select pen).FirstOrDefault();
                    price = PenUpdate.Sum.ToString();
                }
            }
                return price;
        }

        public bool isLoanFinished(int id)
        {
            using (var context = new Context.AppContext())
            {
                var loan = (from x in context.Loans where x.Id == id select x.IsReturned).First();
                if (loan == 1) return true;
            }
                return false;
        }

        public void UpdatePenalties()
        {
            using (var context = new Context.AppContext())
            {
                var Loans = (from loan in context.Loans select loan).ToList();
                foreach (Loan loan in Loans)
                {
                    if (loan.ReturnDate < DateTime.Now && loan.IsReturned == 0)
                    {
                        var isPenaltyExist = (from pen in context.Penalties where pen.LoanID == loan.Id select pen).Any();
                        if (isPenaltyExist)
                        {
                            int DaysAfter = (DateTime.Now - loan.ReturnDate).Days;
                            var PenUpdate = (from pen in context.Penalties where pen.LoanID == loan.Id select pen).FirstOrDefault();
                            PenUpdate.Sum = DaysAfter;
                            context.Attach(PenUpdate).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        else
                        {
                            var newPenalty = new Penalty() { LoanID = loan.Id, Sum =(DateTime.Now - loan.ReturnDate).Days, Date = DateTime.Now };
                            context.Penalties.Add(newPenalty);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }

        public void PayPenalty(Loan loan) {
            using (var context = new Context.AppContext())
            {
                var isPenaltyExist = (from pen in context.Penalties where pen.LoanID == loan.Id select pen).Any();
                if (isPenaltyExist)
                {
                    loan.IsReturned = 1;
                    loan.UserReturn = DateTime.Now;
                    context.Attach(loan).State = EntityState.Modified;
                    var PenUpdate = (from pen in context.Penalties where pen.LoanID == loan.Id select pen).FirstOrDefault();
                    context.Penalties.Remove(PenUpdate);
                    context.SaveChanges();

                }
                else
                {
                    loan.IsReturned = 1;
                    loan.UserReturn = DateTime.Now;
                    context.Attach(loan).State = EntityState.Modified;
                    context.SaveChanges();
                }

            }
        }
        
        public Dictionary<int,string> GetFillteredBooks(string name)
        {
            Dictionary<int,string> books = new Dictionary<int,string>();
            using (var context = new Context.AppContext())
            {
                var query = (from b in context.Books where b.Title.Contains(name) select b).ToList();
                foreach (var book in query)
                {
                    books.Add(book.Id,"Tytuł:" +book.Title);
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
                    context.SaveChanges();

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
