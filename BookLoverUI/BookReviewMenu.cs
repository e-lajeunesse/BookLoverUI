using BookLoverUI.BookReviewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoverUI
{
    public class BookReviewMenu
    {
        public void RunBookReviewMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do with reviews today?\n" +
                "1. Browse through all the Book Reviews\n" +
                "2. Find a Review for a book by ID\n" +
                "3. Leave a review on a book\n" +
                "4. Update a review left on a book\n" +
                "5. Delete a review fro a book\n" +
                "0. Go back to main menu.");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    DisplayAllBookReviews();
                    break;
                case "2":
                    GetBookReviewById();
                    break;
                case "3":
                    PostBookReview();
                    break;
                case "4":
                    UpdateBookReview();
                    break;
                case "5":
                    // DeleteBookReviewById();
                    break;
                case "0":
                    // Run Main Menu
                    break;
                default:
                    Console.WriteLine("please enter a valid number between 0-5");
                    RunBookReviewMenu();
                    break;
            }
        }

        public void DisplayAllBookReviews()
        {
            Console.Clear();
            List<BookReviewListItem> allBookReviews = BookLoverUI.Service.GetAllBookReviews().Result;
            foreach (BookReviewListItem bookReview in allBookReviews)
            {
                Console.WriteLine($"Review Id: {bookReview.ReviewId}");
                Console.WriteLine($"Book Id: {bookReview.BookId}");
                Console.WriteLine($"Title: {bookReview.ReviewTitle}");
                Console.WriteLine($"Text: {bookReview.ReviewText}");
                Console.WriteLine($"Book Rating: {bookReview.BookRating}");
            }

            Console.ReadKey();
        }

        public void GetBookReviewById()
        {
            Console.Clear();
            Console.WriteLine("Enter Review ID: ");
            int id = int.Parse(Console.ReadLine());
            BookReviewDetail bookReview = BookLoverUI.Service.GetBookReviewById(id).Result;
            if (bookReview != null)
            {
                Console.WriteLine($"\n\nReview Id: {bookReview.ReviewId}");
                Console.WriteLine($"Book Id: {bookReview.BookId}");
                Console.WriteLine($"Text: {bookReview.ReviewText}");
                Console.WriteLine($"Title: {bookReview.ReviewTitle}");
                Console.WriteLine($"Book Rating: {bookReview.BookRating}");
            }
            else
            {
                Console.WriteLine("Review not found");
            }
            Console.ReadKey();
        }


        public void UpdateBookReview()
        {
            Console.Clear();
            Console.WriteLine("Please Enter the Review ID you would like to update today.:");
            int reviewId = int.Parse(Console.ReadLine());
            BookReviewEdit bookReview = BookLoverUI.Service.UpdateBookReviewById(reviewId).Result;
            if (bookReview.ReviewId == reviewId)
            {
                Console.WriteLine("What would you like to update for this review?\n" +
                    "1. Title\n" +
                    "2. Text\n" +
                    "3. Rating\n" +
                    "4. Book ID\n" +
                    "5. Return to Main Menu");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Enter a new Title:");
                        string newTitle = Console.ReadLine();
                        bookReview.ReviewTitle = newTitle;
                        break;
                    case "2":
                        Console.WriteLine("Enter new Text for this Review:");
                        string newText = Console.ReadLine();
                        bookReview.ReviewText = newText;
                        break;
                    case "3":
                        Console.WriteLine("Enter a new Rating for this Review. Must be between 1-10:");
                        double newRating = double.Parse(Console.ReadLine());
                        bookReview.BookRating = newRating;
                        break;
                    case "4":
                        Console.WriteLine("Enter the new Book Id for this Review");
                        int newId = int.Parse(Console.ReadLine());
                        bookReview.BookId = newId;
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-5.");
                        RunBookReviewMenu();
                        break;
                }
            }
        }

        /*public void DeleteBookReviewById()
        {
            Console.Clear();
            Console.WriteLine("Please enter the Review Id of the Review you wish to delete:");

            List<BookReviewDisplayItem> bookReviewList = 
        }*/

        public void PostBookReview()
        {
            Console.Clear();
            Console.WriteLine("Enter the Book Id");
            int bookId = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter a Title for the Review");
            string reviewTitle = Console.ReadLine();
            Console.WriteLine("\nEnter text for the Review");
            string reviewText = Console.ReadLine();
            Console.WriteLine("\nEnter a Rating for the book");
            double bookRating = double.Parse(Console.ReadLine());
            string wasAdded = BookLoverUI.Service.AddBookReview(bookId, reviewTitle, reviewText, bookRating).Result;
            Console.WriteLine(wasAdded);
            Console.ReadKey();
        }
    }
}
