using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Hello()
    {
        return Ok("Hello, World!");
    }
}
