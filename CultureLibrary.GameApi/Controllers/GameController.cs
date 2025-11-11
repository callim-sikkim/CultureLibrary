using Microsoft.AspNetCore.Mvc;

namespace CultureLibrary.GameApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly List<string> _mock = new()
    {
        "A",
        "B",
        "C",
        "D",
        "E",
    };

    [HttpGet]
    public IActionResult GetGames()
    {
        return Ok(_mock);
    }

    [HttpGet("{id}")]
    public IActionResult GetGame(string id)
    {
        return Ok(_mock.FirstOrDefault());
    }
}