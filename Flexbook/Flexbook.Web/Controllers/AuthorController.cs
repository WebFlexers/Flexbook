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
