using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI.BookReviewModels
{
    public class BookReviewEdit
    {
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public string ReviewTitle { get; set; }
        public double BookRating { get; set; }
        public int BookId { get; set; }
    }
}
