namespace ApplicationModel.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}