using System.Net.Http.Headers;
using CineBucket.Core.Configuracoes;
using Microsoft.AspNetCore.Mvc;

namespace CineBucket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly HttpClient _clientHttp;
        public MoviesController(ILogger<MoviesController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientHttp = clientFactory.CreateClient(ConfiguracoesGerais.HttpClientName);
            _clientHttp.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfiguracoesGerais.ApiReadAccessToken);
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _clientHttp.GetAsync("/3/movie/558449");

                if (response.IsSuccessStatusCode)
                {
                    var conteudo = await response.Content.ReadAsStringAsync();

                    return Ok(conteudo);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Erro ao chamar a API externa.");
                }
            }
            catch
            {

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}