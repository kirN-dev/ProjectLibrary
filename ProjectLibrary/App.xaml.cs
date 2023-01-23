using Microsoft.Extensions.DependencyInjection;
using ProjectLibrary.Core;
using ProjectLibrary.MVVM.ViewModels;
using ProjectLibrary.MVVM.Views;
using ProjectLibrary.Services;
using System;
using System.Windows;

namespace ProjectLibrary
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly ServiceProvider _serviceProvider;

		public App()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddSingleton(provider => new MainWindow
			{
				DataContext = provider.GetRequiredService<MainViewModel>()
			});

			services.AddSingleton<MainViewModel>();
			services.AddSingleton<BooksViewModel>();
			services.AddSingleton<ReadersViewModel>();
			services.AddSingleton<ShelvesViewModel>();

			services.AddSingleton<INavigationService, NavigationService>();

			services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

			_serviceProvider = services.BuildServiceProvider();
		}

        protected override void OnStartup(StartupEventArgs e)
        {
			var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
			mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
