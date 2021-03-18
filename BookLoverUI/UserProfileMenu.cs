using BookLoverUI.BookModels;
using BookLoverUI.UserProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI
{
    public class UserProfileMenu
    {
        private readonly UserProfileDisplay _profile = BookLoverUI.Service.GetUserProfile().Result;
        public void RunUserProfileMenu()
        {
            
            
            Console.Clear();
            Console.WriteLine($"What would you like to do?\n" +
                "1.See my To Read List\n" +
                "2.Add a Book to my To Read List\n" +
                "3.See my Bookshelves\n" +
                "4.See my reviews\n" +
                "0.Go back to main menu");

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    DisplayToReadList();
                    break;
                case "2":
                    AddBookToReadList();                    
                    break;
                case "3":
                    GetOwnersBookshelves();
                    break;
                case "4":
                    GetOwnersReviews();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    RunUserProfileMenu();
                    break;
            }
        }

        public void DisplayToReadList()
        {
            Console.Clear();
            for(int i= 1; i <= _profile.BooksToRead.Count; i++)
            {
                Console.WriteLine($"{i}. Book Id: {_profile.BooksToRead[i-1].BookId}\n" +
                    $"   Title: {_profile.BooksToRead[i-1].Title}\n");
            }
            Console.ReadKey();
        }

        public void AddBookToReadList()
        {
            Console.Clear();
            Console.Write("Enter name of book you wish to add or type 'esc' to go back to menu: ");
            string title = Console.ReadLine();
            if (title.ToLower() == "esc")
            {
                return;
            }
            BookDetail book = BookLoverUI.Service.GetBookByTitle(title).Result;
            if (book == null)
            {
                Console.WriteLine("Unable to find book with that title, press enter to search again" +
                    " or type 'esc' to go back to menu");
                string response = Console.ReadLine();
                if ( response.ToLower() == "esc")
                {
                    return;
                }
                AddBookToReadList();
            }
            Console.Write($"\nSearch returned {book.Title} by {book.Author.FullName}," +
                $" do you want to add this book enter y/n?");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                string wasAdded = BookLoverUI.Service.AddBookToReadList(_profile.UserProfileId, book.BookId).Result;
                Console.WriteLine(wasAdded);
            }
            else
            {
                AddBookToReadList();
            }
            Console.ReadKey();
        }

        public void GetOwnersBookshelves()
        {
            BookshelfMenu shelfMenu = new BookshelfMenu();
            shelfMenu.BrowseBookshelvesByOwner();
        }

        public void GetOwnersReviews()
        {
            Console.Clear();
            foreach(var review in _profile.BookReviews)
            {
                Console.WriteLine($"Review Id: {review.ReviewId}\n" +
                    $"Book: {review.BookTitle}\n" +
                    $"Rating: {review.BookRating}\n" +
                    $"Review: {review.ReviewText}\n");
            }
            Console.ReadKey();
        }
    }
}
