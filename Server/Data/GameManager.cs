using OnlineCheckers.Shared;

namespace OnlineCheckers.Server.Data
{
    public class GameManager
    {
        private List<Game> Games = new();

        public void AddGame(Game game)
        {
            Games.Add(game);
        }

        //public void IncrementGamePlayerCount(string gameId)
        //{
        //    Games[gameId]++;
        //}

        //public bool GameExists(string gameId)
        //{
        //    return Games.ContainsKey(gameId);
        //}

        //public bool CanJoinGame(string gameId)
        //{
        //    return GameExists(gameId) && Games[gameId] < 2;
        //}

        public IEnumerable<Game> GetAvailableGames()
        {
            return Games.Where(n => n.PlayerCounter < 2);
        }
    }

}
