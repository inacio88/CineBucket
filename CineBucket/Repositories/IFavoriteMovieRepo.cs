using CineBucket.Models;

namespace CineBucket.Repositories;

public interface IFavoriteMovieRepo
{
    public Task<FavoriteMovie?> CreateAsync(FavoriteMovie favoriteMovie);
    public Task<FavoriteMovie?> UpdateAsync(FavoriteMovie favoriteMovie);
    public Task<FavoriteMovie?> GetByIdAsync(int id);
    public Task<FavoriteMovie?> DeleteByIdAsync(int id);
    public Task<FavoriteMovie?> GetByTmdbIdAsync(int tmdbId);
}