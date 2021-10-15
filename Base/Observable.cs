using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_StudentsManager.Base
{
    public class Observable : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) // protected virtual - can be overwitten in subclass
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
}