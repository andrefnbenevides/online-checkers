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

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Game? game = _gameManager.GetGameByPlayerId(Context.ConnectionId);
            if (game != null)
            {
                string disconnectedPlayer = game.WhitePlayerId == Context.ConnectionId ? SharedConstants.WHITE_CHECKER_COLOR_NAME : SharedConstants.BLACK_CHECKER_COLOR_NAME;
                Clients.Group(game.GameId).SendAsync(SharedConstants.MULTIPLAYER_HUB_PLAYER_DISCONNECTED, disconnectedPlayer);
                _gameManager.RemoveGame(game);
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task PassTurn(string gameId)
        {
            await Clients.GroupExcept(gameId, Context.ConnectionId)
                .SendAsync(SharedConstants.MULTIPLAYER_HUB_CHECKER_PLAYER_PASSED_TURN);
        }

        public async Task Concede(string gameId)
        {
            await Clients.GroupExcept(gameId, Context.ConnectionId)
                .SendAsync(SharedConstants.MULTIPLAYER_HUB_CHECKERS_PLAYER_CONCEDED);
        }

        public async Task JoinGame()
        {
            List<Game> availableGames = _gameManager.GetAvailableGames().ToList();
            if (availableGames.Count > 0)
            {
                // pair new player with queue'd player
                Game firstAvailable = availableGames[0];
                string gameId = firstAvailable.GameId;
                firstAvailable.BlackPlayerId = Context.ConnectionId;

                await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
                await Clients.Group(gameId).SendAsync(SharedConstants.MULTIPLAYER_HUB_GAME_STARTED, firstAvailable);
            }
            else
            {
                // create new game and queue player
                Game game = new Game();
                game.GameId = Guid.NewGuid().ToString();
                game.WhitePlayerId = Context.ConnectionId;
                await Groups.AddToGroupAsync(Context.ConnectionId, game.GameId);
                _gameManager.AddGame(game);
            }
        }

        public async Task MoveChecker(string gameId, int prevColumn, int prevRow, int currCol, int currRow)
        {
            await Clients.GroupExcept(gameId, Context.ConnectionId)
                .SendAsync(SharedConstants.MULTIPLAYER_HUB_CHECKER_MOVED, prevColumn, prevRow, currCol, currRow);
        }

    }
}
