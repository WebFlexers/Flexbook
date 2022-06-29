using Flexbook.Data.Models.Users;
using Flexbook.Data.Models.Users.Components;
using Flexbook.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flexbook.Web.Controllers;
public class AuthorController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private ICrudService<Author> _authorService;

    public AuthorController(ILogger<AuthorController> logger, ICrudService<Author> authorService)
    {
        _authorService = authorService;
        _logger = logger;
    }

    [HttpGet("/authors/{id}")]
    public IActionResult GetAuthor(int id)
    {
        var author = _authorService.GetById(id);
        return Ok(author);
    }

    [HttpPost("/authors/register")]
    public IActionResult AddAuthor()
    {
        Author author = new Author()
        {
            Username = "jeffKn",
            Password = "123456",
            Fullname = "Jeff Kinney",
            Email = "jeffkinney@gmail.com",
            Address = new Address
            {
                Street = "K Street NW",
                Number = 167,
                City = "Ford Washington",
                PostCode = "19100",
                IsActive = true
            },
            PhoneNumber = "6983701433",
            Image = "author_jeffKn.jpg",
            BirthDate = new DateTime(2001, 11, 23).ToUniversalTime(),
            Description = "A very talented man!"
        };

        _authorService.Insert(author);

        return Ok();
    }

    [HttpPost("/authors/delete/{id}")]
    public IActionResult RemoveAuthor(int id)
    {
        _authorService.Delete(_authorService.GetById(id));
        return Ok();
    }
}
