namespace MiddleClientWebApi.Interfaces;

public interface IGeneratedClientService
{
    [Get("/jokes/random?limitTo=[nerdy]")]
    Task<JokeTaleResponse> GetRandomJokeTaleResponse();
}
