using BookLoverUI.BookModels;
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
        private HttpClient _client;
        

        public BookLoverService()
        {
            _client = new HttpClient();
        }

        public async Task<List<BookListItem>> GetAllBooks()
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "qPMUckGKzglMYH8AuXWuvmQ5heTYNAziA3lZ-JBCOhZD6A3F9pQb8u6a9YeeGhWctDJyUc7B-BZwy5mwbxFvo2uw4EH-FQ52YcptDmNtEQL40OjR7v9EIykV9ikwUrmGeijxblcJtb0unUfhYnp1rxLH5r8mKRxTZH7eUCYSEy8_" +
                "73njgLu3AyGXZBBwOGl8PtbNJSgswVHWlvzPLO62ybMRJEs5pgeZTJYOqelyZcj52sGXblXEujunREVLQD-mxUi4xkx8J9sVTd90HHhpjdYsgaS6_g-PeFJGCQ7mF-kea_XBWaxYHNUfBqoz5XqE5VPCRf-oyZ33s0VH6jH8gm-RLk746x3HnAenzsWSfSKR4P1Q3MD4LA-IC-5Ptzmps6dRk-" +
                "GXIs2pbhdDEq0XRHH3AqKUA0hI_u_UrfhoTN-IzCnv6ujyMrGszwD06zG9eapl6V5wwOY3LY9l2RnkaQ2-fLYZAtExmtP6BfKWalM");
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
