using Microsoft.AspNetCore.Mvc;

namespace Flexbook.Web.Controllers;

[Route("api/author/")]
[ApiController]
public class ForumController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
