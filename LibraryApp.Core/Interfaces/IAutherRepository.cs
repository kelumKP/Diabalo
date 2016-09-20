using LibraryApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Interfaces
{
    public interface IAutherRepository
    {
        void AddAuther(Auther auther);
        void EditAuther(Auther auther);
        void RemoveAuther(int Id);
        IEnumerable<Auther> GetAuthers(); 
        Auther FindAutherById(int Id);
    }
}
