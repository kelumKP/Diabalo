using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApp.Core.Entities;
using LibraryApp.Infrastructure;


namespace LibraryApp.UnitTest
{
    [TestClass]
    public class LibraryRepositoryTest
    {
        LibraryRepository Repo;

        [TestInitialize]
        public void TestSetup()
        {
            LibraryDbInitalize db = new LibraryDbInitalize();
            System.Data.Entity.Database.SetInitializer(db);
            Repo = new LibraryRepository();
        }

        //------------------Author  
        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_Author()
        {
            var result = Repo.GetAuthors();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(3, numberOfRecords);
        }

        [TestMethod]
        public void IsRepositoryAddsAuthor()
        {
            Author productToInsert = new Author
            {
                Auth_Id = 4,
                First_Name = "Author FirstName 004",
                Last_Name = "Author LastName 004",
                Biography = "Author 4th Bio"

            };
            Repo.AddAuthor(productToInsert);
            // If Product inserts successfully, 
            //number of records will increase to 4 
            var result = Repo.GetAuthors();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(4, numberOfRecords);
        }

        //------------------Book 
        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_Book()
        {
            var result = Repo.GetBooksWithAuthors();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(3, numberOfRecords);
        }

        [TestMethod]
        public void IsRepositoryAddsBook()
        {
            Book productToInsert = new Book
            {
                Book_Id = 4,
                Book_Title = "Book Title 004",
                Price = 9.00M,
                Edition = "4th Edition",
                Author_Id = 1
                

            };
            Repo.AddBook(productToInsert);
            // If Product inserts successfully, 
            //number of records will increase to 4 
            var result = Repo.GetBooks();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(4, numberOfRecords);
        }

        //------------------Books with Author 

        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_BooksWithAuthor()
        {
            var result = Repo.GetBooksWithAuthors();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(4, numberOfRecords);
        }

        //------------------DropDown
        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_AuthorDropDown()
        {
            var result = Repo.GetAuthorsIdName();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(4, numberOfRecords);
        }



    }
}
