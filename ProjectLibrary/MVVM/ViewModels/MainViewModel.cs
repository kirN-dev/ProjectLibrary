using ProjectLibrary.Core;
using ProjectLibrary.Services;
using System.Windows;

namespace ProjectLibrary.MVVM.ViewModels
{
	public class MainViewModel : ViewModel
	{
		private INavigationService _navigationService;

        public RelayCommand NavigateBooksCommand { get; set; }
        public RelayCommand NavigateReadersCommand { get; set; }
        public RelayCommand NavigateShelvesCommand { get; set; }
        public RelayCommand QuitCommand { get; set; }

        public INavigationService Navigation
        {
            get => _navigationService;
            set => Set(value, ref _navigationService);
        }

        public MainViewModel(INavigationService novigationService)
		{
			Navigation = novigationService;
            Title= "Библиотека";

            NavigateBooksCommand = new RelayCommand(o => { Navigation.NavigateTo<BooksViewModel>(); });
            NavigateReadersCommand = new RelayCommand(o => { Navigation.NavigateTo<ReadersViewModel>(); });
            NavigateShelvesCommand = new RelayCommand(o => { Navigation.NavigateTo<ShelvesViewModel>(); });
			QuitCommand = new RelayCommand(o => Application.Current.Shutdown());

            NavigateBooksCommand.Execute(null);

        }
	}
}
