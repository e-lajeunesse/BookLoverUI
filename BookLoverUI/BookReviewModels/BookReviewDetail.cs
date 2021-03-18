using BookLoverUI.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI.BookReviewModels
{
    public class BookReviewDetail
    {
        public int ReviewId { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewText { get; set; }
        public double BookRating { get; set; }
        public int BookId { get; set; }
        public BookListItem Book { get; set; }
        // public List<CommentDisplayItem> Comments { get; set; }
    }
}
