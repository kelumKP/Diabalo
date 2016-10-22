using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Core.Entities;
using LibraryApp.Core.Interfaces;

namespace LibraryApp.Infrastructure
{
    public class LibraryRepository : IBookRepository, IAuthorRepository, IBooksWithAuthorsRepository,IBasic
    {
        LibraryContext context = new LibraryContext();

        #region //-----------Books with Authors
        public IEnumerable<BookWithAuthor> GetBooksWithAuthors()
        {
            var bookswithauthors = (
                                        from book in context.Books
                                        join author in context.Authors
                                        on book.Author_Id equals author.Auth_Id
                                        select new BookWithAuthor
                                        {

                                            BookWithAuthor_Id = book.Book_Id,
                                            BookWithAuthor_Title = book.Book_Title,
                                            BookWithAuthor_AuthorName = author.First_Name + " " + author.Last_Name,
                                            Edition = book.Edition,
                                            Price = book.Price

                                        }).ToList();

            return bookswithauthors;
        }

        public BookWithAuthor FindBooksWithAuthorsById(int BookWithAuthor_Id)
        {
            var bookwithauthor = (
                                   from book in context.Books
                                   join author in context.Authors
                                   on book.Author_Id equals author.Auth_Id
                                   where book.Book_Id == BookWithAuthor_Id
                                   select new BookWithAuthor
                                   {
                                       BookWithAuthor_Id = book.Book_Id,
                                       BookWithAuthor_Title = book.Book_Title,
                                       BookWithAuthor_AuthorName = author.First_Name + " " + author.Last_Name,
                                       Edition = book.Edition,
                                       Price = book.Price

                                   }).FirstOrDefault();

            return bookwithauthor;

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

        #region //-----------Authors

        public void AddAuthor(Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
        }

        public void EditAuthor(Author author)
        {
            context.Entry(author).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Author FindAuthorById(int Author_Id)
        {
            var c = (from r in context.Authors where r.Auth_Id == Author_Id select r).FirstOrDefault();
            return c;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return context.Authors;
        }
        public void RemoveAuthor(int Author_Id)
        {
            Author author = context.Authors.Find(Author_Id);
            context.Authors.Remove(author);
            context.SaveChanges();
        }

        #endregion

        #region //-----------DropDowns

        public IEnumerable<Basic> GetAuthorsIdName()
        {
            var authoridname = (
                                        from author in context.Authors
                                        select new Basic
                                        {

                                            ID = author.Auth_Id,
                                            NAME = author.First_Name + " " + author.Last_Name

                                        }).ToList();

            return authoridname;
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
