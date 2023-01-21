using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Core
{
	public  class ViewModel : ObservableObject
	{
		private string _title;

		public string Title
		{
			get { return _title; }
			set => Set(value, ref _title);
		}

		public void Set<T>(T value, ref T filed, [CallerMemberName] string? propertyName = null)
		{
			if (Equals(value, filed))
			{
				return;
			}

			filed = value;
			OnPropertyChanged(propertyName);
		}

	}
}
