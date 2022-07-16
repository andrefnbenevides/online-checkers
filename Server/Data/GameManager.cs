namespace OnlineCheckers.Server.Data
{
    public class GameManager
    {
        private Dictionary<string, int> Games = new();

        public void AddGame(string gameId)
        {
            Games.Add(gameId, 1);
        }

        public void IncrementGamePlayerCount(string gameId)
        {
            Games[gameId]++;
        }

        public bool GameExists(string gameId)
        {
            return Games.ContainsKey(gameId);
        }

        public bool CanJoinGame(string gameId)
        {
            return GameExists(gameId) && Games[gameId] < 2;
        }

        public IEnumerable<string> GetAvailableGames()
        {
            return Games.Where(n => n.Value < 2).Select(n => n.Key);
        }
    }
}
