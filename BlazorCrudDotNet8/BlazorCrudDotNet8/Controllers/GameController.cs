using BlazorCrudDotNet8.Shared.Entities;
using BlazorCrudDotNet8.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudDotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameById(int id)
        {
            var game = await _gameService.GetGameById(id);
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGames(Game game)
        {
            var addedGame = await _gameService.AddGame(game);
            return Ok(addedGame);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> UpdateGame(int id, Game game)
        {
            var updatedGame = await _gameService.UpdateGame(id, game);
            return Ok(updatedGame);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            var deletedGame = await _gameService.DeleteGame(id);
            return Ok(deletedGame);
        }
    }
}
