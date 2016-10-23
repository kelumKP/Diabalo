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

        // initialize the test class
        [TestInitialize]
        public void TestSetup()
        {
            LibraryDbInitalize db = new LibraryDbInitalize();
            System.Data.Entity.Database.SetInitializer(db);
            Repo = new LibraryRepository();
        }

        #region Author  

        // check valid number of author/s(1) existing in current DB
        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_Author()
        {
            var result = Repo.GetAuthors();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(3, numberOfRecords);
        }

        // check add author method working and total number of authors(2) correct
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
        #endregion

        #region Book 

        // check valid number of book/s(3) existing in current DB
        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_Book()
        {
            var result = Repo.GetBooksWithAuthors();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(3, numberOfRecords);
        }

        // check add book method working and total number of books(4) correct
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
        #endregion

        #region Books with Author 

        // check valid number of book and author/s(4) existing in current DB
        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_BooksWithAuthor()
        {
            var result = Repo.GetBooksWithAuthors();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(4, numberOfRecords);
        }

        #endregion     

        #region DropDowns

        // check valid number of author/s(4) listing in dropdown
        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_AuthorDropDown()
        {
            var result = Repo.GetAuthorsIdName();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(4, numberOfRecords);
        }
        #endregion
    }
}
