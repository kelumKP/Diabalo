using LibraryApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Interfaces
{
    public interface IBooksWithAuthorsRepository
    {
        IEnumerable<BookWithAuthor> GetBooksWithAuthors();
        BookWithAuthor FindBooksWithAuthorsById(int BookWithAuthor_Id);
    }
}
