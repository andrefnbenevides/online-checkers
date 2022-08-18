using Microsoft.AspNetCore.Components;
using OnlineCheckers.Shared;
using System.Net.Http;

namespace OnlineCheckers.Client.Data
{
    public class OnlineCheckersService : IOnlineCheckersService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly NavigationManager _navigationManager;

        public OnlineCheckersService(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
        {
            _httpClientFactory = httpClientFactory;
            _navigationManager = navigationManager;
        }

        public async Task<int> GetPlayerCount()
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(_navigationManager.BaseUri);
            HttpResponseMessage response = await httpClient.GetAsync(SharedConstants.API_ENDPOINT_GET_PLAYER_COUNT);
            if (response.IsSuccessStatusCode)
            {
                return int.Parse(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return 0;
            }
        }
    }
}
