namespace OnlineCheckers.Client.Data
{
    public class Checker
    {
        public string Color { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public CheckerDirection Diretion { get; set; }
    }

    public enum CheckerDirection
    {
        Up, Down, Both
    }
}
