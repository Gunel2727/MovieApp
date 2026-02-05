using System.IO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.BLL.Dtos.Director_Dtos;
using MovieApp.BLL.Interfaces;
using MovieApp.BLL.Profiles;
using MovieApp.DAL.Data;
using MovieApp.DAL.Interfaces;
using MovieApp.DAL.Models;

namespace MovieApp.BLL.Services
{
    public class DirectorService(
        IRepository<Director> _directorrepo,
        IMapper mapper
        ) : IDirectorService
    {
        public async Task<List<DirectorReturnDto>> GetAllDirectorsAsync()
        {
            var directors = await _directorrepo.GetAll(false,null,"Movies")
                .ToListAsync();
            List<DirectorReturnDto> directorReturnDtos = mapper.Map<List<DirectorReturnDto>>(directors);
            return directorReturnDtos;
        }

        public async Task<DirectorReturnDto> GetDirectorByIdAsync(int id)
        {
            var existingdirector = await _directorrepo.GetByIdAsync(id);
            if (existingdirector == null)
                throw new Exception();
            var directorReturnDto = mapper.Map<DirectorReturnDto>(existingdirector);
            return directorReturnDto;
        }

        public async Task<List<DirectorReturnDto>> GetAllDirectorsSearchAsync(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
                throw new Exception();
            var directors= await _directorrepo.GetAll(false,d=>d.Name.Contains(value),"Movies")
                .ToListAsync();
            var directorReturnDtos=mapper.Map<List<DirectorReturnDto>>(directors);
            return directorReturnDtos;
        }

        public async Task AddDirectorAsync(DirectorCreateDto directorCreateDto)
        {
            if (await _directorrepo.IsExistAsync(d => d.Name.Equals(directorCreateDto.Name)))
                throw new Exception("Director already exists");
            var director = DirectorMapper.ToDirector(directorCreateDto);
            await _directorrepo.AddAsync(director);
            await _directorrepo.SaveChangesAsync();
        }

        public async Task UpdateDirectorAsync(int id, DirectorUpdateDto directorUpdateDto)
        {
            if (id != directorUpdateDto.Id)
                throw new Exception();
            var existingDirector = await _directorrepo.GetByIdAsync(id);
            if (existingDirector == null)
                throw new Exception("Director not found");
            if (await _directorrepo.IsExistAsync(d => d.Name == directorUpdateDto.Name && d.Id == id))
                throw new Exception();
            mapper.Map(directorUpdateDto, existingDirector);
            await _directorrepo.SaveChangesAsync();
        }

        public async Task DeleteDirectorAsync(int id)
        {
            var existingDirector=await _directorrepo.GetByIdAsync(id);
            if (existingDirector == null)
                throw new Exception("Director not found");
            _directorrepo.Delete(existingDirector);
            await _directorrepo.SaveChangesAsync();
        }
    }
}
