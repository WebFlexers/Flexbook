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
    private IAuthorService _authorService;

    public AuthorController(ILogger<AuthorController> logger, IAuthorService authorService)
    {
        _logger = logger;
        _authorService = authorService;
    }

    [HttpGet("get/{id}")]
    public IActionResult GetAuthor(int id)
    {
        var author = _authorService.GetById(id);
        return Ok(author);
    }

    [HttpGet("get_by_name/{fullname}")]
    public IActionResult GetAuthorByName(string fullname)
    {
        var author = _authorService.GetAuthorByName(fullname);
        return Ok(author);
    }
    
    [HttpGet("get_by_email/{email}")]
    public IActionResult GetAuthorByEmail(string email)
    {
        var author = _authorService.GetAuthorByEmail(email);
        return Ok(author);
    }

    [HttpGet("get_all")]
    public IActionResult GetAllAuthors()
    {
        var authors = _authorService.GetAllAuthors();
        return Ok(authors);
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
                Street = authorRequest.Address.Street,
                Number = authorRequest.Address.Number,
                City = authorRequest.Address.City,
                PostCode = authorRequest.Address.PostCode,
            },
            PhoneNumber = authorRequest.PhoneNumber,
            Image = authorRequest.Image,
            BirthDate = authorRequest.BirthDate,
            Description = authorRequest.Description,
            Role = authorRequest.Role
        };

        if (ModelState.IsValid)
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
