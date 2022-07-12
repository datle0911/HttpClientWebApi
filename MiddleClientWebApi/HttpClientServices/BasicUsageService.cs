namespace MiddleClientWebApi.HttpClientServices;

public class BasicUsageService
{
    private readonly IHttpClientFactory _httpClientFactory = null!;

    public BasicUsageService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<JokeTale> GetRandomJokeAsyncAnonymouys()
    {
        // Create Client
        var client = _httpClientFactory.CreateClient();

        JokeTaleResponse? response = await client.GetFromJsonAsync<JokeTaleResponse>("http://api.icndb.com/jokes/random?limitTo=[nerdy]");
        
        if (response?.Value.Joke is not null)
        {
            return response.Value;
        }

        return null;
    }

    public async Task<Response> CreateCustomerAsync(Customer customer)
    {
        // Create Client
        var client = _httpClientFactory.CreateClient();

        var response = await client.PostAsJsonAsync("https://deliverywebapi.azurewebsites.net/api/customers", customer);
        //response.Content.ReadAsStringAsync().Wait();
        //Console.WriteLine(response.Content);

        var result = new Response(response.Content, (Int32)response.StatusCode);
        return result;
    }
}
