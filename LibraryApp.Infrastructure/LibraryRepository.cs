using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Core.Entities;
using LibraryApp.Core.Interfaces;

namespace LibraryApp.Infrastructure
{
    public class LibraryRepository : IBookRepository, IAutherRepository, IBooksWithAuthersRepository,IBasic
    {
        LibraryContext context = new LibraryContext();

        #region //-----------Books with Authers
        public IEnumerable<BookWithAuther> GetBooksWithAuthers()
        {
            var bookswithauthers = (
                                        from book in context.Books
                                        join auther in context.Authers
                                        on book.Auther_Id equals auther.Auth_Id
                                        select new BookWithAuther
                                        {

                                            BookWithAuther_Id = book.Book_Id,
                                            BookWithAuther_Title = book.Book_Title,
                                            BookWithAuther_AutherName = auther.First_Name + " " + auther.Last_Name,
                                            Edition = book.Edition,
                                            Price = book.Price

                                        }).ToList();

            return bookswithauthers;
        }

        public BookWithAuther FindBooksWithAuthersById(int BookWithAuther_Id)
        {
            var bookwithauther = (
                                   from book in context.Books
                                   join auther in context.Authers
                                   on book.Auther_Id equals auther.Auth_Id
                                   where book.Book_Id == BookWithAuther_Id
                                   select new BookWithAuther
                                   {
                                       BookWithAuther_Id = book.Book_Id,
                                       BookWithAuther_Title = book.Book_Title,
                                       BookWithAuther_AutherName = auther.First_Name + " " + auther.Last_Name,
                                       Edition = book.Edition,
                                       Price = book.Price

                                   }).FirstOrDefault();

            return bookwithauther;

        }

        #endregion
        
        #region //-----------Books
        public void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }
        public void EditBook(Book book)
        {
            context.Entry(book).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Book FindBookById(int Book_Id)
        {
            var c = (from r in context.Books where r.Book_Id == Book_Id select r).FirstOrDefault();
            return c;
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books;
        }

        public void RemoveBook(int Book_Id)
        {
            Book book = context.Books.Find(Book_Id);
            context.Books.Remove(book);
            context.SaveChanges();
        }

        //Get book price by book Id
        //OOP - Method Overloading 
        public decimal findBookPrice(int? book_id)
        {
            var bookprice = (
                            from r in context.Books
                            where r.Book_Id == book_id
                            select r.Price
                            ).FirstOrDefault();

            return bookprice;

        }  
        public decimal findBookPrice(int? book_id, string bookname)
        {
            var bookprice = (
                             from book in context.Books
                             where book.Book_Id == book_id | book.Book_Title == bookname
                             select book.Price
                             ).FirstOrDefault();

            return bookprice;

        }

        #endregion

        #region //-----------Authers

        public void AddAuther(Auther auther)
        {
            context.Authers.Add(auther);
            context.SaveChanges();
        }

        public void EditAuther(Auther auther)
        {
            context.Entry(auther).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Auther FindAutherById(int Auther_Id)
        {
            var c = (from r in context.Authers where r.Auth_Id == Auther_Id select r).FirstOrDefault();
            return c;
        }

        public IEnumerable<Auther> GetAuthers()
        {
            return context.Authers;
        }
        public void RemoveAuther(int Auther_Id)
        {
            Auther auther = context.Authers.Find(Auther_Id);
            context.Authers.Remove(auther);
            context.SaveChanges();
        }

        #endregion

        #region //-----------DropDowns

        public IEnumerable<Basic> GetAuthersIdName()
        {
            var autheridname = (
                                        from auther in context.Authers
                                        select new Basic
                                        {

                                            ID = auther.Auth_Id,
                                            NAME = auther.First_Name + " " + auther.Last_Name

                                        }).ToList();

            return autheridname;
        }

        public IEnumerable<Basic> GetEditionIdName()
        {
            return new List<Basic>(new[]
                {
                new Basic()
                {
                    ID = 1,
                    NAME = "1st Edition"
                },
                new Basic()
                {
                    ID = 2,
                    NAME = "2nd Edition"
                },
                new Basic()
                {
                    ID = 3,
                    NAME = "3rd Edition"
                },
                new Basic()
                {
                    ID = 4,
                    NAME = "4th Edition"
                }  ,
                new Basic()
                {
                    ID = 5,
                    NAME = "5th Edition"
                },
                new Basic()
                {
                    ID = 6,
                    NAME = "6th Edition"
                } ,
                new Basic()
                {
                    ID = 7,
                    NAME = "7th Edition"
                },
                new Basic()
                {
                    ID = 8,
                    NAME = "8th Edition"
                } ,
                new Basic()
                {
                    ID = 9,
                    NAME = "9th Edition"
                },
                new Basic()
                {
                    ID = 10,
                    NAME = "10th Edition"
                }
            });
        }

        public IEnumerable<Basic> GetEmplyeeStatusIdName()
        {
            return new List<Basic>(new[]
                {
                new Basic()
                {
                    ID = 1,
                    NAME = "Y"
                },
                new Basic()
                {
                    ID = 2,
                    NAME = "N"
                }
            });
        }

        #endregion

    }
}
