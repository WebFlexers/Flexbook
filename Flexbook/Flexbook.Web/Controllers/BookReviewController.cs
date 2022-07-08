using Flexbook.Data.Models;
using Flexbook.Services;
using Flexbook.Services.Books;
using Flexbook.Services.Users.User;
using Flexbook.Web.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Flexbook.Web.Controllers;

[Route("api/book/review")]
public class BookReviewController : Controller
{
    ILogger<BookReviewController> _logger;

    IBookReviewService _bookReviewService;
    IUserService _userService;
    IBookService _bookService;

    public BookReviewController(ILogger<BookReviewController> logger, 
        IBookReviewService bookReviewService, IUserService userService, IBookService bookService)
    {
        _logger = logger;

        _bookReviewService = bookReviewService;
        _userService = userService;
        _bookService = bookService;
    }

    [HttpGet("get_review")]
    public ActionResult GetReview(int review_id)
    {
        var bookReview = _bookReviewService.GetById(review_id);
        return Ok(bookReview);
    }

    [HttpPost("add_review")]
    public ActionResult AddReviewToBook([FromBody] BookReviewRequest bookReviewRequest)
    {
        BookReview bookReview = new BookReview()
        {
            Rating = bookReviewRequest.Rating,
            Content = bookReviewRequest.Content,
            User = _userService.GetById(bookReviewRequest.UserId),
            Book = _bookService.GetById(bookReviewRequest.BookId)
        };

        if (ModelState.IsValid)
            _bookReviewService.Insert(bookReview);

        return Ok();
    }

    [HttpGet("all_reviews/{book_id}")]
    public ActionResult ShowAllReviewsOfBook(int book_id)
    {
        var all_reviews = _bookReviewService.GetAllReviewsByBook(book_id);
        return Ok(all_reviews);
    }
}
