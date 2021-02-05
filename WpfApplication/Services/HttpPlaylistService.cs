using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ApplicationModel.Models;

namespace WpfApplication.Services
{
    public class HttpPlaylistService : IPlaylistService
    {
        private readonly HttpClient _httpClient;

        public HttpPlaylistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Playlist> GetPlaylistByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Playlists/{id}");
            
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        
            return await response.Content.ReadAsAsync<Playlist>();
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsAsync()
        {
            var response = await _httpClient.GetAsync("api/Playlists");
            
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        
            return await response.Content.ReadAsAsync<IEnumerable<Playlist>>();
        }
    }
}