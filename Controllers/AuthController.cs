using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SicemOperation.Entities;
using SicemOperation.Models;
using SicemOperation.Services;

namespace SicemOperation.Controllers;

public class AuthController(ILogger<AuthController> _logger, AuthService _authService) : Controller
{
    private readonly ILogger<AuthController> logger = _logger;
    private readonly AuthService authService = _authService;



    public IActionResult Login() {
        return View(new LoginRequest());
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginRequest request){
        if(! ModelState.IsValid ){
            return View(request);
        }
        var user = this.authService.ValidateUser(request);
        if( user == null){
            ViewBag.Message = "Usuario y/o contraseña incorrectos.";
            return View(request);
        }

        await LoginUser(user);

        return RedirectToAction("Index", "Home");
    }
    
    public async Task<ActionResult> Logout() {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }


    #region private functions
    private async Task LoginUser(Usuario user){
        var claims = new List<Claim> {
            new(ClaimTypes.Email, user.Correo),
            new(ClaimTypes.Name, user.Nombre),
            new(ClaimTypes.Role, "Administrator"),
            new(ClaimTypes.Actor, $"https://ui-avatars.com/api/?name={user.Nombre!.Replace(" ", "+")}&color=333&rounded=true"),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            //AllowRefresh = <bool>,
            // Refreshing the authentication session should be allowed.

            //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            // The time at which the authentication ticket expires. A 
            // value set here overrides the ExpireTimeSpan option of 
            // CookieAuthenticationOptions set with AddCookie.

            IsPersistent = true,
            // Whether the authentication session is persisted across 
            // multiple requests. When used with cookies, controls
            // whether the cookie's lifetime is absolute (matching the
            // lifetime of the authentication ticket) or session-based.

            //IssuedUtc = <DateTimeOffset>,
            // The time at which the authentication ticket was issued.

            //RedirectUri = <string>
            // The full path or absolute URI to be used as an http 
            // redirect response value.
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        logger.LogInformation("User {Email} logged in at {Time}.", user.Correo, DateTime.UtcNow);
    }
    #endregion

}
