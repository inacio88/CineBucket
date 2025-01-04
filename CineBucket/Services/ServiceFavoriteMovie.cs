using CineBucket.Models;
using CineBucket.Repositories;

namespace CineBucket.Services;

public class ServiceFavoriteMovie(IFavoriteMovieRepo repo) : IServiceFavoriteMovie
{
    public async Task<FavoriteMovie?> Create(int idTmdb, int priority)
    {
        try
        {
            var favmovie = new FavoriteMovie {Priority = priority, TmdbId = idTmdb, AddedAt = DateTime.UtcNow};
            var movie = await repo.CreateAsync(favmovie);
            return movie;
        }
        catch
        {
            return null;
        }
    }
}