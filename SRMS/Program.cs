using Microsoft.AspNetCore.Authentication.Cookies;
using SRMS.Context;
using SRMS.Infrastructure;
using SRMS.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<IUserAccess, UserAccess>();
builder.Services.AddScoped<IStudent, StudentRepo>();
builder.Services.AddScoped<IResultRepo, ResultRepo>();
builder.Services.AddScoped<IStudentResult, StudentResultRepo>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.ExpireTimeSpan = TimeSpan.FromMinutes(60 * 1);
        option.LoginPath = "/Home/Index";
        option.AccessDeniedPath = "/Home/Index";
    });
builder.Services.AddSession(option =>
    {
        option.IdleTimeout = TimeSpan.FromMinutes(5);
        option.Cookie.HttpOnly = true;
        option.Cookie.IsEssential = true;
    });

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

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
