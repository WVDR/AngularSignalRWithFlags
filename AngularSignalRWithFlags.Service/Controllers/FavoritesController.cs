using Microsoft.AspNetCore.Mvc;

namespace AngularSignalRWithFlags.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoritesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "No Commnet"
        };

        private readonly ILogger<FavoritesController> _logger;

        public FavoritesController(ILogger<FavoritesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetFavorites")]
        public IEnumerable<Favorites> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Favorites
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Picture = new byte[] { },
                Comment = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}