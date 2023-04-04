using Microsoft.AspNetCore.Mvc;
// 모듈 뷰 컨트롤러
namespace Test.Controllers;

[ApiController] // 이 클래스가 apicontroller
[Route("[controller]")] // 클래스 이름을 자동으로 가지고와서 라우터 주소를 만들어준ㄴ다
// WeatherForecast 라우터로 들어오는 컨트롤러 클래스 : 컨트롤러 베이스를 상속받는다.
public class WeatherForecastController : Controller
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private int statusCode = 0;
    private string text = " ";
    private readonly ILogger<WeatherForecastController> _logger;

    //생성자
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }


    [HttpGet("GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

    }

// 오버로딩 : 이름은 같지만  매개변수가 다른 메서드를 구현하는 방식
// 오버라이딩 : 부모 클래스에서 정의된 메서드를 재정의 하는 것

    [HttpGet("state")]
    public IActionResult state(int number, string text = " ")
    {
        if(text == " ") { 
            Console.WriteLine("number");
            this.statusCode = number;
            if(statusCode == 404) {
                Console.WriteLine("Notfound"); 
                return NotFound();
            } 
            if(statusCode == 200) {
                Console.WriteLine("Ok"); 
                return Ok();
            } 
            Console.WriteLine("other");
            return Ok("넌 뭐니?");
        }
        else {
            Console.WriteLine("text");
            this.text = text;
            this.statusCode = number;
            if(statusCode == 404) {
                Console.WriteLine("Notfound"); 
                Console.WriteLine(text); 
                return NotFound(statusCode);
            } 
            if(statusCode == 200) {
                Console.WriteLine("Ok"); 
                Console.WriteLine(text); 
                return Ok(statusCode);
            } 
            Console.WriteLine("other");
            Console.WriteLine(text); 
            return Ok("넌 뭐니?");
        }
    }
    [HttpGet("test")]
    public IActionResult test()
    {
        string text = "";
        int num = 0;
        if (!String.IsNullOrEmpty(HttpContext.Request.Query["text"])) {
            text = HttpContext.Request.Query["text"];
        }
        if (!String.IsNullOrEmpty(HttpContext.Request.Query["number"]))
            num = Int32.Parse(HttpContext.Request.Query["number"]);
        Console.WriteLine(text);
        Console.WriteLine(num);
        return Ok("Hello"); 
    }
}
