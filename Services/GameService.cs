using GameApi.Models;

namespace GameApi.Services;

public class GameService : IGameService
{
    private readonly List<Game> _games = new()
    {
        new Game { Id = 1, Name = "The Legend of Zelda", Genre = "Adventure", Price = 59.99m },
        new Game { Id = 2, Name = "Minecraft", Genre = "Sandbox", Price = 26.95m },
        new Game { Id = 3, Name = "Halo Infinite", Genre = "Shooter", Price = 39.99m },
        new Game { Id = 4, Name = "Stardew Valley", Genre = "Farming", Price = 14.99m }
    };

    public Task<List<Game>> GetGamesAsync() => Task.FromResult(_games.ToList());

    public Task<Game?> GetGameByIdAsync(int id) => Task.FromResult(_games.FirstOrDefault(g => g.Id == id));

    public Task<Game> CreateGameAsync(Game game)
    {
        ArgumentNullException.ThrowIfNull(game);

        game.Id = _games.Count > 0 ? _games.Max(g => g.Id) + 1 : 1;
        _games.Add(game);

        return Task.FromResult(game);
    }
}
