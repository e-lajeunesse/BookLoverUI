using BookLoverUI.AuthorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI
{
    public class AuthorMenu
    {
        public void RunAuthorMenu()
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
                    GetAuthorByLastName();
                    break;
                case "3":
                    AddAuthor();
                    break;
                case "4":
                    DeleteAuthorById();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    RunAuthorMenu();
                    break;
            }
        }

        public void DisplayAllAuthors()
        {
            Console.Clear();
            List<AuthorListItems> authorListItems = BookLoverUI.Service.GetAuthors().Result;
            foreach (AuthorListItems author in authorListItems)
            {
                Console.WriteLine($"Author Id: {author.AuthorId}");
                Console.WriteLine($"First Name: {author.FirstName}");
                Console.WriteLine($"Last Name: {author.LastName}");
                Console.WriteLine($"Description: {author.Description}");
            }
            Console.ReadKey();
        }

        public void GetAuthorByLastName()
        {
            Console.Clear();
            Console.Write("Enter author's last name: ");
            string LastName = Console.ReadLine();
            AuthorDetail author = BookLoverUI.Service.GetAuthorByLastName(LastName).Result;
            if (author != null)
            {
                Console.WriteLine($"Author Id: {author.AuthorId}");
                Console.WriteLine($"FirstName: {author.FirstName}");
                Console.WriteLine($"LastName: {author.LastName}");
                Console.WriteLine($"Description: {author.Description}");
              
            }
            else
            {
                Console.WriteLine("Sorry, we don't have information for that author.");
                Console.WriteLine("Please press any key to return to the main menu.");

            }
            Console.ReadKey();
        }

        public void AddAuthor()
        {
            Console.Clear();
            Console.Write("Enter the first name of the author: ");
            string firstName = Console.ReadLine();
            Console.Write("\nEnter the last name of the author: ");
            string lastName = Console.ReadLine();
            Console.Write("\nEnter Author Description: ");
            string description = Console.ReadLine();
            string wasAdded = BookLoverUI.Service.AddAuthor(firstName, lastName, description).Result;
            Console.WriteLine(wasAdded);
            Console.ReadKey();
        }

    }
}



