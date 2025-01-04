using CineBucket.Data;
using CineBucket.Models;
using Microsoft.EntityFrameworkCore;

namespace CineBucket.Repositories;

public class FavoriteMovieRepo : IFavoriteMovieRepo
{
    private AppDbContext _context;
    public FavoriteMovieRepo(AppDbContext context)
    {
        _context = context;
    }
    public async Task<FavoriteMovie?> CreateAsync(FavoriteMovie favoriteMovie)
    {
        try
        {
            await  _context.FavoriteMovies.AddAsync(favoriteMovie);
            await _context.SaveChangesAsync();
            return favoriteMovie;
        }
        catch
        {
            return null;
        }
    }

    public async Task<FavoriteMovie?> UpdateAsync(FavoriteMovie favoriteMovie)
    {
        try
        {
            var movie = await GetByIdAsync(favoriteMovie.Id);
            if (movie is null)
                return null;

            movie.Priority = favoriteMovie.Priority;
            movie.AddedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return movie;
        }
        catch
        {
            return null;
        }
    }

    public async Task<FavoriteMovie?> GetByIdAsync(int id)
    {
        try
        {
            return await _context.FavoriteMovies
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);
        }
        catch
        {
            return null;
        }
    }

    public async Task<FavoriteMovie?> DeleteByIdAsync(int id)
    {
        try
        {
            var movie = await GetByIdAsync(id);
            if (movie is null)
                return null;

            _context.FavoriteMovies.Remove(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
        catch
        {
            return null;
        }
    }

    public async Task<FavoriteMovie?> GetByTmdbIdAsync(int tmdbId)
    {
        try
        {
            return await _context.FavoriteMovies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TmdbId == tmdbId);
        }
        catch
        {
            return null;
        }
    }

    public async Task<List<FavoriteMovie>?> GetAllAsync()
    {
        try
        {
            var movies = await _context.FavoriteMovies
                .AsNoTracking()
                .OrderByDescending(x => x.Priority)
                .ToListAsync();
            
            return movies;
        }
        catch
        {
            return null;
        }
    }
}