using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryApp.Core.Entities;
using System.Net.Http;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace LibraryApp.MVC.Models
{
    public class LibraryClient
    {
        
        private string BOOKWITHAUTHER_URL = "http://localhost:13793/api/BooksWithAuthors";
        private string AUTHER_URL = "http://localhost:13793/api/Authors";
        private string BOOK_URL = "http://localhost:13793/api/Books";

        #region //Books with Authors
        public IEnumerable<BookWithAuthor> GetAllBookWithAuthors()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BOOKWITHAUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("BooksWithAuthors").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<BookWithAuthor>>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }

        public BookWithAuthor GetBookwithAuthor(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BOOKWITHAUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("BooksWithAuthors/" + id).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<BookWithAuthor>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }

        #endregion

        #region // Book

        public Book GetBook(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BOOK_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Books/" + id).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Book>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }          

        public bool CreateBook(Book book)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BOOK_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Books/", book).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }

        }

        public bool EditBook(Book book)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BOOK_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("Books/" + book.Book_Id, book).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteBook(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BOOK_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("Books/" + id).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }

        }

        #endregion

        #region // Author

        public IEnumerable<Author> GetAllAuthors()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Authors").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Author>>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }

        public Author GetAuthor(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Authors/" + id).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Author>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }

        public bool CreateAuthor(Author author)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Authors/", author).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }

        }

        public bool EditAuthor(Author author)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("Authors/" + author.Auth_Id, author).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteAuthr(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("Authors/" + id).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }

        }

        //DropDown
        public IEnumerable<Basic> GetAuthorsIdName()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Authors/all").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Basic>>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }

        public IEnumerable<Basic> GetEmplyeeStatusIdNameMVCModel()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Authors/EmploymentStatus").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Basic>>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }

        public IEnumerable<Basic> GetEditionIdNameMVCModel()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Books/Editions").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Basic>>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }

        #endregion

    }
}