using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Core
{
	public abstract class ViewModel : ObservableObject
	{
		private string _title;

		public string Title
		{
			get => _title;
			set => Set(value, ref _title);
		}

		public bool Set<T>(T value, ref T filed, [CallerMemberName] string? propertyName = null)
		{
			if (Equals(value, filed))
			{
				return false;
			}

			filed = value;
			OnPropertyChanged(propertyName);

			return true;
		}

	}
}
