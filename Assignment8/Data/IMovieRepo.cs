using Assignment8.Models;

namespace Assignment8.Data
{
    public interface IMovieRepo
    {
        Task AddAsync(Movie movie);//
        IEnumerable<Movie> GetAll();//
        Task<IEnumerable<Movie>> GetAllAsync();//
        Task<Movie?> GetByIdAsync(int id);//
        Task<Movie?> GetByIdAsync(int? id);//
        Task RemoveAsync(Movie movie);//
        Task Update(Movie movie);//
        Task Save();//
    }
}
