using CineBucket.Models;

namespace CineBucket.Services;

public interface IServiceFavoriteMovie
{
    public Task<FavoriteMovie?> CreateAsync(int idTmdb, int priority, string userId);
    public Task<List<FavoriteMovie>?> GetAllAsync(string userId);
    public Task<FavoriteMovie?> GetByIdTmdbAsync(int idTmdb, string userId);
    public Task<FavoriteMovie?> DeleteByIdAsync(int id, string userId);
    public Task<FavoriteMovie?> UpdateByIdAsync(FavoriteMovie favoriteMovie);
}