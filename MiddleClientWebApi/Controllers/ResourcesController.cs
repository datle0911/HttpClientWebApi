namespace MiddleClientWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourcesController
{
    private readonly BasicUsageService _basicUsageService;
    private readonly NamedClientService _namedClientService;
    private readonly TypedClientService _typedClientService;
    private readonly GeneratedClientService _generatedClientService;
    //private readonly IGeneratedClientService _generatedClientService;
    public ResourcesController(BasicUsageService basicUsageService, NamedClientService namedClientService, TypedClientService typedClientService, GeneratedClientService generatedClientService)
    {
        _basicUsageService = basicUsageService;
        _namedClientService = namedClientService;
        _typedClientService = typedClientService;
        _generatedClientService = generatedClientService;
    }

    [HttpGet("Anonymous")]
    public async Task<JokeTale> GetByAnonymous()
    {
        var result = await _basicUsageService.GetRandomJokeAsyncAnonymouys();
        if(result == null)
        {
            result = new JokeTale(999,"CANNOT GET JOKE", null);
        }

        return result;
    }

    [HttpPost("Anonymous")]
    public async Task<Response> Post(Customer customer)
    {
        var result = await _basicUsageService.CreateCustomerAsync(customer);

        return result;
    }

    [HttpGet("NamedClient")]
    public async Task<JokeTale> GetByNamedClient()
    {
        var result = await _namedClientService.GetRandomJokeAsyncNamedClient();
        if (result == null)
        {
            result = new JokeTale(999, "CANNOT GET JOKE", null);
        }

        return result;
    }

    [HttpGet("TypedClient")]
    public async Task<JokeTale> GetByTypedClient()
    {
        var result = await _typedClientService.GetRandomJokeAsyncTypedClient();
        if (result == null)
        {
            result = new JokeTale(999, "CANNOT GET JOKE", null);
        }

        return result;
    }

    [HttpGet("GeneratedClient")]
    public async Task<JokeTale> GetByGeneratedClient()
    {
        var result = await _generatedClientService.SerializeResponseToJokeTale();
        if (result == null)
        {
            result = new JokeTale(999, "CANNOT GET JOKE", null);
        }

        return result;
    }
}
