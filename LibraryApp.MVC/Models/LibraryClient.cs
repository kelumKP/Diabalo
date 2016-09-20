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
        
        private string BOOKWITHAUTHER_URL = "http://localhost:13793/api/BooksWithAuthers";
        private string AUTHER_URL = "http://localhost:13793/api/Authers";
        private string BOOK_URL = "http://localhost:13793/api/Books";

        #region //Books with Authers
        public IEnumerable<BookWithAuther> GetAllBookWithAuthers()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BOOKWITHAUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("BooksWithAuthers").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<BookWithAuther>>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }

        public BookWithAuther GetBookwithAuther(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BOOKWITHAUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("BooksWithAuthers/" + id).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<BookWithAuther>().Result;
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

        #region // Auther

        public IEnumerable<Auther> GetAllAuthers()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Authers").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Auther>>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }

        public Auther GetAuther(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Authers/" + id).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Auther>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }

        public bool CreateAuther(Auther auther)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Authers/", auther).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }

        }

        public bool EditAuther(Auther auther)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("Authers/" + auther.Auth_Id, auther).Result;

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
                HttpResponseMessage response = client.DeleteAsync("Authers/" + id).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }

        }

        //DropDown
        public IEnumerable<Basic> GetAuthersIdName()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Authers/all").Result;
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
                HttpResponseMessage response = client.GetAsync("Authers/EmploymentStatus").Result;
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