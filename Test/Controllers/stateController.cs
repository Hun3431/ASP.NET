using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("state")]
public class stateController : ControllerBase
{
    public int number;
    public string text;
    public stateController()
    {

    }

    [HttpGet]
    public IActionResult State(int number)
    {
        if(number == 200) {
            Console.WriteLine(number);
            return Ok(number);
        }
        if (number == 404) {
            Console.WriteLine(number);
            return NotFound(number);
        }
        Console.WriteLine("넌 뭐니?");
        return Ok(number);
    }

    [HttpGet]
    public IActionResult State(int number, string text)
    {
        if(number == 200) {
            Console.WriteLine(number);
            Console.WriteLine(text);
            return Ok(number);
        }
        if (number == 404) {
            Console.WriteLine(number);
            Console.WriteLine(text);
            return NotFound(number);
        }
        Console.WriteLine("넌 뭐니?");
        Console.WriteLine(text);
        return Ok(number);
    }
}