using Microsoft.EntityFrameworkCore;
using Assignment8.Models;

namespace Assignment8.Data;

public class MovieRepoEF : IMovieRepo
{
    private readonly RazorPagesMovieContext _context;

    public MovieRepoEF(RazorPagesMovieContext context)
    {
        _context = context;
    }

    public IEnumerable<Assignment8.Models.Movie> GetAll()//
    {
        return _context.Movie.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToList();
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()//
    {
        return await _context.Movie.ToListAsync();  
    }


    public async Task<Assignment8.Models.Movie?> GetByIdAsync(int id)//
    {
        return await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
    }


    public async Task<Assignment8.Models.Movie?> GetByIdAsync(int? id)//
    {
        return await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Movie movie)//
    {
        _context.Movie.Add(movie);
        await _context.SaveChangesAsync();
    }
   
    public async Task RemoveAsync(Movie movie)//
    {
        _context.Movie.Remove(movie);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Movie movie)
    {
        _context.Attach(movie).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

     public async Task Save()//
    {
        await _context.SaveChangesAsync();
    }
}

