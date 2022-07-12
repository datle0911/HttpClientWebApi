namespace MiddleClientWebApi.Models.Responses;

public class Response
{
    public Response(HttpContent content, int statusCodes)
    {
        Content = content;
        StatusCodes = statusCodes;
    }

    public HttpContent Content { get; set; }
    public int StatusCodes { get; set; }
}
