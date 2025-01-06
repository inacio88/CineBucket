using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineBucket.Models;
using CineBucket.Core.Services;

namespace CineBucket.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IServiceTMDBExternalApi _serviceTMDBExternalApi;

    public HomeController(ILogger<HomeController> logger, IServiceTMDBExternalApi serviceTMDBExternalApi)
    {
        _logger = logger;
        _serviceTMDBExternalApi = serviceTMDBExternalApi;
    }

    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Home index");
        try
        {
            var movies = await _serviceTMDBExternalApi.GetTopRatedMoviesByPageAsync();
            return View(movies);
        }
        catch
        {
            return RedirectToAction("Error", "Home");
        }
    }

    public IActionResult Privacy()
    {
        _logger.LogInformation("Home privacy");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogInformation("Home Error");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
