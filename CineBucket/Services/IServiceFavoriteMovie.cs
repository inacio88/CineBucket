using CineBucket.Models;

namespace CineBucket.Services;

public interface IServiceFavoriteMovie
{
    public Task<FavoriteMovie?> CreateAsync(int idTmdb, int priority);
    public Task<List<FavoriteMovie>?> GetAllAsync();
    public Task<FavoriteMovie?> GetByIdTmdb(int idTmdb);
}