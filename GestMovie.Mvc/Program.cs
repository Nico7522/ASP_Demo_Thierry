
using System.Data.Common;
using System.Data.SqlClient;

using DR = GestMovie.Mvc.Models.Data.Repositories;
using DS = GestMovie.Mvc.Models.Data.Services;

using GestMovie.Mvc.Models.Business.Repositories;
using GestMovie.Mvc.Models.Business.Services;

namespace GestMovie.Mvc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<DbConnection, SqlConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("Default")));
        builder.Services.AddScoped<DR.IMovieRepository, DS.MovieService>();
        builder.Services.AddScoped<IMovieRepository, MovieService>();


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

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}