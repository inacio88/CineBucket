using System.Diagnostics;
using CineBucket.Core.Services;
using CineBucket.Data;
using CineBucket.Models;
using CineBucket.Services;
using Microsoft.AspNetCore.Mvc;

namespace CineBucket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IServiceTMDBExternalApi _serviceTMDBExternalApi;
        private readonly IServiceFavoriteMovie _serviceFavoriteMovie;
        public MoviesController(ILogger<MoviesController> logger, 
            IServiceTMDBExternalApi serviceTMDBExternalApi,
            IServiceFavoriteMovie serviceFavoriteMovie
            )
        {
            _serviceTMDBExternalApi = serviceTMDBExternalApi;
            _logger = logger;
            _serviceFavoriteMovie = serviceFavoriteMovie;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            try
            {
                var movies = await _serviceTMDBExternalApi.GetPopularMoviesByPageAsync(page);
                return View(movies);
            }
            catch
            {
                return RedirectToAction("Error", "Movies");
            }
        }

        public async Task<IActionResult> DetailFullMovie(int movieId)
        {
            
            try
            {
                var movie = await _serviceTMDBExternalApi.GetMovieByIdAsync(movieId);

                if (movie is null)
                {
                    return RedirectToAction("Error", "Movies");
                }
                return View(movie);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Erro ao ver detalhes");
                return RedirectToAction("Error", "Movies");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddToList(int movieId, int priority)
        {
            try
            {
                await _serviceFavoriteMovie.CreateAsync(movieId, priority);
                return RedirectToAction("FavMoviesList", "Movies"); 
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Erro  ao adicionar à lista");
                return RedirectToAction("Error", "Movies");
            }
            
        }
        
        public async Task<IActionResult> FavMoviesList(int page = 1)
        {
            try
            {
                // var movies = await _serviceFavoriteMovie.GetAllAsync();
                // if(movies is null)
                //     return RedirectToAction("Error", "Movies");

                return RedirectToAction("Index", "Movies");
            }
            catch
            {
                return RedirectToAction("Error", "Movies");
            }
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}