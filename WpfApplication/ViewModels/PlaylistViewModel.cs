using ApplicationModel.Models;

namespace WpfApplication.ViewModels
{
    public class PlaylistViewModel: ViewModelBase
    {
        private readonly Playlist _playlist;

        public PlaylistViewModel(Playlist playlist)
        {
            _playlist = playlist;
        }
        
        public int Id
        {
            get => _playlist.Id;
            set
            {
                _playlist.Id = value;
                OnPropertyChanged(nameof(_playlist.Id));
            }
        }

        public string Name
        {
            get => _playlist.Name;
            set
            {
                _playlist.Name = value;
                OnPropertyChanged(nameof(_playlist.Name));
            }
        }
    }
}