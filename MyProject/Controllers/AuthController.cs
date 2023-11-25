
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

     private static List<User> users = new List<User>
    {
        new User { Id = 1, Username = "user1", Password = "password1" },
        new User { Id = 2, Username = "user2", Password = "password2" }
        
    };

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginModel loginModel)
    {
        var user = users.Find(u => u.Username == loginModel.Username && u.Password == loginModel.Password);

        if (user == null)
        {
            return Unauthorized();
        }

        var token = _authService.GenerateToken(user);

        return Ok(new { user, token });
    }
}
