using CineBucket.Core.Configuracoes;
using CineBucket.Core.Services;
using CineBucket.Data;
using CineBucket.Models;
using CineBucket.Repositories;
using CineBucket.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CineBucket.ExtensoesConfiguracao
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            ConfiguracoesGerais.ConnectionString = builder.Configuration.GetValue<string>("conexao")
                                                    ?? builder.Configuration.GetConnectionString("DefaultConnection")  
                                                    ?? string.Empty;

            ConfiguracoesGerais.ApiReadAccessToken = builder.Configuration.GetValue<string>("ApiReadAccessToken")
                                                    ?? string.Empty;
        }
        public static void AddDatabaseContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseNpgsql(ConfiguracoesGerais.ConnectionString)
                );
            
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddHttpClientServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient(ConfiguracoesGerais.HttpClientName, client =>
            {
                client.BaseAddress = new Uri(ConfiguracoesGerais.ExternalApiUrl); 
                client.Timeout = TimeSpan.FromSeconds(30);
            });
        }
        public static void AddRepos(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IFavoriteMovieRepo, FavoriteMovieRepo>();
        }
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IServiceTMDBExternalApi, ServiceTMDBExternalApi>();
            builder.Services.AddScoped<IServiceFavoriteMovie, ServiceFavoriteMovie>();
        }
        

    }
}