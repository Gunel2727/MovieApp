using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MovieApp.BLL.Dtos.MovieDtos;
using MovieApp.BLL.Interfaces;
using MovieApp.DAL.Data;
using MovieApp.DAL.Models;

namespace MovieApp.BLL.Services
{
    public class MovieService(MovieAppDbContext context, IMapper mapper) : IMovieService
    {
        public async Task<List<MovieReturnDto>> GetAllMoviesAsync()
        {
            var movieReturnDtos = await context.Movies
                .ProjectTo<MovieReturnDto>(mapper.ConfigurationProvider)
                .ToListAsync(); ;
            return movieReturnDtos;
        }

        public async Task<MovieReturnDto> GetMovieByIdAsync(int id)
        {

            var movieReturnDtos = await context.Movies
                .Where(m => m.Id == id)
                .ProjectTo<MovieReturnDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (movieReturnDtos == null)
                throw new Exception("Movie not found");
            return movieReturnDtos;
        }
        public async Task<List<MovieReturnDto>> GetMoviesByDirectorAsync(int directorId)
        {
            var movieReturnDtos = await context.Movies
                .Where(m => m.DirectorId == directorId)
                .ProjectTo<MovieReturnDto>(mapper.ConfigurationProvider)
                .ToListAsync(); ;
            return movieReturnDtos;
        }

        public async Task<List<MovieReturnDto>> SearchMovieAsync(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
                throw new Exception("value cannot be empty");
            var movieReturnDtos = await context.Movies
                 .Where(m => m.Title.Contains(searchValue) || m.Description.Contains(searchValue))
                 .ProjectTo<MovieReturnDto>(mapper.ConfigurationProvider)
                 .ToListAsync(); ;
            return movieReturnDtos;
        }

        public async Task AddMovieAsync(MovieCreateDto movieCreateDto)


        {
            if (await context.Movies.AnyAsync(m => m.Title.Equals(movieCreateDto.Title)))
                throw new Exception("Movie with this title already exists");
            var directorExists = await context.Directors.AnyAsync(d => d.Id == movieCreateDto.DirectorId);
            if (!directorExists)
                throw new Exception("Director not found");
            var movie = mapper.Map<Movie>(movieCreateDto);
            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(int id, MovieUpdateDto movieUpdateDto)
        {
            if (id != movieUpdateDto.Id)
                throw new Exception("Id mismatch");
            var existingMovie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (existingMovie == null)
                throw new Exception("Movie not found");
            if (await context.Movies.AnyAsync(m => m.Title == movieUpdateDto.Title && m.Id != id))
                throw new Exception("Movie with this title already exists");
            var directorExists = await context.Directors.AnyAsync(d => d.Id == movieUpdateDto.DirectorId);
            if (!directorExists)
                throw new Exception("Director not found");
            mapper.Map(movieUpdateDto, existingMovie);

            await context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
                throw new Exception("Movie not found");
            context.Movies.Remove(movie);
            await context.SaveChangesAsync();
        }
    }
}
