using Microsoft.AspNetCore.Mvc;

namespace flexbook.web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly ILogger<ShoppingController> _logger;

        public ShoppingController(ILogger<ShoppingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/api/shopping")]
        public ActionResult GetShopping()
        {
            return Ok("I am shoppin'");
        }
    }
}