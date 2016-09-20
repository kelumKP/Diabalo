using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LibraryApp.Core.Entities;

namespace LibraryApp.Infrastructure
{
    public class LibraryDbInitalize : DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            //Auther
            context.Authers.Add
            (
                  new Auther
                  {
                      Auth_Id = 1,
                      First_Name = "Auther FirstName 001",
                      Last_Name = "Auther LastName 001",
                      Biography = "Auther 1st Bio",
                      IsEmployed = "Y"
                  }
              );

            context.Authers.Add
            (
                 new Auther
                 {
                     Auth_Id = 2,
                     First_Name = "Auther FirstName 002",
                     Last_Name = "Auther LastName 002",
                     Biography = "Auther 2nd Bio",
                     IsEmployed = "Y"
                 }
            );

            context.Authers.Add
            (
                 new Auther
                 {
                     Auth_Id = 3,
                     First_Name = "Auther FirstName 003",
                     Last_Name = "Auther LastName 003",
                     Biography = "Auther 3rd Bio",
                     IsEmployed = "N"
                 }
            );


            //Book
            context.Books.Add
            (
                  new Book
                  {
                      Book_Id = 1,
                      Book_Title = "Book Title 001",
                      Edition = "1st Edition",
                      Price = 40.0M,
                      Auther_Id = 1
                  }
              );

            context.Books.Add
            (
                 new Book
                 {
                     Book_Id = 2,
                     Book_Title = "Book Title 002",
                     Edition = "3rd Edition",
                     Price = 80.00M,
                     Auther_Id = 2
                 }
            );

            context.Books.Add
            (
                 new Book
                 {
                     Book_Id = 3,
                     Book_Title = "Book Title 003",
                     Edition = "4th Edition",
                     Price = 120.00M,
                     Auther_Id = 3
                 }
            );

            context.SaveChanges();

            base.Seed(context);

        }
    }
}
