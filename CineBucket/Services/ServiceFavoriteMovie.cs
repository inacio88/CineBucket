using CineBucket.Core.Services;
using CineBucket.Models;
using CineBucket.Repositories;

namespace CineBucket.Services;

public class ServiceFavoriteMovie(IFavoriteMovieRepo repo, IServiceTMDBExternalApi externalApi) : IServiceFavoriteMovie
{
    public async Task<FavoriteMovie?> CreateAsync(int idTmdb, int priority)
    {
        var fullMovie = await externalApi.GetMovieByIdAsync(idTmdb);
        if (fullMovie is null)
            return null;
        
        try
        {
            var favmovie = new FavoriteMovie
                {
                    Title = fullMovie.Title,
                    OriginalTitle = fullMovie.OriginalTitle,
                    Runtime = fullMovie.Runtime,
                    PosterPath = fullMovie.PosterPath,
                    ReleaseDate = fullMovie.ReleaseDate,
                    Status = fullMovie.Status,
                    Priority = priority,
                    TmdbId = idTmdb,
                    AddedAt = DateTime.Now.ToUniversalTime()
                }
                ;
            var movie = await repo.CreateAsync(favmovie);
            return movie;
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
            return await repo.GetAllAsync();
        }
        catch
        {
            return null;
        }
    }

    public async Task<FavoriteMovie?> GetByIdTmdb(int idTmdb)
    {
        try
        {
            return await repo.GetByTmdbIdAsync(idTmdb);
        }
        catch
        {
            return null;
        }
    }
}