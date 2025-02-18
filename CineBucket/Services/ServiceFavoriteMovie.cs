using CineBucket.Core.Services;
using CineBucket.Models;
using CineBucket.Repositories;

namespace CineBucket.Services;

public class ServiceFavoriteMovie(IFavoriteMovieRepo repo,
    IServiceTMDBExternalApi _serviceTMDBExternalApi
    ) : IServiceFavoriteMovie
{
    public async Task<FavoriteMovie?> CreateAsync(int movieId, int priority, string userId)
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
                    ReleaseDate = fullMovie.ReleaseDate?.ToUniversalTime(),
                    Status = fullMovie.Status,
                    Priority = priority,
                    TmdbId = movieId,
                    AddedAt = DateTime.Now.ToUniversalTime(),
                    UserId = userId
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

    public async Task<List<FavoriteMovie>?> GetAllAsync(string userId)
    {
        try
        {
            return await repo.GetAllAsync(userId);
        }
        catch
        {
            return null;
        }
    }

    public async Task<FavoriteMovie?> GetByIdTmdbAsync(int idTmdb, string userId)
    {
        try
        {
            return await repo.GetByTmdbIdAsync(idTmdb, userId);
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
            return await repo.DeleteByIdAsync(id, userId);
        }
        catch
        {
            return null;
        }
    }

    public async Task<FavoriteMovie?> UpdateByIdAsync(FavoriteMovie favoriteMovie)
    {
        try
        {
            return await repo.UpdateAsync(favoriteMovie);
        }
        catch
        {
            return null;
        }
    }
}