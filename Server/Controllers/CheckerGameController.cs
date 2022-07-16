using Microsoft.AspNetCore.Mvc;
using OnlineCheckers.Server.Data;
using OnlineCheckers.Shared;

namespace OnlineCheckers.Server.Controllers
{
    [ApiController]
    [Route("api")]
    public class CheckerGameController : ControllerBase
    {
        private readonly GameManager _gameManager;

        public CheckerGameController(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        [HttpGet("GetAvailableGames")]
        public IEnumerable<string> GetAvailableGames()
        {
            return _gameManager.GetAvailableGames();
        }
    }
}