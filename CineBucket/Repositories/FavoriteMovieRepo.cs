using CineBucket.Data;
using CineBucket.Models;
using Microsoft.EntityFrameworkCore;

namespace CineBucket.Repositories;

public class FavoriteMovieRepo(AppDbContext context) : IFavoriteMovieRepo
{
    public async Task<FavoriteMovie?> CreateAsync(FavoriteMovie favoriteMovie)
    {
        try
        {
            await context.FavoriteMovies.AddAsync(favoriteMovie);
            await context.SaveChangesAsync();
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

            await context.SaveChangesAsync();

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
            return await context.FavoriteMovies
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

            context.FavoriteMovies.Remove(movie);
            await context.SaveChangesAsync();
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
            return await context.FavoriteMovies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TmdbId == tmdbId);
        }
        catch
        {
            return null;
        }
    }
    
}