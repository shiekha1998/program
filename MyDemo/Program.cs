using BlazorProducts.Server.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using MyDemo.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Adding Database Context factory to get the database Context object
builder.Services.AddDbContextFactory<DataContext>(x => x.UseSqlite(configuration.GetConnectionString("SqliteConnection")).UseSnakeCaseNamingConvention());
//Adding DatabaseContext with forcing snake case for database objects naming convention
builder.Services.AddDbContext<DataContext>(x=>x.UseSqlite(configuration.GetConnectionString("SqliteConnection")).UseSnakeCaseNamingConvention());
builder.Services.AddMudServices();
//builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
