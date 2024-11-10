using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SicemOperation.Controllers;

public class AuthController(ILogger<AuthController> _logger) : Controller
{
    private readonly ILogger<AuthController> logger = _logger;
    
    [AllowAnonymous]
    public IActionResult Login() {
        if(!this.User.Identity!.IsAuthenticated){
            // trigger the authentication process
            return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
        }
        return RedirectToAction("Index", "Home");
    }

    [AllowAnonymous]
    public async Task<ActionResult> Logout() {
        if(!this.User.Identity!.IsAuthenticated){
            return this.Challenge(OpenIdConnectDefaults.AuthenticationScheme);
        }

        var idToken = await this.HttpContext.GetTokenAsync("id_token");
        var authResult = this.HttpContext.Features.Get<IAuthenticateResultFeature>()?.AuthenticateResult;
        var tokens = authResult!.Properties!.GetTokens();
        var tokenNames = tokens.Select( token => token.Name).ToArray();
        this.logger.LogInformation("Token Names: {TokenNames}", string.Join(", ", tokenNames));

        return this.SignOut(
            new AuthenticationProperties
            {
                RedirectUri = "/",
                Items = { { "id_token_hint", idToken } }
            },
            CookieAuthenticationDefaults.AuthenticationScheme,
            OpenIdConnectDefaults.AuthenticationScheme
        );
    }

    [AllowAnonymous]
    public IActionResult AccessDenied() => this.RedirectToAction("AccessDenied", "Home");

    [Route("/auth/user/me")]
    public IActionResult GetData(){
        return Ok(
            this.User.Claims.ToDictionary(c => c.Type, c => c.Value)
        );
    }

}
