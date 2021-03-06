using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI.UserProfileModels
{
    public class UserProfileDisplay
    {
        public int UserProfileId { get; set; }
        public string UserName { get; set; }
        public List<UserProfileBookDisplay> BooksToRead { get; set; }
        public List<ProfileBookReviewDisplay> BookReviews { get; set; }
    }
}
