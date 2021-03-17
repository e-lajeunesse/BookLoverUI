
﻿using BookLoverUI.AuthorModels;
using BookLoverUI.BookModels;

﻿using BookLoverUI.BookModels;
using BookLoverUI.BookReviewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI
{
    public class BookLoverService
    {
        public string AccessToken { get; set; }
        private HttpClient _client;


        public BookLoverService()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetToken(string email, string password)
        {
            string url = "https://localhost:44388/token";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"grant_type","password" },
                {"username",$"{email}" },
                {"password",$"{password}" }
            };
            var encodedContent = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = _client.PostAsync(url, encodedContent).Result;
            if (response.IsSuccessStatusCode)
            {
                Dictionary<string, string> responseBody = await response.Content.ReadAsAsync<Dictionary<string, string>>();
                return responseBody["access_token"];
            }
            return response.StatusCode.ToString();
        }

        //Book Methods
        public async Task<string> AddBook(string title,string genre,string description,int authorId)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            string url = "https://localhost:44388/api/Book";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"Title",$"{title}" },
                {"Genre",$"{genre}" },
                {"Description",$"{description}" },
                {"AuthorId",$"{authorId}" }
            };
            var encodedContent = new FormUrlEncodedContent(parameters);


            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");

            HttpResponseMessage response = await _client.PostAsync(url,encodedContent);
            if (response.IsSuccessStatusCode)
            {
                return "Book added";
            }
            
            return response.StatusCode.ToString();

        }

        public async Task<string> AddBookByTitleAndName(string title, string name)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"title",$"{title}" },
                {"authorName",$"{name}" }
            };
            var encodedContent = new FormUrlEncodedContent(parameters);
            string url = $"https://localhost:44388/api/Book?title={title}&authorName={name}";

            HttpResponseMessage response = await _client.PostAsync(url,encodedContent);
            if (response.IsSuccessStatusCode)
            {
                return "Book added";
            }
            return response.StatusCode.ToString();
        }

        public async Task<string> AddBooksByAuthor(string firstName,string lastName)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"authorFirstName",$"{firstName}" },
                {"authorLastName",$"{lastName}" }
            };
            var encodedContent = new FormUrlEncodedContent(parameters);
            string url = $"https://localhost:44388/api/Book?authorFirstName={firstName}&authorLastName={lastName}";

            HttpResponseMessage response = await _client.PostAsync(url, encodedContent);
            if (response.IsSuccessStatusCode)
            {
                return "Book added";
            }
            return response.StatusCode.ToString();
        }
        public async Task<List<BookListItem>> GetAllBooks()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",$"{AccessToken}");

            HttpResponseMessage response = _client.GetAsync($"https://localhost:44388/api/Book").Result;

            if (response.IsSuccessStatusCode)
            {
                List<BookListItem> books = await response.Content.ReadAsAsync<List<BookListItem>>();
                return books;
            }
            return null;
        }
        public async Task<List<AuthorListItems>> GetAuthors()
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            HttpResponseMessage response = _client.GetAsync($"https://localhost:44388/api/Author").Result;

            if (response.IsSuccessStatusCode)
            {
                List<AuthorListItems> authorListItems = await response.Content.ReadAsAsync<List<AuthorListItems>>();
                return authorListItems;
            }
            return null;
        }


        public async Task<BookDetail> GetBookByTitle(string title)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            HttpResponseMessage response = _client.GetAsync($"https://localhost:44388/api/Book?title={title}").Result;

            if (response.IsSuccessStatusCode)
            {
                BookDetail book = await response.Content.ReadAsAsync<BookDetail>();
                return book;
            }
            return null;
        }


        public async Task<AuthorDetail> GetAuthorByLastName(string lastName)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            HttpResponseMessage response = _client.GetAsync($"https://localhost:44388/api/Author?lastName={lastName}").Result;

            if (response.IsSuccessStatusCode)
            {
                AuthorDetail author = await response.Content.ReadAsAsync<AuthorDetail>();
                return author;
            }
            return null;

        }

        

        // BookReview Methods

        public async Task<List<BookReviewListItem>> GetAllBookReviews()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            HttpResponseMessage response = _client.GetAsync($"https://localhost:44388/api/BookReview").Result;

            if (response.IsSuccessStatusCode)
            {
                List<BookReviewListItem> bookReviews = await response.Content.ReadAsAsync<List<BookReviewListItem>>();
                return bookReviews;
            }
            return null;
        }

        // Working on Post endpoint
        public async Task<string> AddBookReview(int bookId, string reviewTitle, string reviewText, double bookRating)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            string url = $"https://localhost:44388/api/BookReview";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"BookId",$"{bookId}" },
                {"ReviewTitle",$"{reviewTitle}" },
                {"ReviewText",$"{reviewText}" },
                {"BookRating",$"{bookRating}" },
            };

            var encodedContent = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await _client.PostAsync(url,encodedContent);
            if (response.IsSuccessStatusCode)
            {
                return "Review has been added";
            }
            return response.StatusCode.ToString();
        }

        public async Task<BookReviewDetail> GetBookReviewById(int id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            HttpResponseMessage response = _client.GetAsync($"https://localhost:44388/api/BookReview/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                BookReviewDetail bookReview = await response.Content.ReadAsAsync<BookReviewDetail>();
                return bookReview;
            }
            return null;
        }

        public async Task<BookReviewEdit> UpdateBookReviewById(int id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            HttpResponseMessage response = _client.GetAsync($"https://localhost:44388/api/BookReview/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                BookReviewEdit bookReview = await response.Content.ReadAsAsync<BookReviewEdit>();
                return bookReview;
            }
            return null;
        }

        /*public async Task<BookReviewDisplayItem> DeleteBookReviewById(int id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            HttpResponseMessage response = _client.GetAsync($"https://localhost:44388/api/BookReview/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                BookReviewDisplayItem bookReview = await response.Content.ReadAsAsync<BookReviewDisplayItem>();
                return bookReview;
            }
            return null;
        }*/

    }
}
