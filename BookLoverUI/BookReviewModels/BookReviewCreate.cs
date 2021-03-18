using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI.BookReviewModels
{
    public class BookReviewCreate
    {
        public string ReviewTitle { get; set; }
        public string ReviewText { get; set; }
        public double BookRating { get; set; }
        public int BookId { get; set; }
    }
}
