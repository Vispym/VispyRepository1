using GameApi.Models;

namespace GameApi.Services;

public interface IGameService
{
    Task<List<Game>> GetGamesAsync();
    Task<Game?> GetGameByIdAsync(int id);
    Task<Game> CreateGameAsync(Game game);
}
