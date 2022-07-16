using Microsoft.AspNetCore.SignalR;
using OnlineCheckers.Server.Data;
using OnlineCheckers.Shared;

namespace OnlineCheckers.Server.Hubs
{
    public class MultiplayerHub : Hub
    {
        private readonly GameManager _gameManager;

        public MultiplayerHub(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public async Task JoinGame(string gameId)
        {
            if (_gameManager.GameExists(gameId))
            {
                if (_gameManager.CanJoinGame(gameId))
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
                    await Clients.GroupExcept(gameId, Context.ConnectionId).SendAsync(SharedConstants.MULTIPLAYER_HUB_GAME_JOINED);
                    _gameManager.IncrementGamePlayerCount(gameId);

                }
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
                _gameManager.AddGame(gameId);
            }

        }

        public async Task MoveChecker(string gameId, int prevColumn, int prevRow, int currCol, int currRow)
        {
            await Clients.GroupExcept(gameId, Context.ConnectionId)
                .SendAsync(SharedConstants.MULTIPLAYER_HUB_CHECKER_MOVED, prevColumn, prevRow, currCol, currRow);
        }

    }
}
