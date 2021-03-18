
using BookLoverUI.AuthorModels;
using BookLoverUI.BookModels;
using BookLoverUI.BookShelfModels;
using BookLoverUI.BookReviewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BookLoverUI.UserProfileModels;

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

        //Author Methods
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

        public async Task<string> AddAuthor(string firstName, string lastName, string description)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            string url = $"https://localhost:44388/api/Author";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"FirstName",$"{firstName}" },
                {"LastName",$"{lastName}" },
                {"Description",$"{description}" },
            };

            var encodedContent = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await _client.PostAsync(url, encodedContent);
            if (response.IsSuccessStatusCode)
            {
                return "Author was added";
            }
            return response.StatusCode.ToString();
        }

        //Book Methods
        public async Task<string> AddBook(string title, string genre, string description, int authorId)
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

            HttpResponseMessage response = await _client.PostAsync(url, encodedContent);
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

            HttpResponseMessage response = await _client.PostAsync(url, encodedContent);
            if (response.IsSuccessStatusCode)
            {
                return "Book added";
            }
            return response.StatusCode.ToString();
        }

        public async Task<string> AddBooksByAuthor(string firstName, string lastName)
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
                return "Book(s) added";
            }
            return response.StatusCode.ToString();
        }
        public async Task<List<BookListItem>> GetAllBooks()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");

            HttpResponseMessage response = _client.GetAsync($"https://localhost:44388/api/Book").Result;

            if (response.IsSuccessStatusCode)
            {
                List<BookListItem> books = await response.Content.ReadAsAsync<List<BookListItem>>();
                return books;
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

        public async Task<List<BookListItem>> GetBooksByAuthor(string firstName,string lastName)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            string url = $"https://localhost:44388/api/Book?firstName={firstName}&lastName={lastName}";
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                List<BookListItem> books = await response.Content.ReadAsAsync<List<BookListItem>>();
                return books;
            }
            return null;
        }

        public async Task<List<BookListItem>> GetBooksByGenre(string genre)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            string url = $"https://localhost:44388/api/Book?genre={genre}";
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                List<BookListItem> books = await response.Content.ReadAsAsync<List<BookListItem>>();
                return books;
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

            HttpResponseMessage response = await _client.PostAsync(url, encodedContent);
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

        public async Task<string> UpdateBookReview(int reviewId, string reviewTitle, string reviewText, double bookRating)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            string Uri = $"https://localhost:44388/api/BookReview";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"ReviewId",$"{reviewId}" },
                {"ReviewTitle",$"{reviewTitle}" },
                {"ReviewText",$"{reviewText}" },
                {"BookRating",$"{bookRating}" },
            };
            var encodedContent = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await _client.PutAsync(Uri,encodedContent);

            if (response.IsSuccessStatusCode)
            {
                // BookReviewEdit bookReview = await response.Content.ReadAsAsync<BookReviewEdit>();
                return "review was updated!";
            }
            return response.StatusCode.ToString();
        }

        public async Task<string> DeleteBookReviewById(int id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            HttpResponseMessage response = await _client.DeleteAsync($"https://localhost:44388/api/BookReview/{id}");

            if (response.IsSuccessStatusCode)
            {
                // BookReviewDisplayItem bookReview = await response.Content.ReadAsAsync<BookReviewDisplayItem>();
                return "Successfully deleted";
            }
            return "not deleted";
        }
        // Bookshelf Methods
        public async Task<string> CreateBookshelf(string title, List<int> bookIds)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"Title",$"{title}" },                                
            };
            for (int i = 0; i < bookIds.Count; i++)
            {
                parameters[$"BookIds[{i}]"] = $"{bookIds[i]}";
            }
            var encodedContent = new FormUrlEncodedContent(parameters);
            string url = "https://localhost:44388/api/Bookshelf";
            HttpResponseMessage response = await _client.PostAsync(url, encodedContent);
            if (response.IsSuccessStatusCode)
            {
                return "Bookshelf added";
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }        
        public async Task<List<BookshelfDisplay>> GetAllBookshelves()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            HttpResponseMessage response = _client.GetAsync($"https://localhost:44388/api/GetAllBookshelves").Result;
            if (response.IsSuccessStatusCode)
            {
                List<BookshelfDisplay> shelves = await response.Content.ReadAsAsync<List<BookshelfDisplay>>();
                return shelves;
            }
            return null;
        }

        public async Task<List<BookshelfDisplay>> GetAllBookshelvesByOwner()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            HttpResponseMessage response = _client.GetAsync($"https://localhost:44388/api/Bookshelf").Result;
            if (response.IsSuccessStatusCode)
            {
                List<BookshelfDisplay> shelves = await response.Content.ReadAsAsync<List<BookshelfDisplay>>();
                return shelves;
            }
            return null;
        }

        //User Profile Methods
        public async Task<UserProfileDisplay> GetUserProfile()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            HttpResponseMessage response = _client.GetAsync($"https://localhost:44388/api/GetsUserByUserId").Result;
            if (response.IsSuccessStatusCode)
            {
                UserProfileDisplay profile = await response.Content.ReadAsAsync<UserProfileDisplay>();
                return profile;
            }
            return null;
        }

        public async Task<string> AddUserProfile(string userName, List<int> bookIds)
        {
            
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"UserName",$"{userName}" },
            };
            for(int i=0; i< bookIds.Count; i++)
            {
                parameters[$"BookIds[{i}]"] = $"{bookIds[i]}";
            }
            
            var encodedContent = new FormUrlEncodedContent(parameters);
            string url = "https://localhost:44388/api/UserProfile";
            HttpResponseMessage response = await _client.PostAsync(url, encodedContent);
            if (response.IsSuccessStatusCode)
            {
                return "Profile Added";
            }
            return "Unable to add profile";
        }

        public async Task<string> AddBookToReadList(int profileId, int bookId)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{AccessToken}");
            string url = $"https://localhost:44388/api/UserProfile?profileId={profileId}&bookId={bookId}";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"profileId",$"{profileId}" },
                {"bookId",$"{bookId}" },
                
            };
            var encodedContent = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await _client.PutAsync(url,encodedContent);
            if (response.IsSuccessStatusCode)
            {
                return "Book added";
            }
            return response.StatusCode.ToString();
        }
    }
}
