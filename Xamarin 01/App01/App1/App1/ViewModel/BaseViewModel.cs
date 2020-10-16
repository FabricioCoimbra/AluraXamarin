using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App1.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string name = "")
		{
			if (PropertyChanged != null)
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
