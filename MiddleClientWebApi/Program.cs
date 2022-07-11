var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Basic Usage
builder.Services.AddHttpClient();

// Named Client
var httpClientName = builder.Configuration.GetSection("HttpClients:Client1");
builder.Services.AddHttpClient(
    httpClientName.Value,
    client =>
    {
        // Set the base address of the named client.
        client.BaseAddress = new Uri("http://api.icndb.com/");

        // Add a user-agent default request header.
        client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
    });

// Typed Client
builder.Services.AddHttpClient<TypedClientService>(
    client =>
    {
        // Set the base address of the named client.
        client.BaseAddress = new Uri("https://api.icndb.com/");

        // Add a user-agent default request header.
        client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
    });

// Generated Client
builder.Services.AddRefitClient<IGeneratedClientService>()
    .ConfigureHttpClient(client =>
    {
        // Set the base address of the named client.
        client.BaseAddress = new Uri("http://api.icndb.com/");

        // Add a user-agent default request header.
        client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
    });

// Add service
builder.Services.AddTransient<BasicUsageService>();
builder.Services.AddTransient<NamedClientService>();
builder.Services.AddTransient<TypedClientService>();
builder.Services.AddTransient<GeneratedClientService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
