namespace MiddleClientWebApi.HttpClientServices;

public class GeneratedClientService
{
    private readonly IGeneratedClientService _generatedClientService = null;
    public GeneratedClientService(IGeneratedClientService generatedClientService)
    {
        _generatedClientService = generatedClientService;
    }

    public async Task<JokeTale> SerializeResponseToJokeTale()
    {
        var response = await _generatedClientService.GetRandomJokeTaleResponse();

        if (response?.Value.Joke is not null)
        {
            return response.Value;
        }

        return null;
    }
}
