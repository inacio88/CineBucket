using System.Text.Json.Serialization;
using CineBucket.Core.Configuracoes;

namespace CineBucket.Core.Responses
{
    public class Response<TData>
    {

        [JsonConstructor]
        public Response()
        {
            _code = ConfiguracoesGerais.DefaultStatusCode;    
        }

        public Response(TData? data, int code = ConfiguracoesGerais.DefaultStatusCode, string? message = null)
        {
            Results = data;
            Message = message;
            _code = code;
        }

        private readonly int _code;
        public TData? Results { get; set; }
        public string? Message { get; set; } = string.Empty;
        [JsonIgnore]
        public bool IsSuccess => _code is >= 200 and <= 299;
    }
}