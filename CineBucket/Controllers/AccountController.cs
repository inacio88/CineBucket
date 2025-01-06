using CineBucket.Core.Requests;
using CineBucket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CineBucket.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<AccountController> _logger;
    public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<AccountController> logger)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _logger = logger;

    }
    public IActionResult Login()
    {
        _logger.LogInformation("Login GET");

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var result = await _signInManager
                 .PasswordSignInAsync(request.Username, request.Password, request.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("FavMoviesList", "Movies");
                }
                ModelState.AddModelError(string.Empty, "Login ou senha incorretos");
                _logger.LogInformation("Login Post valido");
                return View(request);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }
        _logger.LogInformation("Login Post invalido");

        return View();
    }

    public IActionResult Register()
    {
        _logger.LogInformation("Register get");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (ModelState.IsValid)
        {
            try
            {
                AppUser user = new()
                {
                    Name = request.Name,
                    UserName = request.Email,
                    Email = request.Email,
                    Address = request.Address
                };

                var result = await _userManager.CreateAsync(user, request.Password!);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    _logger.LogInformation("Register Post valido");
                    return RedirectToAction("FavMoviesList", "Movies");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }

        }
        _logger.LogInformation("Register Post invalido");
        return View(request);
    }

    public async Task<IActionResult> Logout()
    {
        _logger.LogInformation("logout saindo");
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
}