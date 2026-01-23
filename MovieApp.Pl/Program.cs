// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovieApp.BLL.Dtos.Director_Dtos;
using MovieApp.BLL.Interfaces;
using MovieApp.BLL.Profiles;
using MovieApp.BLL.Services;
using MovieApp.DAL.Data;


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
var serviceProvider = serviceCollection.BuildServiceProvider();
var directorService = serviceProvider.GetService<IDirectorService>();
var movieService = serviceProvider.GetService<IMovieService>();
var movies = await movieService.GetAllMoviesAsync();
foreach(var movie in movies)
    Console.WriteLine(movie.Title);


//var director = await directorService.GetDirectorByIdAsync(1);
//Console.WriteLine(director.Name);



//var directors = await directorService.GetAllDirectorsSearchAsync("a");
//foreach(var director in directors)
//    Console.WriteLine(director.Name);

//var newDirector = new DirectorCreateDto
//{
//    Name="Director Lorem",
//    Description="British-American film director",
//    Address="Los-Angeles, CA",
//    City="Los-Angeles",
//    Age=50,
//    Region="California"
//};
//await directorService.AddDirectorAsync(newDirector);