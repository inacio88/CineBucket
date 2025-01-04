using CineBucket.Core.Responses;

namespace CineBucket.Core.Services;

public interface IServiceTMDBExternalApi
{
    public Task<MoviePagedResponse> GetPopularMoviesByPageAsync(int page);
    public Task<MovieResponse> GetMovieByIdAsync(int id);
}