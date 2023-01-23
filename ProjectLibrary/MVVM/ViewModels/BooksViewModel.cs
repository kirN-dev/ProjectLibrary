using ProjectLibrary.Core;
using ProjectLibrary.Data;
using ProjectLibrary.Data.Entities;
using ProjectLibrary.Services;
using System.Collections.ObjectModel;
using System.Windows.Navigation;

namespace ProjectLibrary.MVVM.ViewModels
{
	public class BooksViewModel : Core.ViewModel
	{
		private INavigationService _navigationService;

		public ObservableCollection<Book> Books { get; set; }
		public Book SelectedBook { get; set; }
		public INavigationService Navigation
		{
			get => _navigationService;
			set => Set(value, ref _navigationService);
		}
		public RelayCommand AddBookCommand { get; set; }

		public BooksViewModel(INavigationService novigationService)
		{
			Title = "Книги";
			Navigation = novigationService;
			using LibraryContext libraryContext = new();
			Books = new ObservableCollection<Book>(libraryContext.Books);

			AddBookCommand = new RelayCommand(o => { Navigation.NavigateTo<ReadersViewModel>(); }) ;
		}
	}
}
