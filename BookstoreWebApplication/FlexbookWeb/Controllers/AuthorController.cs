using FlexbookServices;
using FlexbookData.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlexbookWeb.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;
        private IBaseService<Author> _authorService;

        public AuthorController(ILogger<AuthorController> logger, IBaseService<Author> authorService)
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

        [HttpPost("/authors/register/2")]
        public IActionResult AddAuthor()
        {
            Author author = new Author()
            {
                Username = "jeffKn",
                Password = "123456789",
                Fullname = "Jeff Kinney",
                Email = "jeffkinney@gmail.com",
                Address = new Address()
                {
                    Id = 0,
                    Name = "K Street NW",
                    Number = 1667,
                    City = "Ford Washington",
                    PostCode = "19100",
                    IsActive = true
                },
                PhoneNumber = "6983701433",
                ImageName = "image1.jpg",
                Age = 56,
                Description = "A very talented man!"
            };

            _authorService.Insert(author);

            return Ok();
        }

        [HttpPost("/authors/delete/2")]
        public IActionResult RemoveAuthor()
        {
            _authorService.Delete(new Author() { Id=2 });

            return Ok();
        }
    }
}
