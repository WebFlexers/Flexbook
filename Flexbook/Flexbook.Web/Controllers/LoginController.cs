using System.IdentityModel.Tokens.Jwt;
using System.Net.Security;
using System.Security.Claims;
using System.Text;
using Flexbook.Data.Models.Users;
using Flexbook.Services.Session;
using Flexbook.Web.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Flexbook.Web.Controllers;

[Route("api/session")]
[ApiController]
public class LoginController : ControllerBase
{
    private IConfiguration _config;
    private ILoginService _loginService;

    public LoginController(IConfiguration config, ILoginService loginService)
    {
        _config = config;
        _loginService = loginService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
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
        var currentUser = _loginService.GetUserWithCredentials(userLoginRequest.Username, userLoginRequest.Password);
        return currentUser ?? null;
    }

    private string Generate(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var role = _loginService.GetUserType(user);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public UserLoginRequest GetCurrentUserLoginRequest()
    {
        if (HttpContext.User.Identity is not ClaimsIdentity identity) return null;
        
        var userClaims = identity.Claims;
        return new UserLoginRequest
        {
            Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
            Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
            Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
        };

    }
}