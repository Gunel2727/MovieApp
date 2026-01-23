using System.IO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.BLL.Dtos.Director_Dtos;
using MovieApp.BLL.Interfaces;
using MovieApp.BLL.Profiles;
using MovieApp.DAL.Data;
using MovieApp.DAL.Models;

namespace MovieApp.BLL.Services
{
    public class DirectorService(
        MovieAppDbContext context,
        IMapper mapper
        ) : IDirectorService
    {
        //public List<DirectorReturnDto> GetAllDirectors()
        //{
        //    var directors = context.Directors.ToList();
        //    List<DirectorReturnDto> directorReturnDtos = new List<DirectorReturnDto>();
        //    foreach (var director in directors)
        //    {
        //        DirectorReturnDto directorReturn = new DirectorReturnDto()
        //        {
        //            Name = director.Name,
        //            Description = director.Description,
        //            City = director.City,
        //            Address = director.Address,
        //            Age = director.Age,
        //            Region = director.Region,
        //        };
        //        directorReturnDtos.Add(directorReturn);
        //    }
        //    return directorReturnDtos;
        //}


        public async Task<List<DirectorReturnDto>> GetAllDirectorsAsync()
        {
            var directors = await context.Directors
                .Include(d=>d.Movies)
                .ToListAsync();
            List<DirectorReturnDto> directorReturnDtos = mapper.Map<List<DirectorReturnDto>>(directors);
            return directorReturnDtos;
        }



        //public DirectorReturnDto GetDirectorById(int id)
        //{
        //    var existingdirector = context.Directors.FirstOrDefault(d => d.Id == id);
        //    if (existingdirector == null)
        //        throw new Exception();
        //    var directorReturnDto = mapper.Map<DirectorReturnDto>(existingdirector);
        //    return directorReturnDto;
        //}


        public async Task<DirectorReturnDto> GetDirectorByIdAsync(int id)
        {
            var existingdirector = await context.Directors.FirstOrDefaultAsync(d => d.Id == id);
            if (existingdirector == null)
                throw new Exception();
            var directorReturnDto = mapper.Map<DirectorReturnDto>(existingdirector);
            return directorReturnDto;
        }


        //public List<Director> GetAllDirectorsSearch(string value)
        //{
        //    if (string.IsNullOrWhiteSpace(value))
        //        throw new Exception();
        //    return context.Directors
        //        .Where(d => d.Name.Contains(value))
        //        .ToList();
        //}


        public async Task<List<DirectorReturnDto>> GetAllDirectorsSearchAsync(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
                throw new Exception();
            var directors= await context.Directors
                .Where(d => d.Name.Contains(value))
                .ToListAsync();
            var directorReturnDtos=mapper.Map<List<DirectorReturnDto>>(directors);
            return directorReturnDtos;
        }

        //public void Add(DirectorCreateDto directorCreateDto)
        //{
        //    if (context.Directors.Any(d => d.Name.Equals(directorCreateDto.Name, StringComparison.OrdinalIgnoreCase)))
        //        throw new Exception("Director already exists");
        //    var director = DirectorMapper.ToDirector(directorCreateDto);
        //    context.Directors.Add(director);
        //    context.SaveChanges();
        //}

        public async Task AddDirectorAsync(DirectorCreateDto directorCreateDto)
        {
            if (await context.Directors.AnyAsync(d => d.Name.Equals(directorCreateDto.Name)))
                throw new Exception("Director already exists");
            var director = DirectorMapper.ToDirector(directorCreateDto);
            await context.Directors.AddAsync(director);
            await context.SaveChangesAsync();
        }

        public async Task UpdateDirectorAsync(int id, DirectorUpdateDto directorUpdateDto)
        {
            if (id != directorUpdateDto.Id)
                throw new Exception();
            var existingDirector = await context.Directors.FirstOrDefaultAsync(d => d.Id == id);
            if (existingDirector == null)
                throw new Exception("Director not found");
            if (context.Directors.Any(d => d.Name == directorUpdateDto.Name && d.Id == id))
                throw new Exception();
            mapper.Map(directorUpdateDto, existingDirector);
            await context.SaveChangesAsync();
        }

        public async Task DeleteDirectorAsync(int id)
        {
            var existingDirector=await context.Directors.FirstOrDefaultAsync(d=>d.Id == id);
            if (existingDirector == null)
                throw new Exception("Director not found");
            context.Directors.Remove(existingDirector);
            await context.SaveChangesAsync();
        }
    }
}
