using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[Route("api/flights")]
[ApiController]
public class FlightController : ControllerBase
{
    private static List<Flight> flights = new List<Flight>
    {
        new Flight { Id = 1, FlightNumber = "ABC123", DepartureCity = "CityA", ArrivalCity = "CityB", DepartureTime = DateTime.Now.AddHours(1) },
        new Flight { Id = 2, FlightNumber = "XYZ789", DepartureCity = "CityC", ArrivalCity = "CityD", DepartureTime = DateTime.Now.AddHours(2) }
    };

    [HttpGet]
    public IActionResult GetFlights()
    {
        return Ok(flights);
    }

    [HttpGet("{id}")]
    public IActionResult GetFlightById(int id)
    {
        var flight = flights.Find(f => f.Id == id);
        if (flight == null)
        {
            return NotFound();
        }

        return Ok(flight);
    }
}

public class Flight
{
    public int Id { get; set; }
    public string FlightNumber { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public DateTime DepartureTime { get; set; }
}
