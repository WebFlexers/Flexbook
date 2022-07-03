using Flexbook.Data.Models.Users;
using Flexbook.Data.Models.Users.Components;
using Flexbook.Services;
using Flexbook.Web.RequestModels;
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
    public IActionResult AddAuthor([FromBody] AuthorRequest authorRequest)
    {
        Author author = new Author
        {
            Username = authorRequest.Username,
            Password = authorRequest.Password,
            Fullname = authorRequest.Fullname,
            Email = authorRequest.Email,
            Address = new Address
            {
                Street = authorRequest.Street,
                Number = authorRequest.Number,
                City = authorRequest.City,
                PostCode = authorRequest.PostCode,
            },
            PhoneNumber = authorRequest.PhoneNumber,
            Image = authorRequest.Image,
            BirthDate = authorRequest.BirthDate,
            Description = authorRequest.Description,
            Role = authorRequest.Role
        };

        if(ModelState.IsValid)
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
