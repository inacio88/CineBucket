using System.Net.Http.Headers;
using CineBucket.Core.Configuracoes;
using CineBucket.Core.Responses;
using CineBucket.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineBucket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly HttpClient _clientHttp;
        public MoviesController(ILogger<MoviesController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientHttp = clientFactory.CreateClient(ConfiguracoesGerais.HttpClientName);
            _clientHttp.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfiguracoesGerais.ApiReadAccessToken);
        }

        public async Task<IActionResult> Index()
        {
            MoviePagedResponse movies;
            try
            {
                var response = await _clientHttp.GetAsync("/3/movie/popular?language=en-US&page=1");
                movies = await response.Content.ReadFromJsonAsync<MoviePagedResponse>() ?? new();
            }
            catch
            {
                throw new Exception("Erro ao carregar listas");
            }

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