using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectLibrary.Core;
using ProjectLibrary.Data;
using ProjectLibrary.Data.Entities;
using ProjectLibrary.Services;
using System.Collections.ObjectModel;

namespace ProjectLibrary.MVVM.ViewModels
{
    public class ShelvesViewModel : Core.ViewModel
    {
		private ObservableCollection<Shelf> _shelves;
		private INavigationService _navigation;
		private Shelf _selectedShelf;
		private readonly LibraryContext _libraryContext;
		private ShelfEditerViewModel _shelfEditerViewModel;

		public Shelf SelectedShelf
		{
			get => _selectedShelf;
			set => Set(value, ref _selectedShelf);
		}


		public ObservableCollection<Shelf> Shelves
		{
			get => _shelves;
			set => Set(value, ref _shelves);
		}

		public INavigationService Navigation
		{
			get { return _navigation; }
			set { _navigation = value; }
		}

		public RelayCommand AddShelfCommand { get; set; }
		public RelayCommand EditShelfCommand { get; set; }
		public RelayCommand DeleteShelfCommand { get; set; }

		public ShelvesViewModel(INavigationService navigationService, LibraryContext libraryContext, ShelfEditerViewModel shelfEditerViewModel)
        {
            Title = "Стелажи";

			Navigation = navigationService;
			_libraryContext = libraryContext;

			_libraryContext.Shelves.Load();
			Shelves = _libraryContext.Shelves.Local.ToObservableCollection();

			_shelfEditerViewModel = shelfEditerViewModel;

			AddShelfCommand = new RelayCommand(o => AddShelf());
			EditShelfCommand = new RelayCommand(o => EditShelf(), c => SelectedShelf != null);
			DeleteShelfCommand = new RelayCommand(o => RemoveShelf(), c => SelectedShelf != null);
		}

		private void AddShelf()
		{
			_shelfEditerViewModel.Shelf = new Shelf();
			_navigation.NavigateTo<ShelfEditerViewModel>();
		}
		private void EditShelf()
		{
			_shelfEditerViewModel.Shelf = SelectedShelf;
			_navigation.NavigateTo<ShelfEditerViewModel>();
		}

		private void RemoveShelf()
		{
			_libraryContext.Shelves.Remove(SelectedShelf);
			_libraryContext.SaveChanges();
		}
	}
}
