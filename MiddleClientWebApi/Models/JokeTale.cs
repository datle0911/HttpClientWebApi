namespace MiddleClientWebApi.Models;

public class JokeTale
{
    public JokeTale(int id, string joke, string[] categories)
    {
        Id = id;
        Joke = joke;
        Categories = categories;
    }

    public int Id { get; set; }
    public string Joke { get; set; }
    public string[] Categories { get; set; }
}
