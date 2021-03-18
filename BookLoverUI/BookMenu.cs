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
                "2.Find a book by title\n" +
                "3.Find a book by it's Id\n" +
                "4.Browse books by author\n" +
                "5.Browse books by genre\n" +
                "6.Add a new book\n" +
                "0.Go back to main menu");

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    DisplayAllBooks();
                    break;
                case "2":                    
                    GetBookByTitle();
                    break;
                case "3":
                    GetBookById();
                    break;
                case "4":
                    BrowseBooksByAuthor();                    
                    break;
                case "5":
                    BrowseBooksByGenre();
                    break;
                case "6":
                    AddBookMenu();
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
        public void GetBookById()
        {
            Console.Clear();
            Console.Write("Enter Book Id: ");
            int bookId = int.Parse(Console.ReadLine());
            BookDetail book = BookLoverUI.Service.GetBookById(bookId).Result;
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
                    foreach (var b in book.RecommendedBooks.Books)
                    {
                        Console.WriteLine($"{count}: {b.Title}");
                        count++;
                    }
                }
                if (book.BookReviews.Any())
                {
                    Console.WriteLine($"\nReviews: ");
                    foreach (var review in book.BookReviews)
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

        public void AddBookMenu()
        {
            Console.Clear();
            Console.WriteLine("How would you like to add the book(s)?\n" +
                "1.Enter all information manually\n" +
                "2.Add book by title and author name using Google Books API\n" +
                "3.Add all books by an author using Google Books API\n" +
                "0.Go back to previous menu");
            string userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":                    
                    AddBookManually();
                    break;
                case "2":                    
                    AddBookWithTitleAndName();
                    break;
                case "3":
                    AddBooksByAuthor();                    
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    AddBookMenu();
                    break;
            }
        }

        public void AddBookManually()
        {
            Console.Clear();
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            Console.Write("\nEnter Genre: ");
            string genre = Console.ReadLine();
            Console.Write("\nEnter Book Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Author Id Number: ");
            int authorId = int.Parse(Console.ReadLine());
            string wasAdded = BookLoverUI.Service.AddBook(title, genre, description, authorId).Result;
            Console.WriteLine(wasAdded);
            Console.ReadKey();
        }

        public void AddBookWithTitleAndName()
        {
            Console.Clear();
            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();
            Console.Write("\nEnter Author's Full Name: ");
            string name = Console.ReadLine();
            string wasAdded = BookLoverUI.Service.AddBookByTitleAndName(title, name).Result;
            Console.WriteLine(wasAdded);
            Console.ReadKey();
        }

        public void AddBooksByAuthor()
        {
            Console.Clear();
            Console.Write("Enter Author First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("\nEnter Author Last Name: ");
            string lastName = Console.ReadLine();
            string wasAdded = BookLoverUI.Service.AddBooksByAuthor(firstName, lastName).Result;
            Console.WriteLine(wasAdded);
            Console.ReadKey();
        }

        public void BrowseBooksByAuthor()
        {
            Console.Clear();
            Console.Write("Enter author's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("\nEnter author's last name: ");
            string lastName = Console.ReadLine();
            List<BookListItem> books = BookLoverUI.Service.GetBooksByAuthor(firstName, lastName).Result;
            if (books.Count < 1)
            {
                Console.WriteLine("No books found");
            }
            else
            {
                Console.Clear();
                foreach (BookListItem book in books)
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
            }
            Console.ReadKey();
        }

        public void BrowseBooksByGenre()
        {
            Console.Clear();
            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();
            List<BookListItem> books = BookLoverUI.Service.GetBooksByGenre(genre).Result;
            if (books.Count < 1)
            {
                Console.WriteLine("No books found");
            }
            else
            {
                Console.Clear();
                foreach (BookListItem book in books)
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
            }
            Console.ReadKey();
        }
    }
}
