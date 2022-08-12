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

        public Game? GetGameByPlayerId(string connectionId)
        {
            Game? game = Games.FirstOrDefault(s => s.BlackPlayerId == connectionId || s.WhitePlayerId == connectionId);

            return game;
        }

        public void RemoveGame(Game game)
        {
            Games.Remove(game);
        }

        public IEnumerable<Game> GetAvailableGames()
        {
            return Games.Where(n => n.PlayerCounter < 2);
        }
    }

}
