using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCheckers.Shared
{
    public static class SharedConstants
    {
        public const string MULTIPLAYER_HUB_PATTERN_CONNECT = "/connect";

        public const string MULTIPLAYER_HUB_METHOD_JOIN_GAME = "JoinGame";
        public const string MULTIPLAYER_HUB_METHOD_MOVE_CHECKER = "MoveChecker";

        public const string MULTIPLAYER_HUB_GAME_JOINED = "GameJoined";
        public const string MULTIPLAYER_HUB_CHECKER_MOVED = "CheckerMoved";

        public const string API_ENDPOINT_GET_AVAILABLE_GAMES = "/api/GetAvailableGames";

        public static string MULTIPLAYER_HUB_GAME_STARTED = "GameStarted";
    }
}
