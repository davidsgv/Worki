using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Worki.Data;
using Worki.Data.Models;
using Worki.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

var connectionString = builder.Configuration.GetConnectionString("WorkiContextConnection");
builder.Services.AddDbContext<WorkiContext>();
// builder.Services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Enable cookie authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie();

//builder.Services.AddIdentity<UsuUsuario, IdentityRole>(cfg =>
//{
//    cfg.User.RequireUniqueEmail = true;
//    cfg.Password.RequireDigit = false;
//    cfg.Password.RequiredUniqueChars = 0;
//    cfg.Password.RequireLowercase = false;
//    cfg.Password.RequireNonAlphanumeric = false;
//    cfg.Password.RequireUppercase = false;
//}).AddEntityFrameworkStores<WorkiContext>();

//builder.Services.AddDbContext<WorkiContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
