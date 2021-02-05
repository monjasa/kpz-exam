using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ApplicationModel.Models;

namespace WpfApplication.Services
{
    public class HttpTrackService : ITrackService
    {
        private readonly HttpClient _httpClient;

        public HttpTrackService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Track> GetTrackByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Tracks/{id}");
            
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        
            return await response.Content.ReadAsAsync<Track>();
        }

        public async Task<IEnumerable<Track>> GetTracksAsync()
        {
            var response = await _httpClient.GetAsync("api/Tracks");
            
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        
            return await response.Content.ReadAsAsync<IEnumerable<Track>>();
        }

        public async Task<Track> CreateTrackAsync(Track track)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Tracks", track);
            response.EnsureSuccessStatusCode();
        
            return await response.Content.ReadAsAsync<Track>();
        }

        public async Task DeleteTrackAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Tracks/{id}");
        }
    }
}