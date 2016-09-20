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

        //------------------Auther  
        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_Auther()
        {
            var result = Repo.GetAuthers();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(3, numberOfRecords);
        }

        [TestMethod]
        public void IsRepositoryAddsAuther()
        {
            Auther productToInsert = new Auther
            {
                Auth_Id = 4,
                First_Name = "Auther FirstName 004",
                Last_Name = "Auther LastName 004",
                Biography = "Auther 4th Bio"

            };
            Repo.AddAuther(productToInsert);
            // If Product inserts successfully, 
            //number of records will increase to 4 
            var result = Repo.GetAuthers();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(4, numberOfRecords);
        }

        //------------------Book 
        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_Book()
        {
            var result = Repo.GetBooksWithAuthers();
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
                Auther_Id = 1
                

            };
            Repo.AddBook(productToInsert);
            // If Product inserts successfully, 
            //number of records will increase to 4 
            var result = Repo.GetBooks();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(4, numberOfRecords);
        }

        //------------------Books with Auther 

        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_BooksWithAuther()
        {
            var result = Repo.GetBooksWithAuthers();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(4, numberOfRecords);
        }

        //------------------DropDown
        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_AutherDropDown()
        {
            var result = Repo.GetAuthersIdName();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(4, numberOfRecords);
        }



    }
}
