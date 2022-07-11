namespace MiddleClientWebApi.HttpClientServices;

public class NamedClientService
{
    private readonly IHttpClientFactory _httpClientFactory = null!;
    private readonly IConfiguration _configuration = null;

    public NamedClientService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task<JokeTale> GetRandomJokeAsyncNamedClient()
    {
        // Create Client
        var clientName = _configuration.GetSection("HttpClients:Client1");
        var client = _httpClientFactory.CreateClient(clientName.Value);

        JokeTaleResponse? response = await client.GetFromJsonAsync<JokeTaleResponse>("http://api.icndb.com/jokes/random?limitTo=[nerdy]");

        if (response?.Value.Joke is not null)
        {
            return response.Value;
        }

        return null;
    }
}
