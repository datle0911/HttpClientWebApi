namespace MiddleClientWebApi.HttpClientServices;

public class TypedClientService
{
    private readonly HttpClient _httpClient = null!;

    public TypedClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<JokeTale> GetRandomJokeAsyncTypedClient()
    {
        // No need to create Client

        var response = await _httpClient.GetFromJsonAsync<JokeTaleResponse>("http://api.icndb.com/jokes/random");

        if (response?.Value.Joke is not null)
        {
            return response.Value;
        }

        return null;
    }
}
