using LibraryApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Interfaces
{
    public interface IBooksWithAuthersRepository
    {
        IEnumerable<BookWithAuther> GetBooksWithAuthers();
        BookWithAuther FindBooksWithAuthersById(int BookWithAuther_Id);
    }
}
