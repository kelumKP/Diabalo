using LibraryApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Interfaces
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        void EditBook(Book book);
        void RemoveBook(int Book_Id);
        IEnumerable<Book> GetBooks();
        Book FindBookById(int Book_Id);     

    }
}
