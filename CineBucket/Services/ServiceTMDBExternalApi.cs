using System.Net.Http.Headers;
using CineBucket.Core.Configuracoes;
using CineBucket.Core.Responses;
using CineBucket.Core.Services;

namespace CineBucket.Services;

public class ServiceTMDBExternalApi : IServiceTMDBExternalApi
{
    private readonly HttpClient _clientHttp;

    public ServiceTMDBExternalApi(IHttpClientFactory clientFactory)
    {
        _clientHttp = clientFactory.CreateClient(ConfiguracoesGerais.HttpClientName);
        _clientHttp.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfiguracoesGerais.ApiReadAccessToken);
    }

    public async Task<MoviePagedResponse> GetPopularMoviesByPageAsync(int page)
    {
        MoviePagedResponse movies;
        try
        {
            var response = await _clientHttp.GetAsync($"/3/movie/popular?language=en-US&page={page}");
            movies = await response.Content.ReadFromJsonAsync<MoviePagedResponse>() ?? new();
        }
        catch
        {
            throw new Exception("Erro ao carregar listas");
        }

        return movies;
    }
    
    public async Task<MovieResponse> GetMovieByIdAsync(int id)
    {
        MovieResponse movie;
        try
        {
            var response = await _clientHttp.GetAsync($"/3/movie/{id}");
            movie = await response.Content.ReadFromJsonAsync<MovieResponse>() ?? new();
        }
        catch
        {
            throw new Exception("Erro ao carregar listas");
        }

        return movie;
    }
}