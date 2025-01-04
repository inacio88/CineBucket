using CineBucket.Core.Services;
using CineBucket.Models;
using CineBucket.Repositories;

namespace CineBucket.Services;

public class ServiceFavoriteMovie(IFavoriteMovieRepo repo,
    IServiceTMDBExternalApi _serviceTMDBExternalApi
    ) : IServiceFavoriteMovie
{
    public async Task<FavoriteMovie?> CreateAsync(int movieId, int priority)
    {
        var fullMovie = await _serviceTMDBExternalApi.GetMovieByIdAsync(movieId);
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
                    ReleaseDate = fullMovie.ReleaseDate.ToUniversalTime(),
                    Status = fullMovie.Status,
                    Priority = priority,
                    TmdbId = movieId,
                    AddedAt = DateTime.Now.ToUniversalTime()
                }
                ;

            await repo.CreateAsync(favmovie);

            return favmovie;
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
            //return await repo.GetAllAsync();
            return new List<FavoriteMovie>();
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