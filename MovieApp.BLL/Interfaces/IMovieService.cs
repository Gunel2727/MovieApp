using MovieApp.BLL.Dtos.MovieDtos;

namespace MovieApp.BLL.Interfaces
{
    public interface IMovieService
    {
        Task AddMovieAsync(MovieCreateDto movieCreateDto);
        Task DeleteMovieAsync(int id);
        Task<List<MovieReturnDto>> GetAllMoviesAsync();
        Task<MovieReturnDto> GetMovieByIdAsync(int id);
        Task<List<MovieReturnDto>> GetMoviesByDirectorAsync(int directorId);
        Task<List<MovieReturnDto>> SearchMovieAsync(string searchValue);
        Task UpdateMovieAsync(int id, MovieUpdateDto movieUpdateDto);
    }
}