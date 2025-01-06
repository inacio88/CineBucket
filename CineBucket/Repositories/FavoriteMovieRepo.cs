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
            var movie = await GetByIdAsync(favoriteMovie.Id, favoriteMovie.UserId);
            if (movie is null)
                return null;

            movie.Priority = favoriteMovie.Priority;
            movie.AddedAt = DateTime.Now.ToUniversalTime();
            _context.Update(movie);
            await _context.SaveChangesAsync();

            return movie;
        }
        catch
        {
            return null;
        }
    }

    public async Task<FavoriteMovie?> GetByIdAsync(int id, string userId)
    {
        try
        {
            return await _context.FavoriteMovies
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }
        catch
        {
            return null;
        }
    }

    public async Task<FavoriteMovie?> DeleteByIdAsync(int id, string userId)
    {
        try
        {
            var movie = await GetByIdAsync(id, userId);
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

    public async Task<FavoriteMovie?> GetByTmdbIdAsync(int tmdbId, string userId)
    {
        try
        {
            return await _context.FavoriteMovies
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync(x => x.TmdbId == tmdbId);
        }
        catch
        {
            return null;
        }
    }

    public async Task<List<FavoriteMovie>?> GetAllAsync(string userId)
    {
        try
        {
            var movies = await _context.FavoriteMovies
                .AsNoTracking()
                .Where(x => x.UserId == userId)
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