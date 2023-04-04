using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("test")]
public class testController :ControllerBase 
{
    public testController()
    {

    }

    [HttpGet("hello")]
    public IActionResult Hello() 
    {
        Console.WriteLine("HEllo");
        return Ok();
    }
}