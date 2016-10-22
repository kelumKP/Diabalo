using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Strongly Type using System.Web.Mvc;   
// Install 'System.Web.Mvc.Extensions.Mvc.4'


namespace LibraryApp.Core.Entities
{
    public class Book
    {
        public Book()
        {

        }

        [Key]
        public int Book_Id { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        public string Book_Title { get; set; }
        [DataType("decimal(16 ,3")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Edition")]
        public string Edition { get; set; }

        [Display(Name = "Author")]
        [ForeignKey("Author")] 
        public int Author_Id { get; set; }   
        public Author Author { get; set; }

        // Strongly Type
        //------------------------------------------
        /*
        public IEnumerable<SelectListItem> Authors { get; set; }
        */
    }
}
