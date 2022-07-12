namespace MiddleClientWebApi.Interfaces;

public interface IGeneratedClientService
{
    [Get("/jokes/random?limitTo=[explicit]")]
    Task<JokeTaleResponse> GetRandomJokeTaleResponse();
}
