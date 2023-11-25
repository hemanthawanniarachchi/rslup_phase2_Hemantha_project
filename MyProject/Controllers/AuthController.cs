
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System;
using System.Net.Mail;


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

    [HttpPost("forgotpassword")]
        public IActionResult ForgotPassword([FromBody] UserLoginModel loginModel)
        {
            try
            {
                
                if (!IsValidEmail(loginModel.Username))
                {
                    return BadRequest("Invalid email address");
                }

                // Dummy reset link
                string resetLink = "https://example.com/reset-password/token123";

                // Dummy email sending
                SendPasswordResetEmail(loginModel.Username, resetLink);

                return Ok("Password reset link sent successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void SendPasswordResetEmail(string email, string resetLink)
        {
            // Dummy implementation: Send email using SMTP
            

            var smtp = new SmtpClient
            {
                Host = "",
                Port = 587,
                Credentials = new System.Net.NetworkCredential("hemanthawanniarachi@gmail.com", "your-password"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("hemanthawanniarachi@gmail.com"),
                Subject = "Password Reset",
                Body = $"Click the following link to reset your password: {resetLink}",
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);
            smtp.Send(mailMessage);

            
        }
    }

