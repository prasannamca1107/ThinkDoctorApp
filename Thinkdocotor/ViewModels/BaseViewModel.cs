using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Thinkdocotor
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public BaseViewModel()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void onPropertyChanged(Object sender, [CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(name));
		}
	}
}
