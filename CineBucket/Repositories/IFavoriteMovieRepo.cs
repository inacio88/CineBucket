using CineBucket.Models;

namespace CineBucket.Repositories;

public interface IFavoriteMovieRepo
{
    public Task<FavoriteMovie?> CreateAsync(FavoriteMovie favoriteMovie);
    public Task<FavoriteMovie?> UpdateAsync(FavoriteMovie favoriteMovie);
    public Task<FavoriteMovie?> GetByIdAsync(int id, string userId);
    public Task<FavoriteMovie?> DeleteByIdAsync(int id, string userId);
    public Task<FavoriteMovie?> GetByTmdbIdAsync(int tmdbId, string userId);
    public Task<List<FavoriteMovie>?> GetAllAsync(string userId);
}