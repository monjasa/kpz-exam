using ApplicationModel.Models;

namespace WpfApplication.ViewModels
{
    public class TrackViewModel : ViewModelBase
    {
        private readonly Track _track;

        public TrackViewModel(Track track)
        {
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
    }
}