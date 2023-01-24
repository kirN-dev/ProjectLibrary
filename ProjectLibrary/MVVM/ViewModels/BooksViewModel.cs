using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Core;
using ProjectLibrary.Data;
using ProjectLibrary.Data.Entities;
using ProjectLibrary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectLibrary.MVVM.ViewModels
{
	public class BooksViewModel : Core.ViewModel
	{
		private INavigationService _navigationService;
		private LibraryContext _libraryContext;
		private BookEditerViewModel _addEditBookViewModel;
		private Book _selectedBook;
		private ObservableCollection<Book> _books;
		private string _searchFilter;
		private Reader _selectedReader;
		private List<Reader> _readers;
		private bool _isFiltred = false;

		public int SearchIndex { get; set; }

		public ObservableCollection<Book> Books 
		{ 
			get => _books; 
			set => Set(value, ref _books); 
		}

		public Book SelectedBook
		{
			get => _selectedBook;
			set => Set(value, ref _selectedBook);
		}
		public Reader SelectedReader
		{
			get => _selectedReader;
			set => Set(value, ref _selectedReader);
		}
		public List<Reader> Readers
		{
			get => _readers;
			set => Set(value, ref _readers);
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

		public RelayCommand AddBookCommand { get; set; }
		public RelayCommand EditBookCommand { get; set; }
		public RelayCommand DeleteBookCommand { get; set; }
		public RelayCommand FindBookCommand { get; set; }
		public RelayCommand FilterBookCommand { get; set; }
		public RelayCommand BookReaderCommand { get; set; }

		public BooksViewModel(INavigationService navigationService, LibraryContext libraryContext, BookEditerViewModel addEditBookViewModel)
		{
			Title = "Книги";
			Navigation = navigationService;
			_addEditBookViewModel = addEditBookViewModel;
			_libraryContext = libraryContext;
			_libraryContext.Books.Load();
			Books = _libraryContext.Books.Local.ToObservableCollection();
			Readers = _libraryContext.Readers.ToList();

			AddBookCommand = new RelayCommand(o => AddBook());
			EditBookCommand = new RelayCommand(o => EditBook(), c => SelectedBook != null);
			DeleteBookCommand = new RelayCommand(o => RemoveBook(), c => SelectedBook != null);
			FilterBookCommand = new RelayCommand(o => FilterBook());
			FindBookCommand = new RelayCommand(o => FindBook());
			BookReaderCommand = new RelayCommand(o => BookReader());
		}

		private void BookReader()
		{
			Books = !_isFiltred ? new ObservableCollection<Book>(_libraryContext.Books.Where(b => b.Readers.Count > 0)) :
			new ObservableCollection<Book>(_libraryContext.Books);
			_isFiltred = !_isFiltred;
		}

		private void FilterBook()
		{
			Books = new ObservableCollection<Book>(_libraryContext.Books.Where(b => b.Readers.Contains(SelectedReader)));
		}

		private void FindBook()
		{

			List<Book> filterCollection = new List<Book>();
			switch (SearchIndex)
			{
				case 0:
					filterCollection = _libraryContext.Books.Where(b => b.Title.StartsWith(SearchFilter)).ToList();
					break;
				case 1:
					filterCollection = _libraryContext.Books.Where(b => b.Author.StartsWith(SearchFilter)).ToList();
					break;
				case 2:
					filterCollection = _libraryContext.Books.Where(b => b.ISBN.StartsWith(SearchFilter)).ToList();
					break;
			}
			Books = new ObservableCollection<Book>(filterCollection);
		}

		private void AddBook()
		{
			_addEditBookViewModel.Book = new Book();
			_addEditBookViewModel.Shelves = _libraryContext.Shelves.ToList();
			Navigation.NavigateTo<BookEditerViewModel>();
		}
		private void EditBook()
		{
			_addEditBookViewModel.Book = SelectedBook;
			_addEditBookViewModel.Shelves = _libraryContext.Shelves.ToList();
			Navigation.NavigateTo<BookEditerViewModel>();
		}

		private void RemoveBook()
		{
			_libraryContext.Books.Remove(SelectedBook);
			_libraryContext.SaveChanges();
		}
	}
}
