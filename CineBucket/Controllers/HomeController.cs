using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineBucket.Models;
using CineBucket.Core.Configuracoes;

namespace CineBucket.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Home index");
        return View();
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
