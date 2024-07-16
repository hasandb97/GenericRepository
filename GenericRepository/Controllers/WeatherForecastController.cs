using GenericRepository.Model;
using GenericRepository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GenericRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IGenericRepository<Student> _studentRepo;
        private readonly IGenericRepository<Book> _bookRepo;

        public WeatherForecastController(ILogger<WeatherForecastController> logger , IGenericRepository<Student> std , IGenericRepository<Book> bookrepo)
        {
            _logger = logger;
            _studentRepo = std;
            _bookRepo = bookrepo;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var myStdObj = new Student() {Id=1 , FName = "Hassan", LName = "Ansari" };
            _studentRepo.AddEntity(myStdObj);
            
            var items = _studentRepo.GetAll();


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
