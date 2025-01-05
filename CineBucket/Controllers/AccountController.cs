using CineBucket.Core.Requests;
using CineBucket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CineBucket.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        
    }
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (ModelState.IsValid)
        {
           var result = await _signInManager
               .PasswordSignInAsync(request.Username, request.Password, request.RememberMe, false);
           if (result.Succeeded)
           {
               return RedirectToAction("Index", "Movies");
           }
           ModelState.AddModelError(string.Empty, "Login ou senha incorretos");
           return View(request);
        }
        
        return View();
    }
    
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (ModelState.IsValid)
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
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            
        }
        return View(request);
    }
    
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
}