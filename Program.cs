using GameApi.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddScoped<IGameService, GameService>();

        var app = builder.Build();

        app.MapGet("/", () => Results.Content(
            "<html><body><h1>Game API is running</h1>" +
            "<p>Available endpoints:</p>" +
            "<ul><li>GET /api/games</li><li>GET /api/games/{id}</li><li>POST /api/games</li><li>PUT /api/games/{id}</li><li>DELETE /api/games/{id}</li></ul>" +
            "</body></html>",
            "text/html"));
        app.MapControllers();

        app.Run();
    }
}