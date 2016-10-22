using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Core.Entities;

namespace LibraryApp.Core.Interfaces
{
    public interface IBasic
    {
        IEnumerable<Basic> GetAuthorsIdName();

        IEnumerable<Basic> GetEditionIdName();

        IEnumerable<Basic> GetEmplyeeStatusIdName();
    }
}
