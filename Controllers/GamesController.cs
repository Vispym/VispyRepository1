using GameApi.Models;
using GameApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;

    public GamesController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Game>>> GetGamesAsync()
    {
        var games = await _gameService.GetGamesAsync();
        return Ok(games);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Game>> GetGameByIdAsync(int id)
    {
        var game = _gameService.GetGameByIdAsync(id);
        return game is null ? NotFound() : Ok(game);
    }

    [HttpPost]
    public async Task<ActionResult<Game>> CreateGameAsync([FromBody] Game game)
    {
        if (string.IsNullOrWhiteSpace(game.Name) || string.IsNullOrWhiteSpace(game.Genre) || game.Price <= 0)
        {
            return BadRequest("Name, Genre, and Price are required.");
        }

        var createdGame = await _gameService.CreateGameAsync(game);
        return CreatedAtAction(nameof(GetGameByIdAsync), new { id = createdGame.Id }, createdGame);
    }
}
