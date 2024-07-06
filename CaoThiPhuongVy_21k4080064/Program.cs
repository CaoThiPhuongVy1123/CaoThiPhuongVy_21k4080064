using CaoThiPhuongVy_21k4080064.Data;
using CaoThiPhuongVy_21k4080064.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Blazored.LocalStorage;
using Microsoft.EntityFrameworkCore; // Thêm thư viện này

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<CategoryService>();
builder.Services.AddSingleton<TodoService>();
builder.Services.AddBlazoredLocalStorage();

// Thêm cấu hình cho AppDbContext sử dụng SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=weather.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();

    if (!context.WeatherForecasts.Any())
    {
        context.WeatherForecasts.AddRange(
            new WeatherForecast { Date = DateTime.Now.AddDays(1), TemperatureC = 25, Summary = "Mild" },
            new WeatherForecast { Date = DateTime.Now.AddDays(2), TemperatureC = 27, Summary = "Warm" },
            new WeatherForecast { Date = DateTime.Now.AddDays(3), TemperatureC = 30, Summary = "Hot" }
        );
        context.SaveChanges();
    }
}

app.Run();
