using CineBucket.Models;

namespace CineBucket.Services;

public interface IServiceFavoriteMovie
{
    public Task<FavoriteMovie?> CreateAsync(int idTmdb, int priority, string userId);
    public Task<List<FavoriteMovie>?> GetAllAsync();
    public Task<FavoriteMovie?> GetByIdTmdbAsync(int idTmdb);
    public Task<FavoriteMovie?> DeleteByIdAsync(int id);
    public Task<FavoriteMovie?> UpdateByIdAsync(FavoriteMovie favoriteMovie);
}