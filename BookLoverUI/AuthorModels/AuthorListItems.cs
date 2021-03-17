using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI.AuthorModels
{
    public class AuthorListItems
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public List<Books> ListOfBooks { get; set; }
        public struct Books
        {
            public string BookList { get; set; }
        }

    }
}
