using ProjectLibrary.Core;
using ProjectLibrary.Data.Entities;
using ProjectLibrary.Data;
using ProjectLibrary.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System.Linq;
using System.Windows.Navigation;
using System;

namespace ProjectLibrary.MVVM.ViewModels
{
	public class ReadersViewModel : Core.ViewModel
	{
		private INavigationService _navigationService;
		private readonly LibraryContext _libraryContext;
		private ReaderEditerViewModel _readerEditerViewModel;
		private Reader _selectedReader;
		private string _searchFilter;
		private ObservableCollection<Reader> _readers;
		private bool _isFiltred = false;

		public int SearchIndex { get; set; }

		public ObservableCollection<Reader> Readers
		{
			get => _readers;
			set => Set(value, ref _readers);
		}

		public Reader SelectedReader
		{
			get => _selectedReader;
			set => Set(value, ref _selectedReader);
		}
		public INavigationService Navigation
		{
			get => _navigationService;
			set => Set(value, ref _navigationService);
		}

		public string SearchFilter
		{
			get => _searchFilter;
			set => Set(value, ref _searchFilter);
		}

		public RelayCommand AddReaderCommand { get; set; }
		public RelayCommand EditReaderCommand { get; set; }
		public RelayCommand DeleteReaderCommand { get; set; }
		public RelayCommand FindReaderCommand { get; set; }
		public RelayCommand FilterReaderCommand { get; set; }
		public ReadersViewModel(INavigationService navigationService, LibraryContext libraryContext, ReaderEditerViewModel readerEditerViewModel)
		{
			Title = "Читатели";

			Navigation = navigationService;
			_readerEditerViewModel = readerEditerViewModel;
			_libraryContext = libraryContext;

			_libraryContext.Readers.Load();
			Readers = _libraryContext.Readers.Local.ToObservableCollection();

			AddReaderCommand = new RelayCommand(o => AddReader());
			EditReaderCommand = new RelayCommand(o => EditReader(), c => SelectedReader != null);
			DeleteReaderCommand = new RelayCommand(o => RemoveReader(), c => SelectedReader != null);
			FilterReaderCommand = new RelayCommand(o => FilterReader());
			FindReaderCommand = new RelayCommand(o => FindReader());
		}

		private void FindReader()
		{
			Readers = new ObservableCollection<Reader>(_libraryContext.Readers.Where(r => r.FirstName.StartsWith(SearchFilter) || r.LastName.StartsWith(SearchFilter) || r.Patronymic.StartsWith(SearchFilter)));
		}

		private void FilterReader()
		{

			Readers = !_isFiltred ? new ObservableCollection<Reader>(_libraryContext.Readers.Where(r => r.Books.Count > 0)) :
			new ObservableCollection<Reader>(_libraryContext.Readers);
			_isFiltred = !_isFiltred;
		}

		private void RemoveReader()
		{
			_libraryContext.Readers.Remove(SelectedReader);
			_libraryContext.SaveChanges();
		}

		private void AddReader()
		{
			_readerEditerViewModel.Reader = new Reader();
			_readerEditerViewModel.Books = _libraryContext.Books.ToList();
			Navigation.NavigateTo<ReaderEditerViewModel>();
		}

		private void EditReader()
		{
			_readerEditerViewModel.Reader = SelectedReader;
			_readerEditerViewModel.Books = _libraryContext.Books.ToList();
			Navigation.NavigateTo<ReaderEditerViewModel>();
		}
	}
}
