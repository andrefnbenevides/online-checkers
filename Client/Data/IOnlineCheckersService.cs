namespace OnlineCheckers.Client.Data
{
    public interface IOnlineCheckersService
    {
        Task<int> GetPlayerCount();
    }
}
