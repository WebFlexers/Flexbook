using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Flexbook.Data.Models.Users;
using Flexbook.Services.Session;
using Flexbook.Services.Users.User;
using Flexbook.Web.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Flexbook.Web.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private IConfiguration _config;
    private ILoginService _loginService;
    private IUserService _userService;

    public AuthController(IConfiguration config, ILoginService loginService, IUserService userService)
    {
        _config = config;
        _loginService = loginService;
        _userService = userService;
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
    
    [Authorize]
    [HttpGet("user")]
    public User GetUserByToken()
    {
        if (HttpContext.User.Identity is not ClaimsIdentity identity) return null;
        
        var userEmail = identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
        return userEmail != null ? _userService.GetByEmail(userEmail) : null;
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
}