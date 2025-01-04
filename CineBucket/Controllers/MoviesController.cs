using CineBucket.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CineBucket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IServiceTMDBExternalApi _serviceTMDBExternalApi;
        public MoviesController(ILogger<MoviesController> logger, IServiceTMDBExternalApi serviceTMDBExternalApi)
        {
            _serviceTMDBExternalApi = serviceTMDBExternalApi;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var movies = await _serviceTMDBExternalApi.GetPopularMoviesByPageAsync(page);
            return View(movies);
        }

        // public async Task<IActionResult> Index()
        // {

        //     try
        //     {
        //         var response = await _clientHttp.GetAsync("/3/movie/558449");
        //         //var response = await _clientHttp.GetFromJsonAsync<Movie?>("/3/movie/23");
        //         var movie = await response.Content.ReadFromJsonAsync<MovieResponse>();
        //         // if (response.IsSuccessStatusCode)
        //         // {
        //         //     var conteudo = await response.Content.ReadAsStringAsync();

        //         //     return Ok(conteudo);
        //         // }
        //         // else
        //         // {
        //         //     return StatusCode((int)response.StatusCode, "Erro ao chamar a API externa.");
        //         // }
        //         var dd = 3;
        //     }
        //     catch
        //     {
        //         var ff = 3;
        //     }
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}