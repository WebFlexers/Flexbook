using System.Net.Security;
using Flexbook.Data.Models.Users;
using Flexbook.Web.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flexbook.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private IConfiguration _config;

    public LoginController(IConfiguration config)
    {
        _config = config;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody] UserLoginRequest userLoginRequest)
    {
        var user = Authenticate(userLoginRequest);

        if (user != null)
        {
            var token = Generate(user);
            return Ok(token);
        }

        return NotFound("User not found");
    }

    private User Authenticate(UserLoginRequest userLoginRequest)
    {
        throw new NotImplementedException();
    }
    
    private string Generate(User user)
    {
        throw new NotImplementedException();
    }
}