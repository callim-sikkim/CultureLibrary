using Microsoft.AspNetCore.Mvc;

namespace CultureLibrary.API.BookApi;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly List<string> _mock = new()
    {
        "Test",
        "test2"
    };
    
    [HttpGet]
    public IActionResult GetBooks()
    {
        return Ok(_mock);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetBook(string id)
    {
        return Ok(_mock.First());
    }
}