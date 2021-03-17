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
                    // Add Book to ToRead List method
                    break;
                case "3":
                    // Get all bookshelves by owner
                    break;
                case "4":
                    //Get all reviews by owner
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
    }
}
