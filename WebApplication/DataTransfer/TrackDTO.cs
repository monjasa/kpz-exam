using ApplicationModel.Models;

namespace WebApplication.DataTransfer
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public PlaylistDTO Playlist { get; set; }
    }
}