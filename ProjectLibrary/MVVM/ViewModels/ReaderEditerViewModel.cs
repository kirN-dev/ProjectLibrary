using ProjectLibrary.Core;
using ProjectLibrary.Data.Entities;
using ProjectLibrary.Data;
using ProjectLibrary.Services;
using System.Collections.Generic;
using System.Windows.Navigation;
using System;
using System.Collections.ObjectModel;
using static System.Reflection.Metadata.BlobBuilder;

namespace ProjectLibrary.MVVM.ViewModels
{
	public class ReaderEditerViewModel : Core.ViewModel
	{
		private INavigationService _navigationService;
		private Book _selectedBook;
		private readonly LibraryContext _libraryContext;

		public Reader Reader { get; set; }
		public List<Book> Books { get; set; }
		public string ErrorMessage { get; set; }

		public RelayCommand SaveReaderCommand { get; set; }
		public RelayCommand AddBookToReaderCommand { get; set; }
		public RelayCommand RemoveBookToReaderCommand { get; set; }
		public RelayCommand CancelCommand { get; set; }
		public INavigationService Navigation
		{
			get => _navigationService;
			set => Set(value, ref _navigationService);
		}
		public Book SelectedBook
		{
			get => _selectedBook;
			set => Set(value, ref _selectedBook);
		}
		public ReaderEditerViewModel(INavigationService navigationService, LibraryContext libraryContext)
		{
			Navigation = navigationService;

			_libraryContext = libraryContext;


			SaveReaderCommand = new RelayCommand(o => Save());
			CancelCommand = new RelayCommand(o => Navigation.NavigateTo<ReadersViewModel>());
			AddBookToReaderCommand = new RelayCommand(o => AddBookToReader());
			RemoveBookToReaderCommand = new RelayCommand(o => RemoveBookToReader());
		}

		private void RemoveBookToReader()
		{
			if (SelectedBook != null)
			{
				Reader.Books.Remove(SelectedBook);
			}
		}

		private void AddBookToReader()
		{
			if (SelectedBook != null)
			{

				Reader.Books ??= new List<Book>();



				if (!Reader.Books.Contains(SelectedBook))
				{
					Reader.Books.Add(SelectedBook);
				}
			}
		}

		private void Save()
		{
			if (_libraryContext.Readers.Find(Reader.Id) == null)
			{
				_libraryContext.Readers.Add(Reader);
			}
			else
			{
				_libraryContext.Entry(Reader).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}

			try
			{
				_libraryContext.SaveChanges();
			}
			catch
			{

			}
			Navigation.NavigateTo<ReadersViewModel>();
		}
	}
}
