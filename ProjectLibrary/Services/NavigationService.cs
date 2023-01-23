using ProjectLibrary.Core;
using System;

namespace ProjectLibrary.Services
{
    public class NavigationService : Core.ObservableObject, INavigationService
    {
        private readonly Func<Type, ViewModel> _viewModelFactory;
        private ViewModel _currentView;

        public NavigationService(Func<Type, ViewModel> viewModelFactory)
        {
            _viewModelFactory= viewModelFactory;
        }

        public ViewModel CurrentView 
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
            ViewModel viewModel = _viewModelFactory(typeof(TViewModel));
            CurrentView = viewModel;
        }
         
    }
}
