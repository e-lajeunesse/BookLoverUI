using BookLoverUI.AuthorModels;
using BookLoverUI.BookModels;
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
            LogIn();
            while (keepRunning)
            {
                
                Console.Clear();
                Console.WriteLine("Welcome to the BookLover API, what would you like to do?\n" +
                    "1.Browse or add books\n" +
                    "2.Browse or add authors\n" +
                    "3.Browse or add reviews\n" +
                    "4.Browse or add bookshelves\n" +                    
                    "0.Exit\n");

                string userSelection = Console.ReadLine();
                switch (userSelection)                
                {
                    case "1":                        
                        BookMenu();
                        break;
                    case "2":
                        AuthorMenu();
                        break;
                    case "3":
                        //Review Menu method
                        break;
                    case "4":
                        //Bookshelf Menu method
                        break;
                    case "0":
                        keepRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid entry");
                        break;
                }


            }


        }

        //User logs in with email and password, method generates a new authorization token that is stored in the 
        // BookLoverService AccessToken property and can then be used for other requests
        public void LogIn()
        {
            Console.WriteLine("Welcome to the BookLover API, please enter your " +
                "email and password to log in.\n");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("\nPassword: ");
            string password = Console.ReadLine();

            string token = _service.GetToken(email,password).Result;
            Console.WriteLine($"Here's your token: {token}");
            _service.AccessToken = token;
            Console.ReadKey();
        }

        public void BookMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?\n" +
                "1.Browse all book\n" +
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
                    break;
                case "3":
                    // add method to add a book
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    BookMenu();
                    break;
            }
        }
        public void DisplayAllBooks()
        {
            Console.Clear();
            List<BookListItem> allBooks = _service.GetAllBooks().Result;
            foreach (BookListItem book in allBooks)
            {
                Console.WriteLine(book.Title);
            }
            Console.ReadKey();
        }

        public void AuthorMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?\n" +
                "1.Browse all authors\n" +
                "2.Find an author by name\n" +
                "3.Add a new author\n" +
                "0.Go back to main menu");

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    DisplayAllAuthors();
                    break;
                case "2":
                    //add method to look up author by name
                    break;
                case "3":
                    // add method to add an author
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    AuthorMenu();
                    break;
            }
        }
        public void DisplayAllAuthors()
        {
            Console.Clear();
            List<AuthorListItems> allAuthors = _service.GetAllAuthors().Result;
            foreach (AuthorListItems author in allAuthors)
            {
                Console.WriteLine(author.FullName);
            }
            Console.ReadKey();
        }

    }
}
