using BookLoverUI.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI
{
    public class BookMenu
    {
        
        public void RunBookMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?\n" +
                "1.Browse all books\n" +
                "2.Find a book by name\n" +
                "3.Add a new book\n" +
                "0.Go back to main menu");

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    DisplayAllBooks();
                    break;
                case "2":
                    //add method to look up book by name
                    GetBookByTitle();
                    break;
                case "3":
                    // add method to add a book
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    RunBookMenu();
                    break;
            }
        }
        public void DisplayAllBooks()
        {
            Console.Clear();
            List<BookListItem> allBooks = BookLoverUI.Service.GetAllBooks().Result;
            foreach (BookListItem book in allBooks)
            {
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Book Id: {book.BookId}");
                Console.WriteLine($"Genre: {book.Genre}");
                Console.WriteLine($"Average rating: {book.AverageRating}");
                Console.WriteLine($"Review count: {book.ReviewCount}");
                Console.WriteLine($"Author Id: {book.AuthorId}");
                Console.WriteLine($"Author: {book.Author.FullName}");
                Console.WriteLine($"Description: {book.Description}\n\n");
            }
            Console.ReadKey();
        }

        public void GetBookByTitle()
        {
            Console.Clear();
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            BookDetail book = BookLoverUI.Service.GetBookByTitle(title).Result;
            if (book != null)
            {
                Console.WriteLine($"\n\nTitle: {book.Title}");
                Console.WriteLine($"Book Id: {book.BookId}");
                Console.WriteLine($"Genre: {book.Genre}");
                Console.WriteLine($"Average rating: {book.AverageRating}");
                Console.WriteLine($"Review count: {book.ReviewCount}");
                Console.WriteLine($"Author Id: {book.AuthorId}");
                Console.WriteLine($"Author: {book.Author.FullName}");
                Console.WriteLine($"Description: {book.Description}\n\n");
                if (book.RecommendedBooks != null)
                {
                    Console.WriteLine($"This book is included on the Bookshelf: \"{book.RecommendedBooks.Title}\"," +
                        $" you might also enjoy the other books on this shelf.");
                    int count = 1;
                    foreach(var b in book.RecommendedBooks.Books)
                    {
                        Console.WriteLine($"{count}: {b.Title}");
                        count++;
                    }
                }
                if (book.BookReviews.Any())
                {
                    Console.WriteLine($"\nReviews: ");
                    foreach(var review in book.BookReviews)
                    {
                        Console.WriteLine($"Review Id: {review.ReviewId}\n" +
                            $"Rating: {review.BookRating}\n" +
                            $"{review.ReviewText}\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nBook not found");
            }
            Console.ReadKey();
        }
    }
}
