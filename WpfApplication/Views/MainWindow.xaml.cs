using System.Windows;
using WpfApplication.ViewModels;

namespace WpfApplication.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            DataContext = mainViewModel;
            InitializeComponent();
        }
    }
}