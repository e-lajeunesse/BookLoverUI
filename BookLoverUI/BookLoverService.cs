﻿using BookLoverUI.BookModels;
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
                Dictionary<string,string> responseBody = await response.Content.ReadAsAsync<Dictionary<string,string>>();
                return responseBody["access_token"];
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

    }
}
