using CineBucket.Core.Configuracoes;
using CineBucket.Core.Services;
using CineBucket.Services;

namespace CineBucket.ExtensoesConfiguracao
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            ConfiguracoesGerais.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                                    ?? throw new Exception("Falha nas configurações da aplicação");

            ConfiguracoesGerais.ApiReadAccessToken = builder.Configuration.GetValue<string>("ApiReadAccessToken")
                                                    ?? throw new Exception("Falha nas configurações da aplicação");
        }

        public static void AddHttpClientServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient(ConfiguracoesGerais.HttpClientName, client =>
            {
                client.BaseAddress = new Uri(ConfiguracoesGerais.ExternalApiUrl); 
                client.Timeout = TimeSpan.FromSeconds(30);
            });
        }
        
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IServiceTMDBExternalApi, ServiceTMDBExternalApi>();
        }

    }
}