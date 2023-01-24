using ProjectLibrary.Core;
using ProjectLibrary.Data;
using ProjectLibrary.Data.Entities;
using ProjectLibrary.Services;
using System.Collections.Generic;
using System.Linq;

namespace ProjectLibrary.MVVM.ViewModels
{
	public class BookEditerViewModel : Core.ViewModel
	{
		private INavigationService _navigationService;
		private readonly LibraryContext _libraryContext;

		public Book Book { get; set; }
		public List<Shelf> Shelves { get; set; }
		public string ErrorMessage { get; set; }

		public RelayCommand SaveBookCommand { get; set; }
		public RelayCommand CancelCommand { get; set; }
		public INavigationService Navigation
		{
			get => _navigationService;
			set => Set(value, ref _navigationService);
		}

		public BookEditerViewModel(INavigationService navigationService, LibraryContext libraryContext)
		{
			Navigation = navigationService;

			_libraryContext = libraryContext;

			SaveBookCommand = new RelayCommand(o => Save());
			CancelCommand = new RelayCommand(o => Navigation.NavigateTo<BooksViewModel>());
		}

		private void Save()
		{
			if (_libraryContext.Books.Find(Book.Id) == null)
			{
				_libraryContext.Books.Add(Book);
			}
			else
			{
				_libraryContext.Entry(Book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}

			try
			{
				_libraryContext.SaveChanges();
			}
			catch
			{

			}
			Navigation.NavigateTo<BooksViewModel>();
		}
	}
}
