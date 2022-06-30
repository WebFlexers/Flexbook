using Flexbook.Data.Models.Users;
using Flexbook.Data.Models.Users.Components;
using Flexbook.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flexbook.Web.Controllers;

[Route("api/authors")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private ICrudService<Author> _authorService;

    public AuthorController(ILogger<AuthorController> logger, ICrudService<Author> authorService)
    {
        _authorService = authorService;
        _logger = logger;
    }

    [HttpGet("get/{id}")]
    public IActionResult GetAuthor(int id)
    {
        var author = _authorService.GetById(id);
        return Ok(author);
    }

    [HttpPost("register")]
    public IActionResult AddAuthor()
    {
        Author author = new Author
        {
            Username = "varoufakis",
            Password = "1234567",
            Fullname = "Gianis Varoufaki",
            Email = "sotirasTisElladas@gmail.com",
            Address = new Address
            {
                Street = "Eyergeton",
                Number = 13,
                City = "Paleo Faliro",
                PostCode = "17565",
                IsActive = true
            },
            PhoneNumber = "6936988704",
            Image = "author_varoufakis.jpg",
            BirthDate = new DateTime(2001, 11, 23).ToUniversalTime(),
            Description = "A very talented man!"
        };

        _authorService.Insert(author);

        return Ok();
    }

    [HttpPost("delete/{id}")]
    public IActionResult RemoveAuthor(int id)
    {
        _authorService.Delete(_authorService.GetById(id));
        return Ok();
    }
}
