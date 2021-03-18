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
                "5. Delete a review for a book\n" +
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
                    //UpdateBookReview();
                    break;
                case "5":
                    DeleteBookReviewById();
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

        /*public void UpdateBookReview()
        {
            Console.Clear();
            Console.WriteLine("Enter the new Book Id");
            int bookId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the the Rating Id");
            int reviewId = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter a Title for the Review");
            string reviewTitle = Console.ReadLine();
            Console.WriteLine("\nEnter text for the Review");
            string reviewText = Console.ReadLine();
            Console.WriteLine("\nEnter a Rating for the book");
            double bookRating = double.Parse(Console.ReadLine());
            string wasAdded = BookLoverUI.Service.UpdateBookReview(reviewId, bookId, reviewTitle, reviewText, bookRating).Result;
            Console.WriteLine(wasAdded);
            Console.ReadKey();
        }*/

        /*public void UpdateBookReview()
        {
            Console.Clear();
            Console.WriteLine("Enter the Id of the Review you wish to update");
            int reviewId = int.Parse(Console.ReadLine());

            Console.WriteLine("Pulling that up now");
            
            if (reviewId = )
            {

            }
        }*/

        public void DeleteBookReviewById()
        {
            Console.Clear();
            // List<BookReviewListItem> allBookReviews = BookLoverUI.Service.GetAllBookReviews().Result;
            Console.WriteLine("Please enter the Review Id of the Review you wish to delete:");

            int reviewId = int.Parse(Console.ReadLine());
            string wasDeleted = BookLoverUI.Service.DeleteBookReviewById(reviewId).Result;
            Console.WriteLine("Review was deleted");
        }

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
