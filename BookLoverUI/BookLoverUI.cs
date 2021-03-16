using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI
{
    public class BookLoverUI
    {
        private readonly BookLoverService _service = new BookLoverService();

        public void RunUI()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the BookLover API, what would you like to do?\n" +
                    "1.Browse all books\n" +
                    "2.Find a book by name\n" +
                    "3.Enter a new book\n" +
                    "4.Browse all authors\n" +
                    "5.Find an author by name\n" +
                    "6.Enter a new author" +
                    "7.Review a book\n" +
                    "8.Create a bookshelf\n" +
                    "0.Exit\n");

            }
        }
    }
}
