using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using SicemOperation.Data;
using SicemOperation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SicemOperationContext>( options =>{
    options.UseSqlServer( builder.Configuration.GetConnectionString("SicemOperation") );
});

// * configure authentication
builder.Services.Configure<CookiePolicyOptions>( o => {
    o.CheckConsentNeeded = (context) => true;
    o.MinimumSameSitePolicy = SameSiteMode.Unspecified;
});
builder.Services
    .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddKeycloakWebApp(
        builder.Configuration.GetSection(KeycloakAuthenticationOptions.Section),
        configureOpenIdConnectOptions: options => {
            options.SaveTokens = true;
            options.ResponseType = OpenIdConnectResponseType.Code;
            options.Events = new OpenIdConnectEvents {
                OnSignedOutCallbackRedirect = context =>
                {
                    context.Response.Redirect("/Home/Index");
                    context.HandleResponse();
                    return Task.CompletedTask;
                }
            };
        }
    );

builder.Services.AddKeycloakAuthorization(builder.Configuration)
    .AddAuthorizationBuilder()
    .AddPolicy("PrivacyAccess", policy => policy.RequireRealmRoles("Admin"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IncidenceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy(new CookiePolicyOptions {
    MinimumSameSitePolicy = SameSiteMode.Lax,
});


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
