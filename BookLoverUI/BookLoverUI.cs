using BookLoverUI.AuthorModels;
using BookLoverUI.BookModels;
using BookLoverUI.UserProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI
{
    public class BookLoverUI
    {
        public static readonly BookLoverService Service = new BookLoverService();

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
                    "5.Go to User Profile\n" +                    
                    "0.Exit\n");

                string userSelection = Console.ReadLine();
                switch (userSelection)                
                {
                    case "1":                        
                        BookMenu bookMenu = new BookMenu();
                        bookMenu.RunBookMenu();
                        break;
                    case "2":
                        AuthorMenu authorMenu = new AuthorMenu();
                        authorMenu.RunAuthorMenu();
                        break;
                    case "3":
                        BookReviewMenu bookReviewMenu = new BookReviewMenu();
                        bookReviewMenu.RunBookReviewMenu();
                        break;
                    case "4":
                        //Bookshelf Menu method
                        BookshelfMenu shelfMenu = new BookshelfMenu();
                        shelfMenu.RunBookshelfMenu();
                        break;
                    case "5":
                        UserProfileMenu profileMenu = new UserProfileMenu();
                        profileMenu.RunUserProfileMenu();
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
            string token = Service.GetToken(email,password).Result;
            Console.WriteLine($"Here's your token: {token}");
            Service.AccessToken = token;
            UserProfileDisplay profile = Service.GetUserProfile().Result;
            if (profile == null)
            {
                Console.WriteLine("Warning, no profile exists for this user.");
                Console.WriteLine("Please enter desired username for profile: ");
                string userName = Console.ReadLine();
                List<int> bookIds = new List<int>();
                bool keepAdding = true;
                while(keepAdding)
                {
                    Console.Write("Enter Book Id number to add to your To Read List or enter 0 to continue: ");
                    int id = int.Parse(Console.ReadLine());
                    if (id == 0)
                    {
                        keepAdding = false;
                    }
                    bookIds.Add(id);
                }
                string profileAdded = Service.AddUserProfile(userName,bookIds).Result;
                Console.WriteLine(profileAdded);
            }


            Console.ReadKey();
        }

        
    }
}
