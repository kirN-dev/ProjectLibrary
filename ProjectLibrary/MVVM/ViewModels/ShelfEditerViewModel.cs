using ProjectLibrary.Core;
using ProjectLibrary.Data;
using ProjectLibrary.Data.Entities;
using ProjectLibrary.Services;
using System;

namespace ProjectLibrary.MVVM.ViewModels
{
    public class ShelfEditerViewModel : Core.ViewModel
    {
        private INavigationService _navigationService;
		private readonly LibraryContext _libraryContext;

        public INavigationService Navigation
        {
            get => _navigationService;
            set => Set(value, ref _navigationService);
        }


		public RelayCommand SaveShelfCommand { get; private set; }
		public RelayCommand CancelCommand { get; private set; }
		public Shelf Shelf { get; set; }


        public ShelfEditerViewModel(INavigationService navigationService, LibraryContext libraryContext)
        {
            Navigation = navigationService;

			_libraryContext = libraryContext;

			SaveShelfCommand = new RelayCommand(o => Save());
			CancelCommand = new RelayCommand(o => Navigation.NavigateTo<ShelvesViewModel>());
		}

		private void Save()
		{
			if (_libraryContext.Shelves.Find(Shelf.Id) == null)
			{
				_libraryContext.Shelves.Add(Shelf);
			}
			else
			{
				_libraryContext.Entry(Shelf).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}

			try
			{
				_libraryContext.SaveChanges();
			}
			catch
			{

			}
			Navigation.NavigateTo<ShelvesViewModel>();
		}
	}
}
