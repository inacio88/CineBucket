using CineBucket.Models;

namespace CineBucket.Services;

public interface IServiceFavoriteMovie
{
    public Task<FavoriteMovie?> Create(int idTmdb, int priority);
}