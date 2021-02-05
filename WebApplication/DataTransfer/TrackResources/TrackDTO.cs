using WebApplication.DataTransfer.PlaylistResources;

namespace WebApplication.DataTransfer.TrackResources
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public PlaylistDTO Playlist { get; set; }
    }
}