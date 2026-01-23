using MovieApp.BLL.Dtos.Director_Dtos;
using MovieApp.DAL.Models;

namespace MovieApp.BLL.Interfaces
{
    public interface IDirectorService
    {
        Task AddDirectorAsync(DirectorCreateDto directorCreateDto);
        Task<List<DirectorReturnDto>> GetAllDirectorsAsync();
        Task<List<DirectorReturnDto>> GetAllDirectorsSearchAsync(string value);
        Task<DirectorReturnDto> GetDirectorByIdAsync(int id);
        Task UpdateDirectorAsync(int id, DirectorUpdateDto directorUpdateDto);
        Task DeleteDirectorAsync(int id);
    }
}