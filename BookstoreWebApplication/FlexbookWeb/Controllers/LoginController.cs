using Microsoft.AspNetCore.Mvc;
using FlexbookData.Models;

namespace FlexbookWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public const string SessionUserID = "_ID";
        public const string SessionName = "_Name";        

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult LoginAuthor(Author author)
        {
            if (author.Username.Equals("Lefteris@gmail.com") && author.Password.Equals("12345"))
            {
                HttpContext.Session.SetString(SessionUserID, "252001");
                HttpContext.Session.SetString(SessionName, "Lefteris Kontouris");

                _logger.LogInformation("Session Name {ID}", SessionUserID);
                _logger.LogInformation("Session Name {Name}", SessionName);

                return RedirectToAction("Index", "Profile", author);
            }                
            else
                return Content("Invalid credentials");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
