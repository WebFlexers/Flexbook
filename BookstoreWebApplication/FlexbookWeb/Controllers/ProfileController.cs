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

        public ActionResult Login()
        {
            return View("Profile");
        }
    }
}
