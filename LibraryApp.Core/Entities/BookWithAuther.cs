using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Entities
{
    public class BookWithAuther
    {
        [Key]
        public int BookWithAuther_Id { get; set; }  
        public string BookWithAuther_Title { get; set; } 
        public string BookWithAuther_AutherName { get; set; }
        public decimal Price { get; set; }
        public string Edition { get; set; } 

    }
}
