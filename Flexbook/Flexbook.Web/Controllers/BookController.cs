using Flexbook.Data.Models.Products;
using Flexbook.Data.Models.Users;
using Flexbook.Data.Models.Users.Components;
using Flexbook.Services;
using Flexbook.Services.Books;
using Flexbook.Web.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Flexbook.Web.Controllers;

[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private IBookService _bookService;
    private ICrudService<Author> _authorService;

    public BookController(ILogger<BookController> logger, IBookService bookService, ICrudService<Author> authorService)
    {
        _bookService = bookService;
        _authorService = authorService;
        _logger = logger;
    }

    [HttpGet("get/{id}")]
    public IActionResult GetBook(int id)
    {
        var book = _bookService.GetById(id);
        return Ok(book);
    }

    [HttpGet("get_all")]
    public IActionResult GetAllBooks()
    {
        var books = _bookService.GetAllBooks();
        return Ok(books);
    }

    [HttpPost("create")]
    public IActionResult CreateBook([FromBody] BookRequest bookRequest)
    {
        var datetimeNow = DateTime.Now.ToUniversalTime();
        
        Book book = new Book
        {
            CreatedOn = datetimeNow,
            UpdatedOn = datetimeNow,
            Title = bookRequest.Title,
            Description = bookRequest.Description,
            Image = bookRequest.Image,
            StartingPrice = bookRequest.StartingPrice,
            FinalPrice = bookRequest.FinalPrice,
            ISBN = bookRequest.ISBN,
            Genre = bookRequest.Genre,
            Publisher = bookRequest.Publisher,
            PageCount = bookRequest.PageCount,
            Language = bookRequest.Language,
            Summary = bookRequest.Summary,
            Author = _authorService.GetById(bookRequest.AuthorId)
        };

        _bookService.Insert(book);

        return Ok();
    }

    [HttpPost("delete/{id}")]
    public IActionResult RemoveAuthor(int id)
    {
        _bookService.Delete(_bookService.GetById(id));
        return Ok();
    }
}