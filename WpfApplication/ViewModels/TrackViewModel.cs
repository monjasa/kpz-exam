using System.Linq;
using ApplicationModel.Models;

namespace WpfApplication.ViewModels
{
    public class TrackViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        
        private readonly Track _track;

        public TrackViewModel(MainViewModel mainViewModel, Track track)
        {
            _mainViewModel = mainViewModel;
            _track = track;
        }
        
        public int Id
        {
            get => _track.Id;
            set
            {
                _track.Id = value;
                OnPropertyChanged(nameof(_track.Id));
            }
        }

        public string Title
        {
            get => _track.Title;
            set
            {
                _track.Title = value;
                OnPropertyChanged(nameof(_track.Title));
            }
        }
        
        public string FilePath
        {
            get => _track.FilePath;
            set
            {
                _track.FilePath = value;
                OnPropertyChanged(nameof(_track.FilePath));
            }
        }

        public PlaylistViewModel Playlist
        {
            get => _mainViewModel.Playlists.Single(playlist => playlist.Id == _track.Playlist.Id);
            set
            {
                _track.PlaylistId = value.Id;
                OnPropertyChanged(nameof(_track.Playlist));
            }
        }
    }
}