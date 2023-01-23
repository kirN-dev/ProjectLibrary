using ProjectLibrary.Core;

namespace ProjectLibrary.Services
{
    public interface INavigationService
    {
        ViewModel CurrentView { get; }
        void NavigateTo<TViewModel>() where TViewModel : ViewModel;
    }
}
