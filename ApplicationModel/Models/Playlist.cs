using System.Collections;
using System.Collections.Generic;

namespace ApplicationModel.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; } = new List<Track>();
    }
}