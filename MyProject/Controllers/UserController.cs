
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private static List<User> users = new List<User>
    {
        new User { Id = 1, Username = "user1", Password = "password1" },
        new User { Id = 2, Username = "user2", Password = "password2" }
        
    };

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = users.Find(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User newUser)
    {
        newUser.Id = users.Count + 1;
        users.Add(newUser);

        return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
    {
        var existingUser = users.Find(u => u.Id == id);

        if (existingUser == null)
        {
            return NotFound();
        }

        existingUser.Username = updatedUser.Username;
        existingUser.Password = updatedUser.Password;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = users.Find(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        users.Remove(user);

        return NoContent();
    }
}
