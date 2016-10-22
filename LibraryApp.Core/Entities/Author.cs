using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Core.Entities
{
    public class Author
    {
        public Author()
        {

        }
        [Key]
        public int Auth_Id { get; set; }

        [StringLength(50)]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }  
        
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Display(Name = "Biography")]
        public string Biography { get; set; }

        [StringLength(1)]
        [Column(TypeName = "char")]  
        [Display(Name = "Empoyed or Not")]
        public string IsEmployed { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
