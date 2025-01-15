using BAWLib;
using BAWLib.Configs;
using Bike_Around_Worlds.Components;
using Domain.Interfaces;
using Domain.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/accessdenied";
    });

 

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddDbContextFactory<MotorContext>(
    options => options.UseMySql(builder.Configuration
            .GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    )
);

builder.Services.AddTransient<IRepository<Motorbike>,BikeRepository>();
builder.Services.AddTransient<IRepository<Groups>,GroupRepository>();
builder.Services.AddTransient<IRepository<Favorite>, FavoriteRepository>();
builder.Services.AddTransient<IRepository<User>, UserRepository>();
builder.Services.AddTransient<IRepository<LeasingContract>, LeasingContractRepository>();
builder.Services.AddTransient<IRepository<Waypoint>, WaypointsRepository>();


builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();



app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();