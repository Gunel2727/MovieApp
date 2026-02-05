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
using MovieApp.DAL.Interfaces;
using MovieApp.DAL.Models;

namespace MovieApp.BLL.Services
{
    public class MovieService(IRepository<Movie> _movierepo,IRepository<Director> _directorrepo, IMapper mapper) : IMovieService
    {
        public async Task<List<MovieReturnDto>> GetAllMoviesAsync(bool isTracking = false, int page = 1, int take = 2, params string[] includes)
        {
            var movieReturnDtos = await _movierepo.GetAll(isTracking,page,take,includes)
                .ProjectTo<MovieReturnDto>(mapper.ConfigurationProvider)
                .ToListAsync(); ;
            return movieReturnDtos;
        }

        public async Task<MovieReturnDto> GetMovieByIdAsync(int id)
        {

            var movie = await _movierepo.GetByIdAsync(id,false,"Director");
            if (movie == null)
                throw new Exception("Movie not found");
            return mapper.Map<MovieReturnDto>(movie);
        }
        public async Task<List<MovieReturnDto>> GetMoviesByDirectorAsync(int directorId)
        {
            var movieReturnDtos = await _movierepo.GetAll(false, m => m.DirectorId == directorId,"Director")
                .ProjectTo<MovieReturnDto>(mapper.ConfigurationProvider)
                .ToListAsync(); ;
            return movieReturnDtos;
        }

        public async Task<List<MovieReturnDto>> SearchMovieAsync(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
                throw new Exception("value cannot be empty");
            var movieReturnDtos = await _movierepo.GetAll(false, m => m.Title.Contains(searchValue) || m.Description.Contains(searchValue),"Director")
                 .ProjectTo<MovieReturnDto>(mapper.ConfigurationProvider)
                 .ToListAsync(); ;
            return movieReturnDtos;
        }

        public async Task AddMovieAsync(MovieCreateDto movieCreateDto)


        {
            if (await _movierepo.IsExistAsync(m => m.Title.Equals(movieCreateDto.Title)))
                throw new Exception("Movie with this title already exists");
            var directorExists = await _directorrepo.IsExistAsync(d => d.Id == movieCreateDto.DirectorId);
            if (!directorExists)
                throw new Exception("Director not found");
            var movie = mapper.Map<Movie>(movieCreateDto);
            await _movierepo.AddAsync(movie);
            await _movierepo.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(int id, MovieUpdateDto movieUpdateDto)
        {
            if (id != movieUpdateDto.Id)
                throw new Exception("Id mismatch");
            var existingMovie = await _movierepo.GetByIdAsync(id);
            if (existingMovie == null)
                throw new Exception("Movie not found");
            if (await _movierepo.IsExistAsync(m => m.Title == movieUpdateDto.Title && m.Id != id))
                throw new Exception("Movie with this title already exists");
            var directorExists = await _directorrepo.IsExistAsync(d => d.Id == movieUpdateDto.DirectorId);
            if (!directorExists)
                throw new Exception("Director not found");
            mapper.Map(movieUpdateDto, existingMovie);

            await _movierepo.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _movierepo.GetByIdAsync(id);
            if (movie == null)
                throw new Exception("Movie not found");
           _movierepo.Delete(movie);
            await _movierepo.SaveChangesAsync();
        }
    }
}
