using Microsoft.AspNetCore.Mvc;
using FlexbookData.Models;

namespace FlexbookWeb.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult LoginAuthor(Author author)
        {
            if (author.Username.Equals("Lefteris@gmail.com") && author.Password.Equals("12345"))
                return View("Profile", author);
            else
                return Content("Invalid credentials");
        }
    }
}
