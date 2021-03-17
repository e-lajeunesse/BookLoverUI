using BookLoverUI.BookReviewModels;
using BookLoverUI.BookShelfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI.BookModels
{
    public class BookDetail
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public double AverageRating { get; set; }
        
        public int ReviewCount { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        
        public BookshelfDisplay RecommendedBooks { get; set; }
        public List<BookReviewDisplayItem> BookReviews { get; set; }
    }

    
}
