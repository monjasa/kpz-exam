using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ApplicationModel.Models;
using WpfApplication.Services;
using WpfApplication.ViewModels.Commands;

namespace WpfApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ITrackService _trackService;
        
        private TrackViewModel _selectedTrack;
        
        private string _trackTitle;
        private string _trackFilePath;
        private int _trackPlaylistId;
        
        private ICommand _createTrackCommand;
        private ICommand _readTracksCommand;
        private ICommand _deleteTrackCommand;

        public MainViewModel(ITrackService trackService)
        {
            _trackService = trackService;
            
            Tracks = new ObservableCollection<TrackViewModel>();
        }

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
            
            var trackViewModel = new TrackViewModel(track);
            
            Tracks.Add(trackViewModel);
            SelectedTrack = trackViewModel;
        }

        private async void ReadTracks(object args)
        {
            var tracks = await _trackService.GetTracksAsync();

            Tracks.Clear();
            tracks.Select(track => new TrackViewModel(track))
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