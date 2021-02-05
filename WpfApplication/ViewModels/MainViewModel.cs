using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using ApplicationModel.Models;
using WpfApplication.Services;
using WpfApplication.ViewModels.Commands;

namespace WpfApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IPlaylistService _playlistService;
        private readonly ITrackService _trackService;
        
        private TrackViewModel _selectedTrack;
        
        private string _trackTitle;
        private string _trackFilePath;
        private int _trackPlaylistId;
        
        private ICommand _createTrackCommand;
        private ICommand _readTracksCommand;
        private ICommand _deleteTrackCommand;

        public MainViewModel(IPlaylistService playlistService, ITrackService trackService)
        {
            _playlistService = playlistService;
            _trackService = trackService;
            
            Playlists = new ObservableCollection<PlaylistViewModel>();
            Tracks = new ObservableCollection<TrackViewModel>();
        }

        public ObservableCollection<PlaylistViewModel> Playlists { get; set; }
        public ObservableCollection<TrackViewModel> Tracks { get; set; }
        
        public TrackViewModel SelectedTrack
        {
            get => _selectedTrack;
            set
            {
                _selectedTrack = value;
                OnPropertyChanged();
            }
        }
        
        public string TrackTitle
        {
            get => _trackTitle;
            set
            {
                _trackTitle = value;
                OnPropertyChanged();
            } 
        }
        
        public string TrackFilePath
        {
            get => _trackFilePath;
            set
            {
                _trackFilePath = value;
                OnPropertyChanged();
            } 
        }
        
        public int TrackPlaylistId
        {
            get => _trackPlaylistId;
            set
            {
                _trackPlaylistId = value;
                OnPropertyChanged();
            } 
        }
        
        public ICommand CreateTrackCommand
        {
            get { return _createTrackCommand ??= new Command(CreateTrack); }
        }

        public ICommand ReadTracksCommand
        {
            get { return _readTracksCommand ??= new Command(ReadTracks); }
        }
        
        public ICommand DeleteTrackCommand
        {
            get { return _deleteTrackCommand ??= new Command(DeleteTrack); }
        }

        private async void CreateTrack(object args)
        {
            var track = await _trackService.CreateTrackAsync(new Track
            {
                Title = TrackTitle,
                FilePath = TrackFilePath,
                PlaylistId = TrackPlaylistId
            });

            track = await _trackService.GetTrackByIdAsync(track.Id);

            var trackViewModel = new TrackViewModel(this, track);
            
            Tracks.Add(trackViewModel);
            SelectedTrack = trackViewModel;
        }

        private async void ReadTracks(object args)
        {
            Playlists.Clear();
            Tracks.Clear();
            
            var playlists = await _playlistService.GetPlaylistsAsync();
            playlists.Select(playlist => new PlaylistViewModel(playlist))
                .ToList()
                .ForEach(Playlists.Add);
            
            var tracks = await _trackService.GetTracksAsync();
            tracks.Select(track => new TrackViewModel(this, track))
                .ToList()
                .ForEach(Tracks.Add);
        }
        
        private async void DeleteTrack(object args)
        {
            await _trackService.DeleteTrackAsync(SelectedTrack.Id);
            
            Tracks.Remove(SelectedTrack);
        }
    }
}