using CineBucket.Core.Configuracoes;

namespace CineBucket.ExtensoesConfiguracao
{
    public static  class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            ConfiguracoesGerais.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                                    ?? throw new Exception("Falha nas configurações da aplicação");

            ConfiguracoesGerais.ApiReadAccessToken = builder.Configuration.GetValue<string>("ApiReadAccessToken") 
                                                    ?? throw new Exception("Falha nas configurações da aplicação");
        }
        
    }
}