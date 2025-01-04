namespace CineBucket.Core.Configuracoes
{
    public static class ConfiguracoesGerais
    {
        public static string ApiReadAccessToken {get;set;} = string.Empty;
        public static string ApiKey {get;set;} = string.Empty;
        public static string ConnectionString {get;set;} = string.Empty;
        public const string HttpClientName = "CBClientHttp";
        public static string ExternalApiUrl { get; set; } = "https://api.themoviedb.org/";
        public const int DefaultStatusCode = 200;
    }
}