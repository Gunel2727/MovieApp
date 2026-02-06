// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovieApp.BLL.Dtos.Director_Dtos;
using MovieApp.BLL.Interfaces;
using MovieApp.BLL.Profiles;
using MovieApp.BLL.Services;
using MovieApp.DAL.Concretes;
using MovieApp.DAL.Data;
using MovieApp.DAL.Interfaces;
using MovieApp.DAL.Models;


var serviceCollection = new ServiceCollection();
serviceCollection.AddDbContext<MovieAppDbContext>(options =>
{
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MovieAppDb;Trusted_Connection=True;TrustServerCertificate=True;");
});
serviceCollection.AddLogging();
serviceCollection.AddAutoMapper(options =>
{
    options.AddProfile<MapperProfile>();
});
serviceCollection.AddScoped<IDirectorService,DirectorService>();
serviceCollection.AddScoped<IMovieService,MovieService>();
serviceCollection.AddScoped(typeof(IRepository<>),typeof(Repository<>));
var serviceProvider = serviceCollection.BuildServiceProvider();
var directorService = serviceProvider.GetService<IDirectorService>();
var movieService = serviceProvider.GetService<IMovieService>();

var movie=await movieService.GetAllMoviesAsync(false,1,6,"Director");
