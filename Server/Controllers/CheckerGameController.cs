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

        [HttpGet("GetPlayerCount")]
        public IActionResult GetPlayerCount()
        {
            int count = _gameManager.GetPlayerCount();
            return Ok(count);
        }
    }
}