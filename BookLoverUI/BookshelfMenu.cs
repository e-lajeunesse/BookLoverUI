using BookLoverUI.BookShelfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI
{
    public class BookshelfMenu
    {
        public void RunBookshelfMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?\n" +
                "1.Browse all Bookshelves\n" +
                "2.Browse all of your Bookshelves\n" +
                "3.Create a new Bookshelf\n" +
                "0.Go back to main menu");

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":                    
                    BrowseAllBookshelves();
                    break;
                case "2":
                    BrowseBookshelvesByOwner();
                    break;
                case "3":                    
                    CreateBookshelf();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    RunBookshelfMenu();
                    break;
            }
        }

        public void CreateBookshelf()
        {
            Console.Clear();
            Console.Write("Enter Bookshelf Title: ");
            string title = Console.ReadLine();
            List<int> bookIds = new List<int>();
            bool keepAdding = true;
            while(keepAdding)
            {
                Console.Write("\nEnter Book Id to add to Bookshelf or enter 0 if done adding: ");
                int id = int.Parse(Console.ReadLine());
                if (id == 0)
                {
                    keepAdding = false;
                }
                bookIds.Add(id);                
            }
            string wasAdded = BookLoverUI.Service.CreateBookshelf(title, bookIds).Result;
            Console.WriteLine(wasAdded);
            Console.ReadKey();
        }
        public void BrowseAllBookshelves()
        {
            Console.Clear();
            List<BookshelfDisplay> shelves = BookLoverUI.Service.GetAllBookshelves().Result;
            if (shelves != null)
            {
                foreach(var shelf in shelves)
                {                    
                    DisplayBookshelf(shelf);
                    Console.WriteLine("--------------------");
                }
            }
            else
            {
                Console.WriteLine("No Bookshelves found");
            }
            Console.ReadKey();
        }

        public void BrowseBookshelvesByOwner()
        {
            Console.Clear();
            List<BookshelfDisplay> shelves = BookLoverUI.Service.GetAllBookshelvesByOwner().Result;
            if (shelves != null)
            {
                foreach(var shelf in shelves)
                {
                    DisplayBookshelf(shelf);
                    Console.WriteLine("-----------------");
                }
            }
            else
            {
                Console.WriteLine("No bookshelves found for user");
            }
            Console.ReadKey();
        }

        public void DisplayBookshelf(BookshelfDisplay shelf)
        {
            Console.WriteLine($"Bookshelf Id: {shelf.BookshelfId}\n" +
                        $"Title: {shelf.Title}\n");
            foreach (var book in shelf.Books)
            {
                Console.WriteLine($"Book Id: {book.BookId}\n" +
                    $"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author.FullName}\n");
            }
        }
    }
}
